# ApiNotes — Скрипты в Robur: IronPython

**Текущий движок — IronPython 2.6.1008.2**, поставляется вместе с Robur. **TLC** (аналог
лиспа для мелкой автоматизации) — отдельный скриптовый язык Robur, здесь НЕ используется.

Статусы: `[DECOMP]` — метаданные/декомпиляция сборок; `[CODE]` — RailModelExporter,
DxfExport, штатные скрипты Robur.

## Сборки движка

| Сборка | Что это |
|---|---|
| `IronPython.dll`, `IronPython.Modules.dll` | IronPython 2.6.1008.2 (идёт с Robur) |
| `Microsoft.Scripting.dll`, `Microsoft.Scripting.Core.dll` | DLR 2.6: хостинг `IronPython.Hosting.Python`, `Microsoft.Scripting.Hosting.ScriptEngine/ScriptScope` |
| `Topomatic.Scripting.dll` | Штатный хостинг: `ScriptingHost : PluginHostInitializator`, `ScriptingModule : PluginInitializator` (команда `loadpy`), `PythonPluginInitializator`, `OutputStreamWriter` |
| `Topomatic.Scripting.IronPython.dll` | `PythonPackage` (регистрация пакета «Topomatic»/движка), `Dlr.{DlrModule, ParamsChecker, ResultChecker}` |

## Способ 1: штатный Python-плагин (манифест `.plugin`)

`.py`-файл может быть «сборкой» плагина. В `core.plugin` (манифест самого Robur):

```json
"assemblies": {
  "scripting": "Topomatic.Scripting.dll, Topomatic.Scripting.ScriptingHost",
  "mapsigns": { "assembly": "lib\\surface_mapsigns.py", "dependency": "scripting" }
}
```

Контракт загрузчика (по штатному Python-плагину + строкам `Topomatic.Scripting.dll`):

1. файл выполняется движком IronPython;
2. обязан быть модульный вызов `initialize()`, возвращающий **экземпляр** модуля плагина;
3. класс модуля наследует `PyModule` (`Lib/robur.py`), который реализует
   `Topomatic.ApplicationPlatform.Plugins.IPluginInitializator`;
4. команды — методы с декоратором `@cmd("uid")`; `PyModule.Initialize(factory)` сам
   вызывает `factory.RegisterFunction(uid, func)` — команды «первого класса», как
   `[cmd]` в C#.

Эталон конца штатного Python-плагина:

```python
# -*- coding: 1251 -*-
from robur import *
class SurfaceMapsignsModule(PyModule):
    @cmd("insert_complex_text")
    def act_insert_complex_text(self, args):
        ...
def initialize():
    return SurfaceMapsignsModule().register('Какие-либо знаки')
```

## `Lib/robur.py` — штатный Python-API плагинов

Штатный скрипт Robur `Lib/robur.py` (кодировка **cp1251**):

| Элемент | Назначение |
|---|---|
| `PyModule(IPluginInitializator)` | База модуля; `Initialize(factory)` регистрирует `@cmd`-функции; `register(name=None)` возвращает self |
| `@cmd(uid, window='ID_PLAN')` | Декоратор команды (оборачивает ошибки, транзакции, ввод) |
| `operation_canceled(msg)` | Поднимает `System.OperationCanceledException` |
| `get_active_cadview()` / `get_active_project()` / `get_active_document()` / `get_active_surface()` / `get_active_drawing()` | Активные объекты Robur |
| `initget()` / `getkword()` / `getint()` / `getreal()` / `getdist()` / `getangle()` / `getorient()` / `getpoint()` / `getcorner()` / `getstring()` | Эквиваленты `CadCursors` с обработкой Alt-команд |

⚠️ `robur.py` делает `import dlr` — модуль `dlr` регистрирует хостинг
(`Topomatic.Scripting.IronPython.dll`), т.е. вне окружения Robur этих импортов нет.

## Способ 2: C#-модуль + мост PyBridge (горячая перезагрузка)

Паттерн RailModelExporter.PyBridge / DxfExport (`[CODE]`): логика, которую
нужно менять без пересборки DLL, выносится в `.py` в подпапку `py` каталога приложения;
C# вызывает именованные функции скрипта:

```csharp
var engine = Python.CreateEngine();                       // IronPython.Hosting
engine.SetSearchPaths(new[] { Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "py") });
var scope = engine.CreateScope();
engine.ExecuteFile(path, scope);                          // выполнить скрипт(ы)
var fn = scope.GetVariable<Func<object, object>>("dxf_map_entity");   // хендлер
fn(ctx);                                                  // ровно один аргумент — DTO
```

Правила моста:

- **Горячая перезагрузка**: перед каждым вызовом сравнивается
  `File.GetLastWriteTimeUtc(path)` с сохранённым mtime; изменённые файлы выполняются
  заново в **новом** `ScriptScope` (старый живёт, пока новый не загрузился успешно),
  затем `_scope` подменяется. Ошибка загрузки → обработчик не вызывается, экспорт
  продолжается с исходными данными (graceful-откат), пользователю — текст ошибки.
- **Handler-диспетчеризация**: контракт — функция с ровно одним аргументом:
  `dxf_map_entity(ctx)`, `dxf_map_layer(dto)`, `dxf_map_linetype(dto)`.
- **DTO на простых CLR-типах** (string/int/bool), без структур и enum Robur: DLR
  вызывает C#-сеттер обычным присваиванием (`ctx.TargetLayer = "..."`).
- Ошибка Python оборачивается в текст; пользователю — через `MessageDlg.Show`
  (по-русски).
- Принудительная перезагрузка: команда модуля `export_py_reload` + пункт меню
  (DxfExport) — «Скрипты Python перезагружены.» / текст ошибки.

Контракт обработчиков скрипта экспорта (`[CODE]` DxfExport):

```python
# -*- coding: utf-8 -*-
LAYER_MAP    = { u"Земля": u"EARTH" }                     # исходное имя -> имя в DXF
COLOR_MAP    = { 1: 6 }                                   # исходный ACI -> целевой ACI
LINETYPE_MAP = { u"Dashed2": u"ACAD_ISO07W100" }
SKIP_LAYERS      = { u"Defpoints" }
SKIP_ENTITY_TYPES = { "VIEWPORT" }

def dxf_map_entity(ctx):
    if ctx.SourceLayer in SKIP_LAYERS:
        ctx.IsVisible = False
    ...
def dxf_map_layer(dto):
    dto.TargetName = LAYER_MAP.get(dto.SourceName, dto.SourceName)
def dxf_map_linetype(dto):
    ...
```

## Interop с .NET-сборками из IronPython

Штатные скрипты Robur (`Lib`, `[CODE]`):

```python
import clr
import dlr
clr.AddReferenceByPartialName("Topomatic.Crs")
clr.AddReferenceByPartialName("Topomatic.Alg.Runtime")
from Topomatic.Crs.Templates import CrsContour

@dlr.result(CrsContour)          # конвертация результата функции в CLR-тип
def build(...):
    ...
```

## Кодировки и поиск файлов

- Штатные скрипты Robur — **cp1251**: `# -*- coding: 1251 -*-`.
- Наши скрипты — UTF-8: `# -*- coding: utf-8 -*-`.
- Поиск модулей: `engine.SetSearchPaths(...)` — каталог `py` приложения; при
  необходимости добавить `Lib` Robur для `import robur` / `import dlr`.
- Все ссылки на сборки Robur/DLR в C#-проекте — Copy Local = False (AGENTS.md).
- Если после замены DLL/скриптов плагин «не грузится» — `clearcache` в командной
  строке Robur (AGENTS.md).

## ⚠️ Ловушки IronPython 2.6 (= Python 2.6)

`[CODE]` DxfExport — загруженный скрипт падал с «unexpected token ','»:

| Ловушка | Симптом | Правило |
|---|---|---|
| **Set-литералы `{ a, b }` запрещены** (появились в Python 2.7) | Парсер ждёт `key: value`, падает на запятой: `unexpected token ','` | Использовать список `[a, b]` или кортеж `(a, b)` — оператор `in` работает так же |
| Set-выражения `{ x for x in ... }` запрещены | Аналогично | Собирать через `set(...)`/цикл |
| f-строки `f"..."` запрещены | — | `u"..."` + `%`-форматирование (`u"[%s] %s" % (a, b)`) |
| `dict` по умолчанию не упорядочен | Порядок итерации непредсказуем | Не полагаться на порядок ключей |

Признак проблемы из C#-лога PyBridge:
`Ошибка Python («dxf_map_*»): Ошибка загрузки Python-скриптов: unexpected token …` —
значит, скрипт не парсится; правка синтаксиса + `export_py_reload` (или следующий
экспорт) подхватят его без пересборки DLL.
# ApiNotes — Каркас плагина

3 обязательных элемента: класс модуля, хост-класс, манифест `.plugin`. Паттерны `[TUT]`
(официальные туториалы), команды-мосты `[CODE]` (боевые плагины).

## Модуль и команды

| API | Назначение | Статус |
|---|---|---|
| `PluginInitializator` — базовый класс модуля, всегда `partial`, может быть `internal` | `internal partial class Module : PluginInitializator` | `[TUT]` |
| `[cmd("имя")] public void M(string prms)` | Команда из `.plugin` (макровызов `$(имя, ...)`); атрибут всегда коротко, через `using` | `[TUT]` |
| `[cmd("имя")] public bool P(string prms)` | Команда-предикат для `flags` | `[TUT]` |
| `public override void Initialize(PluginFactory factory) { base.Initialize(factory); }` | Точка инициализации; здесь регистрируют типы моделей, подписки | `[TUT]` |
| `PluginHostInitializator` — хост, обязан быть `public` | `public class ModulePluginHost : PluginHostInitializator { protected override Type[] GetTypes() => new Type[] { typeof(Module) }; }` | `[TUT]` |

⚠️ **Число параметров метода = число аргументов в тексте `cmd`.** Robur разбирает
`cmd` и передаёт столько аргументов, сколько в нём литералов в кавычках и
подстановок `%N`. Голый идентификатор без аргументов — ноль параметров:

```json
"id_x": { "cmd": "my_launcher" }              → public void MyLauncher()          // без параметров
"id_y": { "cmd": "rmepy_run \"rail.props\"" } → public void Run(string prms)     // один параметр
```

Расхождение даёт `TargetParameterCountException` **при нажатии**, и выглядит это
как «кнопка сломана», хотя объявлена верно. Штатная проверка формы `cmd` такое не
ловит: `rmepy_launcher` — корректный идентификатор, ровно как **2531** действие в
манифестах самого Robur (`Development/Out/Bin/*.plugin`: `cmd` без кавычек и `%N`).

Проверено в Robur: метод с `string prms` под действием с `cmd` без аргументов
падал `TargetParameterCountException`; после замены на метод без параметров
работает. Ловится скриптом сверки `[cmd]` и `actions` — в NewPluginSystem это
`tests/cmd_args_test.py`.

## Мост к хост-приложению

| API | Назначение | Статус |
|---|---|---|
| `ApplicationHost.Current.Plugins.Execute("команда", new object[]{...})` | Вызов чужой/штатной команды (`"mkitem"`, `"getname"`) — не ссылаться на `*.Controller.dll` | `[TUT]` |
| `ApplicationHost.Current.ActiveProject` → `ModelProject` | Текущий активный проект | `[TUT]` |
| `project.TransactionManager.BeginUpdate()/EndUpdate()` | Групповое изменение проекта (в `try/finally`) | `[TUT]` |
| `factory.RegisterModelEditor("type", new ModelEditorInfo(...))` | Регистрация типа модели в `Initialize` | `[TUT]` |

## Манифест `.plugin`

Имя файла **обязательно совпадает** с именем сборки; «Копировать в выходной каталог» = Всегда.

```json
{
  "assemblies": {
    "MyPlugin": { "assembly": "MyPlugin.dll, MyPlugin.ModulePluginHost" }
  }
}
```

Секции (используемые примерами): `actions`, `menubars` (корень — `rbproj`), `contexts`, `cores`,
`broadcasts`, `hotkeys`. Полный перечень верхнего уровня (веб core.plugin) — также `name`, `version`,
`priority`, `variables`, `environments`, `coreitems`, `dynamics`, `toolbars`, `statusbar`, `ribbon`.

- `%0` в `cmd` — параметр из пункта меню.
- Видимость: `"flags": "$(if, $(check_state_cmd,name), 0, 1)"`.

Известные баги upstream `[TUT]` (не повторять): `tutorial1.plugin` — ключ `"tutroial1"`;
`tutorial9.plugin` — ключ `"tutorial8"`; в PascalCase-проектах не хватает `<Private>False</Private>`.

### Флаги видимости: 0 — доступен, 1 — серый, 2 — скрыт

`flags` у действий и у групп ленты принимают эти три значения (`0` — доступен,
`1` — серый, `2` — скрыт; `core.plugin`). Для пункта, который **неприменим** в
текущем состоянии, нужен именно `2`: серым он выглядел бы как «есть, но не сейчас».

Признак «активна модель Rail/Road» берётся из макросов самого Robur — переменные
`rail` и `road` определены в его `ribbon.plugin` (`Development/Out/Bin/ribbon.plugin`,
секция `variables`):

```text
rail = $(if,$(configuration,rail),$(if,$(readonly_alg_flag),1,
        $(if,$(strncasecmp,$(get_active_model_type),rail),0,1)),1)
road = $(if,$(configuration,road),$(if,$(readonly_alg_flag),1,
        $(if,$(strncasecmp,$(get_active_model_type),road),0,1)),1)
```

То есть признак — это ровно `$(strncasecmp,$(get_active_model_type),rail)`.
Практика: подставлять выражение прямо в `flags` своего действия, а не через
свою переменную в секции `variables` — иначе результат зависит от того, объявлена
ли переменная в **чужом** манифесте, и `flags` тихо не сработает.

Проверено на group's действии в NewPluginSystem: восемь legacy-команд (IronPython,
работают только с Rail) скрыты на авто- и площадках.

## Контекстные меню (`contexts`)

Два независимых вида ключей. `[DECOMP]` `Development/Out/Bin/*.plugin` + литералы
платформы, расшифрованные раннером по штатному декриптору строк.

### 1. По окну/видовому экрану — `<база окна>.<суффикс>`

Платформа строит имя как `<база окна>` + `.cmdefault` / `.cmedit` (`Topomatic.ApplicationPlatform.dll`,
строки `.cmdefault`/`.cmedit` в деобфусцированном виде). `[DECOMP]`

| Суффикс | Когда |
|---|---|
| `.cmdefault` | правая кнопка, **выделения нет** |
| `.cmedit` | правая кнопка, **есть выделение** |
| `.cmcommand` | правая кнопка в ходе активной команды |
| `.grips` | меню шурвалов (grips) |

База = вид окна: `rbproj.cadview.id_dwg_editor` (редактор чертежа), `rbproj.cadview.plan`
(план). В `core.plugin` окна только **ссылаются** на базовый контекст
(`{"contextrefs": "rbproj.cadview.plan.cmedit"}`), реальные пункты лежат в базовом.
`[DECOMP]`

⚠️ Штатных пунктов в `object`-контекстах для сущностей чертежа почти нет — писать
свои (см. ниже), а не искать готовый «Разбить тэг» где-то в `core.plugin`.

### 2. По типу объекта — `object.<тип-обёртки>`

Срабатывает **при выборе объекта** — то, что нужно для «меню по правому клику на сущности».
Ключ = имя типа-обёртки в нижнем регистре. `[DECOMP]` `mockup.plugin` и др.

**`object.dwgtag` = вставка блока** (`DwgInsert`) — Robur называет вставку «тэг»
(штатный пункт `id_break_dwg_tag` «Разбить тэг на примитивы»). `[DECOMP]` `mockup.plugin`

Другие ключи корпуса: `object.dwgentity`, `object.dwghatch`, `object.dwgtable`, `object.mtext`,
`object.text`, `object.leader`, `object.polygon`, `object.patch`, `object.ilayeredobject`,
`object.ilinearobject`, `object.imasscontainerwrapper`, `object.model3delement`, `object.ifcitem`,
`object.pipe`, `object.structure_line`, `object.surface_point`, `object.planchet` + десятки
`object.pipes_*`/`object.*soilworksobject*` (собственные обёртки модулей). `[DECOMP]`

```json
"contexts": {
  "object.dwgtag": {
    "items": [ "id_block_edit" ]
  }
}
```

- Элемент `items` — строка-ссылка на `actions` (`"id_..."`), `"-"` (разделитель)
  либо объект `{ "default": "<команда>", "title": "..." }`. `[CODE]`
- Свой контекст можно **дополнить** чужим: `"contextrefs": "<чужой.ключ>"`; можно задать
  `"priority": 1001` (канон tutorial6/8/10). `[TUT]`
- Видимость пункта в контексте — теми же `flags`, что и в `actions` (`0` — доступен,
  `1` — серый, `2` — скрыт). `[CODE]` `core.plugin` (`hascadview = $(if,$(ccadview),0,2)`)

⚠️ Ключ `object.*` — **это не `IDocumentWindow`, а объектный контекст**: в такой пункт
`%0` приходит с идентификатором/типом, а не с параметром меню. `[DECOMP]`

## Ограничения окон

```csharp
protected override bool ValidateWindow(string cmd, IDocumentWindow window)
```

`Consts.PlanWindow` (план), `Consts.ProfileWindow` (профиль), `Consts.CrossWindow` (поперечники);
иначе — текущее окно. `[TUT]`

## Диалоги с выбором (Да/Нет/Отмена)

`MessageDlg.Show(msg, MessageBoxButtons, MessageBoxIcon)` возвращает
`System.Windows.Forms.DialogResult` — «дождаться решения» перед продолжением
(например, подтверждение применения правок по закрытию окна). Сигнатуры — метаданные
SDK 16.0.62.x. `[DECOMP]`

```csharp
var r = MessageDlg.Show("Применить изменения блока?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
if (r == DialogResult.Yes)   { /* применить */ }
else if (r == DialogResult.Cancel) { /* отмена закрытия окна */ }
```

Системные диалоги (`SaveFileDialog`/`FolderBrowserDialog`) — обычный WinForms,
доступен из UI-потока команды (STA). `[CODE]`

## Правила кода (сквозные)

- Сообщения пользователю по-русски, `MessageDlg.Show(...)`, не `MessageBox`.
- Все команды в UI-потоке; модели не менять из фоновых потоков.
- Copy Local на ссылках на сборки Robur **обязательно False** (перезапись DLL ломает хост).
- После смены DLL в хосте — команда `clearcache` в командной строке Robur.
# IronPython 2.6 в Robur — особенности платформы

Плагины-скрипты (экспортёр/импортёр RailModel, ReRo-скрипты) исполняются **встроенным** в Robur
IronPython. Это не CPython и не standalone-интерпретатор: своя сборка DLR, отсутствие stdlib и
ряд специфических ловушек маршалинга .NET↔Python. Все факты ниже подтверждены живыми прогонами
в Robur (`[CODE]`) либо рефлексией DLL (`[REFL]`).

## Версия и состав

| Компонент | Значение | Источник |
|---|---|---|
| `IronPython.dll` FileVersion | **2.6.1008.2** | `[REFL]` ilspycmd edu 16.0.62.10 |
| `IronPython.dll` AssemblyVersion | **2.6.10920.0** | `[REFL]` то же |
| Ядро Python | Python **2** (не 3): int/int → целочисленное деление, `print` — оператор, есть `basestring`/`long`, нет `__future__` | `[CODE]` (шапки скриптов импортёра/экспортёра) |
| DLR | `Microsoft.Scripting.dll`, `Microsoft.Dynamic.dll`, `Microsoft.Scripting.Core.dll`, `Microsoft.Scripting.Debugging.dll`, `IronPython.Modules.dll` — рядом с `Robur.exe` | `[REFL]` |
| Обёртка плагинов | `Topomatic.Scripting.dll`, `Topomatic.Scripting.IronPython.dll` (host, оверлод команд) | `[REFL]` |

Версия может отличаться в других редакциях Robur — при воспроизведении смотрите
`AssemblyVersion` своей установки.

## Нет stdlib

В Robur IronPython не включает стандартную библиотеку Python:

- `from __future__ import ...` → **No module named __future__** (недоступно даже для `division`).
- Нет `os`, `zipfile` и т.п. Всё, что нужно (пути, файлы, кодировки), — через .NET:
  `System.IO.Path/File/Directory`, `System.Text.Encoding`.
- `int/int` даёт целое (Python 2), `print` — оператор. Пишите код только в синтаксисе CPython 2.6/2.7.

## Строки: маршалинг .NET→Python теряет символы

Главная ловушка платформы. **При каждом переходе строка из .NET в Python может потерять первые
символы**; чем больше промежуточных конвертаций, тем больше потеря (`[CODE]`). Следствия:

- **Не сравнивайте и не проверяйте строки «в Python»** (например, схему из манифеста):
  получите ложное несовпадение. Проверку делайте целиком на стороне .NET и наружу пускайте
  только `bool` — `tok.ToString().Contains(fragment)` (`token_contains`).
- Строки JSON (токены JValue) через `_jvalue_str` — **только диагностика**:
  живой Robur режет первые символы — прямой `tok.Value` теряет 1 (лог 20:24), отражённый
  `GetValue` — 2 (лог 20:54: «_LDW1»→«DW1», «E»→«»). Для ЛОГИКИ значения читайте числами
  (`jnum`/`Convert.ToDouble` на токене) и именами (`ToObject(String)` + `.Equals` в .NET).
  Строки МОДЕЛИ (string-типизированный `read` — ключи `KeyValuePair<string,T>` и т.п.)
  проходят ПОЛНЫМИ. `unicode()` для строк не нужен (гипотеза «съедает первый символ»
  опровергнута probe_jstr).
- **Запись строк в модель** — через `set_jstring`: строка целиком
  доходит до .NET, без потерь. Проверка записанного — `jstring_equals_prop` (.NET-сравнение, bool).
- Для чисел/bool/enum маршалинг надёжен (см. ниже) — необфусцированные примитивы целые.

## BOM: `\ufeff` не входит в isspace() в Python 2

`u"\ufeff".strip()` ничего не удаляет — в отличие от Python 3. При разборе JSON-строк
обрабатывайте BOM вручную: `if s.startswith(u"\ufeff"): s = s[len(u"\ufeff"):].strip()`.
Файлы самих скриптов — `# -*- coding: utf-8 -*-`;

## Обфускация имён и исключения

- Имена **типов, полей, свойств** в сборках Robur НЕ обфусцированы; обфусцированы имена
  **методов** (в декомпиляции выглядят как `\u0086...`). Свойства читаются по имени, вызовы
  необфусцированных методи привилегия, а обфусцированных — только через
  `invoke_nonpublic`/паттерны туториалов. `[DECOMP]`.
- `GetMethod("Add")` на типе с **несколькими перегрузками** → `AmbiguousMatchException`
  («Ambiguous match found for '... BeginUpdate(System.String)'»). Для рефлексии указывайте
  типы параметров: `GetMethod("Add", (String,))`; прямой вызов `obj.Add(args)` из Python
  резолвит перегрузку по арности — надёжнее и предпочтительнее. `[CODE]`
- **Исключения из обфусцированных методов**: `unicode(e)` на CLR-исключении может вернуть
  мусор — например `('unknown', '\x00', 0, 1, '')` (живой лог импорта userProfiles). По такому
  кортежу тип исключения не определить. Для диагностики используйте
  `e.GetType().FullName` и цепочку `InnerException` (тип + message), а не `unicode(e)`. `[CODE]`
- **Явные вызовы `System.String(unicode)` / `System.Boolean(bool)` ПАДАЮТ** с настоящим
  Python-исключением `IronPython.Runtime.Exceptions.PythonExceptions+_UnicodeEncodeError: ('unknown', '\x00', 0, 1, '')`
  — интерпретатор пытается закодировать Python-строку в байты кодеком по умолчанию,
  который в Robur сломан (`'unknown'`). Живой лог: сборка массива аргументов ctor
  UserProfile с `System.String(nm)` внутри → падение на «массив аргументов».
  **Передавайте сырые Python/CLR-значения** — конвертацию в параметры метода делает сам
  `MethodInfo.Invoke`/`Activator.CreateInstance` (путь `rim_reflection.construct`):
  `objs = System.Array[System.Object]([up, nm, ds, color, sd])` вместо
  `[up, System.String(nm), ..., System.Boolean(sd)]`. `[CODE]`

## JSON (Newtonsoft.Json): индексаторы и типизация

- **У `JObject` два публичных индексатора** — `this[object]` и `this[string]`
  (декомпиляция Newtonsoft.Json.Linq.JObject) → `GetProperty("Item")` или `get_Item` без
  типов даёт `AmbiguousMatchException`. Индексатор берите явно:
  `GetMethod("get_Item", (String,))` + `Invoke(jobj, (key,))` — `jindex`.
  На корневом объекте JSON прямой `jobj[key]` работал — это запасной
  путь, но на узлах из `JArray` молча падал (`jtyped`/`Properties()` на узлах — лог 12:06/12:16).
- **`JToken.ToObject(Boolean)` молча возвращал default** (живой прогон 01:57 — «FromEdge не
  разобран», «от бровки=нет»). Для bool — только `Convert.ToBoolean(token, invariant)` через
  `jbool`. Числа — `Convert.ToDouble` через `jnum`, enum — `jtyped`
  (часть имени после последней точки парсится в .NET).
- **JSON-null**: `JValue.Value` в IronPython 2.6 для `null`-токена не отдаёт значение —
  распознавайте по `token.Type == JTokenType.Null` (`jbool`).

## .NET-типы в Python

- **`isinstance(py_int, IConvertible)` ложно** — PythonInt не реализует интерфейс, а
  `GetType()` у Python `int`/`float` возвращает System.Int32/System.Double. Проверки — по
  CLR-типу (`t.IsPrimitive`, `t == Decimal`), не по интерфейсу.
- **Boxed-структуры: прямое присваивание молча не пишет.** `node.X = ...` на элемент-структуре
  мутирует локальную копию; в коллекцию попадает прежнее значение (подтверждено M3: узлы
  добавились, станции/отметки остались 0, в keyed-collection RedProfile узлы со станцией 0
  схлопнулись). Пишите только через `FieldInfo.SetValue` — `set_field`.
- **Python-dict перечисляется в порядке хеш-таблицы**, а не вставки → JsonConvert пишет ключи
  «перемешанно». Для детерминированного JSON используйте `.NET Dictionary[String, object]`
  (`_dict()`) — перечисляется в порядке Add, как в C#-версии.

## Модули и скоуп

- **RailPyBridge каждый вызов выполняет файлы скриптов заново**, но `import` кэширует
  `sys.modules` в рамках движка → принудительный `del sys.modules[...]` до импорта.
- **Функции, внедрённые в скрипт-скоуп до `ExecuteFile`** (например, `asm_info`), не видны из
  модульных копий (`import` скрипта создаёт собственные глобалы) → получались `null`.
  Метаданные (сборка, sha1) считайте прямо в Python через отражение по загруженным сборкам.

## Воспроизведение вне Robur (Linux / .NET Core)

Стенд (`[TEST]`): хост net10 + IronPython 2.6.1008.2 из Robur edu:

- IronPython 2.6 на .NET Core требует пакетов `System.CodeDom` и
  `System.Text.Encoding.CodePages` + `Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)`
  («No data is available for encoding 0» — иначе).
- `GetType(name, throwOnError: true)` на .NET Core даёт **ложный** `TypeLoadException`
  («Could not resolve type ... in assembly»), даже если все зависимые сборки загружены
  (конфликт LoadFrom-контекста рантайма). Показательна только диагностика внутри реального
  Robur (.NET Framework).
- Для рефлексии без исполнения кода удобен `MetadataLoadContext`; для исполнения — только
  настоящий Robur.

## Выводы для кодовой базы

1. Весь скриптовый код пишется в синтаксисе **Python 2.6** (без `__future__`, без stdlib).
2. Строки — только «одномаршалинговые» пути (`set_jstring`, `_jvalue_str`, `token_contains`),
   никогда не сравнивать строки в Python.
3. Числа/bool — конвертация на стороне .NET (`jnum`/`jbool`/`jtyped`); bool — только `jbool`.
4. Поля структур — только `set_field`; индексаторы JObject — только через `jindex`.
5. Диагностика исключений — `GetType().FullName` + `InnerException`, не `unicode(e)`.
6. Детерминированный JSON — .NET `Dictionary`, не Python-dict.
7. Никогда не вызывать `System.String(...)`/`System.Boolean(...)` на Python-значениях — только
   сырые значения (конвертирует сам `Invoke`/`Activator.CreateInstance`, path `construct`).
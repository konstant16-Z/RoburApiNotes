# ApiNotes — Сквозные ловушки API Robur

Свод проверенных граблей. Каждая — с источником `[DECOMP]`/`[CODE]`/`[TUT]`.

## 1. Векторы и структуры — ПОЛЯ, не свойства

`[DECOMP]` `Topomatic.Cad.Foundation.dll`, `[CODE]` Runoff:

- `Vector2D.X/Y`, `Vector3D.X/Y/Z` — публичные **поля**. `GetProperty("X")` молча вернёт null,
  вектор выйдет нулевым, а `ToString()` выглядит здоровым (ловили дважды).
- Запись — через `FieldInfo.SetValue` (для boxed-структуры мутирует саму упаковку).
- `VertexItem`, `SurfacePoint` — структуры: изменяйте локальную копию и **записывайте обратно**:
  `var item = vertex[j]; item.R = 500; vertex[j] = item;`
- **Из IronPython прямое присваивание поля boxed-структуры МОЛЧА НЕ пишет** (ловили дважды):
  `node.Station = v` на конструкции `construct(ProfileNode, [])` оставляет поле 0, `Add()`
  при этом проходит. Всегда использовать хелпер `set_field` (`FieldInfo.SetValue` мутирует
  бокс — проверено). Симптомы: `Count=N`, но «обратно станция=0»; в keyed-коллекциях
  (RedProfile — ProjectProfile по станции) все узлы схлопываются в одну запись.
  `[CODE]` прогоны M2.5/M3 RailModelImporter (лог импорта).
- **Отображение имён в сводке: стройте от МОДЕЛИ, а не от JSON через `jstr`**
  (лог 00:12/00:20 M2.5/M3): данные в модели полные (`set_jstring` + `jstring_equals_prop`
  — `в модели=True`; read-back «первая=НТ … последняя=КТ»; `PlanVertexesValid=True`),
  а строки, полученные из JSON `jstr`-путём, в загруженной среде РЕЖУТ первый символ
  («НТ»→«Т», «ВУ1»→«У1», «ось»→«сь», «1-й левый»→«-й левый»).
  **Фикс: имя для сообщения брать из модели** — `format_value(read(v, u"Name"))`
  (план), `read(tr, u"Name")` (M3, свойство `Name` на базовом
  `Topomatic.Alg.Prf.Transition` подтверждено asmread). Этот путь в логе полный.
- **Окончательно подтверждено логом 01:23/01:24** (`[TEST]` живой Robur):
  `план: узел[0] имя-сводка: jstr_len=1 model_len=2 jstr_codes=[U+0422]
  model_codes=[U+041D U+0422]` — `jstr` в загруженной среде реально
  возвращает строку БЕЗ первого символа. Сводка строится от `read()` из модели
  (`format_value(read(v, u"Name"))`, `read(tr, u"Name")`) и на экране выводятся
  полные «НТ»/«ВУ1»…/«КТ», «Ось», «1-й левый» и т.д. — «Применено (8): узел 1
  «НТ», … узел 8 «КТ»»; M3: «Применено (11): Ось [0]/eg: 159 узлов, …».
- **Порча строк JValue→Python ЛОКАЛИЗОВАНА логом 20:24/20:54 (M5.5,
  параметры-реестр): режет маршалинг токенов Newtonsoft**, причём потеря зависит
  от пути: ПРЯМОЙ доступ `tok.Value` теряет 1 символ (лог 20:24: «_LDW1»→«LDW1»,
  «TRAY_HEIGHT_RIGHT1»→«RAY_HEIGHT_RIGHT1», строки «0»→«», станции
  «1154.396…»→«154.396…»), ОТРАЖЁННЫЙ `read(tok, u"Value")` — 2 символа (лог
  20:54: «_LDW1»→«DW1», «TRAY_HEIGHT_RIGHT1»→«AY_HEIGHT_RIGHT1», «E»→«»).
  Вывод: **оба «строковых» пути `jval`/`jstr`/`as_text` на JValue ненадёжны**,
  порядок путей в `_jvalue_str` на корректность не влияет (возвращён к исходному).
  НАДЁЖНЫЕ пути (по ним в логе 20:54 записаны все 106 значений): числа —
  `jnum`/`Convert.ToDouble` на токене (конверсия целиком в .NET); имена —
  `ToObject(String)` + `.Equals`-сверка с реестром (канон `jstring_equals_prop»);
  строки МОДЕЛИ (string-типизированный GetValue — ключи
  `KeyValuePair<string,IParameter>`) проходят полными.
- **Потеря точности станций таблиц параметров НЕДОПУСТИМА (баг `_LDW1/_RDW1` → −1,
  закрыт 2026-09-17)**: станции секций/таблиц спускаются до 9-го знака (секция 32 на
  `3156.061957997823`), поэтому экспортёр пишет станции таблиц через **`format_d`
  (формат «R», полный round-trip double)**, а не через `format_value`
  (`ToString("0.########")` — 8 знаков): иначе две реально разные станции
  (`3156.061957997823` и `3156.061958…`) сливаются в одну строку «3156.061958», импорт
  пишет её в модель, `IParameter.Item[3156.061957997823]` не находит точного совпадения
  → отдаёт **DefaultValue (−1, «лотка нет»)** в `.act` последней секции.
  `[CODE]` фикс `format_d` (диагностика таблиц параметров); импортёр не виноват
  (ни `Add`, ни индексатор `this[double]` дубль станции не создают — общий `GetIndex`
  по пикету, лог: «строк в JSON=34, записано=34, контроль Count=33»).
- **Политика A — whitelist пользовательских параметров (W1 и др.)**: при отсутствии
  в живом реестре (`GetTableParameters()` не вернул пару для табличного дескриптора
  из схемы) параметр НЕ создаётся «с нуля» руками, а заводится канонической
  фабрикой реестра:
  `AlignmentParameters.DefineParameterTable<T>(variable, caption, behaviorType,
  defaultValue, overrideExisting, isSystem)` — `[DECOMP]` (реализация реестра параметров).
  Для `T=double` фабрика сама делает `new DoubleParameter(this, caption, behaviorType,
  defaultValue, isSystem)` и регистрирует в словаре реестра (+ Changed); дубликат не
  перезаписывает при `overrideExisting=false`. Ровно так же работает штатный Add-хелпер
  реестра (строка 174: `DefineParameterTable(имя, имя, BehaviorType.Interpolate, …)`) —
  это путь «пользовательских переменных». `T` берём из JSON `valueType`
  («DoubleParameter»→`System.Double` и т.д.), caption — из JSON `caption` (W1 → «Лотки»),
  `BehaviorType` — из JSON `behaviorType` (W1 → «BehaviorType.Discrete» → член
  «Discrete»; фолбэк `Interpolate`), enum-тип — от существующего IParameterTable
  (namespace не хардкодим), `isSystem=false` (пользовательская переменная). Дальше
  строки пишутся общим путём (Clear + индексатор this[double]). Скалярные
  (неключевые) параметры не создаются. Без фабрики — только ctor+Add вручную —
  нельзя: у `AlignmentParameters` нет публичного Add для готового экземпляра
  (коллекция-словарь внутри приватная).
- **Отдельной коллекции «пользовательских переменных» в API НЕТ**: `AlignmentParameters`
  имеет всего две коллекции — `GetTableParameters()` (и системные, и пользовательские
  вперемешку; при загрузке stg не-системные добавляются в неё же — `[DECOMP]` стр. 670)
  и `GetComputedParameters()`. Различитель — `IParameterTable.IsSystem`. Поэтому
  «экспорт пользовательских в отдельный файл» (с 2026-09-14:
  `parameters_user.json` + `parameters_registry.json` системный) — это фильтрация
  экспортёра по `IsSystem=false` (`split_parameters_dump`), а не отдельная коллекция.
  Импортёр создаёт пользовательских из user-файла всегда; системных (isSystem=true)
  не создаёт никогда; легаси-реестр (без user-файла) создаёт отсутствующих
  несистемных whitelist'ом.
- **Гипотеза «`unicode(CLR-строка)` съедает первый символ» ОПРОВЕРГНУТА** логом
  00:12:45 (`probe_jstr`: `net_ok=True raw_len=2 uni_len=2 raw_eq=True val_len=2` —
  токен целый и до, и после `unicode()`, и через `_jvalue_str` по ВСЕМ путям
  зонда). Виноват не `unicode()`, а сам маршалинг свойства `JValue.Value`/`GetValue`
  (см. пункт выше); для ЛОГИКИ строки JSON читаются числами (`jnum`) и именами
  (`ToObject(String)`), а `jstr`/`jval`/`as_text` — только диагностика.
- **Правило: строки в модель писать целиком в .NET**: `set_jstring(target, prop, jobj, key)` —
  `ToObject(String)` + `SetValue`, строка не участвует в Python-маршале; контроль —
  `jstring_equals_prop(...)` (сравнение `.Equals` целиком в .NET, наружу bool).
  Диагностика порчи — `probe_jstr(tok, expected)`: только надёжные int/bool
  (`JToken.DeepEquals` — .NET-истина; `len` raw vs после `unicode()`).
  `[CODE]` M2.5/M3 RailModelImporter, `[TEST]`
  C#-зонд (JSON c BOM — чистый C# возвращает полные строки).

## 2. Undo/redo — обязателен для всех изменений моделей

```csharp
model.BeginUpdate();
try { … } finally { model.EndUpdate(); }
```
- «Примерить и отменить»: `BeginTransaction()` → изменения → `Commit()`/`Rollback()`.
- Загрузка из файла → писать во внутренние коллекции (`InnerList`), не засорять undo-историю.
- После изменений: `cadView.Unlock(); cadView.Invalidate();`

## 3. `CadCursors.GetPoint` — две сигнатуры

Обе — `[TUT]`: bool-вариант — tutorial3/4/7/8/9/10/11, TutorialEditAlignment;
`GetPointResult` (с `params string[] options`) — TutorialEditSurfaceElements.
Плюс `[CODE]` Runoff/DemLoader — bool-вариант (false на отмену). Проверяйте, какую вызываете.

## 4. ЦММ: создание с нуля

`[CODE]` DemLoader:
- `node.Model` остаётся `null` после `LockWrite()` до вызова `LockRead()` — без исключения.
- `surface.Points.Add(new SurfacePoint(...))` начинается с **проверки лицензии** — без неё
  «успешно» молча ничего не делает.
- `BeginUpdate()` без парного `EndUpdate()` — запись видна в текущей сессии, но нештатно.
- `node.GetChilds()` бросает `NullReferenceException` — try/catch.

## 5. Профиль земли — не `??`, а try/catch

`[CODE]` Runoff: каждое из `StaticEg`/`DynamicEg`/`EgProfile` может кинуть —
буквальный `t.StaticEg ?? t.DynamicEg ?? t.EgProfile` упадёт. Паттерн `SafeGroundProfile`.

## 6. Проект и модель

- `project.TransactionManager.BeginUpdate()/EndUpdate()` — в `try/finally`.
- `IProjectModel.Modified` — ручной флаг (когда нет undo-обёрток).
- Блокировки `LockRead()/LockWrite()/UnlockWrite()` — в `try/finally`.
- Copy Local на ссылках на сборки Robur **обязательно False** — перезапись DLL ломает хост.
- После смены DLL — `clearcache` в командной строке Robur.
- Не ссылаться на `*.Controller.dll`; чужие команды — через `ApplicationHost.Current.Plugins.Execute(...)`.

## 7. Вызовы из внешнего кода

- «Правка точек ЦММ — только через `PointEditor`» — относится к существующим точкам;
  создание с нуля — прямой `Points.Add`.
- `Pipes` на реальном проекте часто пуст — не полагайтесь без проверки.
- `Prism.*CulvertPosition` — координаты сечения, а не плана.

## 8. Owner элементов таблиц (вираж/дренаж/лотки) — ТАБЛИЦА, а не ось

`[DECOMP]` `Topomatic.Alg.Rail.dll` (канонические `LoadFromStg`), `[TEST]` живой прогон
RailModelImporter M4 (2026-09-11):

- Канонический паттерн создания элементов таблиц M4 — `new X(this)`, где `this` —
  **сама таблица**: `new Virage(this)` (VirageTable), `new Drain(this)` (DrainTable),
  `new TrayLayout(this)` (TrayLayoutTable), `new Tray(this)` (TrayTable).
- Если элемент создать через `ctor(ось)`, он «работает» на уровне данных: JSON-round-trip
  сходится, свойства читаются/пишутся — **но UI падает**. `VirageWrapper.get_Stationing()`
  (в `Topomatic.Alg.Rail.Controller`) кастует `(VirageTable)virage.Owner`; при
  `Owner=RailAlignment` → `InvalidCastException` («Не удалось привести тип объекта
  "RailAlignment" к типу "VirageTable"») в `PropertyGrid.OnPaint` — окно виража
  не отрисовывает колонку «Пикетаж». Аналогичные касты есть у обёрток
  дренажа/лотков (`*Wrapper.get_Stationing`).
- **Правило импорта**: конструктор элемента получает owner-таблицу. В
  `_m4_construct` кандидаты идут `[[table], [axis]]` (таблица первой), а read-back
  проверяет `v.Owner.GetType().FullName == "Topomatic.Alg.Rail.Virage.VirageTable"`.
- Ошибка не проявляется на этапе импорта — только при открытии окна таблицы в Robur.
  Диагностический признак в логе импорта: `вираж: узел[1] ... Owner=…RailAlignment`
  вместо `…VirageTable`.

## 9. `PropertyGrid` — `null` в коллекции = NRE на `Object.GetType()`

`[DECOMP]` `Topomatic.ComponentModel.dll` (16.0.62.12, снимок
`Tools/Decomp/Topomatic.ComponentModel.PropertyExplorer.cs`),
`[DECOMP]` `Topomatic.Controls.dll` (снимок
`Tools/Decomp/Topomatic.Controls/Topomatic.Controls.ObjectInspection.PropertyGrid/`),
`[RUNTIME]` стектрейс из Robur 16.0.62.x. Подробно — `propertygrid.md`.

Симптом (падает на перерисовке, не на вызове `SelectObjects`):

```
System.NullReferenceException
   в System.Object.GetType()
   в Topomatic.ComponentModel.PropertyExplorer.smethod_10(IList, Type&)
   в Topomatic.ComponentModel.PropertyExplorer.smethod_0(IEnumerable, Boolean)
   в Topomatic.ComponentModel.PropertyExplorer.GetProperties(IEnumerable)
   в ...PropertyGridHeader..ctor(IEnumerable)
   в ...PropertyGrid.OnPaint(PaintEventArgs)
```

Причина — цикл определения общего типа **без проверки на null**:

```csharp
private static void smethod_10(IList items, out Type commonType)   // снимок, ~строка 737
{
    for (int i = 0; i < items.Count; i++)
    {
        Type type = items[i].GetType();   // ← NRE, если items[i] == null
        ...
    }
}
```

- Проверяются **все** элементы, не только первый: достаточно одного `null` в любой
  позиции (в том числе в конце списка). Пустая коллекция и `null`-коллекция
  безопасны — падает только непустая с `null`-элементом.
- Второй путь того же NRE: если коллекция пустая, но реализует `IActivator`
  (`CanCreateInstance`), `PropertyGridHeader..ctor` вызывает `CreateInstance()` и
  передаёт результат в `GetProperties(new object[1]{ result })` — возврат `null`
  из `CreateInstance` даёт тот же стектрейс.
- Данные для грида Robur берёт из обёрток (wrapper). Типичные источники `null`:
  не созданный `IActivator`-объект, `null`-обёртка в `IList`, узел дерева с
  `Model == null` (тот же класс ловушки, что в `model-editor.md`).
- Обход на стороне вызова: фильтровать `null` перед `SelectObjects`
  (`items.Where(i => i != null).ToList()`), проверять `CanCreateInstance`/`CreateInstance`
  на `null`, не отдавать в грид списки с незаполненными элементами.
## 10. `Exception.ToString()` на исключениях Robur **бросает исключение**

Обфусцированные сборки Robur идут под .NET Reactor, и `ToString()` на типах
собой не является: `System.Object.ToString()` недоступен через атрибут, вызов
падает `AttributeError`/аналогом. Проверено на `Plugin executing exception`:
логгер, который писал `ex.ToString()`, **выбрасывал исключение вместо записи**,
пользователь видел «Plugin executing exception» без причины, а лог обрывался.

Читать текст исключения надо **по частям**, и каждая часть обязана падать
независимо:

```csharp
parts.Add("Message: " + ex.Message);        // свойство, а не ToString()
if (ex.InnerException != null) parts.Add("Inner: " + ex.InnerException.Message);
try { parts.Add("Stack: " + ex.StackTrace); } catch { }   // у Robur тоже недоступен
```

Общее правило шире логгера: **на обфусцированных типах Robur не работает
`ToString()` через атрибут** — сначала `getattr(obj, "ToString", None)`, затем
`str(obj)`, который для CLR-объекта отдаёт полное имя типа. Всё обходное
отражение, которое зовёт `ToString()`, падает целиком.

## 11. Лента, палитра и строка меню статичны; динамично только контекстное меню

Состав ленты и строки меню задаётся `.plugin`-манифестом **при старте Robur**:
`PluginManager.GenerateMenu(uid, registers, root)` разбирает плоский список id из
секций `menubars`/`ribbon`, и нашего кода в этом процессе нет. Добавление пункта
в рантайме невозможно — публичного API нет (`IToolbarCreator`/`IPanelCreator` в
корпусе отсутствуют, поиск по членам с `Palette` даёт только WinForms-шум).

Динамически строится **только** контекстное меню окна: Robur поднимает
`CadView.CreateMenu` (`HandleCreateMenu(CreateMenuEventArgs)`), а `e.Root` —
дерево `MenuAction` с `Add`/`Insert`/`AddSeparator`/`FillMenu`. Отсюда рабочая
схема: список команд наполняется при каждом правом клике, новый `.py` виден сразу.
`MenuAction.Add(caption, handler, tag, enabled, visible)` задаёт видимость и
доступность в рантайме, без макросов манифеста.

Проверено на работающих модулях того же автора (QuickCommands 1.1.2, ModelDesk
1.2.0 — `.tpm` это zip, манифесты внутри): их схема совпадает с нами.

## 12. Разрядность: сборки Robur — AnyCPU, а не x86/32BITREQUIRED

Проверено по PE-заголовкам и CLR-флагам (`CorFlags`) `Development/Out/Bin`:

```text
Robur.exe                  machine=x86  PE32  corflags=9  = ILONLY + STRONGNAMESIGNED
Topomatic.Alg.dll          machine=x86  PE32  corflags=9  = ILONLY + STRONGNAMESIGNED
```

`32BITREQUIRED` **нет ни в одной сборке** — это AnyCPU: заголовок собран под x86,
но 64-битный хост грузит их как 64-битные. Фактически процесс 64-битный
(`IntPtr.Size == 8`).

Практический вывод: **не выбирать разрядность внешней библиотеки по PE-заголовку
`Robur.exe`.** В NewPluginSystem так был выбран 64-битный CPython — и это
единственный рабочий вариант; заголовок вводил в омысел, будто нужен 32-битный.

Проверка разрядности процесса — только своя: `IntPtr.Size == 8`.

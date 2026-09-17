# ApiNotes — Сквозные ловушки API Robur

Свод проверенных граблей. Каждая — с источником `[DECOMP]`/`[CODE]`/`[TUT]`.

## 1. Векторы и структуры — ПОЛЯ, не свойства

`[DECOMP]` `Topomatic.Cad.Foundation.dll`, `[CODE]` Runoff/Robur/VectorRead.cs:

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
  `[CODE]` прогоны M2.5/M3 RailModelImporter (`rim_py_*`, `_import_diagnostics.log`).
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
  `[CODE]` `describe_parameter_table` (rail_json.py) — фикс `format_d`; импортёр не виноват
  (ни `Add`, ни индексатор `this[double]` дубль станции не создают — общий `GetIndex`
  по пикету, лог: «строк в JSON=34, записано=34, контроль Count=33»).
- **Политика A — whitelist пользовательских параметров (W1 и др.)**: при отсутствии
  в живом реестре (`GetTableParameters()` не вернул пару для табличного дескриптора
  из схемы) параметр НЕ создаётся «с нуля» руками, а заводится канонической
  фабрикой реестра:
  `AlignmentParameters.DefineParameterTable<T>(variable, caption, behaviorType,
  defaultValue, overrideExisting, isSystem)` — `[DECOMP]` AlignmentParameters.cs:365.
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
  `[CODE]` M2.5/M3 RailModelImporter (`rim_reflection.py`/`rim_commands.py`), `[TEST]`
  /tmp jstest (plan.json c BOM — чистый C# возвращает полные строки).

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
`GetPointResult` (с `params string[] options`) — TutorialEditSurfaceElements/Module.cs:70.
Плюс `[CODE]` Runoff/DemLoader — bool-вариант (false на отмену). Проверяйте, какую вызываете.

## 4. ЦММ: создание с нуля

`[CODE]` DemLoader/TerrainWriter.cs:
- `node.Model` остаётся `null` после `LockWrite()` до вызова `LockRead()` — без исключения.
- `surface.Points.Add(new SurfacePoint(...))` начинается с **проверки лицензии** — без неё
  «успешно» молча ничего не делает.
- `BeginUpdate()` без парного `EndUpdate()` — запись видна в текущей сессии, но нештатно.
- `node.GetChilds()` бросает `NullReferenceException` — try/catch.

## 5. Профиль земли — не `??`, а try/catch

`[CODE]` Runoff/RailDitchReader.cs: каждое из `StaticEg`/`DynamicEg`/`EgProfile` может кинуть —
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
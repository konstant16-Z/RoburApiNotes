# ApiNotes — Ж/Д специфика (RailAlignment / Topomatic.Alg.Rail.dll)

> Вся информация в этом файле относится к сборке **`Topomatic.Alg.Rail.dll`** (namespace `Topomatic.Alg.Rail` и `Topomatic.Alg.Rail.Trains`, `Topomatic.Alg.Rail.Tray`).
> Базовые классы (`Alignment`, `PlanLine`, `Transitions`, `Corridor`, `Parameters`, `Kilometres`, `Stationing`, `ConventionalSigns`, cutting surfaces, parameter tables) описаны в `alignment.md`.

---

## Установленные скорости (`TrainSpeeds` / `TrainSpeed`) — write-API

`[DECOMP]` ilspycmd `Topomatic.Alg.Rail.dll` (namespace `Topomatic.Alg.Rail.Trains`),
`[CODE]` экспорт `build_train_speeds` + импорт `_write_train_speeds` (фикс 2026-09-13):

- `axis.TrainSpeeds` → `TrainSpeeds : UndoObject, IList<TrainSpeed>`.
  Публичные `Clear()`, `Add(TrainSpeed)`, `Count`, индексатор `Item[int]`,
  `get_Alignment` (IAlignmentContainer), `Owner` (private set — NotSupportedException).
  Паттерн записи — Clear+Add внутри `BeginUpdate()/EndUpdate()` (как M4).
- Элемент `TrainSpeed` — **СТРУКТУРА** с публичными **полями**
  `Station / Passenger / Cargo / Empty` (все double) и публичным конструктором
  `TrainSpeed(double station, double passenger, double cargo, double empty)`.
- **Ловушка сериализации**: у структуры нет свойств — `build_object_dict`
  (по `GetProperties()`) выгружал пустой `{}`, и значения скоростей терялись
  ещё на экспорте. Читать/писать только через ПОЛЯ (`GetField`/`try_add_field`),
  как у `VertexItem`. Формат JSON-экспорта:
  `{ "type": "TrainSpeeds", "count": N, "items": [{ "Station":.., "Passenger":.., "Cargo":.., "Empty":.. }] }`.
- **Пустой элемент `{}` (фикс 2026-09-17)**: если источник уже потерял значения
  (экспорт через объектно-свойственный выгрузчик), импортёр **не пропускает**
  элемент, а создаёт дефолтную запись `TrainSpeed(0,0,0,0)`, чтобы `Count`
  коллекции не обнулялся (эталон: `count:1, items:[{}]`). Частично заданные
  элементы (без всех 4 полей) по-прежнему пропускаются с пометкой в stats.
- **C#-экспортёр (фикс 2026-09-17)**: скорости выгружались через
  `BuildCollectionJson` → `BuildObjectDict` (свойства) — тот же баг `{}`.
  Добавлен `BuildTrainSpeeds` (чтение полей `TryAddField`, зеркало
  `build_train_speeds`).

---

## Вираж, водоотвод, лотки (M4) — write-API

`[DECOMP]` asmread `Topomatic.Alg.Rail.dll` (таблицы — `UpdatableObject`,
есть `BeginUpdate()/EndUpdate()`; элементы — `TransactableField`'ы, пишутся
свойствами или конструктором). Пишем перезаписью Clear+Add внутри
`BeginUpdate()/EndUpdate()` (паттерн M3). `[CODE]` импорт `rim_import_virage`,
`rim_import_drain` (RailModelImporter, этап M4).

### VirageTable / Virage (возвышение)

`VirageTable : UpdatableObject, ICollection, IList, IOwned, IAlignmentContainer,
IStgSerializable, IEnumerable` — есть интерфейсный `Alignment Alignment {get;}` (каст
`Owner as Alignment`), `Refresh()` (пересчёт служебных таблиц параметров из
`alignment.Parameters`).

| Член таблицы | Сигнатура |
|---|---|
| `Add(Virage)` | → void |
| `Remove(Virage)`, `Clear()`, `IndexOf/Insert/RemoveAt` | IList-члены |
| `Item[int]`, `Count` | get |
| `ctor(object owner)` | таблица |

`Virage: UpdatableObject, IOwned, IStgSerializable, IEquatable<Virage>`:
ctor `(object)` либо полный
`ctor(object, string Name, double StartSta, double EndSta, double L1, double L2, VirageDirection)`,
либо копирующий `ctor(object, Virage)`.
Записываемые свойства: `Name`, `StartStation`, `EndStation`, `L1`, `L2`, `Elevation`,
`Offset`, `BallastOffset`, `Radius`, `Velocity`, `Direction` (`VirageDirection.{Left,Right}`).
Enum из JSON «VirageDirection.Left» разбирается `jtyped(..., DirectionType)`.

⚠ **Owner элемента — ТАБЛИЦА, а не ось** (для ВСЕХ таблиц M4: `new Virage(this)`,
`new Drain(this)`, `new TrayLayout(this)`, `new Tray(this)` в канонических
`LoadFromStg`). При создании через `ctor(axis)` элемент «работает» и round-trip
JSON сходится, но UI падает: `VirageWrapper.get_Stationing()` делает
`(VirageTable)virage.Owner` → `InvalidCastException` («Не удалось привести тип
RailAlignment к VirageTable»), PropertyGrid не рисует колонку «Пикетаж».
Поэтому в импортёре кандидаты ctor идут `[[table], [axis]]` (таблица — первой),
а read-back проверяет `v.Owner.GetType().FullName == ...VirageTable`.
Аналогичный каст есть у обёрток дренажа/лотков (`*Wrapper.get_Stationing`).

### ExistingCant / ExistingCantValue (существующее возвышение)

`ExistingCant`: `Add(ExistingCantValue)` → void; `Item[int] {get set}`, `Count`.
`ExistingCantValue` — **структура** `ctor(double Station, double Value)` (поля `Station`, `Value`).

### DrainTable / Drain (водоотвод)

`DrainTable`: `Add(Drain)` → void; `ctor(object)`; `Item[int] {get set}`, `Count`.
`Drain` (`ctor(object)`): записываемые `StartStation`, `EndStation` (double),
`Construction`, `BottomIn`, `BottomOut`, `EdgeNode` (string), `TransitionIndex`
(Int32), `Type` (`DrainType.{Drain,Ditch,Tray}`), `Strengthened` (bool).
⚠ **`Side` (`DrainSide.{Left,Right}`) — только чтение**; вычисляется из
`TransitionIndex` (пары переходов левая/правая: 1→Left, 2→Right — подтверждено
эталоном drain.json). При импорте ставится только `TransitionIndex`.

### TrayLayoutTable / TrayLayout + TrayCollection (раскладка лотков)

`TrayLayoutTable`: `Add(TrayLayout)` → void; `Item[int] {get set}`, `Count`.
`TrayLayout` ctor: `(object owner, Int32 TransitionIndex, double StartSta,
double EndSta, bool FromEdge, TrayCollection)`; свойства соответствуют аргументам.

`TrayCollection : UpdatableObject, IOwned, IStgSerializable` (`[DECOMP]` полный API):
`ctor(TrayTable)`, `Add(int)`, `Insert(int,int)`, `RemoveAt(int)`, `Clear()`;
`Item[int]` → int (индекс типа лотка), `Count`, `Length`; запросы:
`GetLengthAt(int) → double`, `FindIndex(double sta) → int`,
`TryGetTrayHeight(double sta, out double value) → bool`,
`GetTrayCount(int[] counts)`, `GetIntervals(List<TrayInterval>)`.
`struct TrayInterval { double StartSta; double EndSta; int Type; int Count; }`
+ ctor `(double, double, int, int)` — интервалы раскладки с количеством.

Экспортёр (новый формат .railx) выгружает `items[]` — сами индексы
типов (читаются через индексатор `Item[int]`, который общий обход `build_object_dict`
пропускает) — последовательность лотков восстанавливается точно. Старый формат
(только `Count`/`Length`) — fallback: коллекция заполняется первым типом (индекс 0),
пикетаж и `Length` сходятся (все типы `Length`=1.5).

⚠ **Ловушка импорта**: `TrayCollection.Add(int)` на лету пересчитывает длины по
`trayTable[index].Length` (декомпиляция `Topomatic.Alg.Rail.Tray.TrayCollection.Add`
→ AfterInsert → пересчёт `_lengths`). Пока `TrayTable` пуста, **любой `Add` падает
`IndexOutOfRangeException`** («Индекс за пределами диапазона»). Поэтому импортёр
пишет `tray_table.json` **до** `tray_layout.json` (см. `_write_tray_table`/
`_write_tray_layout` в скрипте импортёра), плюс защитная проверка `Count>0` с
понятной ошибкой вместо исключения.

### TrayTable / Tray (типы лотков)

`TrayTable`: `Add(Tray)` → void; `Item[int]`, `Count`.
`Tray` ctor: `(object owner, double Length, double Height)`; свойства `Length`,
`Height` — **только чтение** (задаются конструктором).

---

## Динамическая поверхность, реконструкция, габарит — write-API (M5.5)

`[DECOMP]` ilspycmd `Topomatic.Alg.Rail.dll`, `[CODE]` импорт
`_write_dynamic_surface`/`_write_reconstruction`/`_write_surface_clearence`
(RailModelImporter):

- `RailAlignment.DynamicSurface` (bool), `DynamicProjectSurfaceUseFactor` (bool),
  `DynamicProjectSurfaceUserFactorValue` (double) — собственные TransactableField-
  свойства оси (экспорт `model/DynamicSurface/dynamic_surface.json`).
- `RailAlignment.ReconstructionData` → `ReconstructionData : UndoObject, IOwned`:
  `MinBallastDepth` (double), `ShowBallastLine`/`ShowRatedRailHeadLine` (bool) —
  записываемые; `ExistBallastSoiling` — коллекция (read-only).
- `RailAlignment.SurfaceClearence` → `SurfaceClearence : UpdatableObject,
  IOwned, IStgSerializable`: `LeftSize`/`RightSize` (double) записываемые.
  `Distances` — `TransactableDictionary<int,double>` (декомпиляция
  `Topomatic.FoundationClasses.Undo.TransactableDictionary`): публичные
  `Clear()`/`Add(key,value)`/индексатор; канон записи — `LoadFromStg`
  (`InnerDictionary.Clear()` + `[key]=value`). Экспорт пар: `build_dictionary_pairs`
  → `front-end { type, count, items[{key,value}] }` (generic `build_object_dict`
  раньше давал только счётчики — пары пикет→дистанция терялись, импорт отмечал
  «пары не выгружены экспортёром»).

### Тип ж/д пути и два «непарсимых» раздела

`[DECOMP]` `Topomatic.Alg.Rail.dll` (`rail_md.il` + `Controller.cs`), `[CODE]`
экспорт `alignment/parameters.json` / импорт `_PARAMETERS_SCALAR_MAP`:

- **`RailAlignment.AlignmentType`** — `enum Topomatic.Alg.Rail.RailAlignmentType`
  (`Project = 0`, `Existing = 1`), публичные get/set (TransactableField). BSTG-ключ
  `RailAlignmentType` (Int32 в разделе `Alignment`; во всех реальных моделях = 0).
  Экспорт: `parameters["RailAlignmentType"] = int(axis.AlignmentType)` (на
  `RoadAlignment` свойства нет → None). Импорт: `jtyped` enum-путём
  (`Enum.Parse(type, "0")` — числовая строка разбирается как underlying-значение).

- **`DynamicSurfaceType`** — BSTG Int32 (0..1), но **публичного свойства НЕТ**
  (только `DynamicSurface` bool, `DynamicProjectSurfaceUseFactor` bool,
  `DynamicProjectSurfaceUserFactorValue` double, `DynamicSurfaceFactor`,
  `DynamicSurfaceGaps` — они с get/set и уже импортируются). Скорее всего приватное
  кэш-поле сериализации (как у DwgBorderline); парсить не стали — int 0/1, ценности
  мало. Для round-trip не требуется.

- **`Model3DElementContext`** — BSTG-узел (каталог Smdx-агрегатов: `classes`/
  `types`/`models`; в ж/д-моделях — рельсы Р65, скрепления Костыльное/ЖБР-65,
  шпалы Тип I/Ш3 с `properties`). Присутствует и в `Alignment/`, и в
  `Alignment/Plugins/Gridiron/`. **Публичного свойства нет ни в `Topomatic.Alg.dll`,
  ни в `Topomatic.Alg.Rail.dll`** (ни один IL/декомпилированный .cs его не
  объявляет) — не парсим.

---

## Верхнее строение пути (ВСП) — два формата, конвертация sections→таблицы

`[DECOMP]` ilspycmd `Topomatic.Alg.Rail.dll` (16.0.50.7 и 16.0.62.x), `[CODE]`
экспорт `build_permanent_way*` (RailModelExporter), импорт
`_write_permanent_way[_sections]`/`_pw_make_scalar_row` (RailModelImporter).
**Статус: подтверждено** round-trip 16.50-экспорт → импорт в новую Robur →
повторный экспорт (экспорт → импорт → повторный экспорт,
значения побайтово совпали: эпюра 1600 шпал, балласт 0.45/0.37).

### Новая модель (Bin, 16.0.62.x) — таблицы

`PermanentWay` (свойства оси `ProjectPermanentWay`/`ExistingPermanentWay`) —
коллекции `Rails`/`Fastenings`/`Sleepers` (строки `RailsSection{Station}` +
параметры `Rail`/`Fastening`/`Sleeper` = типовой элемент по `Caption`),
`SleepersDistribution` (`SleepersDistributionSection{Station, SleepersCount}`),
`BallastDepth` (`BallastDepthSection{Station, BallastDepth}`).

### Старая модель (Robur 16.0.50) — поучастковая

- `PermanentWay` = список `PermanentWaySection{Station, EndStation, Rail, Sleeper,
  Fastening}` — **без** коллекций (определяется `is_old_permanent_way`:
  `Rails`/`Fastenings`/`Sleepers` = None).
- Эпюра шпал живёт **вне** PermanentWay: `ReconstructionData.SleepersDistribution`
  (единственная, проектная) — `SleepersDistributionSection{Station, SleepersCount}`
  + `LastRule` (enum `RuleType`: `User/CPT_53/SP_119_13330_2017/SP_37_13330_2012`).
- Толщина балласта: проектная — `RailAlignment.ProjectBallastDepth`;
  существующая — `ReconstructionData.ExistBallastDepth` (обе —
  `BallastDepthSection{Station, BallastDepth}`).

### Формат экспорта 16.0.50 (sections)

JSON-блок `{ type, model:"sections", count, items[] }` — в `permanent_way.json`/
`permanent_way_existing.json`. Экспортёр дописывает в блок коллекции каноном
табличной модели:
- проектное ВСП → `SleepersDistribution` (из `ReconstructionData`, + `lastRule`)
  и `BallastDepth` (из `ProjectBallastDepth`);
- существующее ВСП → `BallastDepth` (из `ExistBallastDepth`);

каждая `{ type, count, items:[{station, value}] }` (+ `lastRule` у эпюры).
`build_permanent_way(perm_way, axis, existing)` пробрасывает ось; для новых Robur
параметр `axis` игнорируется (данные читаются из самого PermanentWay).

### Импорт (в новую Robur)

`sections` → таблицы новой модели:
- секции → строки `Rails`/`Fastenings`/`Sleepers` по станции (`Clear` + `Add`,
  строка на секцию; параметры из секционных подблоков `rail/fastening/sleeper`,
  ключ `caption` строчный);
- `SleepersDistribution`/`BallastDepth` (доп. блок) → одноимённые таблицы через
  `_pw_write_extra` (scalar-строки: `SleepersDistributionSection` ctor
  `(owner, double station)`, `BallastDepthSection` ctor
  `(owner, double station, double value)`); восстановление
  `SleepersDistribution.LastRule` из `lastRule` (set_typed_prop, enum целиком);
- при отсутствии ключей коллекции очищаются (обратная совместимость со старыми
  экспортами 16.0.50, где эпюры/балласта в JSON не было).

### Примечания

- Тип элемента таблицы: `element_type_of` ИЛИ индексер `Item[int]` — у пустой
  таблицы `element_type_of` вернёт None (нет первого элемента), индексер обязателен.
- Все четыре коллекции — перезапись (Clear), эталон из тестового файла `.railx`:
  VirageTable 1 запись («ВУ1», R=600), DrainTable 2 записи (левый ву 1, правый лоток 2),
  TrayLayoutTable 1 участок (переход 2, ПК 0–3156.06, от бровки), TrayTable 4 типа
  (Длина 1.5 × Высота 0.75/1.0/1.25/1.5).
# ApiNotes — Трассы (Alignment) и подобъекты

## Базовый класс `Alignment`

`[DECOMP]` `Topomatic.Alg.dll` (`Topomatic.Alg.Alignment`): **все** нужные свойства
объявлены на базовом `Alignment`, а не на `RoadAlignment` → одинаково работают для
автодороги (`RoadAlignment`) и ж/д (`RailAlignment`). `[CODE]` Runoff
(«Берём БАЗОВЫЙ Alignment»; на `Topomatic.Alg.Rail` ссылку не добавляют, тип пути
определяют по имени типа: `Road is RoadAlignment`).

```csharp
public abstract class Alignment : UndoObject, IAlignmentContainer, IStgSerializable, IStationingContainer, IOwned
```

Публичные свойства:

| Член | Тип |
|---|---|
| `Plan` | `PlanLine` |
| `Stationing` | `AlgBaseStationing` |
| `Kilometres` | `AlgAlignmentKilometres` |
| `Style` | `AlignmentStyle` |
| `Transitions` | `ITransitions` (`Topomatic.Alg.Prf.ITransitions`, `IEnumerable` + `IStgSerializable`) |
| `Parameters` | `AlignmentParameters` |
| `Corridor` | `Corridor` |
| `SelectedSections` | `SelectedSectionsCollection` |
| `Pipes` | `PipesCollection` |
| `Bridges` | `BridgesCollection` |
| `Signs` | `ConventionalSigns` |
| `StartStation`, `Description`, `DtmSizeLeft/Right` | `double`/`string` |
| `EgSurfaceRelativePaths`, `ProfileCuttingSurfacesRelativePaths`, `SectionCuttingSurfacesRelativePaths`, `AlignmentIntersectionsRelativePaths` | `IList<string>` |
| `ConstructionTemplates`, `PlanVertexEditedItems`/`PlanVertexElementsEditedItems`/`PlanLineSegmentsEditedItems` (`BasicEditedItemsTable`) | служебные |
| `IsLimitedChange`, `MinChangeStation`, `MaxChangeStation`, `HasSynchronizedAlignment`, `SynchronizedAlignmentIdRelativePath` | опциональные |
| `Owner`, `Alias` (abstract), событие `SettingsChanged` | — |

Помимо свойств, на базовом классе есть `public virtual void Clear()` — полная очистка
собственных подобъектов (внутри `BeginUpdate/EndUpdate`).

**Интерфейсы — единая навигация «владелец»**: `IAlignmentContainer` даёт
`Alignment Alignment {get;}`; его же реализуют таблицы M4 — `VirageTable.Alignment`
просто кастует свой `Owner` в `Alignment` (декомпиляция VirageTable):

```csharp
public Alignment Alignment { get { return owner as Alignment; } }
```

То же у `AlgAlignmentKilometres.Alignment` (`Owner is IAlignmentContainer`). Т.е. от
любого звена (километраж, таблица M4) можно подняться до оси одним свойством.

## Активная трасса

```csharp
using (var r = ActiveAlignmentReciver<Alignment>.CreateReciver(false))
{
    var alignment = r.Alignment; // null, если нет активной трассы; r.ProjectModel, r.Manager
}
```
`[TUT]` (см. tutorial3). `CreateReciver(true)` — регистрировать изменение.

## План (PlanLine)

| API | Назначение | Статус |
|---|---|---|
| `alignment.Plan.CompoundLine` | Плановая линия; `StaOffsetToPos`/`PosToStaOffset`, `Length` | `[DECOMP]`+`[CODE]` |
| `CompoundLine.SectLine(line2D, List<double>)` | Пересечения плановой линии с прямой; наполняет список пикетами | `[DECOMP]` (AlgAlignmentKilometres.SectLinked) |
| `CompoundLine.StaOffsetToPosInfinite(u, offset, out Vector2D)` | Пикет+смещение → точка (infinite-вариант, без ограничения границ) | `[DECOMP]` (AlgAlignmentKilometres.SectLinked) |
| `plan.SearchNearest(station)` → vertex | Ближайшая вершина угла плана (опорный узел — vertex[0]) | `[TUT]` |
| `plan.Add(Vertex)` / `Insert(int, Vertex)` / `RemoveAt(int)` / `Clear()` | `PlanLine` = `IList<Vertex>`; `Add` сам открывает `BeginTransaction→Commit`, назначает `Owner`/`ID`; **геометрию НЕ пересчитывает** — после записи нужен `Invalidate()`+`CompoundLine` (см. ниже) | `[DECOMP]` |
| `PlanLineSolver.PlanVertexesValid(plan)` | Валидация геометрии плана | `[DECOMP]`/`[TUT]` |

### Запись плана с нуля — подтверждено декомпиляцией `Topomatic.Alg.dll`

(`[DECOMP]` `ilspycmd -t Topomatic.Alg.Plan.PlanLine`; XML-доков для Rail-типов нет,
Stg-поля обфусцированы, публичный API цел):

```csharp
plan.AutomaticNames = false;              // иначе plan.Add переименует узлы в «НТ/ВУ1/…/КТ»
plan.BeginUpdate();
try
{
    plan.Clear();                              // IList<Vertex>
    var v = new PlanLine.Vertex();             // public ctor; Owner назначает plan.Add
    v.Name = "ВУ1";
    v.Position = new Vector2D(x, y);           // settable; P/Beta — internal set (считает солвер)
    var item = new PlanLine.Vertex.VertexItem { R = 651, L1 = 0, K = 100, L2 = 3 };
    v.Add(item);                               // пишет L1/R/K; L2 — «хвостовое» поле вершины
    plan.Add(v);                               // BeginTransaction→Commit, Owner, ID; НЕ геометрия
}
finally { plan.EndUpdate(); }

// ОБЯЗАТЕЛЬНО: пересчёт геометрии — иначе P/Beta остаются 0, кривые теряются,
// PlanVertexesValid=False и hit-testing падает NullReferenceException в слое плана.
GetMethod("Invalidate", NonPublic|Instance).Invoke(plan, null);  // protected
var cl = plan.CompoundLine;                  // публичный геттер → Refresh() → P/Beta+сборка

bool ok = PlanLineSolver.PlanVertexesValid(plan);
```

- **`plan.Add` не считает P/Beta и не собирает CompoundLine** (декомпиляция `PlanLine`:
  `Add` = вставка + Owner/ID + автопереименование; пересчёт P/Beta и сборка геометрии
  — приватные методы, вызываемые из `protected Refresh()` по «грязным» флагам, которые
  ставит `protected Invalidate()`). `Refresh()` триггерится публичным геттером
  `CompoundLine`. Без этого в Robur: `PlanVertexesValid=False` + NRE в
  `Topomatic.Alg.Layers` при клике. Ловушка воспроизведена на живом прогоне M2.5.

- `PlanLine` реализует `IList<PlanLine.Vertex>` и `IStgSerializable` (`LoadFromStg`/`SaveToStg`); опорный узел — «vertex[0]» из `SearchNearest`.
- `VertexItem` — **структура** с публичными полями `L1, R, K, L2`. Копировать-изменять-записывать обратно (`vertex[j] = item`).
- **Длины переходных кривых связаны между соседними элементами одной вершины**
  `[DECOMP]` (`Topomatic.Alg.dll`, `PlanLine.Vertex.get_Item`):
  - для `0 <= i < vertex.Count - 1`: `vertex[i].L2 == vertex[i + 1].L1`;
  - у последнего элемента `L2` — отдельная хвостовая длина вершины, а не длина
    следующей вершины плана;
  - поэтому в составной кривой `L2` нельзя трактовать как независимое значение
    каждого элемента. При экспорте через API читайте все четыре поля структуры,
    возвращённой `vertex[i]`; при подготовке данных для записи согласуйте
    `items[i].L2` и `items[i + 1].L1`.
  Это семантика публичного индексатора `Vertex`, не правило файлового формата.
- `Vector2D.X/Y` — публичные поля.
- `vertex.BeginTransaction()/Commit()/Rollback()` — изменение вершины с валидацией.

Полные доказательства из IL (сигнатуры `Add`/`Insert`, свойства `Vertex`, семантика
`Vertex.Add`) — задокументированы отдельно (write-API плана).

## Профили (Transitions / Transition)

`[DECOMP]` `Topomatic.Alg.Prf.Transition` (`UpdatableObject, IAlignmentContainer, IStgSerializable, IOwned`):

| Член | Назначение | Статус |
|---|---|---|
| `RedProfile` → `ProjectProfile` | Красный (проектный) профиль | `[CODE]` |
| `EgProfile` → `Profile` | Чёрный/земля (общий профиль) | `[CODE]` |
| `StaticEg` → `StaticProfile`, `DynamicEg` → `DynamicProfile` | Профиль земли: статический/динамический | `[CODE]` |
| `AgProfile` → `AgProfile` | Вспомогательный профиль — **один** (интерполированный, `IList<AgProfileNode>`) | `[DECOMP]` |
| `UserProfiles` → `UserProfiles` | Коллекция пользовательских вспомогательных — **несколько на базовый** (см. ниже) | `[DECOMP]` |
| `Offset` → `IOffset` (`TryGetValue`) | Смещение линии от оси | `[CODE]` |
| `GetY(station, out y)` (на `IProfile`) | Интерполяция профиля по пикету | `[CODE]` |
| `IsDynamicEarth`, `Name`, `Description`, `FillArea`, `CutArea` | Атрибуты | `[DECOMP]` |
| `Split/CanSplit`, `Join/CanJoin`, `CopyFrom`, `EqualsWith` | Служебные операции | `[DECOMP]` |
| `Gaps`, `FixedPoints`, `UserProfiles`, `Underlay` | Подобъекты | `[DECOMP]` |

**Профиль земли — не `??`, а try/catch** `[CODE]` Runoff:
```csharp
try { if (t.StaticEg != null) return t.StaticEg; } catch { }
try { if (t.DynamicEg != null) return t.DynamicEg; } catch { }
try { return t.EgProfile; } catch { return null; }
```

Правка красного профиля `[TUT]`: `redProfile.GetY(sta, out y)`, `profile.Add/Remove`,
`ProjectNode`, `ProjectNodeFlags.UseRadius`.

**Write-API профилей `[DECOMP]` `[TUT]`** (asmread, metadata Topomatic.Alg.dll + TutorialEditAlignment.SmoothPeak):

Паттерн записи (замена содержимого — begin/end в try/finally, как в туториале):
```csharp
var profile = alignment.Transitions[0].RedProfile;
profile.BeginUpdate();
try
{
    profile.Clear();
    profile.Add(new ProjectNode(sta, el, len, r, ProjectNodeFlags.UseRadius));
    profile.Remove(old);                       // Remove → bool
}
finally { profile.EndUpdate(); }
```

Узлы профилей — **структуры** (поля, не свойства; Transaction в коллекции даёт сам `Add`).
⚠ Из IronPython поля boxed-структур писать только через `set_field` — прямое
`node.Station = …` молча оставляет ноль (проверено прогоном M3, см. `pitfalls.md` §1):

| Тип узла | Публичные поля | Конструкторы |
|---|---|---|
| `ProfileNode` | `Station`, `Elevation` (double); `Code` (int), `DisplayFlags` (uint) | `(double, double)`; `(double, double, int, uint)` |
| `ProjectNode` | `Station`, `Elevation`, `Length`, `Radius` (double); `Flags` (`ProjectNodeFlags`) | `(double, double, double, double, ProjectNodeFlags)`; копирующий |
| `AgProfileNode` | `Station`, `AgElevation`, `EgElevation`, `LeftOffset`, `RightOffset`, `Grade` (double) | копирующий |
| `OffsetItem` | `Station`, `Offset` (double) | `(double, double)`; копирующий |

`ProjectNodeFlags` — битовый enum: `UseRadius`, `UseLength`. `ProjectNode.Position` — `Vector2D {get set}`.

Коллекции-профили (внутри `TransactableList<T>`, `BeginUpdate/EndUpdate` от `UndoObject`):

| Коллекция | Add / Insert / Remove / RemoveAt / Clear | Item[int] |
|---|---|---|
| `ProjectProfile` (= `Transition.RedProfile`) | + / + / + (→bool) / + / + | get/set |
| `StaticProfile` (= `Transition.StaticEg`, и `EgProfile` при статической земле) | + (ProfileNode) | get/set |
| `AgProfile` (= `Transition.AgProfile`) | + (AgProfileNode) | get/set |
| `Offset` (= `Transition.Offset`, не ZeroOffset) | + (OffsetItem) | get/set |

Узел `AgProfileNode` — **структура** (поля `Station`, `AgElevation`, `EgElevation`,
`LeftOffset`, `RightOffset`, `Grade`; вычисляемые `Elevation`, `HasPositions`,
`LeftPos/RightPos`); `AgProfile` дополнительно: `FindFirstNode(double) → int`,
`FindNodes(double) → IEnumerable<int>`, `struct Value { Elevation, Ag, Eg }`.
Вспомогательные профили пользователя (`UserProfiles`) сюда не входят — см. подраздел выше.

**Нет Add/Remove**: базовый `Profile` (коллекция — только `Item[int]` get, `Count`,
`Min/MaxStation`, `GetY`; плюс ссылки `Alignment`/`Transition`/`Owner`),
`DynamicProfile` (строится от ЦММ: `Step`/`AdditionalStations`/`Enabled`/`BuildFlags`),
`ZeroOffset` (всегда пуст). Если у перехода `EgProfile` по факту `DynamicProfile` —
узлами чёрный профиль не пишется, пишется `StaticEg`. `Transitions` (`RailTransitions`) —
только чтение: `Item[int]`/`Count` + служебные `Clear`/`RefreshViolations()`; нового
перехода добавить нельзя — заполняются существующие.
`Transition.Name` `{get set}`, `Description` `{get set}` (менять Name не стоит — системные имена линий).

### Пользовательские вспомогательные профили — `UserProfiles` / `UserProfile`

`[DECOMP]` `Topomatic.Alg.Prf.{UserProfiles,UserProfile,StaticProfile}` (Topomatic.Alg.dll).

В UI на один переход можно завести **несколько** вспомогательных профилей → это
`Transition.UserProfiles` (коллекция `UserProfile`), а НЕ `AgProfile` (тот — один).
Внутри — `TransactableDictionary<string, UserProfile>` (**ключ = `Name`**).

`UserProfiles : UndoObject, IOwned, IAlignmentContainer, IStgSerializable, ITransitionContainer,
IEnumerable<UserProfile>`:

| Член | Назначение |
|---|---|
| `ctor(object owner)` | владелец — переход |
| `Add(UserProfile)` | кладёт по `profile.Name` (повтор имени = перезапись) |
| `Remove(UserProfile)` / `Clear()` | удаление по имени / все |
| `ContainsKey(string)` / `TryGetValue(string, out UserProfile)` | поиск по имени |
| `Transition {get}`, `Alignment {get}` | через `Owner is ITransitionContainer/IAlignmentContainer` |
| `LoadFromStg`/`SaveToStg` | STG-сериализация |

⚠ `Count`/`Item[int]` **не публичны** — перебор только через `IEnumerable<UserProfile>`.

`UserProfile : StaticProfile` — узлы как у статического профиля (полный `IList<ProfileNode>`:
`Item[int] {get;set}`, `Add/Insert/RemoveAt/Remove/Clear/Contains/IndexOf/CopyTo`, `Count`,
`Min/MaxStation`) + атрибуты отображения:

| Член | Тип | Запись |
|---|---|---|
| `Name` | `string` | **только чтение** — задаётся ctor'ом (поле, не `TransactableField`) |
| `Description` | `string` | set (TransactableField) |
| `Color` | `CadColor` | set (TransactableField) |
| `ShowDifference` | `bool` | set (TransactableField) |

⚠ Для ИМПОРТА (Name не сеттер): только полный ctor
`(parent, name, description, CadColor color, bool showDifference)` — поля после этого менять можно.

Ctors: `(object parent)`, `(object parent, string name, string description, CadColor color,
bool showDifference)`, `(object parent, UserProfile)` (копирующий).

`Color` — структура `Topomatic.Cad.Foundation.CadColor` (`[DECOMP]`: ctor `(int colorIndex)`
и `(System.Drawing.Color)`, `ColorIndex` int, `IsEmpty`, статические `ByBlock/ByLayer/Empty/...`).
Специальные индексы — сериализация/десериализация это int, НЕ RGB:

```text
ByBlockIndex=0, ByLayerIndex=256, EmptyIndex=33554432 (0x02000000),
BackgroundIndex=67108864 (0x04000000)
```

**Экспорт/импорт**: `AgProfile` пишется экспортёром (`ag`, узлы `AgProfileNode`). `UserProfiles`
**реализованы** и в экспортёре, и в импортёре M3 (`rim_import_transitions`, `_write_user_profiles`):
секция `userProfiles` = `{type, count, items[]}`, каждый элемент
`{name, description?, color, showDifference, nodes{count, nodes[]}}`, где `color` — int-индекс
`CadColor.ColorIndex`, а поле `nodes` — **вложенный объект `{count, nodes[]}`, тот же формат,
что у `eg`/`staticEg`** (ProfileNode: `station`/`elevation`/`code`). Порядок записи импортёра:
`Clear()` → полный ctor `(parent, name, desc, CadColor(idx), showDiff)` → узлы → `Add`
(ключ коллекции — `Name`). Узлы берутся из **внутреннего** массива двухшагово:
`jindex(raw, u"nodes")` → `jarr(inner, u"nodes")`; прямого `jarr(raw, u"nodes")`
недостаточно — поле `nodes` это JObject, а не JArray, и `jarr` молча возвращал `None`
(элемент создавался, узлы пропадали: переэкспорт давал `nodes: 0`).

**Round-trip подтверждён** (экспорт → импорт → повторный экспорт, 2026-09-12): у обоих
профилей «По внутренней бровке водоотвода» (transition_1/2) полное имя без потери символа,
`color=2.0`, `showDifference=True` и узлы 33→33 с нулём расхождений (station/elevation/code
совпадают с исходником до 1e-10; контроль станций первого/последнего узла — в
`_write_profile_nodes`).

Воспроизведение декомпиляции:
```bash
ilspycmd -t "Topomatic.Alg.Prf.Transition"        Topomatic.Alg.dll
ilspycmd -t "Topomatic.Alg.Prf.UserProfiles"      Topomatic.Alg.dll
ilspycmd -t "Topomatic.Alg.Prf.UserProfile"       Topomatic.Alg.dll
ilspycmd -t "Topomatic.Alg.Prf.StaticProfile"     Topomatic.Alg.dll
ilspycmd -t "Topomatic.Alg.Prf.AgProfile"         Topomatic.Alg.dll
ilspycmd -t "Topomatic.Alg.Prf.AgProfileNode"     Topomatic.Alg.dll
ilspycmd -t "Topomatic.Cad.Foundation.CadColor"   Topomatic.Cad.Foundation.dll
```

## Поперечники — Corridor / SectionList / Section

`[DECOMP]` `Topomatic.Alg.Crs`:

| API | Назначение |
|---|---|
| `alignment.Corridor` → `Corridor` (UndoObject, IAlignmentContainer) | Коридор трассы |
| `corridor.Sections` → `SectionList` | **Все** секции поперечников коридора |
| `SectionList`: `Count`, `this[int]`, `Add(double station)`, `Remove(int)`, `Clear()`, `IsExist(double)`, `GetIndex/GetIndexLess/GetIndexMore(double)`, `Move(station, delta)`, события `AfterInsert/BeforeRemove` | Операции над секциями |
| `Section` (элемент): `Station` (double, internal set), `Id` (uint, internal set), `ConstructionId`, `Selected` (bool, writeable), `StaticEg`/`SectionLine` (CrsLine), `IsProject`, `Name`, `Underlay` | Секция поперечника |
| `corridor.CreateDesignContext(station)` (+ перегрузки: `BuildMode`, `listener`, `clipContours`) → `CrsDesignContext` | Контекст дизайна секции |
| `corridor[index]` → `CrsDesignContext`; `corridor.Constructions` → `ConstructionDictionary`; `corridor.RemoveUnusedConstructions()`, `corridor.Clear()` | Доступ к конструкциям |
| `context.FindContour(code)`, `GetEgContour()`, `GetRedLineContour()`, `.AsVectorList()` | Контуры поперечника `[TUT]` |
| `new PolygonOperation().Intersection(eg, red)` | Пересечение контуров `[TUT]` |

Пример станций реальных поперечников `[CODE]` Runoff:
```csharp
var sections = road.Corridor.Sections;
for (int i = 0; i < sections.Count; i++)
{
    double st = sections[i].Station;   // пикет секции
}
```

**Привязка секции — только по фактическому пикетажу** `[DECOMP][DOC]`:

- Станция-свойство у `Section` одно — `Station` (double, `internal set`). Условного
  пикетажа и координат оси на секции **нет**: ни `ConditionalStation`/`MarkStation`,
  ни `Position`/`Origin`/координат в типе `Section` (список свойств — строка выше).
- Запись пикетажа при создании секции — через `SectionList.Add(double station)`
  (пикет задаётся аргументом, а не через `Section.Station`, setter которого internal).
- Условный пикетаж (ПК+плюс) вычисляет движок из таблицы `axis.Stationing`
  (импортируется/экспортируется отдельно — «Станционирование»);
- Координаты оси поперечника (X, Y плана) движок получает из плана:
  `StaOffsetToPos` из Runoff («пикет→координаты»); на секции
  они не хранятся. Для MCP-сервера/экспорта их надо вычислять по плану
  (`Plan.CompoundLine`/вершинам плана), а не читать из `Section`.

### Поперечники — write-API (M5, `[DECOMP]` ilspycmd 14.09)

Прямая декомпиляция `Topomatic.Alg.dll` (`Topomatic.Alg.Crs`) и `Topomatic.Crs.dll`
(`Topomatic.Crs.Templates` / `Topomatic.Crs.Ast`) — те же приёмы, что в Runoff:

**Создание секций.** `SectionList.Add(double station)` — тело декомпиляции:
`new Section(null, 0, 0, station)` для BinarySearch, при отсутствии —
`Insert(~num, new Section(this, id++, 0, station))`. Возвращает **реальный индекс**
(индекс найденной секции либо позиция вставки); новая секция создаётся с
**`constructionId = 0`**. `IsExist(station)` — BinarySearch ≥ 0; `GetIndex` =
`GetIndexLess` (для несуществующего пикета — индекс последней секции «меньше»,
может быть −1). Конструктор `Section` **internal** — только `SectionList.Add`.

**Статическая земля секции.** У `Section` свойства `StaticEg`/`SectionLine` имеют
**только публичный getter** (поля-обёртки `TransactableField`); setter не публичный.
Пишем, мутируя сам `CrsLine`: `eg.BeginUpdate(); try { eg.Clear(); eg.Add(node); } finally { eg.EndUpdate(); }`.
`CrsLine : UpdatableObject` (`BeginUpdate/EndUpdate/Clear/Add/Insert/RemoveAt/Count`).
Элемент — **структура** `Topomatic.Crs.CrsLineNode` с публичными **полями**
`Offset`, `Elevation`, `Code`; ctor `(offset, elevation)` → Code=399, ctor
`(offset, elevation, code)`. В импортёре — `_write_crs_line` (тот же паттерн
set_field на boxed-структуре, что в `_write_profile_nodes`).

**`Corridor.CreateDesignContext`** — **несколько перегрузок**: `(double)`,
`(double, BuildMode)`, `(double, BuildMode, ICrsBuilderListener)`,
`(double, BuildMode, bool clipContours, ICrsBuilderListener)`. Поэтому
`GetMethod("CreateDesignContext")` бросает `AmbiguousMatchException` (ловушка —
в `_log_m5_api` перебираем перегрузки, как `invoke1` экспортёра). Также
`corridor[index]` и `corridor[index, BuildMode]` → `CrsDesignContext`.

**`CrsContainer`** (база контекста и контейнеров компонентов):
`Add(CrsComponent)`, `Insert(int, CrsComponent)`, `Remove`, `Clear`, `IndexOf`,
`FindComponent(string)`, `FindContour(int)`, статические
`Deserialize(container, AstExpression|string)` (создание элемента из AST-выражения)
и `Serialize(container, component)`.

**`CrsDesignContext : CrsContainer`** (sealed): ctors
`(ICrsParams, ICrsBuilderListener[, bool clipContours])`;
`Map` = `IDictionary<CrsComponent, ActBaseComponent>` (здесь «Map» — словарь
CrsComponent→ActBaseComponent, а НЕ контейнер компонентов — сам контекст им и
является); `InvMap`, `BuildStatus`, `Errors`, `Properties`, `Params`, `Listener`,
`ClipContours`; методы `GetEgContour()`, `GetAgContour()`, `GetRedLineContour()`,
`LinkByCode(int)`, `Elevate(double)`.

**Конструкции.** `corridor.Constructions` → `ConstructionDictionary : UpdatableObject`
(IEnumerable<KeyValuePair<uint, Construction>>): **`Add(string name, bool userDefined,
ActConstruction)` → `Construction`** (регистрация рецепта), `this[uint id]`,
`Contains(uint)`/`ContainsConstruction`, `Remove(uint)`, `CloneAndReplace`, константа
`EmptyConstructionId = 0`.

**Id конструкций — тот же механизм, что у Gridiron** `[DECOMP]` (реализация реестра
конструкций):

| Операция | Поведение счётчика ключей |
|---|---|
| Ctor | счётчик = 0; тут же регистрируется **Empty** (id = 0), счётчик → 1 |
| `Add(name, userDefined, act)` | `Id = counter++` → `dict[Id] = construction` |
| `Remove(id)` | счётчик **НЕ сбрасывает** → повторные прогоны дают растущие ключи |
| `Clear()` | счётчик = 0 + заново Empty (id 0) — **отличие от Gridiron** (у того Clear счётчик не трогает) |
| `SaveToStg` | пишет каждый ключ в атрибут Stg-узла (кроме 0) |
| `LoadFromStg` | ключи читаются из Stg и кладутся **прямо в `InnerDictionary`** (дырки сохраняются), счётчик = max+1 |

`Construction.Id` — `internal set` (записывать через рефлексию, хоть нечасто нужно);
`Section.ConstructionId` — **публичный set** (напрямую). Ключи в `.railx` сохраняются
поэлементно, при загрузке восстанавливаются → эталонные 2,3,4 — сохранённые ключи
исходной сессии, дырки от удалённых конструкций.

**Импорт рецепта из файла `.act`** — штатный путь, `[DECOMP] ilspycmd
Topomatic.Crs.dll` + asmread Topomatic.Alg.dll. Воспроизведение команд декомпиляции:

```
ilspycmd -t "Topomatic.Crs.Ast.ActConstruction"        Topomatic.Crs.dll
ilspycmd -t "Topomatic.Crs.Ast.ActComponent"           Topomatic.Crs.dll
ilspycmd -t "Topomatic.Crs.ActConstructionManager"     Topomatic.Crs.dll
ilspycmd -t "Topomatic.Alg.Crs.Construction"           Topomatic.Alg.dll
ilspycmd -t "Topomatic.Alg.Crs.ConstructionDictionary" Topomatic.Alg.dll
```

- Штатный импорт в Robur — команда контроллера `alg_project_controller.id_import_construction`
  (`Topomatic.Alg.Project.Controller.dll`, диалоги `ActApplySelectedDlg`, дерево `ActTree`);
  из плагина напрямую вызывать нельзя (правило: без ссылок на `*.Controller.dll`).
- Её ядро — **публичный XML-парсер** (статический, `ActConstruction`):
  - `public static void LoadConstruction(XmlReader reader, ActConstruction construction)`
    — разбирает корень `<ActConstruction>` **целиком**: ExistingGround/AligmentCrossing/
    Variables/Properties/Semantics/Components. В отличие от перегрузки с out-параметрами
    результат void, а блоки земля/пересечение/переменные кладутся внутрь `construction`
    (в `Properties`, см. ниже) — именно её использует импортёр `_load_act_construction`
    (2 аргумента, `[CODE] M5 шаг 3, 15.09`).
  - перегрузка с out-параметрами: `CrsContour eg` / `AdditionalInfo&` /
    `List<CrsNode> crossing` / `IDictionary<string,object> variables` — т.е. те же
    блоки земля/пересечение/переменные возвращаются явно, а не только в рецепт.
  - Обратный (сериализация) — статический `SaveConstruction(XmlWriter, …)` (перегрузки
    по набору тех же данных: `ActConstruction` + опционально eg/crossing/variables).
- Вызов через `ActConstructionManager.Instance.Load(string name)` → `ActConstruction`:
  открывает `XmlReader.Create(String.Format(шаблон, Application.StartupPath, name))` и парсит
  через `LoadConstruction`; кэширует в `Dictionary<string, ActConstruction>`.
- Корень `<ActConstruction>` и все блоки — см. описание экспорта конструкций и эталонный
  тестовый файл `.act`. **Ловушка**: блоки Cl/Eg (AlignmentCrossing/ExistingGround) и Variables
  существуют только в XML `.act` — публичного API записи их в `ActConstruction` НЕТ (parse-only);
  рецепт, собранный вручную через фабрики `ActComponent.Create*`, их не содержит → контекст
  не резолвит имена `Cl`/`Eg`/переменные («Имя не найдено Cl/Eg» в BuildStatus).
- **Подтверждение round-trip (`[CODE]`, пользователь 2026-09-15)**: `.act` нашего экспортёра
  (`model/crosssections/` в тестовом `.railx`) байт-в-байт совпадают со штатными
  (тот же AST в `<Components>` + `<ExistingGround>/<AlignmentCrossing>/<Variables>`) и
  корректно импортируются штатными средствами — при такой модели потерь данных нет.
  Импортёр группы конструкций использует `LoadConstruction(reader, act)` из `.act` первой
  секции группы: Cl/Eg/Variables попадают в рецепт автоматически, «Имя не найдено» уходит.

**Построение AST-элементов** — статические фабрики `Topomatic.Crs.Ast.ActComponent`
(`[DECOMP] asmread Topomatic.Crs.dll`, шаг 3 M5; сигнатуры точные):

```
CreatePythonConstruction(string name, string typeName) -> ActComponent     // Type=Python (эталон .act: Type="Python")
CreateConstruction(string name, string typeName[, ComponentType[, string allowed]]) -> ActComponent
CreateRay(string, AstExpression node, AstExpression x, AstExpression y) -> ActSimpleRay
CreateRay(string, string node, double x, double y) -> ActSimpleRay        // перегрузка строками
CreateNodeConstruction(string, AstExpression ray, AstExpression container[, int index]) -> ActRayContainerNode
CreateNodeContour(string, AstExpression ray, AstExpression contour[, int index]) -> ActRayContourNode
CreateContour(string, IEnumerable<AstExpression> nodes) -> ActSimpleContour
CreateVolume(string, AstExpression) -> ActSimpleVolume
CreateVolume(string, AstExpression c1, AstExpression c2, AstExpression c3) -> ActSegmentVolume
CreateVolume(string, AstExpression contour1, AstExpression contour2, bool firstUp) -> ActSectVolume
```

Полезные свойства (asmread, включая базовые): `ActSimpleRay` — `Node`/`X`/`Y`
(AstExpression), свойства `Bidirectional` НЕТ (экспортный `bidirectional` на
луче персистентно не хранится — в эталоне всегда False=дефолт); `ActRayContainerNode`
— `Ray`/`Container` (AstExpression), `Index` (int), свойства `Code` НЕТ;
`ActContour` (база `ActSimpleContour`) — `Code` (int), `IsRedLinePart`, `IsFilling`;
`ActVolume` (база `ActSectVolume`) — `Mode`, `Code` (int), `Factor` (double),
`Semantic`/`SemanticEx`. Свойства рецепт-компонентов — `ActComponent.Properties`
(PropertyList: `Add(string name, AstExpression value)`), переменные рецепта —
обычные `ActProperty` (ссылки `design_context['Cl']`, `Основная_площадка1['…']`,
пользовательские `W1` — константы/имя/индекс).

Контейнер рецепта — `ActConstruction : ActSequence` (`[DECOMP]`): ctor
`ActConstruction()` (и `(object owner)`), `Assign(ActConstruction)` (копия),
`Properties` → `ActConstructionProperties`, `Semantics` → `ActConstructionSemantics`.
`ActSequence : ActBaseComponent, ICollection<ActBaseComponent>, IList<…>`: рецепт-
компоненты добавляются `Add(ActBaseComponent)` / `Insert(index, …)`, доступны
`this[int]`, `Count`, `Clear()`, `RemoveAt`, `FindByName(string)`.
Enum `ComponentType { DotNet, Python, Rbt, Act, None }`; `CreateConstruction`
по умолчанию берёт `ComponentType.DotNet`; у `ActComponent` публичные `Type`,
`TypeName`, `AllowedComponentTypes` (settable); есть `CreatePythonConstruction`.

**Зарегистрированная конструкция** (`[DECOMP] Topomatic.Alg.dll`):
`Construction : UpdatableObject` — `Id` (uint), `Name`, `UserDefined`,
`ActConstruction` (get/set — рецепт), ctor(`ConstructionDictionary`, uint, string,
bool, ActConstruction). `ConstructionDictionary : UpdatableObject` —
`Add(string name, bool userDefined, ActConstruction) → Construction`,
`Remove(uint) → void`, `Contains(uint)`, `this[uint]`, `CloneAndReplace`,
`EmptyConstructionId = 0` (штатная пустышка `Empty` без рецепта).

**Состав рецепта — решено в пользу ПОЛНОГО рецепта (M5 шаг 3, итерация 14.09, пересмотрено 14.09 вечер).**
В экспорте `section_N.json` `components` = **built Map AST** (экспортёр собирает
`.act` из Map, не из рецепта): для конструкции id=2 — 13 элементов (5
`ActComponent` + 2 `ActSimpleRay` + 2 `ActRayContainerNode` + 2 `ActSimpleContour`
+ 2 `ActSectVolume`), для id=3 — 7 (5 + 2 `ActSimpleRay`). Эталон полной секции (тестовый файл `.act`) показывает те же 13 в `<Components>` явно (лучи
`<Ray><Initializator><Arg Name="node"/"x"/"y">`, узлы `<Node … ray/container/index>`,
контуры `<Contour><Property Name="Code">/Nodes`, объёмы `<Volume> contour1/contour2/
firstUp + Property Code`). **Вся совокупность 13 элементов — РЕЦЕПТ**
(`ActConstruction.Components`), а не только входные 5 (`_RECIPE_INPUT_TYPES`).
Лучи/узлы/контуры содержат параметры построения (направление луча, пересечение
с землёй Eg, контур привязки Code=2029) — без них `BuildTemplate` строит
неполную Map (5 вместо 13) и укороченную красную линию (3 вместо 15 точек).
`_build_recipe` записывает все 5 типов через фабрики: `CreateRay(name, node, x, y)`,
`CreateNodeConstruction(name, ray, container, index)`, `CreateContour(name, nodes)`
+ `ActContour.Code`, `CreateVolume(name, contour1, contour2, firstUp)` +
`ActVolume.Code/Factor`. Импортёр регистрирует рецепт из `_RECIPE_INPUT_TYPES`
(ActComponent + ActSectVolume + ActSimpleRay + ActRayContainerNode + ActSimpleContour)
и сверяет readback'ом: `_recipe_readback` (Count+имена рецепта) против
`_design_map_readback` (свежий `CreateDesignContext` → Map). При полном рецепте
Map содержит все 13 элементов, красная линия покрывает полную ширину конструкции.
`_build_recipe` (ручная сборка из `components` JSON) остаётся фолбеком на случай
экспорта без `.act`.

**Импортёр (с 2026-09-15) — основной путь через `.act`**: рецепт группы берётся из
`crosssections/section_N.act` первой секции группы через штатный
`ActConstruction.LoadConstruction(XmlReader, ActConstruction)` — это тот же XML-парсер,
что использует команда контроллера `id_import_construction`, поэтому блоки Cl/Eg
(AlignmentCrossing/ExistingGround) и Variables попадают в рецепт автоматически
(ручная сборка через фабрики `ActComponent.Create*` их лишена — «Имя не найдено
Cl/Eg» в BuildStatus). Подтверждено пользователем: `.act` нашего экспортёра
совпадают байт-в-байт со штатными и корректно импортируются штатными средствами.
`_build_recipe` (ручная сборка из `components` JSON) остаётся фолбеком на случай
экспорта без `.act`.

## SelectedSections — именованные наборы станций

`[DECOMP]` `Topomatic.Alg.Crs` + `[CODE]` ModelDesk (рефлексия SDK 16.0.60.11):

- `alignment.SelectedSections` → `SelectedSectionsCollection` (`UpdatableObject`) — **отдельное**
  свойство `Alignment`, НЕ часть `Corridor.Sections` (два независимых объекта).
- Коллекция: `this[string name]` → набор, `Items` → `IEnumerable<KeyValuePair<string, SelectedSections>>`,
  `Add(name)`, `Remove(name)`, `Rename(old, new)`, `IsExist(name)`, `Clear()`.
- Набор `SelectedSections`: `bool this[double station]` (флаг выбора, read+write — `false` снимает),
  `double this[int index]` (пикет, read-only), `AddSection(double)`, `Clear()`, `Count`.

```csharp
SelectedSectionsCollection coll = road.SelectedSections;
coll.BeginUpdate("…");
try
{
    foreach (KeyValuePair<string, SelectedSections> kv in coll.Items)
    {
        SelectedSections set = kv.Value;
        for (int i = 0; i < set.Count; i++) { double st = set[i]; … }
    }
}
finally { coll.EndUpdate(); }
```

## Параметры трассы (`Parameters` / `AlignmentParameters`)

`[DECOMP]` `Topomatic.Alg.Parameters.AlignmentParameters` — generic-словарь
(`IDictionary<string, T>`): `Keys`, `Values`, `this[string]`, `TryGetValue`, `ContainsKey`, `Add`, `Remove`.

`[CODE]` Runoff — один вызов читает всё по поперечнику, CRS-контекст не нужен:
```csharp
var p = road.Parameters.GetStationParams<object>(station);
// ключи: "LEFT_FLAGS"/"RIGHT_FLAGS", "DYNAMIC_LEFT_HK"/"DYNAMIC_RIGHT_HK",
//        "LOFFSX0"/"LOFFSY0"/"ROFFSX0"/"ROFFSY0" и EG-варианты
bool hasDitch = HasFlag(p, "LEFT_FLAGS");        // бит 2 = SLOPE_FLAG_USE_DITCH_PROFILE:
                                              // кювет задан профилем (не точками)
```

`AlignmentParameters` хранит и «обычные» параметры трассы — `Parameters["KEY"]`.

## Трубы (Pipes)

`[CODE]` Runoff:

- `alignment.Pipes` → `PipesCollection`: `Count` + `this[int]`.
- На реальном проекте `Pipes` часто **пуст** (проверено прогоном 2026-08-09). Трубы `.clv`
  читаются через модели `Topomatic.Culverts.Core` (рефлексия по свойству `Culvert`);
  `Prism.*CulvertPosition` — координаты **сечения**, а не плана.

## Километраж (`Kilometres` / `AlgAlignmentKilometres`)

`[DECOMP]` `Topomatic.Alg.Kilometres.AlgAlignmentKilometres` (`alignment.Kilometres`):

| Член | Тип | Примечание |
|---|---|---|
| `StartStation` | `double` | База километража: пикет 0 соответствует этому значению (эталон — 1000.0) |
| `SimpleKilometres` | `bool` | `true` = простой километраж: столбы вычисляются из пикетажа (`ToKm`/`FromKm`/`FillWholes`), явных секторов нет |
| `KilometersSector`-ы | `items[]` | При `SimpleKilometres=false` — явные сектора (`StartKm`, `StartPlus`, `EndKm`, `EndPlus`) |

- Экспорт: `model/alignment/kilometres.json` (`{type, StartStation, SimpleKilometres}`;
  `items[]` — только при явных секторах). `[CODE]` RailModelExporter `build_kilometres`.
- **Импорт: `[CODE]` `rim_import_props` (M2) → `_write_kilometres`** — перезапись
  `axis.Kilometres` по канону `LoadFromStg`/`Assign()` (декомпиляция
  `Kilometers`/`AlgExtendedKilometres`): `BeginUpdate()` → `Clear()` →
  `SimpleKilometres`/`StartStation` (публичные TransactableField-свойства) →
  сектора (`Add(KilometersSector)`). `KilometersSector` — **структура** с полями
  `StartKm(int)/StartPlus/EndKm(int)/EndPlus`, публичного ctor нет (только
  копирующий) → default через `construct(тип, [])` + поля через `set_field`.
  Канонический JSON-путь: `StartStation` в `kilometres.json` (1000.0) — база
  километража, отдельная от `alignment.json.startStation` (0.0, пикетажный сдвиг
  оси, другой член `Alignment.StartStation`).
- **Обе ветки подтверждены живым round-trip `[TEST]` (2026-09-11)**:
  простая (`StartStation=1000.0`, секторов нет) и явные сектора
  (`тестовый файл `.railx`: `StartStation=1516.17`, 4 сектора, в т.ч. широкий
  `4+0.0 – 5+0.0`) — после импорта повторный экспорт байт-в-байт
  (md5 `43f2bfca…`). Замечание: экспортёр пишет `StartKm/EndKm` в JSON как
  **double** (`1.0`), импортёр конвертирует `int()` в поля int32.

### Иерархия и публичный API (`[DECOMP]` полные тела)

`AlgAlignmentKilometres : AlgExtendedKilometres : Kilometers` (оба базовых — в
`Topomatic.Cad.Foundation.dll`, `Alg*` — в `Topomatic.Alg.dll`).

**`Kilometers`** — `UpdatableObject` + полный `IList<KilometersSector>`:

| Член | Назначение |
|---|---|
| `SimpleKilometres` (bool), `StartStation` (double) | транзактируемые свойства (обёртки `.Value`) |
| `Count`, `this[int] {get;set}`, `Add`, `Insert`, `RemoveAt`, `IndexOf`, `Contains`, `Remove`, `Clear`, `GetEnumerator` | содержимое секторов — полный `IList<KilometersSector>` |
| `ToKm(double u, out int km, out double plus, out bool forward)` | пикет → км+плюс |
| `FromKm(int km, double plus, out double u)` | км+плюс → пикет |
| `FromString(string, out double u)` | «1+516.17» (или «1» без плюса) → пикет; на мусоре `false` |
| `IsWhole(u)` / `IsChop(u)` | полный км / «резаный» пикет (бинарный поиск по внутренним проекциям секторов) |
| `FillWholes(start, end)` → `IEnumerable<double>` | пикеты целых км на диапазоне |
| `LoadFromStg`/`SaveToStg` | STG-сериализация |
| ctors: `(object owner)`, `(object owner, Kilometers)` (копирующий) | — |

Формулы простого километража из тел `ToKm`/`FromKm`:

```text
ToKm:   u = Round(u, 3);  km = (int)((StartStation + u) / 1000);
        plus = StartStation + u − km·1000;  forward = true
FromKm: u = km·1000 + plus − StartStation
```

Секторный `FromKm`: ищет сектор, у которого `StartKm == km || EndKm == km`, берёт
внутреннюю базу сектора (обфусцированный пикет) и прибавляет/вычитает `plus` по
внутреннему направлению, проверяя границы. «Привязанный к кривой» километраж
(`HasLinkedCurve()`) — все методы делегируют базовой реализации.

**`AlgExtendedKilometres`** — надстройка:

| Член | Назначение |
|---|---|
| `Assign(AlgExtendedKilometres)` | **канонический копирующий паттерн** (см. ниже) |
| `MakeDefault(double startStation, double traceLength)` | простой: только `StartStation`; секторный: один сектор `{0+0 … (int)(len/1000)+1 + 0}` |
| `Empty` (bool) | `!SimpleKilometres && Count == 0` |
| `CanMakeDefault` | всегда `true` |
| `KilometreToStation(int, double)` | км+плюс → пикет; невалидно — `ArgumentOutOfRangeException` |
| `TryKilometreToStation(int, out double)` | то же без исключения |
| `TryStationToKilometre(double, out int km)` | пикет → только номер км (через `ToKm`) |
| `CanJoin`/`CanSplit`, `Join(AlignmentJoinType, …)`, `Split(double, …)` | склейка/разрез километража |
| ctors: `(object owner)`, `(object owner, Kilometers)` | — |

`Assign()` — точный канон записи (импортёр повторяет его шаг в шаг):

```csharp
public void Assign(AlgExtendedKilometres kilometres)
{
    BeginUpdate();
    try
    {
        Clear();
        base.SimpleKilometres = kilometres.SimpleKilometres;
        base.StartStation = kilometres.StartStation;
        for (int i = 0; i < kilometres.Count; i++) Add(kilometres[i]);
    }
    finally { EndUpdate(); }
}
```

**`AlgAlignmentKilometres`** — конкретный тип `axis.Kilometres`:
`Alignment Alignment {get;}` (через `Owner is IAlignmentContainer`);
`SectLinked` работает через `alignment.Plan.CompoundLine.SectLine(...)` +
`StaOffsetToPosInfinite(...)` (см. таблицу «План»).

**`LoadFromStg` STG-семантика** (`Kilometers`): если в узле есть `StartStation` —
`SimpleKilometres` становится неявно `true` (простой километраж); иначе читаются
`SimpleKilometres`, `StartStation` и массив секторов (`KilometersSector.LoadFromStg`).
Запись идёт во внутренние коллекции (`InnerList`/`InnerValue`) — без транзакций, в
отличие от `Assign()` (транзактируемые свойства + `Add`).

**`KilometersSector`**: статические `LoadFromStg(StgNode[, defaultValue])`,
`SaveToStg(KilometersSector, StgNode)` + instance `SaveToStg`; `Equals(KilometersSector)`.

## Станционирование (`Stationing` / `AlgStationing`)

`[DECOMP]` + `[LOG]` прогон 2026-09-12 (`_log_m5_api`, тестовый `.railx`):

- `axis.Stationing` → `Topomatic.Alg.Stationing.AlgStationing` (31 сектор в эталоне).
- Методы объекта (фактический ↔ условный пикетаж, **конвертеры для MCP-сервера**):
  `StationToPk(double)`, `StationToPkDecimal`, `ToPk`, `ToPkDecimal` (фактический →
  условный ПК+плюс), обратные `PkToStation`, `FromPk`, `TryPkToStation`, а также
  строковые `StationToString`, `StringToStation`, `TryStringToStation`; сервисные
  `MakeDefault`, `FillWholes`, `SetWholeLength`, `IsWhole`, `IsChop`, `CanJoin`/
  `Join`, `CanSplit`/`Split`, `ContainsWhole`, `GetEnumerator`, коллекционные
  `Add/Insert/Remove/RemoveAt/Clear/IndexOf/Contains/CopyTo`, `Assign`,
  `BeginUpdate/EndUpdate` (UpdatableObject), свойства-геттеры `get_Stations`,
  `get_StationLength`, `get_WholeLength`, `get_Owner`/`set_Owner`.
- Сектор `StationingSector` — структура: поля `StartPk`, `StartPlus`, `EndPk`,
  `EndPlus`, `Index` (char?, буква промежуточного пикета). Фактические координаты
  границ секторов хранятся внутри объекта (в JSON экспорта не выгружаются;
  сумма условных длин секторов ≠ длине трассы — сбойные пикеты).

## Условные знаки (`ConventionalSigns`) — write-API

`[DECOMP]` ilspycmd `Topomatic.Alg.dll` (namespace `Topomatic.Alg.Signs`),
`[CODE]` импорт `_write_signs` (RailModelImporter):

- `axis.Signs` → `ConventionalSigns : UpdatableObject, IList<ConventionalSign>,
  IEnumerable<ConventionalSign>, IStgSerializable, IOwned`; `ctor(object owner)`.
  Публичные `Add(ConventionalSign)`, `Clear()`, `Remove`, `IndexOf/Insert/RemoveAt`,
  `Item[int]`, `Count`. Канон `LoadFromStg`: `new ConventionalSign(this, -1)`
  (владелец знака — **коллекция**, не ось).
- Элемент `ConventionalSign(object owner, int semanticCode)`: поля-владельцы
  `TransactableField`; записываемые свойства `Station` (double), `Elevation`
  (double), `SemanticCode` (int), `Description` (string).
  `DataHolder` (`SemanticDataHolder`) создаётся ctor; `DataSet`/`Name`
  разворачиваются из `SemanticLibrarySet.Current` по коду (read-only).
  ⚠ `IsExist` — **только чтение** (TryGetValue кода в библиотеке), сеттера нет;
  `Owner` setter бросает `NotSupportedException`.
- Импорт: перезапись `signs.Clear()` + `Add(новый знак)` внутри
  `signs.BeginUpdate()/EndUpdate()`. JSON-экспорт — generic `build_collection_json`
  (`{type, count, items[]}`).

## Рассекаемые поверхности (списки путей) — write-API

`[CODE]` импорт `_write_cutting_surfaces` (RailModelImporter),
экспорт `build_string_list` (→ `model/alignment/cutting_surfaces.json`):

- 4 свойства базового `Alignment` — `IList<string>` (`TransactableList<String>
  Topomatic.FoundationClasses.Undo`): `EgSurfaceRelativePaths` (пути поверхности
  земли), `ProfileCuttingSurfacesRelativePaths` (рассекаемые поверхности продольных
  профилей), `SectionCuttingSurfacesRelativePaths` (рассекаемые поверхности сечений),
  `AlignmentIntersectionsRelativePaths` (пересечения с другими трассами).
- **Ловушка экспорта**: generic `build_object_dict` для `List<string>` выгружает
  только `Count`/`Capacity` (строки лежат в индексаторе `Item[int]`, не в свойствах)
  → содержимое путей терялось (в round-trip повторного экспорта видно: у
  `SectionCuttingSurfacesRelativePaths` Count вырос 0→1, `AlignmentIntersections` 0→2,
  а самих путей в JSON нет). Фикс — `build_string_list`: итерация `Item[int]`.
- **Запись**: `Clear()` + `Add(строка)` внутри `axis.BeginUpdate()/EndUpdate()`
  (ось внутри импортёра-скрипта уже обёрнута). Строка читается целиком в .NET —
  `tok.ToObject(String)` — и уходит в `Add` как `System.String` (канон
  `set_jstring`/`set_typed_prop`: строки не пересекают Python-маршал).

## Параметры-таблицы (`IParameterTable`) — write-API

`[DECOMP]` ilspycmd `Topomatic.Alg.dll`, `[CODE]` импорт `_write_parameters_table`
(RailModelImporter):

- `AlignmentParameters.GetTableParameters()` → `IEnumerable<KeyValuePair<string, IParameter>>`.
- Табличные параметры (`DoubleParameter : ParameterTable<double>, IParameter<double>,
  IParameter`) реализуют `IParameterTable`: `Count`, `Add(double station, object obj)`,
  `SetValue(int index, object obj)`, `Clear()`, `Remove(double)`, `RemoveAt(int)`,
  `GetStation(i)`, `GetValue(i)`, `GetIndex(double)`.
- Публичный индексатор `DoubleParameter.this[double] {get; set;}` (реализация
  `IParameter<double>`) делает сам: `GetIndex(station) < 0 ? Add : SetValue` — канон
  записи значений на пикетах (explicit `IParameter.this[double] set` кастует в
  double и делегирует). У класса ДВА «Item» (public double + explicit object) —
  брать только `Public|Instance`, иначе `AmbiguousMatchException`.
- Импорт: `GetTableParameters()` → список KeyValuePair; имена дескрипторов
  сравниваются с ключами через `.NET-Equals` (`ToObject(String)` + `k.Equals(name)`,
  канон `jstring_equals_prop`) — `jstr`/`jval` из Python теряли первый символ
  (лог 20:24: `_LDW1`→«LDW1», «0»→«» — строки не писались, станции тихо
  съезжали: «1154.396…»→«154.396…»). Станции/значения — `jnum` (Convert.ToDouble
  на токене целиком в .NET), фолбэк пикет-записи «ПК3+45.6» через `as_text`;
  для дескрипторов с `table.rows` (JSON) — `IParameterTable.Clear()` затем
  `this[station] = value` на каждую строку. Контроль `Count` после записи.
  Формат: **два файла** — `parameters_registry.json` (СИСТЕМНЫЕ табличные +
  computed + `stationValues`-диагностика) и `parameters_user.json`
  (ПОЛЬЗОВАТЕЛЬСКИЕ табличные, `isSystem=false`; файла нет, если таких нет).
  Разделяет `split_parameters_dump` (экспортёр `dump_parameters` пишет
  полный реестр; вызов в точке записи файлов). Импортёр читает оба файла одним
  хелпером `_write_param_descriptors`, из user-файла отсутствующие создаются
  всегда; легаси-формат (одного файла) поддерживается (отсутствующие
  несистемные дескрипторы создаются whitelist'ом, см. ниже).

### Создание отсутствующих параметров (политика A, whitelist)

`GetTableParameters()` возвращает **только существующие ключи** — для свежей
импортированной модели пользовательской переменной (например, W1 «Лотки») в
реестре нет, и обычный поиск даёт `param is None`. Создание — канонической
фабрикой реестра, а не ручным ctor+Add (публичного Add для готового экземпляра
нет: словарь-коллекция внутри `AlignmentParameters` приватная):

- `AlignmentParameters.DefineParameterTable<T>(string variable, string caption,
  BehaviorType behaviorType, T defaultValue, bool overrideExisting, bool isSystem)`
  → `IParameter<T>` — `[DECOMP]` (реализация реестра параметров). Для `T=double` создаёт
  `new DoubleParameter(this, caption, behaviorType, Convert.ToDouble(defaultValue),
  isSystem)` и сам регистрирует `dictionary[variable] = value` (+ Changed);
  при `TryGetValue(variable)` и `!overrideExisting` возвращает существующий.
  Штатный Add-хелпер реестра (строка 174) вызывает её же с
  `BehaviorType.Interpolate`, `overrideExisting: false`, `isSystem: true`.
- Generic-метод из IronPython: `GetMethod(u"DefineParameterTable")` →
  `MakeGenericMethod([System.Double])` → `Invoke(registry, [variable, caption, bt,
  dflt, False, isSystem])`.
- Источники параметров вызова: `variable` и `caption` — из JSON-дескриптора
  (`ToObject(String)`; экспортёр пишет `caption` из `IParameter.Caption` —
  для W1 «Лотки»; для системных имён TRAY_HEIGHT_* подставляет
  `normalize_caption`), `T` — из `valueType` (`DoubleParameter`→`System.Double`,
  `IntegerParameter`→`System.Int32`, `BooleanParameter`→`System.Boolean`,
  `StringParameter`→`System.String`), `behaviorType` — из JSON `behaviorType`
  (имя члена после последней точки: «BehaviorType.Discrete»→«Discrete»;
  фолбэк — `Interpolate`, канон штатного Add-хелпера; enum-тип берём от
  существующего IParameterTable, namespace не хардкодим),
  `isSystem=false` (пользовательская переменная, а не системный параметр).
- Флаг интерполяции применяется **только к создаваемым (пользовательским)
  параметрам**: у существующих системных параметров импортёр BehaviorType не
  трогает (их флаг на платформе). Экспортёр пишет `behaviorType` для всех
  табличных дескрипторов (format_value enum → «BehaviorType.Interpolate»,
  `describe_parameter_pairs`, только при `table`).
- Различение системный/пользовательский — свойство `IParameterTable.IsSystem`
  (`[DECOMP]`; при загрузке stg не-системные добавляются в ту же коллекцию
  `GetTableParameters()`, строки 670+; системные заводит платформа). Отдельной
  коллекции пользовательских переменных в API НЕТ (две коллекции всего:
  табличные и вычисляемые `GetComputedParameters()`). Экспортёр пишет `isSystem`
  для всех IParameterTable-параметров (сырой bool → `true/false`).
  **Не создаём никогда:** дескрипторы с `isSystem=true` (системные → skip) и
  любые отсутствующие в новом формате (`parameters_user.json` существует →
  реестр системный, создания из него нет; создание — только из user-файла и
  легаси-registry).
- Факт по эталонному экспорту: W1 — **единственная пользовательская**
  табличная переменная (`isSystem=false`, `BehaviorType.Discrete`, 3 строки
  0→0.75 / 1150.5→1 / 1269.64→0.75, caption «Лотки»); системные —
  `_LDW1/_RDW1` Default, `TRAY_HEIGHT_RIGHT1` Discrete, E/LE/RE/O/LO/RO/B/LB/RB
  Interpolate.
- После создания значения пишутся общим путём: `Clear()` + `this[station] = value`
  (фабрика создаёт таблицу пустой, Count=0). Сквозной fail-safe в `[_format_stats]`:
  провал создания — это `errors`/`skipped`, а не исключение всей команды (в
  `stats` не заводить новых ключей — рендер знает только applied/errors/skipped/readonly;
  `stats["warnings"]` = `KeyError`, лог 22:03 прервал импорт доп. блоков).

### Диагностические блоки `values` / `stationValues` (разбор 2026-09-17)

`dump_parameters` пишет три блока; рабочий источник параметров поперечника —
`<Variables>` внутри `.act` (`render_recipe_variables_from_registry`), а блоки
ниже — **диагностика** (экспортёр сам помечает «не рабочий файл экспорта»):

- `values` — значения всех параметров на пикетах 0/600 через
  `IParameter.Item[double]` (`parameter_value_at`, C# — `ParameterValueAt`).
  **На импортированной модели индексатор не отвечает** (все `<null>`): код чтения
  в C# и Python идентичен (GetProperty("Item") → GetValue, catch → null), значит
  это состояние модели, а не экспортёра: кадры/индексы таблиц не собраны до
  расчёта, тогда как у нативной модели они есть. Данные при этом на месте —
  `stationValues` и табличные строки совпадают.
- `stationValues` — через `GetStationParams(double)` (замыкание generic по
  object/double/String/int). Сверка по эталону: **все 148 имён × 4 пикета
  (0/500/600/2000) совпадают байтово** (0 расхождений) — общий словарь станции
  работает и на импортированной модели. Рабочий блок `.act` (32/33 файла)
  совпадает тоже — round-trip параметров полный.
- **Фикс 2026-09-17:** блок `diagnostics` (найденные методы GetStationParams и
  ошибки замыкания генерик-метода) пишется **только при реальном сбое** словаря
  станции (хоть один `sp is None`); раньше он добавлялся всегда (station_params
  накапливает записи методов и на успехе) — лишний 5-й элемент в stationValues
  ломал побайтовое сравнение с канонным экспортом (4 элемента).

---

> **Ж/д специфика** (`RailAlignment`, M4 таблицы, ВСП, DynamicSurface, ReconstructionData) — в файле `rail.md` (`Topomatic.Alg.Rail.dll`).
>
> **Дорожная специфика** (`RoadAlignment`, параметры, план, поперечники) — в файле `road.md` (`Topomatic.Alg.dll` / `Topomatic.Alg.Road.dll`).



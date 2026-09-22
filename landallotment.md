# Землеустройство / межевание (Topomatic.Alg.LandAllotment)

Подсистема полосы отвода и земельных участков вдоль трассы: проектные, существующие и
временные линии границ слева/справа от оси, узлы на пикетаже, стили отображения,
слои плана и поперечников, редакторные слои.

**Статус:** `[REFL]` (asmread, метаданные SDK **16.0.62.12**) + `[DECOMP]` (ilspycmd v11.0.0.9375)
для публичных расширений доступа.
Декомпиляции — локальные (см. статусы `[DECOMP]`/`[REFL]`).

Секции доступности объектов (см. `ApiNotes/plugin.md`) не подтверждены — у подсистемы
собственные окна (`LandAllotmentConsts.LandAllotmentWindow`), сопоставление с
`Consts.PlanWindow` не проверялось.

---

## Сборки

| Сборка | Содержимое |
|---|---|
| `Topomatic.Alg.LandAllotment.dll` | Ядро: `LandAllotment`, линии, узлы, enums, стили, `ILandAllotmentContainer`, `LandAllotmentConsts` |
| `Topomatic.Alg.LandAllotment.Core.dll` | Плагин-хост `AlgLandAllotmentCorePluginHost`, GridPanel-слои (план/поперечники/пикетаж/смещения), PLT-поля, панели настроек |
| `Topomatic.Alg.LandAllotment.Layers.dll` | Слои плана и поперечников, редакторные слои, расширения доступа `AlignmentExtensions.GetLandAllotment`, стилевые расширения |
| `Topomatic.Alg.LandAllotment.Controller.dll` | Плагин-хост `AlgLandAllotmentControllerPluginHost`, диалоги (план ЧЗ, свойства вершины, заполнение) |

Ссылки главной сборки: только `Topomatic.Alg`, `Topomatic.Cad.Foundation`, `Topomatic.Crs`,
`Topomatic.FoundationClasses`, `Topomatic.Stg` (все 16.0.62.12), mscorlib 2.0.
Связи с Rail/Road нет — подсистема работает с базовым `Alignment`.

---

## Доступ к межеванию

### Способ 1 — публичное расширение `[DECOMP]`

`Topomatic.Alg.LandAllotment.Layers.AlignmentExtensions` `[DECOMP]`:

```csharp
using Topomatic.Alg.LandAllotment.Layers;

var alignment = ...;            // активная ось (ActiveAlignmentReciver<Alignment>)
LandAllotment la = alignment.GetLandAllotment();   // null, если межевание не создано
```

Реализация: `alignment.Plugins.TryGetValue(обфусцированный_ключ, out value)` →
`value is ILandAllotmentContainer c` → `c.LandAllotment`. Строковый ключ плагина в
метаданных зашифрован (не восстанавливается asmread/IL-дампом), но публичное расширение
инкапсулирует его — это канонический путь.

### Способ 2 — интерфейс `ILandAllotmentContainer` `[REFL]`

```csharp
public interface ILandAllotmentContainer
{
    LandAllotment LandAllotment { get; }
}
```

Любой элемент, реализующий интерфейс (сам `LandAllotment` реализует его явно), отдаёт
ядро межевания. Паттерн тот же, что у `IGridironContainer` для стрелочных переводов
(см. `turnouts.md`).

---

## Иерархия классов (подтверждена `[REFL]`)

```
UndoObject
└── LandAllotment                      (ядро межевания, IOwned, ILandAllotmentContainer)
    ├── Lines: Left/Right × Design/Existent/Temp + Left/Right DesignCrs
    └── Style (LandAllotmentStyle)
        └── LandAllotmentLinesStyle ×3 (Design / Temp / Existent)

UpdatableObject
└── LandAllotmentNode                  (узел линии: пикет/смещение/угол/позиция)

UndoObject
└── LandAllotmentLine : IList<LandAllotmentNode>, IOwned, IStgContextSerializable
    ├── DesignLandAllotmentLine        (Type → LandAllotmentLineType.Design)
    ├── ExistentLandAllotmentLine      (Type → Existent)
    ├── TempLandAllotmentLine          (Type → Temporary)
    └── CrsBoundsLandAllotmentLine     (граница поперечника; TransactionManager)
```

---

## Ядро `LandAllotment` `[REFL]`

Наследник `UndoObject`, реализует `IOwned` + `ILandAllotmentContainer`.
Создание: `ctor(Owner: object)`.

| Член | Тип | Назначение |
|---|---|---|
| `LeftDesignLine` / `RightDesignLine` | `DesignLandAllotmentLine` | Проектные линии границ |
| `LeftExistentLine` / `RightExistentLine` | `ExistentLandAllotmentLine` | Существующие линии |
| `LeftTempLine` / `RightTempLine` | `TempLandAllotmentLine` | Временные линии |
| `LeftDesignCrsLine` / `RightDesignCrsLine` | `LandAllotmentLine` | Границы поперечников |
| `Style` | `LandAllotmentStyle` | Стиль межевания |
| `EditedItems` | `BasicEditedItemsTable` | Таблица редактируемых элементов |
| `Owner` | `object` | Владелец (IOwned) |
| `Clear()` / `LoadFromStg(StgNode)` / `SaveToStg(StgNode)` | — | Очистка, Stg-сериализация |

Оси у ядра нет: `Alignment` отсутствует на `LandAllotment` — ось доступна через
`LandAllotmentLine.Alignment` (см. ниже).

## Линии `LandAllotmentLine` `[REFL]`

Коллекция узлов (`IList<LandAllotmentNode>`): `Count`, `Item[int]`, `Add/Insert/RemoveAt/Clear`.

| Член | Тип | Назначение |
|---|---|---|
| `ctor(Owner, LandAllotmentLineSide, LandAllotmentLinesStyle)` | — | Создание линии с привязкой к владельцу |
| `Type` | `LandAllotmentLineType` | Вид линии (Design/Existent/Temporary/Auxilary) |
| `Side` | `LandAllotmentLineSide` | Сторона (Left/Right) |
| `Style` | `LandAllotmentLinesStyle` | Стиль линии |
| `LandAllotment` | `LandAllotment` | Ядро межевания (владелец) |
| `Alignment` | `Topomatic.Alg.Alignment` | **Привязанная ось** — основной доступ к оси от линии |
| `Owner` | `object` | Владелец (IOwned) |
| `LoadFromStg` / `SaveToStg` | — | Stg-сериализация |

Подклассы `DesignLandAllotmentLine`/`ExistentLandAllotmentLine`/`TempLandAllotmentLine`
отличаются только переопределённым `Type`. `CrsBoundsLandAllotmentLine` дополнительно
отдаёт `TransactionManager` (`ITransactionManager`).

## Узел `LandAllotmentNode` `[REFL]`

Наследник `UpdatableObject` — изменения через `BeginUpdate()`/`EndUpdate()`.
Создание: `ctor(LandAllotmentLine)` — узел сразу привязан к линии.

| Член | Тип | Назначение |
|---|---|---|
| `Line` | `LandAllotmentLine` | Линия-владелец |
| `Station` | `double` | Пикетаж (get/set) |
| `Offset` | `double` | Смещение от оси (get/set) |
| `Pos` | `Vector2D` | Точка в плане (get) |
| `Angle` | `double` | Угол (get) |
| `Valid` | `bool` | Валидность узла (get/set) |
| `OsnExtra` / `OsnCurveExtra` / `CurveExtra` | `bool` | Флаги доп. точек (get/set) |
| `OsnCurveSegmentFactor` | `double` | Коэффициент сегмента кривой (get/set) |
| `Owner` | `object` | Владелец (IOwned) |
| `LoadFromStg` / `SaveToStg` | — | Stg-сериализация |

## Enums `[REFL]`

```csharp
enum LandAllotmentLineType { Design, Existent, Temporary, Auxilary }
enum LandAllotmentLineSide  { Left, Right }
```

---

## Стили `Topomatic.Alg.LandAllotment.Style` `[REFL]`

```
UndoObject
└── LandAllotmentStyleItem                 (база, IOwned, Stg)
    ├── LandAllotmentLayerStyleItem        (+ StandardName)
    │   ├── LandAllotmentLinesStyle        (стиль линии)
    │   ├── LandAllotmentLineEditorStyle   (стиль редактора, TextStandard/ShowLines)
    │   └── LandAllotmentLineCrossSectionStyle
    └── LandAllotmentStyle                 (стиль межевания в целом)
```

| Тип | Ключевые члены |
|---|---|
| `LandAllotmentStyle` | `DesignLinesStyle`/`TempLinesStyle`/`ExistentLinesStyle` (по `LandAllotmentLinesStyle`), `DesignOffset`/`TempOffset`/`ExistentOffset` (double), `ExistentCodes` (string), `CurveSplitSegment`, `LayerStyles` (IEnumerable), `ctor(LandAllotment)` |
| `LandAllotmentLinesStyle` | `Color`/`MarkersColor` (CadColor), `ShowMarkers`/`ShowVertexCoords`/`VertexCoordsExtLine` (bool), `MarkersPrefix`/`MarkersBlockName`/`VertexCoordsBlockName`/`LeftLineTitle`/`RightLineTitle` (string), `EditorStyle`, `CrossSectionStyle`, Default-* пресеты, `ctor(LandAllotmentStyle, string, bool)` |
| `LandAllotmentLineEditorStyle` | `ShowLines` (bool), `TextStandard` (string), `ctor(LandAllotmentLinesStyle, bool)` |

### Расширения слоёв `[DECOMP]`

`Topomatic.Alg.LandAllotment.Layers.LandAllotmentStyleExtensions` `[DECOMP]`:

```csharp
using Topomatic.Alg.LandAllotment.Layers;

DwgLayer layer = style.GetLayer();      // DwgLayer по StandardName (слои владельца)
bool vis = style.GetVisible();
style.SetVisible(true);
bool en  = style.GetEnable();
style.SetEnable(true);
CadColor c = style.GetColor();          // ?? CadColor.White
```

Слой ищется по цепочке владельцев (`IOwned.Owner` → `ILayerLinksContainer.LayerLinks`
→ `GetLayer(StandardName)`).

---

## Слои и контроллер

### `Topomatic.Alg.LandAllotment.Layers.dll` `[REFL]`

| Тип | Базовый класс | Назначение |
|---|---|---|
| `LandAllotmentPlanLayer` | `AlgLayer` | Слой плана межевания |
| `LandAllotmentCrsLayer` | `AlgBaseCrossSectionLayer` | Слой поперечников |
| `LandAllotmentEditorLayer` | `AlgLayer` | База редакторных слоёв |
| `LandAllotmentEditorDesignLinesLayer` / `ExistentLinesLayer` / `TempLinesLayer` / `SectLinesLayer` / `AuxilaryLayer` | `LandAllotmentEditorLayer`/`AlgLayer` | Редакторы линий |
| `LandAllotmentEditorCompoundLayer` | `AlgCompoundLayer` | Составной редакторный слой |
| `LandAllotmentSignDrawer` | `object` | Отрисовка подписей |
| `EditableItems.LandAllotmentEiController` (+ Exist/Design/Temp) | `AlgEditableItemsController` | Контроллеры редактируемых элементов; `LandAllotment`/`Drawing`/`Style` |
| `EditableItems.LandAllotmentEiDrawer` | `EditableItemsDrawer` | Отрисовка редактируемых элементов |

### `Topomatic.Alg.LandAllotment.Core.dll` `[REFL]`

GridPanel-слои (наследники `SimpleGridPanelLayer`/`SimpleGridPanelManager`):
`LandAllotmentGridPlanLayer`, `LandAllotmentGridStationingLayer` (пикетаж),
`LandAllotmentGridCrossSectionsLayer` (поперечники), `LandAllotmentGridOffsetsLayer`
(+ `LandAllotmentGridDesignOffsetsLayer` / `LandAllotmentGridExistentOffsetsLayer`).

### `Topomatic.Alg.LandAllotment.Controller.dll` `[REFL]`

| Тип | Базовый класс | Назначение |
|---|---|---|
| `Dialogs.LandAllotmentPlanDwgDlg` | `SimpleDlg` | Экспорт плана (Аlias/Scale) |
| `Dialogs.VertexPropsDlg` | `SimpleDlg` | Свойства вершины (Sta/Offset/Alignment) |
| `Dialogs.FillLandAllotmentDlg` | `SimpleDlg` | Автозаполнение (диапазон/целиком, Left/Right, смещения) |

---

## Постоянные `LandAllotmentConsts` `[REFL]`

```csharp
public static class LandAllotmentConsts
{
    // строковые константы (значения обфусцированы в метаданных):
    public static readonly string LandAllotmentWindow;   // идентификатор окна
    public static readonly string PluginID;              // идентификатор плагина
}
```

---

## Ловушки

- **Оси на `LandAllotment` нет** — берите `LandAllotmentLine.Alignment` (тип
  `Topomatic.Alg.Alignment`, работает и для Road, и для Rail).
- **Ключ плагина в `alignment.Plugins` обфусцирован** — не восстанавливайте его из
  метаданных; используйте публичное расширение `alignment.GetLandAllotment()`.
- **`GetLandAllotment()` возвращает `null`**, если межевание не создано у оси — проверяйте.
- **Узлы — объекты, не структуры**: правка `Station`/`Offset` возможна напрямую, но
  оберните в `BeginUpdate()/EndUpdate()` (наследник `UpdatableObject`).
- **Создание с нуля**: `new LandAllotment(owner)` → конструкторы линий
  `new DesignLandAllotmentLine(owner, side, style)` → `line.Add(new LandAllotmentNode(line))`.
  Подтверждённых боевых примеров создания/записи пока нет (`[REFL]`), сигнатуры —
  от asmread.

---

## Новый механизм — модуль `Topomatic.Borderline` (замена LandAllotment, 16.0.62) `[DECOMP]`

**Статус:** `[DECOMP]`/`[REFL]` — локальные IL-дампы `monodis` сборок 16.0.62.12
(`Development/Out/Bin/Topomatic.Borderline.dll` / `.Core.dll` / `.Controller.dll`).
Механизм **отсутствует в справке и в 16.50** — появляется только в 16.0.62.

### Суть

В новых версиях межевание/полоса отвода = сущности **`DwgBorderline`** («границы») в
чертеже модели (`Drawing.ActiveSpace`). Слов «LandAllotment»/«otvod» в метаданных
`Topomatic.Borderline.dll` нет — это отдельный модуль, заменивший
`Topomatic.Alg.LandAllotment`.

| Сборка | Содержимое |
|---|---|
| `Topomatic.Borderline.dll` | `Entities.DwgBorderline`, `BorderlineGeometryData`, `BorderlineNodeOffset(s)`, `BorderlineLinks`/`BorderlineLink`, `BoundaryResolvers` (`BoundaryResolver`/`AreaBoundaryResolver`/`OffsetBoundaryResolver`), `BorderlineTriangulation`, `DwgBorderlineController`, `DwgBorderlineCommunication` |
| `Topomatic.Borderline.Core.dll` | `CoreModule` — обход моделей проекта и чтение границ (канонический путь, см. ниже) |
| `Topomatic.Borderline.Controller.dll` | Контроллеры/взаимодействие |
| `borderline_*.plugin` | Манифесты модуля |

### Сущность `DwgBorderline` `[DECOMP]`/`[REFL]`

Наследник `DwgEntity`; `ENTITY_NAME = "Topomatic.Dwg.Entities.DwgBorderline"`.

| Член | Тип | Назначение |
|---|---|---|
| `Links` | `BorderlineLinks` | Привязки границы (список `BorderlineLink`) |
| `GeometryData` | `BorderlineGeometryData` | Геометрия границ (см. ниже) |
| `Area` | `double` | Площадь |
| `Caption` | `string` | Подпись |
| `NodesContent` | `string` | Содержимое узлов (подпись) |
| `ShowOnCrs` / `ShowFilling` | `bool` | Показ на поперечниках / заливка |
| `ToRotateCaptions` / `Annotative` | `bool` | Поворот подписей / аннотативность |
| `IsEditable` / `IsReadOnly` | `bool` | Редактируемость |
| `ApproximationPrecision` / `Height` | `double` | Точность аппроксимации / высота |

### `BorderlineGeometryData` `[DECOMP]`/`[REFL]`

| Член | Тип | Назначение |
|---|---|---|
| `Owner` | `DwgBorderline` | Владелец (IOwned) |
| `Pivot` | `Vector2D` | Опорная точка |
| `VisibleBoundaries` | `List<Vector2D[]>` | **Видимые границы**: каждая граница — массив точек (полилиния) |
| `VisibleTrianglesVertices` | `Vector2F[]` | Вершины видимой триангуляции |
| `NodeOffsets` | `BorderlineNodeOffsets` | Смещения узлов по границам |
| `Numeration` | `Dictionary<int,int>` | Нумерация |
| `Area` | `double` | Площадь |
| `IsEditable` / `IsInvalid` | `bool` | Флаги |

`BorderlineNodeOffsets` — `Count`/`Item[int]` → `BorderlineNodeOffset`; элемент —
**структура**: `BoundaryIndex` (int), `NodeIndex` (int), `Offset` (`Vector2D`), `Rotation` (double).

### Канонический путь доступа (по `CoreModule` `[DECOMP]`)

```csharp
var project = ApplicationHost.Current.ActiveProject as ModelProject; // null → нет
foreach (var pair in project.GetOpenedModels())                      // KVP<IProjectModel, IEditorResult>
{
    var model = pair.Key.Model;                                       // объект модели
    if (!(model is IDrawingContainer dc)) continue;
    foreach (DwgEntity e in dc.Drawing.ActiveSpace)                   // активное пространство
    {
        if (e is DwgBorderline b && b.GeometryData != null)
        {
            var boundaries = b.GeometryData.VisibleBoundaries;        // List<Vector2D[]>
        }
    }
}
```

Из оси (как в экспортёре): цепочка `axis.Owner` → `IDrawingContainer` → `Drawing`
→ `ActiveSpace`; сущность распознаётся по имени типа `"DwgBorderline"` (сборка
`Topomatic.Borderline`). Read-only, Undo/redo не нужен.

### Запись `DwgBorderline` (write-API, импортёр) `[DECOMP]`

Подтверждено `monodis` на `Topomatic.Borderline.dll` 16.0.62.12 (импортёр
`rim_commands._write_borderline`):

| Шаг | API | Комментарий |
|---|---|---|
| Создание | `new DwgBorderline()` | **public** `.ctor()`; `GeometryData`/`Links` — get-only, создаются в ctor |
| Writable-поля | `Caption`, `ShowOnCrs`, `ApproximationPrecision`, `ShowFilling`, `Annotative`, `ToRotateCaptions`, `Height`, `BackgroundColor/FillType`, `NodesContent`, `Style` | обычные сеттеры |
| Геометрия | см. ниже «Запись геометрии» | `VisibleBoundaries` — **производная** (резолвится из `Links`); `AddVertex` — no-op при пустом backing; рабочий путь — приватные поля-кэши |
| Вставка в чертёж | `drawing.ActiveSpace.Entities.Add(ent)` | канон `ApiNotes/dwg.md`; `Entities` — коллекция с `Count/Item/Add` |

Привязка к оси (`Links` → `AlignmentBorderlineLink` из
`Topomatic.Borderline.Controller.dll`, фабрика `BorderlineLinkFactory` по объекту)
записывает `LinkData` (ModelUID, LOffset/ROffset, FromSta/ToSta…) — экспортёр её
в JSON не пишет, импортёр восстанавливает только геометрию (симметрия; без Links
резолвер геометрию не пересчитывает — это константный кэш).

#### Запись геометрии — приватные поля-кэши `BorderlineGeometryData` `[DECOMP]`

`VisibleBoundaries` — **производная геометрия**: getter при пустом backing вызывает
резолвер (`AlignmentBoundaryResolver.GetBoundaries`), который строит полигон из
`Links` оси (`link.get_CachedLinkedObject() isinst Topomatic.Alg.Alignment`); у
свежей сущности `Links.Count == 0` → резолвер молча возвращает null → границ нет.
`AddVertex(boundaryIndex, insertIndex, Vector2D)` при пустом backing — no-op
(требует уже существующих подмассивов + лицензионный gate 44 с возвратом без
работы). `Invalidate()` стирает backing при `!IsEditable`.

Поэтому геометрия пишется **напрямую в приватные поля по ТИПУ** (имена
обфусцированы; `fields_of_type(obj, type)` ищет по точному типу):

| Поле/свойство | Тип | Что пишем |
|---|---|---|
| (поле, 1-е) | `List<Vector2D[]>` | кэш `VisibleBoundaries`: контуры из JSON как есть (5 точек, включая замыкающую) |
| (поле, 2-е) | `Vector2F[]` | триангуляция: веер из первой точки, координаты **`f32(p − pivot)`** — по ней `get_Area` считает площадь |
| `Pivot` (свойство) | `Vector2D` | первая точка первого контура |
| `IsEditable` (свойство) | `bool` | **true** — защита backing от `Invalidate()` |
| `IsInvalid` (свойство) | `bool` | **false** — иначе getter сам вызовет `Invalidate()` |

`SaveToStg` сериализует ровно эти кэши (IsEditable, Pivot, VisibleBoundaries,
Vector2F[]-трис, нумерация, NodeOffsets), `LoadFromStg` восстанавливает —
round-trip сохраняется. Площадь в файл НЕ пишется: `get_Area` = сумма
`TriangleArea(Vector2F-трис)` — для контура 53.railx (5 точек, веер из p0,
`f32(p − p0)`) это в точности `791.7788282785233` (= `791.77882827852329`
в JSON), сверино численно. Double-шолос полигона НЕ совпадает
(791.7788464449523) — трис обязательны для совпадения area.

Пример (IronPython, паттерн импортёра):

```python
ent = rim_reflection.construct(b_type, [])            # DwgBorderline()
rim_reflection.set_prop(ent, u"Caption", caption)
rim_reflection.set_prop(ent, u"ShowOnCrs", True)
gd = rim_reflection.read(ent, u"GeometryData")
gd.BeginUpdate()
try:
    list_t = System.Type.GetType(u"System.Collections.Generic.List`1").MakeGenericType(v2_type.MakeArrayType())
    backing = System.Activator.CreateInstance(list_t)
    for pts in per_b:                                  # per_b: [[(x, y), ...], ...]
        arr = System.Array.CreateInstance(v2_type, len(pts))
        for k, (x, y) in enumerate(pts):
            v = rim_reflection.construct(v2_type, [])
            rim_reflection.set_field(v, u"X", x); rim_reflection.set_field(v, u"Y", y)
            arr.SetValue(v, k)
        backing.Add(arr)
    gd_fields = rim_reflection.fields_of_type(gd, list_t)
    rim_reflection.set_private_field(gd, gd_fields[0][0], backing)
    # Pivot (первая точка), IsEditable=true, IsInvalid=false, Vector2F[]-веер (см. rim_commands)
finally:
    gd.EndUpdate()
entities = rim_reflection.read(active_space, u"Entities")
entities.Add(ent)
```

Перед добавлением импортёр удаляет существующие `DwgBorderline` из
`ActiveSpace.Entities` (замена блока, как `Clear()+Add()` у legacy-линий) —
иначе повторный импорт дублирует зоны.

### Stg-совместимость (данные старого формата)

В `.railx` 16.0.62 межевание может храниться **двумя путями**:

- **legacy-дерево** `Topomatic.Alg.LandAllotment` (золотой `Export_Rail10/3.railx`):
  дочерние узлы оси `design_land_allotment` / `temp_land_allotment` /
  `existent_land_allotment`; атрибуты узла `Landallotment`, `DesignLinesStyle`,
  `EditorStyle`, `MarkersColor`, `ShowMarkers`, `ShowVertexCoords`, `TempLinesStyle`,
  `ShowLines`, `ExistentLinesStyle` (стили старого межевания);
- **сущности `DwgBorderline` в чертеже** (проверено на `Dop/53.railx` —
  `Situation/Blocks[*]/Entities[*]`): зона отвода, созданная через НОВЫЙ UI
  «Полоса отвода», попадает в railx именно так; легasi-плагин оси при этом в
  рантайме НЕ регистрируется (`axis.Plugins.Count = 7` без LandAllotment) —
  экспортёр идёт по Borderline-ветке (`build_borderline_from_drawing`).

Форма Borderline-JSON экспортёра: `type/category/source:"Borderline"/count/borderlines[]`
(каждая: `caption`, `area`, `showOnCrs`, `boundaryCount`, `boundaries[][][x,y]`,
`nodeOffsets[]`). `Links.LinkData` (LOffset/ROffset, FromSta/ToSta, ModelUID…)
экспортёр НЕ пишет — при импорте восстанавливается только геометрия полигона.

### Ловушки

- В headless-экспорте легаси-плагин межевания в `axis.Plugins` может НЕ
  регистрироваться: на модели `3.railx` реально читаются 7 ключей — `Gridiron`,
  `ReferenceTransition`, `WaterLinePlugin`, `ProfileEntities`, `Its`, `GradeSign`,
  `Straightening`; ни один не реализует `ILandAllotmentContainer` → штатный
  `GetLandAllotment()` даёт `null`, хотя данные межевания в модели есть.
- `DwgBorderline` доступны только если чертёж модели материализован (в
  интерактивной сессии — да; в полностью головном прогоне — проверяется, см.
  `land_allotment_debug.txt`).
- `Topomatic.Pipes.Runtime.LandAllotmentZone` (`sealed DwgEntity`,
  `DesignAlias = "LAND_ALLOTMENT_ZONE"`, контроллер `LandAllotmentZoneController`) —
  отдельный след «зон полосы отвода» для труб (поля: `Axis`
  (`List<ContourInfo.LineInfo>`), `OffsetRight/Left/Forward/Backward`, `Contours`/
  `TrimContours` (`List<List<Vector2D>>`), `PlanSignName`, `Area`,
  `SimpleOrComplexZone`, `ArcPrepareType`, `HeightChord`, `StepLength`);
  `ContourInfo.InfoType.LandAllotmentZone = 4`. Не является линией межевания оси.
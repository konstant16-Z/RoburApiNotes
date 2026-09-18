# Землеустройство / межевание (Topomatic.Alg.LandAllotment)

Подсистема полосы отвода и земельных участков вдоль трассы: проектные, существующие и
временные линии границ слева/справа от оси, узлы на пикетаже, стили отображения,
слои плана и поперечников, редакторные слои.

**Статус:** `[REFL]` (asmread, метаданные SDK **16.0.62.12**) + `[DECOMP]` (ilspycmd v11.0.0.9375)
для публичных расширений доступа.
Декомпиляции — в `Tools/Decomp/Topomatic.Alg.LandAllotment.Layers.*.cs`.

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

`Topomatic.Alg.LandAllotment.Layers.AlignmentExtensions` (`Tools/Decomp/Topomatic.Alg.LandAllotment.Layers.AlignmentExtensions.cs`):

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

`Topomatic.Alg.LandAllotment.Layers.LandAllotmentStyleExtensions`
(`Tools/Decomp/Topomatic.Alg.LandAllotment.Layers.LandAllotmentStyleExtensions.cs`):

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
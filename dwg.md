# ApiNotes — Чертёж (Topomatic.Dwg): модель, сущности, запись DXF/DWG

База `[TUT]` (tutorial6), дополнена `[CODE]` (DxfExport — конвертеры сущностей,
запись DXF/DWG через ACadSharp; DemLoader/Runoff) и `[DECOMP]` (Topomatic.Dwg.Controller
— окно чертежа, форматы .dwr/.dwg/.dxf; BlockEditor — правка блоков).

## Сборки

| Сборка | Что содержит |
|---|---|
| `Topomatic.Dwg.dll` | `Drawing`, `DwgBlock`, сущности (`DwgLine`, `DwgArc`, `DwgPolyline`, `DwgText`, `DwgInsert`, …) |
| `Topomatic.Dwg.Layer.dll` | `DrawingLayer` |
| `Topomatic.Tables.Export.dll` | `DwgTable`, `DwgTableCell` — **в основной `Dwg.dll` их нет** |

## Доступ

| API | Назначение | Статус |
|---|---|---|
| `DrawingLayer.GetDrawingLayer(cadView)`, `layer.Drawing` | Слой и чертёж | `[TUT]` |
| `DrawingLayer.GetDrawingLayer(cadView, readOnly)` | 2-арг. перегрузка: `false` — рабочее чтение, `true` — поиск слоя без прав | `[DECOMP]` Topomatic.Dwg.Controller (Class35/38) |
| `Drawing.ActiveDocument` | Текущий открытый чертёж (статическое свойство) | `[CODE]` DxfExport |
| `drawing.ActiveSpace` | Текущее пространство (Model или Layout) | `[TUT]` |
| `drawing.BeginUpdate()/EndUpdate()` | Групповое изменение чертежа (парное, в `try/finally`) | `[TUT]` |

## Окно чертежа в плагине (без загрязнения дерева проекта)

Эталон — `[cmd("open_dwg_cmp")]` из `Topomatic.Dwg.Controller` (`Class38`). Окно
создаётся в памяти проекта (`Project.AddDocumentWindow`), **не** через сохранение
в проект + `mkitem`/`open`. `[DECOMP]`

```csharp
var project = ApplicationHost.Current.ActiveProject;
string key = "DWG_BLOCK_EDIT_" + Guid.NewGuid().ToString("N");
var window = project.AddDocumentWindow(key, "DWG_BLOCK_EDIT", false) as IFramableDocumentWindow;
window.Text = "Редактор: " + blockName;
if (!window.Contains(Consts.ModelFrame))
    window.AddCadViewFrame(Consts.ModelFrame, "Модель");        // (key, заголовок)
var frame = window[Consts.ModelFrame];                          // IDocumentWindowFrame
var layer = DrawingLayer.GetDrawingLayer(frame.CadView, true);  // поиск; null — создать
if (layer == null)
{
    layer = new DrawingLayer();
    layer.Enable = true;      // true — редактируемое окно; false — только просмотр (compare)
    frame.CadView.AddLayer(layer);
}
layer.Drawing = drawing;
frame.CadView.SolveLimits(false);
frame.CadView.Unlock();
frame.CadView.Invalidate();
window.Activate();
```

- `IDocumentWindow`: `Text`, `Activate()`, `Close()`, `Close(FormClosingEventArgs)`,
  **`event FormClosing`** — «дождаться правок»: правки штатных команд чертежа пишутся
  напрямую в `layer.Drawing` (DwgController мутирует активный чертёж окна), а по
  закрытию окна подписчик применяет изменения; `e.Cancel = true` — отмена закрытия.
  Сигнатуры — метаданные SDK 16.0.62.x. `[DECOMP]`
- `IFramableDocumentWindow`: `AddCadViewFrame(key, title)`, `Contains(key)`, индексатор `[key]`.
  `[DECOMP]`
- Команды чертежа в таком окне работают: `ValidateWindow` требует
  `window is ICadViewForm { CadView: { } }` + `DrawingLayer.GetDrawingLayer(cadView, false) != null`.
  `[DECOMP]`

## Листы (Layouts)

| API | Назначение | Статус |
|---|---|---|
| `drawing.Layouts` → `DwgLayouts : Collection<DwgLayout>` | Все пространства документа; `Layouts[0]` — всегда `"Model"` (Model Space) | `[CODE]` DxfExport |
| `layout.Name` / `layout.Block` | Имя листа; `Block` (`DwgBlock`) — сущности paper space листа | `[CODE]` |
| `DwgViewport` | Окно просмотра Model→Layout; **пропускается** при экспорте (служебная) | `[CODE]` |

```csharp
var drawing = Drawing.ActiveDocument;
int totalSpaces = drawing.Layouts.Count;      // включая Model
foreach (DwgLayout layout in drawing.Layouts)
{
    if (layout.Name == "Model") continue;     // Model Space пропускаем
    foreach (DwgEntity entity in layout.Block) { /* сущности листа */ }
}
```

⚠️ Координаты сущностей на листе — в «миллиметрах листа» (0,0 — левый нижний угол
страницы), а не в координатах модели. Масштаб определяется `DwgViewport.ZoomFactor` /
`DwgViewport.ViewHeight`.

## Сущности: проверенные свойства

| Robur класс | Проверенные свойства | Статус |
|---|---|---|
| `DwgLine` | `Start[2]`, `End[2]` | `[CODE]` DxfExport |
| `DwgCircle` | `Center[2]`, `Radius` | `[CODE]` |
| `DwgArc` | `Center[2]`, `Radius`, `StartAngle`, `EndAngle` | `[CODE]` |
| `DwgPolyline` | `IEnumerable<BugleVector2D>` — у элемента поля `.Vertex.X/.Y`, `.Bugle`; `.Closed`; **свойства `Vertices` НЕТ** (перебор + `ConvertToPosArray` для выборки) | `[CODE]` DxfExport, DemLoader |
| `DwgPolyline3D` | 3D-аналог полилинии | `[CODE]` |
| `DwgText` / `DwgMText` | `Position[2]`, `Value`, `Height`, `Rotation`, `FontName` | `[CODE]` DxfExport |
| `DwgInsert` | `Block` (у вставки без блока **null или бросает** — оборачивать try/catch), `Block.Name`, `XScaleFactor/YScaleFactor/ZScaleFactor`, `Rotation` (рад), `Matrix` | `[CODE]` DxfExport |
| `DwgEllipse` | `MajorAxe` — **опечатка API** (вектор центр→конец большой оси), `MinorRatio`, `StartAngle/EndAngle` (рад) | `[CODE]` DxfExport |
| `DwgSpline` | `Count` + `e[i]` → `Vector3D` | `[CODE]` |
| `DwgWipeout` | `Count` + `e[i]` → `Vector2D` | `[CODE]` |
| `DwgHatch` | Только метаданные паттерна; геометрия не разворачивается | `[CODE]` |
| `DwgPoint` | Пропуск при экспорте | `[CODE]` |
| `DwgDimension*` / `DwgCoordinateLeader` / `DwgLeader` / `MapsLeaderEntity` | Комплексные сущности. `DwgDimension*` — свои конвертеры (DIMENSION); `DwgCoordinateLeader` и наследники (`DwgLeader`, картографические `MapsLeaderEntity`) — **не разворачиваются в детей**, пишутся как LEADER/MLEADER | `[CODE]` DxfExport |
| `DwgTable` | `Topomatic.Tables.Export.dll`; `DefaultRowHeight` — **Int32**, не double | `[CODE]` |
| `DwgViewport` | Пропуск (служебная) | `[CODE]` |

Базовые свойства любой сущности: `entity.Layer?.Name`, `entity.Color` (→ `CadColor`),
`entity.Linetype?.Name` — всегда проверять на null (см. резолв контекста ниже).

## Цвет (`CadColor`) и резолв ByLayer/ByBlock

`CadColor` — структура (`Topomatic.Cad.Foundation`):

| API | Назначение | Статус |
|---|---|---|
| `color.ColorIndex` → int | Индекс ACI; `>= 0` — конкретный цвет | `[CODE]` DxfExport |
| `CadColor.ByLayerIndex` / `CadColor.ByBlockIndex` | Маркеры наследования (в DXF/DWG: 256 / 0) | `[CODE]` |
| `color.ToIndexColor()` | RGB-цвет → ближайший ACI | `[CODE]` |
| `color.Win32Color` → `System.Drawing.Color` | Истинный цвет (R/G/B) для TrueColor | `[CODE]` |

Резолв контекста сущности (паттерн `EffectiveContext.Resolve(entity, parent)`, `[CODE]`):

- слой: `entity.Layer?.Name` → иначе родительский → иначе `"0"`;
- цвет: `ByLayer/ByBlock` → **унаследовать от родителя** (иначе сохранить `ColorIndex`);
  RGB → `ToIndexColor()` для ACI + `Win32Color` для TrueColor-строки `#RRGGBB`;
- тип линии: аналогично наследуется через `entity.Linetype?.Name`.

## Матрица вставки

`[CODE]` DxfExport:

```
DwgInsert.Matrix : Topomatic.Cad.Foundation.Matrix  (struct, Double M11..M44)
        ▼ поэлементное приведение к float
System.Numerics.Matrix4x4  (Float M11..M44)   → стек трансформаций WCS = Parent × Insert
```

У вставок-маркеров `Position` часто `(0,0,0)` — тогда позицию брать из `Matrix`
(`M41..M43`).

## Блоки

| API | Назначение | Статус |
|---|---|---|
| `drawing.Blocks[name]`, `Blocks.Add(name)` | Найти/создать блок | `[TUT]` |
| `block.AddCircle(...)` / `block.AddPolyline(...)`, `CadColor.ByBlock` | Примитивы блока | `[TUT]` |
| `drawing.ActiveSpace.AddInsert(pos, scale, angle, name)` | Вставка блока | `[TUT]` |
| `drawing.ActiveSpace.Add(primitive)` / `AddText(...)` | Добавление примитива/текста | `[TUT]` |
| `drawing.Blocks.IsExists(name)` / `Blocks.Remove(name)` / `Blocks.Select(...)` | Таблица блоков: проверка, удаление, перебор | `[CODE]` robur-mcp |
| `block.Entities` → коллекция сущностей; `block.Entities.Count` | Содержимое блока | `[CODE]` |
| `block.Entities.CopyFrom(src, e => e.Layer = null, new ReferencesContext(drawing))` | Копирование сущностей **в** блок | `[CODE]` |
| `drawing.ActiveSpace.Entities.CopyFrom(block.Entities, add, refCtx)` | Взрыв: копирование сущностей блока в пространство | `[CODE]` |
| `entity.ScaleEntity(origin, xScale, yScale)`, `entity.Rotate(origin, angle)`, `entity.Move(x, y, z)` | Позиционирование при взрыве | `[CODE]` |
| `new DwgInsert { Block, Position, Rotation, Scale }` + `ActiveSpace.Add(insert)` | Вставка блока объектом (альтернатива `AddInsert`) | `[CODE]` |
| `insert.Block`, `insert.XScaleFactor / YScaleFactor / ZScaleFactor`, `insert.Rotation`, `insert.Position` | Свойства вставки | `[CODE]` |
| `new Drawing()` → `ActiveSpace.Entities.CopyFrom(block.Entities, new ReferencesContext(drawing))` | Черновик: копия определения блока в пространство модели; `ReferencesContext` переразрешает ссылки на слои/типы линий/вложенные блоки | `[DECOMP]` + BlockEditor |
| `block.Entities.Clear()` → `CopyFrom(space.Entities, new ReferencesContext(sourceDrawing))` (в `BeginUpdate`) | Перезапись определения блока содержимым черновика | `[DECOMP]` + BlockEditor |
| `DrawingConsts.ValidName(name, drawing.Blocks.NameType)` + `Blocks.IsExists(name)` + `block.Name = newName` | Переименование блока — канон `RenameSystemTablesDlg` (`val2.Name = text`) | `[DECOMP]` Class41 |

⚠️ При взрыве трансформации каждой сущности могут бросать исключение — оборачивать и
удалять сбойную сущность из `ActiveSpace` (см. robur-mcp, `ExplodeBlock`).
`ReferencesContext` (`Topomatic.Dwg`) нужен при копировании сущностей между блоками
и пространством.

## Полилинии (запись)

| API | Назначение | Статус |
|---|---|---|
| `DwgPolyline`, `polyline.Prepare(drawing)` (**обязателен**), `.Linetype`, `BugleVector2D` | Полилиния | `[TUT]` |
| `DwgPolyline.ConvertToPosArray(IList<Vector2D>)` | **Вершины полилинии** — свойства `Vertices` НЕТ (см. Dev Guide и DemLoader) | `[CODE]` DemLoader |

```csharp
var positions = new List<Vector2D>();
picked.ConvertToPosArray(positions);    // picked: DwgPolyline
```

Чтение вершин без ConvertToPosArray — перебор `foreach (BugleVector2D b in poly)`
(`b.Vertex`, `b.Bugle`) — `[CODE]` DxfExport.

## Типы линий

| API | Назначение | Статус |
|---|---|---|
| `drawing.Linetypes[name]` / `Linetypes.Add(name, desc, pattern)`, `LinetypePattern` | Типы линий | `[TUT]` |

### Раскладка в `.dwp` — `ComplexLinetype` `[REFL]`

`Linetypes[i] = {@:{Name, Handle, Description}}` + необязательный узел
`ComplexLinetype`. У системных (`ByLayer`, `ByBlock`, `Continuous`) его нет;
у остальных — **есть полное описание рисунка**. Значит «рисунки линитайпов в файле
ОТСУТСТВУЮТ» — неверно.

Формат — **плоский массив чередующихся длин штрих/пробел**, знак задаёт тип
(плюс = штрих, минус = пробел), узлов-объектов внутри нет:

```json
"ComplexLinetype": [ {"@": {"DashDotLenght": 0.75}},
                     {"@": {"DashDotLenght": -0.12}},
                     {"@": {"DashDotLenght":  0.12}},
                     {"@": {"DashDotLenght": -0.12}} ]
```

Проверено на `Dop/DWP`: `Путь.dwp` — 29 лайтайпов, из них **21 сложный**
(`GeologyDash`, `G_BUILDING_LINE`, `axis`, `ACAD_ISO03W100` и др.);
`leader.dwp` / `Проба1.dwp` / `Проба2.dwp` — 3, только системные.

Механизм в SDK: `DwgLinetype.SaveToStg` пишет узел `ComplexLinetype` **только если
`Pattern != null`**, вызывая `LinetypePattern.SaveToStg(node)` — сам узел в
`DwgLinetype` не объявлен, его имя даёт `LinetypePattern` (отсюда «сложный»).
`Pattern` **не** имеет публичного сеттера — заполняется только через Stg-чтение
(`LinetypePattern.LoadFromStg`).

> **Побочный эффект загрузки, важный для переноса.** `DwgLinetype.LoadFromStg`
> **перезаписывает** `item.Style` (у `Pattern.Items[]`) на локальный стиль, подобранный
> по базовому имени `.shx` (`GetStyleByBaseName`): в `По слою` / `GOST` / `Строительный`
> — `"GOSTtypeA"`, `"GOSTtypeA"`, `"ISOCPEUR"` и т. п. То есть при открытии на другой
> машине Robur **подставляет свои системные шрифты**, если базовый файл шрифта есть в
> её `FontDirectory`. Нет Robur — начертание не восстановится, даже имея `.dwp`.

### Раскладка в `.dwp` — `Styles` (шрифты текста) `[REFL]`

`Styles[i].@ = {Name, Handle, FileName, Height, LastUsedHeight, Ratio, Oblique}`.
**Имя файла шрифта в файле есть** — значит «имена DXF-шрифтов ОТСУТСТВУЮТ» тоже неверно:

```json
{"@": {"Name": "Standard", "Handle": 3, "FileName": "ISOCPEUR.ttf", "Height": 2.5}}
```

`Ratio` (ширина символа) и `Oblique` (наклон, радианы — 0.2618 = 15°) пишутся только
когда ≠ дефолту, т.е. опускаются по тому же правилу, что и цвет слоя.

Проверено на `Dop/DWP`: `Путь.dwp` — 13 стилей (`SPDS.shx`, `ISOCPEUR.ttf`, `CALIBRI.TTF`,
`arial.ttf`, `eskd1.shx`…), `5К.dwp` — 5, `Проба1/2.dwp`, `leader.dwp` — 1 (`SPDS.shx`).

> **Вот где переносимость реально ломается.** В файле лежит только **имя** файла
> шрифта, самой гарнитуры там нет. На машине без `SPDS.shx`/`iskd1.shx` текст
> отрисуется подстановочным шрифтом. Цвета слоёв при этом не страдают — они в файле.

## Форматы записи/чтения чертежей (Acax): `.dwp`, `.dwg`, `.dxf`

> **Решение (BlockEditor, согласовано)**: `block_editor_save` по умолчанию пишет **нативный
> `.dwp`** (BSTG, без потерь) — единственный штатно рекомендуемый формат сохранения
> блока. `.dwg`/`.dxf` — опционально, для обмена с другими CAD (DWG = только R2000/AC1015).
> Формат **`.dwr` не используется** — он не нативный (см. таблицу ниже).

| API | Назначение | Статус |
|---|---|---|
| `DrawingExportProvider.GetProvider(ext)` / `GetPreferedProvider()` (static) | Провайдер по расширению / предпочтительный | `[DECOMP]` Class37 (`tables_single_drawing`) |
| `provider.SaveToFile(path, drawing)` / `SaveToStream(...)` | Запись чертежа в файл/поток | `[DECOMP]` |
| `Topomatic.Acax.Export.NativeDwpExportProvider` | **Нативный формат Robur `.dwp`** (в `Topomatic.Acax.Export.dll`); DisplayName «Нативный Stg», Order 3009 — `GetPreferedProvider()` возвращает именно его | `[DECOMP]` |
| `NativeDwpExportProvider.SaveToStream(stream, drawing)` | Запись: `drawing.SaveToStg(stgDoc.Body)` → `StgDocument.SaveToStreamAsBinary(stream)` = **BSTG** | `[DECOMP]` |
| `Topomatic.Acax.Export.DwrExportProvider` | Формат **`.dwr`** — отдельный, НЕ нативный (Order 4009, «DWR»; `DwrWriter`, magic «DRWF» = 0x44575246) | `[DECOMP]` |
| `Topomatic.Acax.Import.Dxf.DwrReader.LoadFromFile(path, drawing)` | Чтение `.dwr` (в `Acax.Import.Dxf.dll`) | `[DECOMP]` |
| `Acax.Export.Dwg.dll` | Провайдеры `.dwg`/`.dxf` (Acax-мост) | `[DECOMP]` |

Канон выбора провайдера (Class37, IL): `GetProvider(Path.GetExtension(file))`,
если `null` — `GetPreferedProvider()`.

- **`.dwp` — нативный формат Robur** (BSTG): `Drawing : IStgSerializable`,
  `SaveToStg`/`LoadFromStg`/`Assign` — публичные. Все Robur-сущности (клотоиды,
  таблицы, выноски, размеры) сохраняются **без потерь**. `GetPreferedProvider()` →
  `NativeDwpExportProvider` (Order 3009, DisplayName «Нативный Stg»).
- **`.dwr` — НЕ нативный**: отдельный формат DWR (`DwrExportProvider`, Order 4009,
  `DwrWriter`/`DwrReader`, magic «DRWF»). В общем случае не используйте для
  совместимости с другими CAD — это формат Robur-конвейера импорта (Acax/DXF).
- **DWG штатный экспортёр пишет только R2000 (AC1015)** — «родной» формат Robur;
  новых версий DWG (R2013/R2018) Acax-мост не даёт — только через ACadSharp
  (см. ниже; DWG-ветка ACadSharp частичная, DXF — полная).
- Для компиляции нужна ссылка на `Topomatic.Acax.Export.dll` (базовый
  `DrawingExportProvider`, `Private=False`).

---

## Запись DXF/DWG через ACadSharp

`[CODE]` DxfExport (NuGet **ACadSharp 3.7.1**, net48; зависимость `System.Memory.dll`).

### Цвет в ACadSharp

```csharp
var aci      = new Color((short)aciIndex);          // ACI 1..255
var rgb      = new Color((byte)r, (byte)g, (byte)b); // TrueColor
var byLayer  = Color.ByLayer;                        // ACI = 256
var byBlock  = Color.ByBlock;                        // ACI = 0
```

⚠️ `Color.FromArgb(...)` **не существует** — только конструкторы выше либо
`Color.FromTrueColor(0xRRGGBB)`.

### Версия формата

- ACadSharp по умолчанию пишет **AC1032** — всегда задавать `doc.Header.Version` явно.
- Рекомендуемая для совместимости — **AC1015 (R2000)**: DXF `DxfWriter` и DWG
  `DwgWriter` (`new DxfWriter(path, doc, config)` / `new DwgWriter(...)`).

### Маппинг Robur → ACadSharp (ключевые)

| Robur | ACadSharp | Примечание |
|---|---|---|
| `DwgLine` | `Line` | `StartPoint`/`EndPoint` (XYZ) |
| `DwgPolyline` | `LwPolyline` | `Vertex.Location` (XY), `Bulge`, `IsClosed` |
| `DwgPolyline3D` | `Polyline3D` | ctor `(IEnumerable<XYZ>, isClosed)` |
| `DwgCircle` | `Circle` | `Center`, `Radius > 0` |
| `DwgArc` | `Arc` | `Center`, `Radius`, **Start/EndAngle (рад)** |
| `DwgEllipse` | `Ellipse` | `MajorAxisEndPoint`, `RadiusRatio ∈ (0..1]`, параметры (рад) |
| `DwgSpline` | `Spline` | `ControlPoints` AddRange, `Degree ≤ n−1`, **Knots обязательны** |
| `DwgPoint` | `Point` | **`Location`** (не `InsertionPoint`) |
| `DwgText` | `TextEntity` | **`InsertPoint`** (не `Position`), `Height`, `Rotation` (рад) |
| `DwgMText` | `MText` | `Value`, `InsertPoint`, `Height`; `Rotation` — read-only |
| `DwgHatch` | `Hatch` | `Paths.Add(BoundaryPath(Polyline))`, `IsSolid`, `PatternAngle/Scale` |
| `DwgInsert` | `Insert` | ctor `(BlockRecord)`, масштабы ≠ 0, `Rotation` (рад) |
| `DwgLeader` / `MapsLeaderEntity` | `Leader` / `MultiLeader` | Текст — только через `MultiLeader` (`ContextData`) |
| `DwgClothoid` | `LwPolyline` | Аппроксимация Френеля (~20 сегм./100 м) |
| `DwgWipeout` | `LwPolyline` | Плоские points |
| `DwgSolid` | `Solid` | `First…FourthCorner`; треугольник → `c4 = c3` |
| `DwgXLine` | `XLine` | **`FirstPoint`** (не `StartPoint`), `Direction` |
| `DwgRay` | `Ray` | `StartPoint`, `Direction` |
| `DwgDimensionAligned/Rotated` | `DimensionLinear` | `FirstPoint`, `SecondPoint`, `DefinitionPoint`, `TextMiddlePoint`; ось по `measurement` + текст принудительно — см. «Размеры: поворот и значение» |
| `DwgTable` | `LwPolyline`+`Line`+`MText` | Развёртка: рамка + сетка + ячейки |
| `DwgDimensionRadius/Diameter/Angular`, `DwgViewport`, `DwgFace`, `DwgShape`, `DwgImage`, `DwgMLine`, `DwgPolyfaceMesh/PolygonMesh`, `DwgAttdef/Attrib/MAttrib` | — | Не реализовано / пропуск |

### Ловушки API ACadSharp

`[CODE]` DxfExport (исходники: https://github.com/DomCR/ACadSharp):

| # | Ловушка | Правило |
|---|---|---|
| 1 | `Text` называется **`TextEntity`** (CS0246) | Использовать `TextEntity`; точка — `InsertPoint` |
| 2 | `Polyline3D` (не PolyLine3D) | Удобный ctor `(IEnumerable<XYZ>, bool)` |
| 3 | `MText.Rotation` — только getter | Поворот вычисляется из `AlignmentPoint`; напрямую не пишется |
| 4 | `Spline.ControlPoints/Knots` — private set | Только `Add`/`AddRange`; **Knots обязательны** (n+d+1) — без них рендеры отбрасывают сплайн |
| 5 | `Insert.Block` — internal set | Только `new Insert(blockRecord)`; масштабы `X/Y/ZScale` **бросают при 0** → заменять на 1 |
| 6 | `Ellipse.MajorAxis` — read-only | `MajorAxisEndPoint`; `RadiusRatio` строго (0..1] |
| 7 | `Leader` не имеет текста | Аннотация — internal; текст через `MultiLeader` |
| 8 | `MultiLeader.GetBoundingBox()` = null | Геометрия в `ContextData` (get-only, мутируемый); `ScaleFactor` обязан быть 1 |
| 9 | `XLine.FirstPoint`, `Point.Location` | Не `StartPoint`/`InsertionPoint` |
| 10 | Цвет: нет `FromArgb` (CS0117) | `new Color(short)` / `new Color(byte,byte,byte)` / `Color.FromTrueColor(uint)` |
| 11 | Таблицы | `TryGetValue(name, out entry)` + `Add(entry)`; дубли при `Add`; `updateCollection` резолвит ссылки при `AssignDocument` |
| 12 | Версия вывода — дефолт AC1032 | Всегда задавать `doc.Header.Version` явно |
| 13 | Блоки с префиксом `*` зарезервированы | Гвардить имена с `*` на обеих сторонах |
| 14 | Стрелка `Leader`/`MultiLeader` не переносится | Берётся из стиля; Robur-enum → BlockRecord не маппится |

### Запись выноски с текстом — `MultiLeader` (MLEADER)

`Leader` в ACadSharp текста не несёт (аннотация internal) — выноска **с текстом**
пишется как `MultiLeader`. Без текста — обычный `Leader` (как раньше).

```csharp
var ml = new MultiLeader();
ml.ContextData.TextLabel = "текст";            // код 304 (CONTEXT_DATA{)
ml.ContextData.ContentType = LeaderContentType.MText;      // 170 = 2
ml.ContextData.ScaleFactor = 1;                            // 41 = 1
ml.ArrowheadSize = 2.5;                                   // 297? — размер стрелки
var root = new LeaderRoot();                               // 300 LEADER_ROOT{
root.Lines.Add(new LeaderLine { Points = new [] { from, to } });  // 302 LEADER_LINE{
ml.ContextData.LeaderRoots.Add(root);
```

Проверено: одна запись `MULTILEADER` + автогенерируемый стиль `MULTILEADERSTYLE`
(`340 → 2D`), текст кириллицей UTF-8 в group `304`, путь лидера в `302`/`10,20`;
`DxfReader` читает всё обратно (`ContextData.TextLabel`). `GetBoundingBox()` = null —
не использовать.

### Чтение лидеров — базовый `DwgCoordinateLeader`

`[CODE]` DxfExport (`LeaderConverter.cs`) + декомпиляции `Tools/Decomp/`:

- Все лидеры (простой `DwgLeader` и картографические `MapsLeaderEntity` из
  `Topomatic.Maps`) наследуют `DwgCoordinateLeader`. Геометрия выноски живёт в
  базовом поле `list_0` (публичные `Count` + индексатор `Item[int]` →
  `Vector2D`, Stg-сериализуется); `Position` — отдельное поле **позиции текста**
  (тоже `Vector2D` в базе). Точки стрелки и позиция текста ортогональны:
  у классической выноски точка стрелки отстоит от `Position` на габарит.

- **Ловушка (рефлексия):** у `MapsLeaderEntity` индексатор переопределён
  **только с сеттером** (IL: `.property Item { .set }` без `.get` — геттер
  наследуется из базы). `GetProperty("Item", typeof(int)).GetValue(...)` даёт
  `PropertyInfo` с `CanRead = false` и бросает — точки молча теряются
  (`points = []`). Читайте типизированно: `leader.Count` + `leader[i]` —
  виртуальный вызов уходит в базовый `get_Item`. `ArrowHeadEnabled`-свойства в
  иерархии лидеров нет вовсе — настоящий признак стрелки: `ArrowheadType != None`
  (у `MapsLeaderEntity` оформление лежит в `Style` (`MapsLeaderStyle`): `Height`,
  `ArrowheadType`, `ArrowheadSize`).

- Уклоноуказатели (`MapsLinearLeaderEntity` / `MapsPolylineLeaderEntity`, слои
  «Уклоноуказатели»): геометрия — из `GetPolyline()` (`Polyline2DCurve`,
  `IEnumerable<BugleVector2D>` — булги игнорируются, берутся точки); стрелка —
  `GradeArrowheadType` **самой сущности** (в `Recreate` копируется в детей
  `DwgLeader` как `acDimArrowheadType_0`), `Style.ArrowheadType` — только fallback.
  Битые выноски (`IsPurged`: `PrepareLine` не нашёл привязанную полилинию по
  `DependentHandle`) имеют пустую геометрию и детей — в экспорт не попадают.

### Размеры: поворот и значение (DIMENSION)

`DimensionLinear` считает значение как **проекцию** вектора (First→Second) на ось
поворота (группа `50`). При `Rotation=0` показывается горизонтальная проекция —
для крутых размеров получается ерунда (1.19 вместо 99.67).

Правило (проверено на реальных данных Robur):
1. Ось подбирать так, чтобы проекция совпала с `measurement` из JSON:
   - если `|dx| ≈ measurement` → ось горизонтальная (`Rotation=0`);
   - если `|dy| ≈ measurement` → ось вертикальная (`Rotation=π/2`) — чаще всего;
   - иначе → `Rotation = Atan2(dy, dx)` (вдоль отрезка).
2. Принудительно писать `dim.Text` из `measurement` (`"0.00"`, инвариантная
   культура), если `TextOverride` пуст — тогда AutoCAD не пересчитывает значение.
   `dim.Rotation` — в радианах.

### LWPOLYLINE: булги на каждую вершину + облако ревизии

- `Vertex.Bulge = bulges[i]` ставится **для каждой вершины** (индексы не сжимать —
  булг может быть нулевым у прямой вершины, это легально).
- Облако ревизии Robur = замкнутая LWPOLYLINE с равномерными булгами (дугами) и
  **без XDATA-признака**. Чтобы AutoCAD опознал её как облако, пишем маркер
  `RevcloudProps` сами (спецификация пользователя):

| DXF-группа | DxfCode | Значение |
|---|---|---|
| `1001` | `ExtendedDataRegAppName` | `"RevcloudProps"` |
| `1070` | `ExtendedDataInteger16` | тип: 0=Freehand, 1=Rectangular, 2=Polygonal |
| `1040` | `ExtendedDataReal` | длина дуги (средняя хорда сегмента) |

```csharp
var xd = new ExtendedData();
xd.Records.Add(new ExtendedDataInteger16(cloudType)); // 1070
xd.Records.Add(new ExtendedDataReal(avgChord));       // 1040
poly.ExtendedData.TryAdd("RevcloudProps", xd);
```

Детект облака: `IsClosed`, вершин ≥ 4, все `|bulge|` ненулевые и одинаковые
(допуск ~15%), нулевые хорды (дубли вершин) игнорировать. Тип: равные хорды →
Rectangular (1), разброс хорд > 2× → Freehand (0). Регистрировать APPID в
`doc.AppIds` **не нужно** — DxfWriter создаёт запись в таблице сам (проверено:
`1001/1070/1040` на месте, APPID в таблице).

---

## Расширенный словарь сущности (`DwgDictionary`)

`DwgEntity` (через базу `DwgObject`) несёт произвольный строковый словарь — штатное
место для прикладных меток (`guid`, `name`, `libUid` и т. п.). `[CODE]` robur-mcp

| API | Назначение | Статус |
|---|---|---|
| `entity.HasExtensionDictionary` → bool | Есть ли словарь | `[DECOMP]` |
| `entity.CreateExtensionDictionary()` | Создать словарь, если нет | `[DECOMP]` |
| `entity.GetExtensionDictionary()` → `Topomatic.Dwg.DwgDictionary` | Получить словарь | `[DECOMP]` |
| `dict.SetString(key, value)` / `GetString(key, default)` | Строка | `[DECOMP]` |
| `dict.SetInteger(key, int)` / `GetInteger(key, default)` | Целое | `[DECOMP]` |
| `dict.SetDouble(key, double)` / `GetDouble(key, default)` | Дробное | `[DECOMP]` |
| `dict.SetBoolean(key, bool)` / `GetBoolean(key, default)` | Логическое | `[DECOMP]` |

```csharp
if (!entity.HasExtensionDictionary)
    entity.CreateExtensionDictionary();
var dict = entity.GetExtensionDictionary();
dict.SetString("guid", guidStr);
dict.SetString("name", name);
// поиск сущности в ActiveSpace по своему guid:
if (e.HasExtensionDictionary && e.GetExtensionDictionary().GetString("guid", null) == guidStr) ...
```

`robur-mcp` дополнительно кэширует `guid → entity` в собственном `ObjectStorage`
(`Topomatic.ToolBridge.Services`, **не** API Robur) — при поиске сначала проверяется
кэш, затем перебор `drawing.ActiveSpace.Entities` по расширенному словарю. Кэш
проверяет `entity.Drawing == drawing`, чтобы не отдать сущность чужого чертежа.

## Слои

| API | Назначение | Статус |
|---|---|---|
| `drawing.Layers` → `DwgLayers`: `IsExists(name)`, `this[name]` → `DwgLayer`, `Add(name)` → `DwgLayer`, `Remove(name)`, `Select(...)` | Таблица слоёв | `[CODE]` robur-mcp |
| `DwgLayer.Name`, `.Description`, `.Color` (`CadColor`), `.Color.ColorIndex`, `.Visible`, `.IsSystem` | Свойства слоя | `[CODE]`/`[DECOMP]` `Topomatic.Dwg.DwgLayer` |
| `drawing.ActiveLayer` → `DwgLayer`, `drawing.ActiveLayer?.Name` | Активный слой | `[CODE]` |
| `entity.Layer = drawing.Layers[name]` | Назначить слой сущности (проверив `IsExists`) | `[CODE]` |
| `DwgLayers.Add(name, CadColor, DwgLinetype)`; `Add(name)` = `Add(name, CadColor.White, Drawing.Linetypes.Continuous)` | Создание слоя; **новый слой всегда белый** | `[DECOMP]` ilspycmd |

### Физическое хранение в `.dwp` — почему в файле нет цвета слоя `[REFL]`+`[DECOMP]`

**Атрибут пишется, но опускается при значении по умолчанию.** 3-аргументные
перегрузки `StgCollection` это делают явно (`Topomatic.Stg`, `StgCollection.cs`):

```csharp
public void AddInt32(string name, int value)            // пишет всегда
public void AddInt32(string name, int value, int optional)
{
    if (optional == value) return;                        // ← опускаем дефолт
    ...
}
```

`DwgLayer` реализует `Topomatic.Visualization.IStgContextSerializable` (явная
реализация, `private`), а не обычный `IStgSerializable`. Полный набор ключей узла
слоя (`Topomatic.Dwg.dll` 16.0.62.12, IL-дамп `Tools/IL/Dwg.il`):

| ключ | перегрузка | дефолт | пишется |
|---|---|---|---|
| `Name`, `Handle` | из `DwgNamedCollection.SaveToStg` | — | **всегда** |
| `Visible`, `Enable`, `Plottable` | `AddBoolean(n, v, true)` | `true` | только если `false` |
| `Color` | `AddInt32(n, Color.ToCompressValue(), CadColor.White.ColorIndex)` | `White.ColorIndex` | только если ≠ дефолта |
| `Transparency` | `AddInt32(n, v)` — **2 арг.** | — | **всегда** |
| `Linetype` | `AddInt32(n, Index, 2)` | `2` | если ≠ 2 |
| `Lineweight` | `AddInt32(n, v, -3)` | `-3` | если ≠ -3 |
| `Description` | `AddString(n, v, "")` | `""` | если ≠ "" |

Цвет кладётся в **словарь атрибутов** (`node.Attribute`), а не как дочерний элемент.
Проверено на всех `.dwp` из `Dop/DWP` (16 файлов): у слоёв **ноль** атрибутов, кроме
`{Name, Handle, Transparency}` — то есть **все слои видимы/включены/печатаемы,
`Linetype.Index == 2`, `Lineweight == -3`, `Description == ""` и белые**
(`ToCompressValue() == White.ColorIndex`).

Сеттер `DwgLayer.Color` вдобавок отбрасывает служебные значения
(`if (value != Color && value != CadColor.ByBlock && value != CadColor.ByLayer)`),
поэтому слой физически не может быть `ByLayer`.

### Цвет сущности — тоже пишется, дефолт `256` = `ByLayer` `[DECOMP]`

`DwgEntity.SaveToStg` (`Tools/IL/Dwg.il`) пишет в `@` сущности:

| ключ | дефолт | пишется |
|---|---|---|
| `Color` | `256` = `ByLayer` | только если ≠ 256 |
| `Transparency` | `Transparency.ByLayer.Value` | **всегда** |
| `Layer` | `0` | **всегда** — и это **индекс** в `Layers[]`, не имя |
| `Linetype` | `0` | всегда |
| `Lineweight` | `-1` | всегда |
| `Scale` | `1f` | если ≠ 1 |

Отсюда наблюдаемое в `leader.dwp`: `@` сущности = `{Class, Handle, Transparency,
Layer}` — `Color` опущен, т.е. сущность `ByLayer`; явный цвет в `@` у сущностей
в `.railx` **есть** (у границ — `BackgroundColor`, у таблиц — `textColor`/`fillColor`).
`256` = «взять цвет слоя» ⇒ при белых слоях рисуется белым, а палитру плана задают
сущности с явно записанным цветом.

### Откуда берётся цвет при переносе на другую машину `[DECOMP]`

**Только из файла.** В цепочке загрузки (`DwgLayer.LoadFromStg`) нет ни реестра,
ни пользовательских настроек, ни палитры «по индексу слоя»: ключа нет ⇒
`CadColor.White` (и конструктор слоя тоже стартует с `new Field<CadColor>(White)`).
`DwgDatabase` содержит только `FindOrCreate`/`ObjectName` — члена `Colors` нет;
обращений к `Microsoft.Win32.Registry` в сборках `Dwg`/`Dwg.Controller` нет.

**Единственный найденный переносимый «палитра-файл» — состояния слоёв:**

| API | Назначение |
|---|---|
| `drawing.LayerStates` → `DwgLayersStates` (`DwgLayersState : DwgNamedObject, IEnumerable<DwgLayerStateInformation>`) | именованные состояния слоёв |
| `DwgLayersState.Create()` | снимок текущих `Color`, `Enable`, `Linetype`, `Lineweight`, `Plottable`, `Visible` |
| `DwgLayersState.Restore()` | откат по флагам `RestoreLayerPropertiesFlags` (11 бит: `Color = 0x20`, `Linetype = 0x40`, `Lineweight = 0x80`, дефолт `1023`) |
| `Topomatic.Dwg.Controller.Dialogs.LayerStatesManager` (`btnCreateState_Click` / `btnImport_Click` / `btnExport_Click`) | UI; **экспорт — отдельный файл**: `StgDocument` + `Drawing` с копией `LayerStates` → `SaveToFileAsXml()` (XML-Stg) |

`DwgLayerStateInformation.SaveToStg` — единственное место, где цвет пишется
**безусловно-корректно**: `AddInt32(<34942>, Color.ToCompressValue(), White.ToCompressValue())`.
Но `DwgNamedCollection.SaveToStg` пишет коллекцию только при `Count > 0` ⇒ в файлах
без состояний слоёв узла нет вовсе. **Это и есть ответ: «палитра» переносится не в
`.dwp`, а отдельным экспортом состояний слоёв.**

> **Вывод про переносимость.** Цвет слоя/сущности с нестандартным значением везётся
> с собой в файле; «слетают цвета» означает одно из: открыли не `.dwp` (а `.dxf`/`.dwg`),
> либо состояния слоёв не импортировали на целевой машине. Реальные риски —
> **файлы шрифтов** (в файле только имя) и `ComplexLinetype` со ссылками на них, см. ниже.

> **Несогласованность в самом Robur:** в `DwgLayer.SaveToStg` дефолт взят как
> `White.ColorIndex`, а в `DwgLayerStateInformation.SaveToStg` и в `Drawing.SaveToStg`
> для `ActiveColor` — как `White.ToCompressValue()`. Наблюдаемая форма файла
> (`{Name, Handle, Transparency}`) доказывает, что для белого
> `ToCompressValue() == ColorIndex` (ACI-индекс).

## Пространство чертежа (`ActiveSpace`)

| API | Назначение |
|---|---|
| `drawing.ActiveSpace.Entities` | Коллекция сущностей пространства: `Count`, `Add`, `Remove`, `CopyFrom(...)` |
| `drawing.ActiveSpace.Bounds` | Рамка пространства (`Left`/`Right`/`Top`/`Bottom`) |

> `.railx` — это SFCX-контейнер, внутри которого BSTG-документ хранит **ту же**
> ситуацию (`Situation.Collections/Styles/Linetypes/Layers/MLineStyles/
> DimensionStyles/TableStyles/Filters/Classes/Blocks/Layouts`) плюс ветвь
> `Alignment`. Слои связываются с `Situation/Layers` через отдельный
> `body/LayersLinks` по `LayerId` = `Layer[].Handle` (не по имени!). Формат,
> счётчики и эталонное сравнение — `railx.md`; механизм границ —
> `landallotment.md`.

## Штриховки

| API | Назначение | Статус |
|---|---|---|
| `HatchPatternManager.Current` → `HatchPatternManager`, `.GetDefinedPatterns()` → перечисление `HatchPattern` | Реестр паттернов | `[CODE]` robur-mcp |
| `HatchPattern.Name`, `.Description`, `pattern.Select(line => ...)` | Описание паттерна; у линии — `Angle`, `StartX/StartY`, `DeltaX/DeltaY`, `LinetypePattern` | `[CODE]` |
| `DwgHatch.PatternName`, `.PatternScale`, `.PatternAngle`, `.PatternType` (`AcPatternType`), `.HatchStyle` (`AcHatchStyle`) | Задание штриховки | `[CODE]` |

Энумы (подтверждены): `Topomatic.Dwg.Entities.AcPatternType`,
`Topomatic.Dwg.Entities.AcHatchStyle`, `Topomatic.Dwg.TextAlignment`,
`Topomatic.Dwg.AttachmentPoint` — разбираются по имени через `Enum.TryParse`.

## Таблицы (`DwgTable`)

| API | Назначение | Статус |
|---|---|---|
| `new DwgTable(drawing.TableStyles.Standard, rowCount, 1, columnCount, 1)` | Создать таблицу (`DwgTableStyle`) | `[CODE]` robur-mcp |
| `table.Prepare(drawing)` | Подготовить (обязательно) | `[CODE]` |
| `table.UnMergeAll(true)` / `table.MergeCells(c1, r1, c2, r2)` | Объединение ячеек | `[CODE]` |
| `table[row, column]` → ячейка; `.SourceText` | Текст ячейки | `[CODE]` |
| `table.Position` (`Vector3D`), затем `ActiveSpace.Add(table)` | Позиционирование и вставка | `[CODE]` |

### Реальные источники write-данных таблицы — `[DECOMP]` `Topomatic.Tables.Export.dll`

Write-данные таблиц приходят **не** выдуманным `DwgTableSourceData`-однострочником,
а через **реально объявленные** декомпиляцией токены (`[DECOMP]`,
`Topomatic.Tables.Export.dll`); класс-импортёр `DwgTableImport` объявлен в под-namespace `Import`:

| Токен | Namespace typedef | extends→родитель | Статус |
|---|---|---|---|
| `DwgTableImport` | `Topomatic.Tables.Export.Import.DwgTableImport` (flist=215, mlist=468) | extends=0x65 | `[DECOMP]` |
| `DwgTableSourceData` | `Topomatic.Tables.Export.Import.DwgTableSourceData` (flist=218, mlist=489) | extends=0x65 | `[DECOMP]` |
| `DwgTableSourceDataCSV` | `Topomatic.Tables.Export.Import.DwgTableSourceDataCSV` (flist=224, mlist=498) | extends=0xe0 | `[DECOMP]` |
| `DwgTableSourceDataMultiSheet` | `Topomatic.Tables.Export.Import.DwgTableSourceDataMultiSheet` (flist=227, mlist=503) | extends=0xe0 | `[DECOMP]` |
| `DwgTableSourceDataDWP` | `Topomatic.Tables.Export.Import.DwgTableSourceDataDWP` (flist=228, mlist=506) | extends=0xe8 | `[DECOMP]` |
| `DwgTableSourceDataExcel` | `Topomatic.Tables.Export.Import.DwgTableSourceDataExcel` (flist=228, mlist=512) | extends=0xe8 | `[DECOMP]` |
| `DwgTableUtils` | `Topomatic.Tables.Export.DwgTableUtils` (flist=110, mlist=180) | extends=0x65 | `[DECOMP]` |

Мост «источник данных → сущность таблицы» — на `DwgTableImport` (write-токены
`CreateTable`/`DwgTableRefreshDataFromSource`, mlist 469–471) и на самом источнике
`DwgTableSourceData.CreateDwgTable(DwgTableStyle)` (mlist 494). Члена `DataSource`
на `Topomatic.Dwg.Entities.DwgTable` **нет** (проверено декомпиляцией) — не использовать:

```csharp
// [DECOMP] токены доказаны (Topomatic.Tables.Export.dll, namespace Import):
var source = new DwgTableSourceDataCSV("modelId"); // ctor (string modelId), mlist 498
var importer = new DwgTableImport();               // токен объявлен (flist=215, mlist=468)
var table = importer.CreateTable(source, style);           // → Entities.DwgTable (mlist 469)
importer.DwgTableRefreshDataFromSource(table);             // перечитать данные из источника (mlist 470)
```

## Базовые write-сущности

Общий базовый write-тип всех плановых сущностей (`DwgLine`, `DwgCircle`,
`DwgText`, `DwgInsert`, `DwgPolyline`) подтверждён декомпиляцией
(`[DECOMP]`, `Topomatic.Dwg.dll`): у всех пяти строка typedef имеет
**ровно один и тот же** `extends=0xdc`, который разворачивается в
`Topomatic.Dwg.Entities.DwgEntity`.

| Базовый токен | Сборка | typedef-факт | Статус |
|---|---|---|---|
| `DwgEntity` | `Topomatic.Dwg.dll` | `Topomatic.Dwg.Entities.DwgEntity` (flist=158, mlist=580) | `[DECOMP]` |
| `DwgObject` | `Topomatic.Dwg.dll` | `Topomatic.Dwg.DwgObject` (flist=84, mlist=149) | `[DECOMP]` |

Все write-сущности ActiveSpace наследуют `DwgEntity` (общий `extends=0xdc`),
поэтому принимаются одним write-методом (члены подтипов из robur-mcp,
см. §Пространство чертежа):

```csharp
// [DECOMP] базовый тип DwgEntity доказан; конкретный член line.Geometry НЕ
// подтверждён декомпиляцией (токена нет) — поэтому пример честно ограничен:
// создание write-сущности и вставка в ActiveSpace (только доказанные шаги).
DwgEntity MakeLine()
{
    var line = new DwgLine();           // [DECOMP] extends=0xdc → DwgEntity
    return line;                        // возвращаем по базовому типу
}
drawing.ActiveSpace.Entities.Add(MakeLine()); // [DECOMP] ActiveSpace.Entities см. §Пространство
```

### Честные «пусто» — токенов коллекций НЕТ [DECOMP]

| Токен | Факт |
|---|---|
| `DwgObjectReference` | `[DECOMP]` не объявлен — не использовать |
| `DwgObjectCollection` | `[DECOMP]` не объявлен — не использовать |
| `DwgEntityCollection` | `[DECOMP]` не объявлен — не использовать |

Реальный контейнер сущностей — `ActiveSpace.Entities` / `Layout.Block`
(см. §Пространство чертежа), а не несуществующий `DwgEntityCollection`.

## Определение типа сущности

Классы сущностей, встречающиеся в robur-mcp: `DwgPolyline`, `DwgTable`, `DwgMText`,
`DwgText`, `DwgCircle`, `DwgLine`, `DwgHatch`, `DwgInsert`,
`DwgModel3DElement` с `Element is StaticSolidElement` (твердое тело) или
`Element is ConstructedModel3dElement` (TLC), `DwgSmdxPointLandscaping` (посадка).
Определение — цепочкой `is` (см. robur-mcp, `GetEntityType`).
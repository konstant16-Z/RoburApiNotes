# ApiNotes — Чертёж (Topomatic.Dwg): модель, сущности, запись DXF/DWG

База `[TUT]` (tutorial6), дополнена `[CODE]` (New_export/src/DxfExport — конвертеры сущностей,
запись DXF/DWG через ACadSharp; DemLoader/Runoff).

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
| `Drawing.ActiveDocument` | Текущий открытый чертёж (статическое свойство) | `[CODE]` DxfExport/SPEC §2.4 |
| `drawing.ActiveSpace` | Текущее пространство (Model или Layout) | `[TUT]` |
| `drawing.BeginUpdate()/EndUpdate()` | Групповое изменение чертежа (парное, в `try/finally`) | `[TUT]` |

## Листы (Layouts)

| API | Назначение | Статус |
|---|---|---|
| `drawing.Layouts` → `DwgLayouts : Collection<DwgLayout>` | Все пространства документа; `Layouts[0]` — всегда `"Model"` (Model Space) | `[CODE]` DxfExport/SPEC §2.4 |
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
| `DwgLine` | `Start[2]`, `End[2]` | `[CODE]` DxfExport/SPEC §3.3 |
| `DwgCircle` | `Center[2]`, `Radius` | `[CODE]` |
| `DwgArc` | `Center[2]`, `Radius`, `StartAngle`, `EndAngle` | `[CODE]` |
| `DwgPolyline` | `IEnumerable<BugleVector2D>` — у элемента поля `.Vertex.X/.Y`, `.Bugle`; `.Closed`; **свойства `Vertices` НЕТ** (перебор + `ConvertToPosArray` для выборки) | `[CODE]` PolylineConverter.cs, DemLoader |
| `DwgPolyline3D` | 3D-аналог полилинии | `[CODE]` |
| `DwgText` / `DwgMText` | `Position[2]`, `Value`, `Height`, `Rotation`, `FontName` | `[CODE]` DxfExport/SPEC §3.3 |
| `DwgInsert` | `Block` (у вставки без блока **null или бросает** — оборачивать try/catch), `Block.Name`, `XScaleFactor/YScaleFactor/ZScaleFactor`, `Rotation` (рад), `Matrix` | `[CODE]` InsertConverter.cs |
| `DwgEllipse` | `MajorAxe` — **опечатка API** (вектор центр→конец большой оси), `MinorRatio`, `StartAngle/EndAngle` (рад) | `[CODE]` EllipseConverter.cs |
| `DwgSpline` | `Count` + `e[i]` → `Vector3D` | `[CODE]` |
| `DwgWipeout` | `Count` + `e[i]` → `Vector2D` | `[CODE]` |
| `DwgHatch` | Только метаданные паттерна; геометрия не разворачивается | `[CODE]` |
| `DwgPoint` | Пропуск при экспорте | `[CODE]` |
| `DwgDimension*` / `DwgCoordinateLeader` / `DwgLeader` | Комплексные сущности (дети) — экспортировать по дочерним примитивам | `[CODE]` ExportCommand.cs |
| `DwgTable` | `Topomatic.Tables.Export.dll`; `DefaultRowHeight` — **Int32**, не double | `[CODE]` |
| `DwgViewport` | Пропуск (служебная) | `[CODE]` |

Базовые свойства любой сущности: `entity.Layer?.Name`, `entity.Color` (→ `CadColor`),
`entity.Linetype?.Name` — всегда проверять на null (см. резолв контекста ниже).

## Цвет (`CadColor`) и резолв ByLayer/ByBlock

`CadColor` — структура (`Topomatic.Cad.Foundation`):

| API | Назначение | Статус |
|---|---|---|
| `color.ColorIndex` → int | Индекс ACI; `>= 0` — конкретный цвет | `[CODE]` EffectiveContext.cs |
| `CadColor.ByLayerIndex` / `CadColor.ByBlockIndex` | Маркеры наследования (в DXF/DWG: 256 / 0) | `[CODE]` |
| `color.ToIndexColor()` | RGB-цвет → ближайший ACI | `[CODE]` |
| `color.Win32Color` → `System.Drawing.Color` | Истинный цвет (R/G/B) для TrueColor | `[CODE]` |

Резолв контекста сущности (паттерн `EffectiveContext.Resolve(entity, parent)`, `[CODE]`):

- слой: `entity.Layer?.Name` → иначе родительский → иначе `"0"`;
- цвет: `ByLayer/ByBlock` → **унаследовать от родителя** (иначе сохранить `ColorIndex`);
  RGB → `ToIndexColor()` для ACI + `Win32Color` для TrueColor-строки `#RRGGBB`;
- тип линии: аналогично наследуется через `entity.Linetype?.Name`.

## Матрица вставки

`[CODE]` EntityWalker.cs / DxfExport SPEC §2.3:

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

## Полилинии (запись)

| API | Назначение | Статус |
|---|---|---|
| `DwgPolyline`, `polyline.Prepare(drawing)` (**обязателен**), `.Linetype`, `BugleVector2D` | Полилиния | `[TUT]` |
| `DwgPolyline.ConvertToPosArray(IList<Vector2D>)` | **Вершины полилинии** — свойства `Vertices` НЕТ (см. Dev Guide и DemLoader) | `[CODE]` DemLoader/AreaPicker.cs:72–74 |

```csharp
var positions = new List<Vector2D>();
picked.ConvertToPosArray(positions);    // picked: DwgPolyline
```

Чтение вершин без ConvertToPosArray — перебор `foreach (BugleVector2D b in poly)`
(`b.Vertex`, `b.Bugle`) — `[CODE]` PolylineConverter.cs.

## Типы линий

| API | Назначение | Статус |
|---|---|---|
| `drawing.Linetypes[name]` / `Linetypes.Add(name, desc, pattern)`, `LinetypePattern` | Типы линий | `[TUT]` |

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
| `DwgLeader` | `Leader` / `MultiLeader` | Текст — только через `MultiLeader` (`ContextData`) |
| `DwgClothoid` | `LwPolyline` | Аппроксимация Френеля (~20 сегм./100 м) |
| `DwgWipeout` | `LwPolyline` | Плоские points |
| `DwgSolid` | `Solid` | `First…FourthCorner`; треугольник → `c4 = c3` |
| `DwgXLine` | `XLine` | **`FirstPoint`** (не `StartPoint`), `Direction` |
| `DwgRay` | `Ray` | `StartPoint`, `Direction` |
| `DwgDimensionAligned/Rotated` | `DimensionLinear` | `FirstPoint`, `SecondPoint`, `DefinitionPoint`, `TextMiddlePoint`; ось по `measurement` + текст принудительно — см. «Размеры: поворот и значение» |
| `DwgTable` | `LwPolyline`+`Line`+`MText` | Развёртка: рамка + сетка + ячейки |
| `DwgDimensionRadius/Diameter/Angular`, `DwgViewport`, `DwgFace`, `DwgShape`, `DwgImage`, `DwgMLine`, `DwgPolyfaceMesh/PolygonMesh`, `DwgAttdef/Attrib/MAttrib` | — | Не реализовано / пропуск |

### Ловушки API ACadSharp

`[CODE]` DxfExport/SPEC §4.8 (исходники: https://github.com/DomCR/ACadSharp):

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
# ApiNotes — Твёрдые тела и Brep (Topomatic.Cad.Foundation.Brep / Visualization)

Источник — боевой плагин `[CODE]` `robur-mcp/tool_bridge/Tools/SolidTools.cs`
(публичный `github.com/topomatic-code/robur-mcp`) и `DwgUtils.cs`. Полный список
методов `Brep.Tools` подтверждён монодизассемблированием
`Development/Out/Bin/Topomatic.Cad.Foundation.dll` (16.0.62.x); типы обёрток —
`Topomatic.Visualization.dll` / `Topomatic.Visualization.Runtime.dll`.

## Сборки и типы

| Тип | Сборка | Роль |
|---|---|---|
| `Topomatic.Cad.Foundation.Brep.Shell` | `Topomatic.Cad.Foundation.dll` | Твёрдое тело: `Edges`, `Faces`, `Vertices` |
| `Topomatic.Cad.Foundation.Brep.Face` | там же | Грань: `Loops`, `Plane`, `Flags`, `Bounds` |
| `Topomatic.Cad.Foundation.Brep.Loops` / `Loop` | там же | Контуры грани; `Loop.GetPolygon3d()` → точки контура |
| `Topomatic.Cad.Foundation.Brep.Edges` / `Edge` / `LoopEdge` | там же | Рёбра |
| `Topomatic.Cad.Foundation.Brep.Tools` | там же | Все операции над `Shell` (static) |
| `Topomatic.Cad.Foundation.Plane` | там же | Плоскость: ctor `(Vector3D normal, Vector3D position)`, `Normalize()`, `Project(point)` |
| `Topomatic.Visualization.StaticSolidElement` | `Topomatic.Visualization.dll` | Твёрдотельное тело как элемент модели (`Name`, `Color`, `Origin`) |
| `Topomatic.Visualization.Runtime.DwgModel3DElement` | `Topomatic.Visualization.Runtime.dll` | Dwg-сущность, несущая `Element` |
| `Topomatic.Visualization.ImProperties` / `ImDocuments` | `Topomatic.Visualization.dll` | Свойства/документы smdx-элемента |

## Обёртка сущности: `DwgModel3DElement`

```csharp
var entity = new DwgModel3DElement
{
    Element = new StaticSolidElement(name, "SmdxElement", new ImProperties(), shell, new ImDocuments())
};
drawing.ActiveSpace.Add(entity);
```

| API | Назначение | Статус |
|---|---|---|
| `DwgModel3DElement.Element` | `StaticSolidElement` (или `ConstructedModel3dElement` у TLC) | `[CODE]` |
| `DwgModel3DElement.Position` / `Rotation` / `Scale` / `Normal` / `Angle` | Позиционирование сущности | `[CODE]` |
| `DwgModel3DElement.BeginChange()` / `EndChange()` | Точечное изменение перед сменой `Element`/цвета (парно) | `[CODE]` |
| `StaticSolidElement.Name`, `.Color` (`System.Drawing.Color`), `.Origin` (`Vector3D`) | Свойства тела | `[DECOMP]` |
| `StaticSolidElement.GetBrep()` → `Shell` | Геометрия | `[CODE]` |
| `StaticSolidElement.GetObjectType()` / `GetAllProperties()` → `ImProperties` | Тип и свойства (`.Clone()`) | `[CODE]` |

⚠️ **Ловушка `[CODE]`:** `DwgModel3DElement` не допускает трансформаций, когда тело
задано через `Brep`. После замены `entity.Element` обязательно сбросить
`Position = (0,0,0)`, `Rotation = 0`, `Scale = (1,1,1)` — иначе тело «уезжает».

## Создание тел примитивами (`Brep.Tools`, static)

| Метод (подтверждённая сигнатура) | Назначение |
|---|---|
| `Shell Cube(double width, double height, double depth)` | Параллелепипед |
| `Shell Sphere(double radius, int slices, int stacks)` | Сфера |
| `Shell Cylinder(double radius1, double radius2, double height, int slices)` | Цилиндр/конус |
| `Shell Circle(double radius, int slices)` | Диск |
| `Shell Pyramid(double width, double height, double depth)` | Пирамида |
| `Shell Polygon(Vector3D[] positions)` | Плоский полигон (используется как секущая плоскость) |
| `Shell Extrude(double height, Face face)` / `Extrude(double height, Shell shell)` | Вытягивание |
| `Shell Sweep(IList<Vector3D> path, IList<Vector2D> profile, int mode)` | Вытягивание 2D-профиля вдоль 3D-пути |

## Правка и топология

| Метод | Назначение |
|---|---|
| `void Copy(Shell src, Shell dst)` | Копия (правят копию, затем подменяют `Element`) |
| `void AddFace(Shell shell, List<Vector3D> positions)` | Добавить грань (есть перегрузки с `edgeFlags`, `flags`) |
| `void AddEdge(Shell shell, Vector3D start, Vector3D end)` | Добавить ребро (перегрузки с `flags`, `curve`) |
| `void RemoveFace(Shell shell, Face face)` / `void RemoveFaces(Shell shell, IEnumerable<Face> faces)` | Удалить грань(и) |
| `void RemoveEdge(Shell shell, Edge edge)` | Удалить ребро |
| `void RemoveStrayFaces(Shell shell)` / `void RemoveStrayEdges(Shell shell)` | Убрать «мусорные» грани/рёбра |
| `void FixHole(Shell shell)` | Зашить отверстие |
| `void Flip(Shell shell)` | Развернуть ориентацию |
| `void SimplifyFaces(Shell shell)` / `void SimplifyEdges(Shell shell)` | Упростить |
| `void FaceTriangulation(Face face, ...)` | Триангуляция грани (для отрисовки) |

## Логические операции

| Метод | Назначение |
|---|---|
| `Shell Union(Shell s1, Shell s2)` | Объединение |
| `Shell Difference(Shell s1, Shell s2)` | Вычитание |
| `Shell Intersection(Shell s1, Shell s2)` | Пересечение |
| `Shell Clip(Shell shell, Shell solid, bool inside)` | Разрезание плоскостью, заданной `Shell` |
| `Shell[] Slice(Shell shell, Topomatic.Cad.Foundation.Brep.Plane plane)` | Разрез плоскостью |
| `Shell[] Separate(Shell shell)` | Разделить на компоненты |

## Трансформации и анализ

| Метод | Назначение |
|---|---|
| `Shell Translate(double x, double y, double z, Shell shell)` | Перенос |
| `Shell Rotate(double ox, double oy, double oz, Shell shell)` | Поворот (углы по осям, рад) |
| `Shell Scale(double scale, Shell shell)` | Масштаб |
| `Shell Multmatrix(Matrix matrix, Shell shell)` | Произвольная матрица |
| `BoundingBox3D GetBounds(Shell shell)` | Рамка (`Center`, `GetCorners()`) |
| `bool IsSolid(Shell shell)` / `bool PosInsideSolid(Shell solid, Vector3D pos)` | Признак тела / точка внутри |
| `bool IsCCW(IList<Vector2D> polygon)` / `IsCCW(Vector2D a, Vector2D b, Vector2D c)` | Обход против часовой |
| `void MassProperties(Shell shell, out double volume, out Vector3D center, out Vector3D moments, out Vector3D products)` | Массовые характеристики |
| `int[] SolidInfo(Shell shell)` | Сводка по телу |
| `void LoadFromStg(Shell, StgNode)` / `void SaveToStg(Shell, StgNode)` | Сериализация |
| `GeometryModel3D CreateModel3D(Shell shell, Vector3D origin, System.Drawing.Color color)` | 3D-модель для отрисовки |

## Сечение тела плоскостью (паттерн)

```csharp
var solidShell = solidElement.GetBrep();
var plane = new Plane(normal, position);
plane.Normalize();
var bounds = Brep.Tools.GetBounds(solidShell);
var center = plane.Project(bounds.Center);
// построить секущий Shell-полигон с запасом по размеру рамки
var cuttingShell = Brep.Tools.Polygon(cornerPoints);
var clip = Brep.Tools.Clip(cuttingShell, solidShell, true);
var contours = clip.Faces.SelectMany(f => f.Loops.Select(l => l.GetPolygon3d()));
```

⚠️ `Brep.Tools.Clip` возвращает **`Shell`**, а не отдельный результат с полями,
и принимает `inside` третьим аргументом. Источник: `SolidTools.cs` (`Section`).

## Ловушки

- Геометрию правят на **копии** `Shell` (`Tools.Copy`), затем создают новый
  `StaticSolidElement` и присваивают `entity.Element` внутри `drawing.BeginUpdate()`.
- Свойства старого элемента переносят через `solidElement.GetAllProperties().Clone()`
  и `solidElement.GetObjectType()`, цвет — `newSolidElement.Color = solidElement.Color`.
- Индексы граней из `shell.Faces` нестабильны между перестроениями — сохранять
  ссылки на `Face` или индексы в рамках одной операции.
- `System.Drawing.Color` (`StaticSolidElement.Color`) и `Topomatic.Cad.Foundation.CadColor`
  (`DwgEntity.Color`) — разные типы; синхронизируются через `CadColor.Win32Color`.

# ApiNotes — Поверхности (ЦММ)

## Доступ к поверхности

```csharp
var layer = SurfaceLayer.GetSurfaceLayer(cadView);
var sfc = layer.Surface;
```
`[TUT]` (см. tutorial4).

## Чтение

| API | Назначение | Статус |
|---|---|---|
| `sfc.Points[index]` → `.Vertex.Elevation` | Точки поверхности и отметки | `[TUT]` |
| `sfc.GetExtensiveInformation(ind)` → `info` | Расширенная информация о точке | `[TUT]` |
| `info.Code`, `info.Semantic["CENTER"]`, `GetStringTags`, `sfc.RefreshPointSign(info)` | Код и семантика точки | `[TUT]` |
| `surface.Points[i].Vertex` → `Vector3D` | Прямое чтение вершин | `[CODE]` Runoff/SurfaceReader.cs:32 |
| `surface.GetElevation(new Vector2D(x, y))` → `double?` | Отметка в точке | `[CODE]` Runoff/SurfaceReader.cs:86 |
| `surface.Triangles[t]` → `.A/B/C`, `.IsRemoved` | Треугольники триангуляции (пропускать `IsRemoved`) | `[CODE]` Runoff/SurfaceReader.cs:38–44 |
| `surface.CreateSection(Vector2D[] pts, SectionFlags)` | Сечение поверхности по ломаной | `[CODE]` Runoff/LogProfile.cs:36 |
| `StructureLine.ToPolyline(list)`, `strLine[i].Index`, `IsClosed` | Структурная линия | `[TUT]` |
| `ILinearObject.GetPolyline(poly)`, `poly.GetArea2D()`, `EqualEps(v)` | Площадь замкнутой горизонтали | `[TUT]` |
| `SurfaceLayer.SurfaceSelectionSet.IsHorizontalSelectable`, `HorizontalsStyle.GetLayer()` | Горизонтали | `[TUT]` |

## Выбор точек

| API | Назначение | Статус |
|---|---|---|
| `layer.SelectPoints(...)`, `SelectedPointsCount`, `GetSelectedPoints()` | Выбор точек поверхности | `[TUT]` |
| `layer.SelectOneStructureLine(pred, ...)`, `layer.PickOnePoint(...)` | Выбор структурной линии/точки | `[TUT]` |

## Правка

| API | Назначение | Статус |
|---|---|---|
| `sfc.BeginUpdate("описание")/EndUpdate()` | Групповое изменение (обязательно парное) | `[TUT]`+`[CODE]` |
| `PointEditor(sfc).Add(...)` | Правка/добавление **существующих** точек — только через него | `[TUT]` |
| `sfc.StructureLines.Add(...)`, `structureLine.Add(index)` | Структурные линии из индексов точек | `[TUT]` |

⚠️ «Правка только через PointEditor» относится к существующим точкам; **создание с нуля** —
через прямой `Points.Add` (ниже).

## Создание ЦММ с нуля — `[CODE]` DemLoader/Robur/TerrainWriter.cs

```csharp
IProjectModel node = PluginCoreOps.CreateModel(parent, TerrainModel.MODEL_TYPE, name);
node.LockWrite();
try
{
    var surface = node.Model as Surface;      // ⚠️ после LockWrite() node.Model ЕЩЁ null!
    node.LockRead();                          //   данные появляются только после LockRead()
    surface = node.Model as Surface;          //   теперь не null (без исключения — просто null)
    surface.BeginUpdate();
    try
    {
        foreach (var p in points)
            surface.Points.Add(new SurfacePoint(new Vector3D(p.X, p.Y, p.Z)));
        // поверхность без треугольников допустима; при необходимости:
        // surface.Triangles.Add(new SurfaceTriangle { … });
    }
    finally { surface.EndUpdate(); }
}
finally { node.UnlockWrite(); }
```

### Ловушки (см. также `pitfalls.md`)

1. **`node.Model` остаётся `null` после `LockWrite()`** до вызова `LockRead()` — без исключения.
2. **`surface.Points.Add` начинается с проверки лицензии** — без лицензии «успешно» молча
   ничего не делает (видна в текущей сессии, счётчики сходятся, но данные не пишутся).
3. **`BeginUpdate()` без парного `EndUpdate()`**: запись видна в текущей сессии — но это
   нештатный режим; всегда парный вызов.
4. **`node.GetChilds()` бросает `NullReferenceException`** — оборачивать в `try/catch`.

## Обход поверхностей проекта

`[CODE]` Runoff/Robur/SurfaceAccess.cs:

```csharp
// Примечание: обход дерева файлов, а не FilterModels? — наоборот:
PluginCoreOps.FilterModels((Predicate<IProjectModel>)delegate (IProjectModel pm) { … return false; });
// или FilterOpenedModels — только открытые; имя файла:
string fileName = PluginCoreOps.GetFileName(node);
string name = string.IsNullOrEmpty(fileName) ? "(без имени)" : Path.GetFileNameWithoutExtension(fileName);
```
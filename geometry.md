# ApiNotes — Геометрия и форматирование

## Векторы — ПОЛЯ, не свойства (ловушка №1)

`[DECOMP]` `Topomatic.Cad.Foundation.dll` + `[CODE]` Runoff/Robur/VectorRead.cs:

- `Vector2D.X/Y`, `Vector3D.X/Y/Z` — **публичные поля**, НЕ свойства.
- `GetProperty("X")` молча возвращает null → вектор «нулевой», а `ToString()` выглядит здоровым.
- Касается и чтения, и **записи**: писать через `GetField(...).SetValue(obj, value)` /
  `FieldInfo.SetValue` (для boxed-структуры мутирует саму упаковку).

| API | Назначение | Статус |
|---|---|---|
| `Vector2D`, `Vector3D`, `Vector3D.Pos`, `vertex.Pos` | Точки; `.Pos` — плоская проекция | `[TUT]` |
| `new Vector2D(x, y)` | Конструктор точки плана | `[DECOMP]` |
| `Vector2D.Empty` | Пустой вектор (для out-результатов по умолчанию) | `[CODE]` Runoff/PlanProjector.cs |

## Геометрические операции

| API | Назначение | Статус |
|---|---|---|
| `ValueConverter.CoordinateToStr/LengthToStr/FloatToStr(x, digits)/AreaToStr` | Форматирование по настройкам проекта | `[TUT]` |
| `ValueConverter.CompValues(a, b)` | Сравнение координат с погрешностью | `[TUT]` |
| `CadLibrary.PolygonArea(list)` | Площадь многоугольника | `[TUT]` |
| `RectangleD.ToBoundingBox()`, `cadView.UnProjectBox(box)` | Рамка выбора → мировые координаты | `[TUT]` |
| `Polyline3D.Offset(double, list)` | Эквидистанта | `[TUT]` |
| `CadLibrary.PosToPolylineStaOffset(poly, pt, out off, out sta)` | Ста-офсет точки на линии | `[TUT]` |
| `CompoundLine.StaOffsetToPos(station, offset, out Vector2D pos)` / `PosToStaOffset(pt, out sta, out off)` | Пикетаж ↔ координаты по `alignment.Plan.CompoundLine` | `[TUT]`+`[CODE]` |
| `CompoundLine.Length` | Длина оси трассы | `[CODE]` Runoff/DitchReader.cs:59 |

## Рамки и зум

`[CODE]` Runoff/RunoffPlugin.cs:144–171:

```csharp
// BoundingBox2D не имеет пустого конструктора и Min/Max — собираем точки списком:
var box = Topomatic.Cad.Foundation.BoundingBox2D.CreateFromPoints(points.ToArray());
box.Inflate(20.0, 20.0);          // поля вокруг участка
view.ZoomBound(box, true);
```

| API | Назначение | Статус |
|---|---|---|
| `BoundingBox2D.CreateFromPoints(Vector2D[])` | Построить рамку из точек | `[CODE]` |
| `BoundingBox2D.Inflate(dx, dy)` | Поля вокруг рамки | `[CODE]` |
| `CadView.ZoomBound(BoundingBox2D, bool)` | Зум на рамку | `[CODE]` |
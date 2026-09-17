# ApiNotes — Видовой экран (CadView): слой, ввод, выбор, грипы

Основной паттерн `[TUT]`, дополнен боевым кодом `[CODE]` (Runoff/DemLoader).

## Экран и слой

| API | Назначение | Статус |
|---|---|---|
| `CadView` (свойство модуля) | Текущий видовой экран; **всегда проверять на `null`** | `[TUT]` |
| `CadViewLayer`, `PlanModelEditor.CreatePlanLayer` | Собственный слой отображения модели | `[TUT]` |
| `ModelLayer.GetModelLayer(cadView)` | Поиск своего слоя: экран → `MultiLayer` → `ResolveActive` → `CompoundLayer` | `[TUT]` |
| `CadViewLayer.OnGetLimits/OnPaint/OnHilightObject/OnDynamicDraw/OnGetSnapObjects` | Отрисовка, подсветка, привязки слоя | `[TUT]` |
| `cadView.Unlock(); cadView.Invalidate();` | Обновление экрана после изменений моделей | `[TUT]` |
| `cadView.ZoomBound(box, true)` | Зум на рамку `BoundingBox2D` (см. `geometry.md`) | `[CODE]` RunoffPlugin.cs:171 |

## Ввод от пользователя (CadCursors, `Topomatic.Cad.View.Hints`)

| API | Назначение | Статус |
|---|---|---|
| `bool CadCursors.GetPoint(CadView view, out Vector3D p, string msg)` | **bool-вариант**: точка или `false` на отмену; основная сигнатура туториалов | `[TUT]` tutorial3/4/7/8/9/10/11, TutorialEditAlignment/Module.cs:58; `[CODE]` RunoffPlugin.cs:128, DemLoader/AreaPicker.cs:37 |
| `CadCursors.GetPoint(...)` → `GetPointResult` | Другая сигнатура: `Accept`/`UserCmd`/`Cancel` (опция вместо точки), `cadView.LastUserCmd` | `[TUT]` TutorialEditSurfaceElements/Module.cs:70 |
| `CadCursors.GetDouble/GetInteger/GetString/GetBoolean/GetLength/GetFrame/GetUserSelect` | Остальные вводы | `[TUT]` |
| `bool CadCursors.GetUserSelect(CadView view, ref string value, object filter, string msg, params string[] options)` | Выбор строки из списка опций; `false` на отмену (пример: «Вся модель / Только выбранные») | `[CODE]` ExportCommand.cs:43 |
| `FrameCursor.GetFrame()` → результат типа `GetPointResult` | Ввод рамки | `[TUT]`/`[CODE]` |

⚠️ **У `GetPoint` есть обе сигнатуры** — проверяйте, какую вызываете (см. `pitfalls.md`).

## Выбор объектов (SelectionSet)

| API | Назначение | Статус |
|---|---|---|
| `SelectionSet.PickOneObjectAtScreen(pred, msg)` | Выбор одного объекта (без помещения в набор) | `[TUT]` |
| `SelectionSet.SelectObjectsAtScreen(pred, msg)` | Выбор нескольких (попадают в SelectionSet) | `[TUT]` |
| `SelectionSet.SelectOneObjectAtScreen(...)` | Выбор одного (tutorial EditAlignment) | `[TUT]` |
| `SelectionSet.SelectAll()` / `FilterSelected(pred)` | Выделить всё / отфильтровать | `[TUT]` |
| `SelectionSet.Count, Clear, Select, IsSelected, IsOwned, IsEnable, GetSelectable, Erase` | Переопределяемы для собственного набора | `[TUT]` |
| `SelectionSet.GetObjectsAtPoint(point, match, timeOut)` / `GetObjectsByFrame(mode, rect, match, action)` | Поиск по клику/рамке; `NullDeviceContext`/`FullDeviceContext` | `[TUT]` |

## Грипы редактирования

| API | Назначение | Статус |
|---|---|---|
| `SelectionSet.GetObjectGrips(obj)` | Грипы объекта (`Grip`) | `[TUT]` |
| `Grip.OnMove/OnDynamicRender`, `ClickGrip` | Перемещение/удаление вершины | `[TUT]` |
| `AddGrip("Имя", "key", g)` | Добавление грипа | `[TUT]` |

## Динамическая отрисовка

| API | Назначение | Статус |
|---|---|---|
| `cadView.DynamicDraw += DrawCursorEvent` | Подписка на отрисовку; **отписка в `finally`** | `[TUT]` |
| `DrawCursorEvent` — делегат `(CadPen pen, Vector3D vertex)` | Сигнатура события | `[TUT]` |
| `CadPen.BeginDraw()/EndDraw()/DrawLine(...)` | Рисование между Begin/EndDraw | `[TUT]` |
| `PaintEntityEventArgs.PaintEntity(entity, pen)` | Отрисовка Dwg-примитива в DynamicDraw | `[TUT]` |
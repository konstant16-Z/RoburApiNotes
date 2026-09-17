# ApiNotes — Собственная модель / редактор

## Модель и сериализация Stg

| API | Назначение | Статус |
|---|---|---|
| `StateControllerObject` + `IStgSerializable` | База модели + сериализация (`LoadFromStg`/`SaveToStg`), переопределить `ReadOnly` | `[TUT]` |
| `StgNode.AddString/GetString, AddInt32/GetInt32, AddBoolean, AddDouble` | Поля узла Stg | `[TUT]` |
| `node.AddArray(name, StgType.X)`, `node.GetArray(name, StgType.X)` | Массив; элементы: `AddString(i)`/`GetString(i)` | `[TUT]` |
| `StgDocument.LoadFromStreamAsBinary(stream)` / `SaveToStreamAsBinary(stream)` | Документ из файлового потока (бинарный) | `[TUT]` |
| `StgDocument.LoadFromFileAsXml(path)` / `SaveToFileAsXml(path)` | То же, но XML-файл (профили настроек) | `[CODE]` `RoadStyle/RoadProfileCommand.cs` |
| `doc.Body.GetNode("meta")`, `meta.GetBoolean("has_plan", false)`, `meta.AddBoolean("has_plan", v)` | Служебный узел дерева Stg | `[CODE]` |
| `alignment.Style.SaveToStg(node)` / `LoadFromStg(node)` | Стиль трассы — сохранение/загрузка напрямую | `[CODE]` |

Пример XML-профиля `[CODE]`:
```csharp
var doc = new StgDocument();
doc.LoadFromFileAsXml(path);
var meta = doc.Body.GetNode("meta");
bool hasPlan = meta.GetBoolean("has_plan", false);
// ...
var body = doc.Body;
am.Alignment.Style.SaveToStg(body.AddNode("plan_style"));
doc.SaveToFileAsXml(path);
```

## Редакторы

| API | Назначение | Статус |
|---|---|---|
| `ModelEditor` | Без планового вида: `LoadFromFile`, `SaveToFile`, `Open` → `IEditorResult` | `[TUT]` |
| `PlanModelEditor` | С плановым слоем: + `CreatePlanLayer`, `ReloadModel`, `RemovePlanLayer` | `[TUT]` |
| `IProjectModel.LockRead()/LockWrite()/UnlockWrite()` | Блокировка модели (в `try/finally`) — см. ловушку в `pitfalls.md` (Model остаётся null до LockRead) | `[TUT]`+`[CODE]` |
| `IProjectModel.Modified` | Ручной флаг модификации (когда нет undo-обёрток) | `[TUT]` |
| `PluginCoreOps.CreateModel(parent, type, name)` | Создание новой модели (ЦММ — см. `surface.md`) | `[CODE]` DemLoader/TerrainWriter.cs |
| `base.TransactionManager` / `BeginUpdate()/EndUpdate()` | Групповое изменение проекта | `[TUT]` |

## Дерево проекта (категории, поиск, обход)

| API | Назначение | Статус |
|---|---|---|
| `PluginCoreOps.CreateFolder(...)` | Категория проекта | `[TUT]` |
| `PluginCoreOps.FindModelPathId(...)`, `FindModel(model)` | Поиск модели в дереве | `[TUT]` |
| `PluginCoreOps.FilterModels(pred)` / `FilterOpenedModels(pred)` | Обход дерева/открытых моделей (предикат `IProjectModel` → bool) | `[CODE]` Runoff/SurfaceAccess.cs:43, ModelDesk/RoadModelAccess.cs:57 |
| `PluginCoreOps.GetFileName(node)` | Имя файла модели (null-safe; пустое → «(без имени)») | `[CODE]` Runoff/SurfaceAccess.cs:99 |
| `node.GetChilds()` → `IProjectModel[]` | Дети узла; **бросает `NullReferenceException`** — всегда `try/catch`, возврат null | `[CODE]` DemLoader/TerrainWriter.cs:89 |

## Отображение в инспекторе

| API | Назначение | Статус |
|---|---|---|
| `IOwned` (`Owner`) | Владение дочерним объектом; setter бросает `NotSupportedException` | `[TUT]` |
| `BaseTransactableList<T>` (`InnerList`) | Транзактируемый список с undo; загрузка пишется в `InnerList` | `[TUT]` |
| `[DisplayName(...)]`, `[Browsable(false)]`, `override ToString()` | Инспектор объектов | `[TUT]` |
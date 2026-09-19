# ApiNotes — Собственная модель / редактор

## Модель и сериализация Stg

| API | Назначение | Статус |
|---|---|---|
| `StateControllerObject` + `IStgSerializable` | База модели + сериализация (`LoadFromStg`/`SaveToStg`), переопределить `ReadOnly` | `[TUT]` |
| `StgNode.AddString/GetString, AddInt32/GetInt32, AddBoolean, AddDouble` | Поля узла Stg | `[TUT]` |
| `node.AddArray(name, StgType.X)`, `node.GetArray(name, StgType.X)` | Массив; элементы: `AddString(i)`/`GetString(i)` | `[TUT]` |
| `StgDocument.LoadFromStreamAsBinary(stream)` / `SaveToStreamAsBinary(stream)` | Документ из файлового потока (бинарный) | `[TUT]` |
| `StgDocument.LoadFromFileAsXml(path)` / `SaveToFileAsXml(path)` | То же, но XML-файл (профили настроек) | `[CODE]` RoadStyle |
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
| `PluginCoreOps.CreateModel(parent, type, name)` | Создание новой модели (ЦММ — см. `surface.md`) | `[CODE]` DemLoader |
| `base.TransactionManager` / `BeginUpdate()/EndUpdate()` | Групповое изменение проекта | `[TUT]` |

### Добавление/дублирование/перемещение модели в дереве проекта `[CODE]` (пример от Топоматик; Robur-прогон не выполнялся)

Источник — официальный пример разработки. Три операции через общую систему команд
(обёртки-хелперы сокращены до сути):

```csharp
// 1. Новая модель: путь папки — относительно файла проекта («Модели/ЦММ»);
//    подпапки и имя задаются одним filePath: «папка/подпапка/Имя.расширение»
var folder = PluginCoreOps.CreateFolder(new[] { "Модели/ЦММ" }).Uri.AsAbsoluteUri;
var node = ApplicationHost.Current.Plugins.Execute(
    Consts.FunctionAddItem,
    new object[] { folder + "/" + "Моя модель" + ".sfcx", "dtm" }) as IProjectModel;

// 2. Дубликат существующей модели (имя команды с опечаткой — «dublicate»)
var pathId = PluginCoreOps.FindModelPathId(projectModel);
var duplicate = ApplicationHost.Current.Plugins.Execute(
    "dublicate", new object[] { pathId }) as IProjectModel;

// 3. Перемещение/переименование: новый относительный путь + имя с расширением
var moved = ApplicationHost.Current.Plugins.Execute(
    "mvitem", new object[] { pathId, "Наша новая папка/Дублированная.sfcx" }) as IProjectModel;
```

- `Consts.FunctionAddItem` — константа имени команды добавления; тип и расширение
  берутся из примера для ЦММ (`"dtm"`, `".sfcx"`). **Для Rail не подтверждены**:
  сначала прочитать `ModelType` и расширение существующей ж/д модели
  (`node.ModelType`, `PluginCoreOps.GetFileName(node)`).
- Для создания новой пустой Rail-модели путь: `FunctionAddItem` с типом Rail,
  а не `dublicate` (копирует содержимое) и не `new RailAlignment()`.
- Активную модель брать штатно: `PlanModelEditor.FindActiveModel(project, out bool ro)`.
- Изменения дерева — внутри `project.TransactionManager.BeginUpdate()/EndUpdate()`
  (try/finally); результаты `Execute` проверять на null.

## Дерево проекта (категории, поиск, обход)

| API | Назначение | Статус |
|---|---|---|
| `PluginCoreOps.CreateFolder(...)` | Категория проекта | `[TUT]` |
| `PluginCoreOps.FindModelPathId(...)`, `FindModel(model)` | Поиск модели в дереве | `[TUT]` |
| `PluginCoreOps.FilterModels(pred)` / `FilterOpenedModels(pred)` | Обход дерева/открытых моделей (предикат `IProjectModel` → bool) | `[CODE]` Runoff, ModelDesk |
| `PluginCoreOps.GetFileName(node)` | Имя файла модели (null-safe; пустое → «(без имени)») | `[CODE]` Runoff |
| `node.GetChilds()` → `IProjectModel[]` | Дети узла; **бросает `NullReferenceException`** — всегда `try/catch`, возврат null | `[CODE]` DemLoader |

### Обход дерева через `IProjectModel` (`[CODE]` robur-mcp)

| API | Назначение | Статус |
|---|---|---|
| `ApplicationHost.Current.ActiveProject as ModelProject`, `.Model` → `IProjectModel` | Корневая модель активного проекта | `[CODE]` |
| `model.Uri` → `URI`, `model.Uri.AsAbsoluteUri` → string | Абсолютный URI узла | `[CODE]` |
| `model.ModelType` → string | Тип узла (строка, см. ниже) | `[CODE]` |
| `model.GetChilds()` → `IEnumerable<IProjectModel>` | Дети узла | `[CODE]` |
| `model.Project` → проект; `project.Model` → `IProjectModel` | Проект-владелец модели | `[CODE]` |
| `project.BeginUpdate()` / `project.EndUpdate()` + `projectModel.Remove(model, false)` | Удалить элемент проекта (в `try/finally`) | `[CODE]` |
| `ApplicationHost.Current.Plugins.Execute("getname", new object[] { model })` → string | Имя модели/элемента проекта | `[CODE]` |

```csharp
var appHost = ApplicationHost.Current;
var project = appHost.ActiveProject as ModelProject;
var projectModel = project.Model;                       // IProjectModel
string name = appHost.Plugins.Execute("getname", new object[] { projectModel }) as string;
foreach (var child in projectModel.GetChilds())         // IProjectModel
{
    string type = child.ModelType;                      // "road", "dtm", "culvert", ...
    string uri  = child.Uri.AsAbsoluteUri;
}
```

**Значения `ModelType`, встречающиеся в robur-mcp** (`[CODE]`):
`folder`, `dtm` (поверхность), `road` (автодорога), `survey` (изыскательская/геологическая
трасса), `global_glg` (геология), `culvert` (водопропускная труба),
`application/dwg` (чертёж), `application/culvert-dwl` (динамический чертёж трубы).
Проверять тип лучше по строке, а не приводить к типу без проверки.

## Отображение в инспекторе

| API | Назначение | Статус |
|---|---|---|
| `IOwned` (`Owner`) | Владение дочерним объектом; setter бросает `NotSupportedException` | `[TUT]` |
| `BaseTransactableList<T>` (`InnerList`) | Транзактируемый список с undo; загрузка пишется в `InnerList` | `[TUT]` |
| `[DisplayName(...)]`, `[Browsable(false)]`, `override ToString()` | Инспектор объектов | `[TUT]` |
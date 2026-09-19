# ApiNotes — Водопропускные трубы (Topomatic.Culverts)

Единственный источник — боевой плагин `[CODE]`
robur-mcp (публичный репозиторий
`github.com/topomatic-code/robur-mcp`, .NET Framework 4.8). Имена типов и сигнатуры
подтверждены монодизассемблированием `Topomatic.Culverts.dll`
(16.0.62.x) и `Topomatic.Tables.dll`.

## Сборки и пространства имён

| Сборка | Пространство имён | Типы |
|---|---|---|
| `Topomatic.Culverts.dll` | `Topomatic.Culverts` | `Culvert`, `ICulvertContainer`, `Construction`, `Place`, `Prism`, `Reconstruction`, `Restrictions` |
| `Topomatic.Culverts.dll` | `Topomatic.Culverts.Sheets` | `SheetContext`, `VariableInfo`, `SheetTableNames`, `TableInfo`, `ColumnInfo`, `SpecificationData` |
| `Topomatic.Culverts.dll` | `Topomatic.Culverts.Specifications` | `SpecificationType`, `ComponentSpecification` |
| `Topomatic.Tables.dll` | `Topomatic.Tables.Sheets` | `RowData`, `ContextTag`, `ColumnContextTag` |

## Доступ к модели трубы

Модель трубы берётся из дерева проекта по `uri` (элемент с `ModelType == "culvert"`
или `"application/culvert-dwl"`, см. `model-editor.md`) и оборачивается в контейнер
через `PluginCoreOps` (как и другие модели платформы):

```csharp
var culvertModel = node.Model;                                     // IProjectModel
var container = PluginCoreOps.LockReadContainer<ICulvertContainer>(culvertModel);
var culvert = container.Culvert;                                   // Topomatic.Culverts.Culvert
```

| API | Назначение | Статус |
|---|---|---|
| `PluginCoreOps.LockReadContainer<T>(model)` → `T` | Обернуть модель в контейнер `ICulvertContainer`; `null`, если тип не совпал | `[CODE]` |
| `ICulvertContainer.Culvert` → `Culvert` | Модель трубы | `[CODE]` |
| `Culvert.SheetContext` → `SheetContext` | Ведомости/параметры трубы | `[CODE]` |
| `Culvert.Construction` → `Construction` | Конструкция (спецификации, сечения) | `[CODE]` |
| `Culvert.Place`, `Culvert.Prism`, `Culvert.Reconstruction`, `Culvert.HoleCount`, `Culvert.Diameter`, `Culvert.Material`, `Culvert.HoleType` | Прочие свойства модели | `[CODE]` |

⚠️ Как и любая модель платформы, `LockRead`/`LockWrite` парный; `node.Model` после
`LockWrite` может быть `null` до `LockRead` (см. `pitfalls.md`).

## Параметры (`SheetContext`)

```csharp
var ctx = culvert.SheetContext;
for (int i = 0; i < ctx.VariablesCount; i++)
{
    VariableInfo v = ctx.GetVariable(i);
    string value = ctx.GetValue(v.Value);   // v.TableId, v.Name, v.Description, v.Value
}
```

| API | Назначение | Статус |
|---|---|---|
| `SheetContext.VariablesCount` → int | Число переменных (параметров) | `[CODE]` |
| `SheetContext.GetVariable(int index)` → `VariableInfo` | Параметр по индексу | `[CODE]` |
| `SheetContext.GetValue(string expression)` → string | Значение по выражению `VariableInfo.Value` | `[CODE]` |
| `SheetContext.UseVolumesTable` → bool | Есть ли ведомость объёмов | `[CODE]` |
| `SheetContext.UseCustomSpecs` → bool | Пользовательские спецификации (`SPECIFICATION_1/2`) или стандартные | `[CODE]` |
| `SheetContext.CreateDataset(string tableId)` → `List<RowData>` | Данные таблицы по идентификатору | `[CODE]` |

`VariableInfo` — поля: `TableId` (группа таблицы), `Name`, `Description`, `Value`
(выражение для `GetValue`). Группировать параметры принято по `TableId`.

## Спецификации

```csharp
if (ctx.UseCustomSpecs)
{
    ctx.CreateDataset(SheetTableNames.SPECIFICATION_1);
    ctx.CreateDataset(SheetTableNames.SPECIFICATION_2);
}
else
{
    culvert.Construction.CreateSpecificationDataset(
        SheetTableNames.SPECIFICATION, SpecificationType.NewConstruction);
    culvert.Construction.CreateSpecificationDataset(
        SheetTableNames.LEFT_DISMANTLING_SPEC, SpecificationType.LeftDismantle);
    culvert.Construction.CreateSpecificationDataset(
        SheetTableNames.RIGHT_DISMANTLING_SPEC, SpecificationType.RightDismantle);
}
```

| API | Назначение | Статус |
|---|---|---|
| `Construction.CreateSpecificationDataset(string tableId, SpecificationType specType)` → `List<RowData>` | Набор строк спецификации | `[CODE]` |
| `SpecificationType.NewConstruction` = 0 | Новая конструкция | `[DECOMP]` |
| `SpecificationType.LeftDismantle` = 1 | Демонтаж слева | `[DECOMP]` |
| `SpecificationType.RightDismantle` = 2 | Демонтаж справа | `[DECOMP]` |

## Чтение таблиц (`RowData`)

`RowData` — абстрактная база строки таблицы; конкретные строки дают `SheetContext`
и `Construction`.

| API | Назначение | Статус |
|---|---|---|
| `RowData.Id` → string | Идентификатор строки | `[DECOMP]` |
| `RowData.GetContextsTags()` → `IEnumerable<ContextTag>` | Колонки-контексты строки | `[DECOMP]` |
| `ContextTag.m_Tag` / `ContextTag.m_Description` | **Публичные поля**: тег и подпись колонки | `[DECOMP]` |
| `RowData.TryGetValue(string name, out string value)` → bool | Значение по тегу | `[DECOMP]` |
| `RowData.GetColumns(string columnContextTag)` → `TableColumnValue[]` | Колонки контекста | `[DECOMP]` |
| `RowData.GetFunctions()` → `IEnumerable<DieselContextFunction>` | Функции строки (Diesel) | `[DECOMP]` |

Паттерн чтения таблицы (первая строка задаёт набор колонок, значения — по тегам):

```csharp
var dataset = ctx.CreateDataset(SheetTableNames.VOLUMES_TABLE);
if (dataset.Count > 0)
{
    var tags = dataset[0].GetContextsTags().ToArray();
    foreach (var row in dataset)
        foreach (var tag in tags)
            if (!row.TryGetValue(tag.m_Tag, out string value)) value = "-";
}
```

## Идентификаторы таблиц (`SheetTableNames`)

`public static literal string`-константы (`[DECOMP]`):

| Константа | Значение |
|---|---|
| `VOLUMES` / `VOLUMES_TABLE` | `"Volumes"` / `"VolumesTable"` |
| `TOTAL_VOLUMES_TABLE` | `"TotalVolumesTable"` |
| `GENERAL` | `"General"` |
| `SPECIFICATION` / `SPECIFICATION_1` / `SPECIFICATION_2` | `"Specification"` / `"Specification_1"` / `"Specification_2"` |
| `LEFT_DISMANTLING_SPEC` / `RIGHT_DISMANTLING_SPEC` | `"LeftDismantlingSpec"` / `"RightDismantlingSpec"` |
| `MONOLITHIC_STREN_VOLUMES`, `P1_STREN_VOLUMES`, `GABION_STREN_VOLUMES`, `ROCK_STREN_VOLUMES` | объёмы по типам укрепления |
| `CUSTOM_STREN_COMBINED_VOLUMES`, `CUSTOM_STREN_DETAILED_VOLUMES`, `CUSTOM_STREN_TOTAL_VOLUMES` | пользовательские укрепления |

## Ловушки

- `ICulvertContainer` возвращает `PluginCoreOps.LockReadContainer`, а не приведение
  `as` — несовпадение типа даёт `null` без исключения, проверяйте результат.
- `SheetContext.GetValue` принимает **выражение** из `VariableInfo.Value`, а не имя.
- `UseVolumesTable == false` / `UseCustomSpecs == false` — соответствующие датасеты
  запрашивать нельзя (в коде robur-mcp они под `if`).

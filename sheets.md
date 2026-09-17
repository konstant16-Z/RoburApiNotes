# ApiNotes — Ведомости и поля шаблонов

Все паттерны `[TUT]` (TutorialFields/TutorialSheets).

## Ведомости

| API | Назначение |
|---|---|
| `TemplateStationingSheet`, `TemplateSheet`, `TemplateSheetSymbols` | База ведомости |
| `TableConsts.TABLES_SHEET_FUNCTION` (через `Plugins.Execute`) | Запуск мастера ведомостей |

## Форматирование и диапазоны

| API | Назначение |
|---|---|
| `TablesExtensions.FloatToStr(...)` | Форматирование чисел ведомости |
| `AlignmentValueConverter.StationInLimits(sta, sta1, sta2, b1, b2)` | Проверка пикета в диапазоне |

## Регистрация полей шаблона

| API | Назначение |
|---|---|
| `TemplateFieldProvider.Provide(processor)` | Провайдер полей |
| `RegisterFieldAlias(alias, type, name)`, `desc.Add("Prop")` | Регистрация тега поля |
| `TypeExplorer.GetSerializableString(typeof(...))` | Сериализуемое имя типа поля |
| `PrfField` / `CrsField`, `DataManager["ActiveTransition"]` / `DataManager["Alignment"]` | Поле профиля/поперечника |
| `BeginMockup(key, pos)/EndMockup()`, `GenerateSimpleKey(...)`, `ScaleStation/ScaleOffset` | Макет поля |
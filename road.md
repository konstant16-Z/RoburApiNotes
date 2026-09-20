# ApiNotes — Дорожная трасса (Road / Topomatic.Alg)

> Общий каркас (`Alignment`, `Plan`, `Transitions`, `Corridor` и т.д.) описан в `alignment.md`.
> Здесь — только **дорожная специфика** (`RoadAlignment`, `RoadPlan` и т.п.) из `Topomatic.Alg.dll` / `Topomatic.Alg.Road.dll`.

---

## Базовый класс `RoadAlignment`

`[DECOMP]` `Topomatic.Alg.Road.dll` (`Topomatic.Alg.Road.RoadAlignment` — наследник `Alignment`):

- Всё необходимое для чтения/записи модели — на базовом `Alignment` (см. `alignment.md` §«Базовый класс `Alignment`»).
- Тип пути определяется по имени типа (`Road is RoadAlignment` — канон Runoff, не через `Topomatic.Alg.Rail`).
- Специфичные свойства в документации частично недокументированы API; подтвержденные данные — декомпиляция `Topomatic.Alg.Road.dll` (класс `RoadAlignment` наследует `Alignment` с минимальными дополнениями: `Clear()`, `LoadFromStg`, `SaveToStg`, `GetSectionStations()`, `TryGetValue(station, out value)` и др.).

```csharp
// Определение типа пути без ссылок на Rail
if (alignment is RoadAlignment) { /* автодорога */ }
else if (alignment is RailAlignment) { /* ж/д */ }
```

---

## План дороги (`PlanLine` — общий, дорожные особенности)

План (`alignment.Plan`) — `PlanLine` из `Topomatic.Alg.Plan`. Для дорожной трассы:
- `PlanLine.Vertex` содержит геометрию углов поворота (`P`, `Beta`) и параметры кривых (`L1`, `R`, `K`, `L2`).
- Запись с нуля — см. `alignment.md` §«Запись плана с нуля». После `plan.Add(v)` **обязателен** `CompoundLine` (через `plan.CompoundLine` геттер), иначе `PlanVertexesValid=False` и клики по слою падают NRE.
- `PlanLineSolver.PlanVertexesValid(plan)` — валидация геометрии дорожного плана.

---

## Поперечники (`Corridor` / `Section`)

`[DECOMP]` `Topomatic.Alg.Crs` — общий, подтверждено декомпиляцией `Topomatic.Alg.dll` (см. `alignment.md` §«Поперечники»):

- `alignment.Corridor.Sections` — все секции.
- `SectionList.Add(double station)` — создание секции по пикету; `Section.Station` (internal set) задаётся при вставке.
- `Section.ConstructionId` — публичный set; используется для привязки к конструкции (`corridor.Constructions`).
- `CreateDesignContext(station, BuildMode[, listener[, clip]])` — контекст дизайна секции.

---

## Параметры трассы (`Parameters` / `AlignmentParameters`)

Общая таблица параметров (`alignment.Parameters`) описана в `alignment.md`.
Дорожные специфические дескрипторы (подтверждено экспортёром/импортёром `[CODE]`):

| Дескриптор (ключ) | Назначение | Примечание |
|---|---|---|
| `LEFT_FLAGS` / `RIGHT_FLAGS` | Флаги кювета/откоса (бит 2 = `SLOPE_FLAG_USE_DITCH_PROFILE`) | Проверка через `HasFlag` |
| `DYNAMIC_LEFT_HK` / `DYNAMIC_RIGHT_HK` | Динамические откосы | Прочие ключи через `GetStationParams` |
| `LOFFSX0` / `LOFFSY0` / `ROFFSX0` / `ROFFSY0` | Смещения левой/правой бровки | Читаются через `GetStationParams<object>` |
| `TRAY_HEIGHT_*` / `TRAY_*` | Параметры лотков | Табличные (`DoubleParameter`) |

Метод: `road.Parameters.GetStationParams<object>(station)` — универсальный доступ ко всем параметрам на пикете (см. пример в `alignment.md`).

---

## Интенсивности движения (`Intensities` / `Intensity`) — write-API

`[DECOMP]` `Topomatic.Alg.Road.dll`, namespace `Topomatic.Alg.Road.Intensities`
(web-спр. `developers:references:topomatic.alg.road.intensities`, typedef дампа
`IntensitiesCollection.flist=1720» — класс **дорожный** (`RoadAlignment`), в Ж/Д
его нет):

- `road.Intensities` → `IntensitiesCollection : UpdatableObject, IList<Intensity>`.
  Публичные члены (декомпилировано):
  - `Count`, индексатор `Item[int] {get set}`, `Clear()`, 
  - `Add(Intensity) → void`, `Remove(Intensity) → bool`, `Insert/RemoveAt/IndexOf`,
  - `get_Alignment` (IAlignmentContainer), 
  - `Owner` (`IOwnedCollection` = владелец-связка, транзактабельный),
  - `LoadFromStg(StgNode)` / `SaveToStg(StgNode)` (канон `Owner ∈ IOwnedCollection`).
- Элемент `Intensity : UpdatableObject, IStgSerializable`:
  - **`Station`** (double) — пикет; уровень — узел-владелец `road.Intensities`
    → `Station` задаётся через `Item[station]` или `Add(новый Intensity(...))`;
  - `SaveToStg(StgNode)` / `LoadFromStg(StgNode)` — та же STG-пара «зелёный лист».

Паттерн записи (пишем перезаписью, как таблицы M4 из `rail.md`):
```csharp
var ints = alignment.Intensities;         // RoadAlignment
ints.BeginUpdate();
try
{
    ints.Clear();
    ints.Add(new Intensity(axis.Station, 850));   // пример: пикет, интенсивность
}
finally { ints.EndUpdate(); }
```

⚠ **Ловушка**: в **дорожном** `Alignment.Intensities` сериализуется через
`Kilometres`/`ProjectIntensities` как отдельная коллекция (`IntensitiesCollection`
у каждой оси), НЕ в составе `Parameters`-таблиц дороги — см. `road.Parameters`
§выше. В Ж/Д (`rail.md`) соответствующей коллекции нет.

---

## Километраж (`Kilometres` / `AlgAlignmentKilometres`)

Базовый километраж (`alignment.Kilometres`) — общий; дорожные особенности формата:
- `StartStation` (double) — база километража (эталон 1000.0); отдельно от `alignment.StartStation` (0.0 — пикетажный сдвиг оси).
- `SimpleKilometres` (bool) — простой (`ToKm`/`FromKm`) или секторный.
- Формат JSON: `kilometres.json` (`StartStation`, `SimpleKilometres`, `items[]` при явных секторах).
- Импорт/экспорт подтвержден round-trip (`[TEST]` 2026-09-11).

---

## Станционирование (`Stationing` / `AlgStationing`)

Общий (`Topomatic.Alg.Stationing.AlgStationing`), описан в `alignment.md`.
Для дороги используются конвертеры фактический ↔ условный пикетаж (`PkToStation`, `ToPk` и т.д.) — применяются при экспорте/импорте для MCP-сервера.

---

## Ссылки к `alignment.md`

- Базовый `Alignment` — `alignment.md` §«Базовый класс `Alignment`».
- План (`PlanLine`) — `alignment.md` §«План (PlanLine)».
- Профили (`Transitions`) — `alignment.md` §«Профили (Transitions / Transition)».
- Поперечники (`Corridor`) — `alignment.md` §«Поперечники — Corridor / SectionList / Section».
- Параметры (`Parameters`) — `alignment.md` §«Параметры трассы (`Parameters` / `AlignmentParameters`)».
- Километраж (`Kilometres`) — `alignment.md` §«Километраж (`Kilometres` / `AlgAlignmentKilometres`)».
- Станционирование (`Stationing`) — `alignment.md` §«Станционирование (`Stationing` / `AlgStationing`)».

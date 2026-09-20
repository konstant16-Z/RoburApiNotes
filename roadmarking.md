# ApiNotes — Дорожная разметка (`RoadMarking` / Topomatic.RoadMarking)

> Здесь — **only разметка дорог** (write-паттерны пакета
> `Topomatic.RoadMarking.dll` / `Topomatic.RoadMarking.Entities.dll`:
> линейная `DwgLinearRoadMarking`, пешеходный переход `DwgPedestrianCrossingMarking`,
> построители геометрии `AreaBuilder`/`ArrowsBuilder`/`DashedBuilder`, enum
> `CrossingType`).
>
> Не путать: **ж/д путь** — `alignment.md`/`rail.md`; **дорожные знаки ПДД** —
> `roadsigns.md`; здесь — **только разметка** (линии, переходы, стрелки).

---

## Корень write-модели — классы разметки (`[DECOMP]` monodis
`Topomatic.RoadMarking.dll`, typedef; write-наборы — `[TUT]` веб-справка
`topomatic.roadmarking.entities.dwglinearroadmarking`/`.dwgpedestriancrossingmarking`)

```csharp
Topomatic.RoadMarking.Entities.DwgLinearRoadMarking            // [DECOMP]: typеdef (класс разметки)
Topomatic.RoadMarking.Entities.DwgPedestrianCrossingMarking     // [DECOMP]: typеdef (пешеходный переход)
Topomatic.RoadMarking.Entities.CrossingType                    // [DECOMP]+[TUT]: enum (см. ниже)
```

## Выделенный enum — `CrossingType` ([TUT]+[DECOMP])

`Topomatic.RoadMarking.Entities.CrossingType` — тип перехода:

| Член enum | Значение |
|---|---|
| `BicycleCrossing` | велосипедная дорожка |
| `PedestrianCrossing` | пешеходный переход |

---

## Write-паттерн (линейная разметка, M4-свободная — элемент чертежа плана)

[`DwgLinearRoadMarking`][rs:linear] — write-элемент плана: `[TUT]`-набор
методов (веб `topomatic.roadmarking.entities.dwglinearroadmarking`):

| Метод/свойство | Роль |
|---|---|
| `Add(...)` / `Remove(...)` / `RemoveAt(...)` / `Insert(...)` | правка вершин разметки |
| `Clear()` | очистка |
| `GetEnumerator()` / `get_Item` | перечисление элементов |
| `AssignPolyline(...)` | замена геометрии полилинией |
| `BreakEntity(...)` / `Contains(...)` / `IntersectWith(...)` / `CopyTo(...)` | операции над линией |
| `GetCenterPoint()` / `GetEndPoint()` / `GetMiddlePoint()` / `GetPolyline()` | геометрия |
| `LoadFromStg(StgNode)` / `SaveToStg(StgNode)` | Bin-сериализация |

⚠ **Ловушка уровня II (write-путь через чертёж, а НЕ таблицу M4)**:
пешеходный переход — `DwgPedestrianCrossingMarking` ([TUT]:
`get_Length`, `get_Rotation`, веб `topomatic.roadmarking.entities.
dwgpedestriancrossingmarking.length` / `.rotation`), т.е. **двумерный элемент
чертежа**: привязка позиция+угол+масштаб (пикет/смещение — см. `road.md`
§«План»), НЕ запись в таблицу-коллекцию оси. Пишите переход как
элемент плана/поперечника (паттерн «знак/переход на пикете» — `roadsigns.md`
+ `road.md` §«План и поперечники»).

---

## Построители геометрии (`[DECOMP]`+`[TUT]`)

`Topomatic.RoadMarking.Builders` — создают геометрию разметки из параметров:

- `AreaBuilder` — площадная разметка (островки);
- `ArrowsBuilder` — стрелки направления;
- `DashedBuilder` — пунктирные линии.

Паттерн: построитель берёт параметры (паттерн-«вход»), создаёт
`BuilderData`-геометрию, затем пишет её как элемент плана (см. выше).
Изменения геометрии — внутри `BeginUpdate()/EndUpdate()` владельца-чертежа
(канон M4), см. `road.md` §«План».

---

## Не смешивать

1. `RoadSigns` (`Topomatic.RoadSigns.dll`) — дорожные знаки **ПДД**;
   разметка пешеходных переходов/островков — **здесь**.
2. `Road.Alignment`/`road.md` — дорожный план, поперечники, интенсивности;
   здесь — только разметка как **write-элемент чертежа**.
3. `Topomatic.RoadMarking.dll` содержит `.Entities` (модель-классы, написаны
   выше) и `.Design` (PropertyGrid-редакторы/атрибуты — НЕ модель, повторяем
   конвенцию `roadsigns.md` §«Design»).

---

## Ссылки

- `roadsigns.md` — дорожные знаки ПДД (`RoadSignData`, IStgSerializable);
- `road.md` §«План и поперечники» — позиционирование разметки/знака на
  пикете (элемент чертежа, без отдельной write-таблицы M4);
- `alignment.md` §«Условные знаки» — ж/д `ConventionalSign` (другой тип).

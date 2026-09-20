# RoadSigns — Дорожные знаки (Topomatic.RoadSigns.dll)

> [DECOMP]: monodis Topomatic.RoadSigns.dll (Bin 16.0.6x, Development/Out/Bin)
> + TUT: веб-страница developers:references:topomatic.roadsigns.roadsigndata

RoadSignData — МОДЕЛЬ дорожного знака (bin-serializable, IStgSerializable),
НЕ таблица/пример. Условные знаки ж/д — в alignment.md (ConventionalSign).
Знаки дорожные ПДД — здесь.

## Свойства (веб, [TUT]; get_/set_ подтверждены [DECOMP])

| Свойство | Тип | Статус |
|---|---|---|
| Angle | double | [TUT]+[DECOMP] |
| Guid | System.Guid | [TUT]+[DECOMP] |
| InsPos | Vector2D | [TUT]+[DECOMP] |
| IsTemp | bool | [TUT]+[DECOMP] |
| Name | string | [TUT]+[DECOMP] |
| Number | string | [TUT]+[DECOMP] |
| Scale | double | [TUT]+[DECOMP] |

## Методы (write; [DECOMP] — монодис-группа; совпадает с [TUT])

| Метод | Сигнатура | Статус |
|---|---|---|
| Конструктор | RoadSignData() | [TUT]+[DECOMP] |
| Assign | void Assign(RoadSignData source) | [TUT]+[DECOMP] |
| LoadFromStg | void LoadFromStg(StgNode node) | [TUT]+[DECOMP] |
| SaveToStg | void SaveToStg(StgNode node) | [TUT]+[DECOMP] |

## Write-паттерн (паттерн IStgSerializable; НЕ M4-таблица)

RoadSignData — IStgSerializable (не UpdatableObject): нет BeginUpdate/EndUpdate,
нет Clear, нет Add/Remove. Прямой write-путь:

```csharp
var sign = new RoadSignData();          // [TUT]: пустой ктор
sign.Assign(source);                    // [TUT]+[DECOMP]: копирование из эталона
// затем:
sign.SaveToStg(node);                   // [TUT]+[DECOMP]: bin-запись в StgNode
```

## Стойка знака на плане (`DwgRoadSignStand`) — write-элемент чертежа, НЕ модель

Отдельная от `RoadSignData` сущность плана — стойка (стойка-труба/стойка-опора),
на которую вешаются знаки. `[DECOMP]` (monodis typedef, row 16): `Topomatic.RoadSigns.DwgRoadSignStand`
(`flist=13, mlist=67, extends=0x8d`). НЕ таблица M4 — это `DwgEntity` чертежа,
позиционируется как «знак на пикете» (см. `road.md` §«План» и `alignment.md`
§«План»): пикет + смещение + угол.

Write-факт из веб-дампа ([TUT]; страницы `topomatic.roadsigns.dwgroadsignstand.*` —
уникальные имена, 68 шт.), честно только ДОКУМЕНТИРОВАННЫЕ имена (не выдумывал):

| Имя (страница) | Роль (по контексту страницы) |
|---|---|
| `baseinspos` | базовая точка вставки стойки |
| `angletower` / `defaultangletower` | угол поворота стойки / значение по умолчанию |
| `heighttower` / `defaultheighttower` | высота стойки / по умолчанию |
| `defaultdiametertower` | диаметр стойки по умолчанию |
| `allsignsscale` | общий масштаб знаков на стойке |
| `addroadsign` / `changesign` / `alignsigns` | добавление/замена/выравнивание знака на стойке |
| `movesigndown` / `movesign` | смещение знака по стойке |
| `const_footlength` / `const_heighttower` / `const_spacesize` | константы-параметры стойки |

Ловушка (уровень II): `DwgRoadSignStand` — **чертёжный элемент** (`DwgEntity`
+ stg-сериализация, есть `OnSaveToStg`/`OnLoadFromStg`), а НЕ `UpdatableObject`
и НЕ `RoadSignData`. Позиционирование знака на плане/поперечнике — паттерн
«знак на пикете» (`road.md` §«План»), как и дорожные знаки ПДД — write-элемент,
а не таблица-интенсивность M4.

## Ловушки

1. **НЕ писать знак как таблицу M4**: RoadSignData — IStgSerializable,
   т.е. сериализованный объект, а не UpdatableObject. Нет Clear()/BeginUpdate.
2. **Привязка на пикет** — знак на плане/поперечнике (позиция InsPos + угол
   Angle), путь «знак на пикете» описан в road.md §«План» и alignment.md
   §«Установка знака». Здесь — только write-модель знака RoadSignData.
3. **RoadSigns.Design** (.Design namespace) — редакторы/атрибуты PropertyGrid
   (53 веб-страницы), NOT write-модель; никаких выдуманных членов.

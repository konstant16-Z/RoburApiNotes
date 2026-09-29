# `.railx` — контейнер чертежа ситуации + трассы

Файл `.railx` — это **не** `Topomatic.Alg`-структура, а **контейнер SFCX**, внутри
которого лежит **один BSTG-документ чертежа** с двумя независимыми ветвями: чертёж
ситуации и модель трассы.

Структура и содержимое разобраны `[DECOMP]` по `Topomatic.Stg.dll` / `Topomatic.Sfc.dll`
(снимки IL — `Tools/IL/`, декомпиляции — `Tools/Decomp/`) и сверены на реальных файлах,
записанных Robur `16.0.62.12` (`Situation/@.Version`), из `Dop/railx/*.railx`. Практический
читатель (SFCX + BSTG → dict-дерево) — локальный RE-инструмент `~/robur-re/robur_native`,
в репозиторий не входит; в самих примерах ниже вызывается `robur_native.read()` +
`stg.node_to_obj()`.

> В репозитории лежат **два** разных файла с именем `53.railx`:
> `Dop/53.railx` (19 075 Б, `stg_len` 19 007, `name_count` 548) и `Dop/railx/53.railx`
> (19 110 Б, `stg_len` 19 042, `name_count` 552). **Декодированное BSTG-тело у них
> идентично** (та же ось, тот же `ModelUID`, `PlanVertexes[].ID = 1,2`, 24 слоя) —
> расходятся только 4 лишних записи в пуле имён и выравнивание. Эталон в §3 —
> `Dop/railx/53.railx` ↔ `Dop/railx/531.railx`.

Смежные документы: формат контейнера SFCX — [`surface.md`](surface.md) §«Формат SFCX»;
модель трассы и BSTG-ключи — [`alignment.md`](alignment.md), [`rail.md`](rail.md);
сущности чертежа/слои/блоки — [`dwg.md`](dwg.md); границы и `ModelUID` —
[`landallotment.md`](landallotment.md) §«Новый механизм — модуль `Topomatic.Borderline`».

---

## 1. Контейнер

Формат **тот же**, что у `.sfcx` (см. `surface.md`): сигнатура `'SFCX'`, `version = 4`,
защитный префикс (guard), геометрическая секция, затем BSTG по смещению.

| Поле | `53.railx` (19 110 Б) | `531.railx` (27 205 Б) |
|---|---|---|
| `size` | 19 110 | 27 205 |
| `version` / `geometry_version` | 4 / 4 | 4 / 4 |
| `stg_off` / `stg_len` | 64 / 19 042 | 64 / 27 137 |
| `guard` | 0 | 0 |
| геометрия (`points/triangles/lines/groups/patches`) | **пусто (0)** | **пусто (0)** |
| BSTG `name_count` | 552 | 722 |
| BSTG `version` / `codepage` | 2 / 65001 | 2 / 65001 |

**Важно:** геометрическая секция SFCX в `.railx` **пуста** — ни точек, ни треугольников.
Вся графика чертежа лежит в BSTG-ветке `Situation` (сущности `DwgEntity` со своей
полилайновой геометрией), а не в SFCX-поверхности. То есть SFCX-обёртка в `.railx`,
по всей видимости, нужна только ради единого загрузчика Robur, а не ради
`.sfcx`-поверхности.

Читается без Robur:
```python
import robur_native, robur_native.stg as stg   # локальный RE-инструмент ~/robur-re
doc = robur_native.read('53.railx')              # SFCX-заголовок + байты BSTG
body = stg.node_to_obj(doc['stg']['body'])      # → dict-дерево
```

---

## 2. BSTG-тело документа (корень)

```
Seeds          — Node(3)   счётчики handle-сидов (см. §5)
Situation      — Node(11)  чертёж ситуации
LayersLinks    — Array[N]  привязка StandardName → LayerId  (корень документа, НЕ внутри Situation)
Style          — Node      стили отрисовки (Common/Horizontals/Points/Inclinations/Contours/…)
Alignment      — Node      модель трассы
```

`Situation` (в порядке сериализации):
`Version`, `HandleSeed`, `Database`, `DimensionStyle`, `DisplayLineweight`,
`Collections[16]`, `Styles`, `Linetypes`, `Layers[N]`, `MLineStyles`,
`DimensionStyles`, `TableStyles`, `Filters`, `Classes`, `Blocks`, `Layouts`.

`Alignment` — **то же**, что и в модели трассы: `Plan`, `Sections`, `Stationing`,
`Transitions`, `Style`, `Parameters`, `Kilometres`, `EgSurfaces`, `Plugins`,
`ReconstructionData`, `ExistPermanentWay`/`ProjectPermanentWay`, `Model3DElementContext`, …
Соответствие BSTG-ключей ↔ свойств .NET — таблица в `alignment.md` §«Соответствие ключей».

> Чистый `.dwp` — это **тот же самый чертёж без обёртки**: корень BSTG = сам drawing
> (`Collections, Styles, Linetypes, Layers, MLineStyles, DimensionStyles, TableStyles,
> Filters, Classes, Blocks, Layouts`), без узлов `Situation`/`Alignment`/`Seeds`.
> Что физически лежит в этих коллекциях (цвет слоя, рисунок лайтайпа, имя шрифта) —
> `dwg.md` §«Физическое хранение в `.dwp`».

---

## 3. Эталонное сравнение: `53.railx` vs `531.railx`

Два файла — **одна и та же ось**, сохранённая в разное время. Разбор сведён к
сравнению значений (без обфусцированных имён-констант) — см. §7, п.3:

### 3.1 Что идентично

| Раздел | Результат |
|---|---|
| `Plan.PlanVertexes` | равны по всем полям, кроме `ID`: `1,2` → `13,14` (координаты/пикеты/имена «НТ»/«КТ» совпадают) |
| `Kilometres`, `Sections`, `Stationing`, `Transitions`, `EgSurfaces`, `ReconstructionData`, `Parameters` | идентичны |
| `Style` (корень) | идентичен |
| `Seeds`, `Situation/{Styles, Linetypes, MLineStyles, DimensionStyles, TableStyles, Filters, Classes, Collections, Layouts}` | идентичны целиком |
| `Situation.Blocks` | 5 блоков с теми же именами/handle (31/55/58/61/64), теми же `StandardName` в текстах (`%vn%`, `%vo%`, `%vn% %vo%`, `%number%`) |
| Геометрия `GeometryData.VisibleBoundaries` | равна (та же лента ±2 м вокруг оси, 5 точек) |
| Слои 9, 42…54, 75…84 | идентичны (24 общих) |
| `Plugins` — 8 общих | идентичны |

### 3.2 Что изменилось

| | `53.railx` | `531.railx` | Комментарий |
|---|---|---|---|
| `Alignment.Plugins` | 8 узлов | **14** | добавлены `CrsClearencePlugin`, `DynamicGeology`, `Ecs`, `Opr`, `Platform`, `SlopeStability` — узлы модулей, созданных в 16.0.62; часть с настройками по умолчанию (`Ecs.Id` = свой Guid, `SlopeStability.Options` = дефолт), `Opr`/`Platform` — только `VisualEmpty` |
| `Situation.Layers` | 24 | **32** | +`86` «Проектные откосы», +`96`…`102` (отвод земель ×3, МЦС ×4) |
| `LayersLinks` | 21 | **29** | +8: `design_land_allotment`(→`96`), `temp_land_allotment`(→`97`), `existent_land_allotment`(→`98`), `ecs_masts`(→`99`), `ecs_spans`(→`100`), `ecs_offsets`(→`101`), `ecs_clearences`(→`102`) — id совпадают с `Handle` новых слоёв; и `platform` →`9` (слой `"0"`, см. §6) |
| `Alignment.ExistPermanentWay` / `ProjectPermanentWay` | `{LastRule:0}` | полные `RailsTable`/`FasteningsTable`/`SleepersTable` | см. §3.3 |
| `Alignment.Model3DElementContext` | **отсутствует** | есть | контекст 3D-модели (СМДХ-типы), см. §3.4 |
| `Plan.PlanVertexes[].ID` | `1, 2` | `13, 14` | см. §4 — **важно для импорта** |
| `Situation.HandleSeed` | 85 | 102 | = max `Handle` в поддереве `Situation` — см. §5 |
| `Blocks[0].Entities[0].@.Handle` | 85 | 89 | |
| `Entities[0].Links` | **есть** | **нет** | см. §3.5 — ключевое расхождение |
| `Entities[0].GeometryData.IsEditable` | нет (не записан) | `true` | новое поле версии |
| `Entities[0].Annotative` | `true` | не записан | флаг поведения |
| `Entities[0].GeometryData.VisibleTrianglesVertices` | 6 точек (2 треугольника) | **9 точек (3 треугольника, последний вырожденный)** | вершины те же, триангуляция другая — координаты пары = (пикет, смещение) |

### 3.3 Путь постоянного пути (permanent way)

`ExistPermanentWay` / `ProjectPermanentWay` — три таблицы, в каждой одна строка
`{Station, <Type>Object}`; объект = `{@:{class:0}, Guid, Model, Type, Name, Properties[]}`,
`Properties[i]` = `{@:{tag,name,fixed,type,value}, info:{@:{units,ptype}}}`.

| Таблица | Ключ элемента | `Type` | В 531 |
|---|---|---|---|
| `RailsTable` | `RailObject` | 3 | `Р65` |
| `FasteningsTable` | `FasteningObject` | 5 | `ЖБР-65`, prop `rail_gasket` («Толщина прокладки под рельсом», мм) |
| `SleepersTable` | `SleeperObject` | 7 | `Тип I`, props `height`/`width`/`length`/`depth` (мм) |

Все `value` = 0.0, все `Station` = 0.0 — файл тестовый, числовых данных нет.
`Guid` — **собственные** Guid объектов рельса/скрепления/шпалы, **не** модельные
(в отличие от `ModelUID` в `LinkData` границы, см. `landallotment.md`).

### 3.4 `Model3DElementContext` (только в 531)

```
Model3DElementContext
  classes — [{@:{class:"Model3DLibraryItemReference", id:0}}]
  types   — [{@:{id:"SmdxAggregates",   title:"Заполнители"}},
             {@:{id:"SmdxRailwayAggregates", title:"Параметры железной дороги", type:0}},
             {@:{id:"SmdxRailwayAggregates", title:"Тип рельса", type:1},
              properties:[{@:{tag,name,type}}, info:{@:{ptype}}] …}]
  models  — [{"@": {"id": 0}}]   (ссылки на модели 3D-библиотеки)
```

Пустой вход = «3D-контекст не сформирован». Идентификаторы типов — **СМДХ-библиотечные**
(`Smdx*`), не Robur-классы; при импорте не выдумываются.

### 3.5 Почему в `531.railx` нет `ModelUID`

У сущности `*MODEL_SPACE` в `53.railx` есть `Links`:

```json
{"Links":[{"Extend":true,"Alias":"AlignmentBorderlineLink",
  "Boundaries":[[ …5 точек, лента ±2 м… ]],
  "LinkData":{"ModelUID":"72c67aeb-…","ByCrs":false,"WholeLength":true,
              "OsnDesignMode":false,"OsnOptimize":true,"FromTunnelAxis":true,
              "FromSta":0.0,"ToSta":0.0,"OsnCurveSegmentFactor":0.1,
              "OsnOptimizeOffset":0.5,"LOffset":2.0,"ROffset":2.0,"VOffset":100.0}}]}
```

В `531.railx` узла `Links` **нет вообще** — сущность хранит только `GeometryData`
(та же самая геометрия ленты). Т.е. по смыслу `531.railx` — та же ось, сохранённая
позже версией Robur **без привязки к оси** (кэш геометрии сохранён), плюс новые
слои/модули и сдвинутый счётчик `ID` вершин плана.

Это легитимно: `ModelUID` выдаёт проект при добавлении модели в дерево
(`ModelProject.GetModelId(URI)`), а не контейнер, поэтому дописывать его вручную
при импорте бессмысленно. Полный разбор — `landallotment.md` §«ModelUID».

---

## 4. `Plan.PlanVertexes[].ID` — не 1..N, а счётчик

План из **двух** точек (НТ/КТ, 197.94 м) в обоих файлах одинаков, но `ID` — `1,2` против
`13,14`. `Plan` не хранит счётчик новых ID; `ID` — внутренний идентификатор вершины,
который продолжается сквозные сессии (к моменту сохранения 531 счётчик дошёл до 13).

Практические следствия для импортёра:

- **Не полагаться** на «`ID` = позиция в массиве» и **не вычислять** `ID` как `i+1`:
  при добавлении вершины Robur выдаст `ID`, которого в файле не было, и нумерация
  «по порядку» разъедется с `ID`.
- При чтении — хранить `ID` как есть; при записи — задавать явно, если создаёте вершины
  (`Vertex` → `ID`), иначе получите коллизию с существующими.
- Ссылок на `ID` вершин в BSTG нет: `Transitions` (2380 Б, идентичны) `ID` не содержат,
  `Sections` в обоих файлах пуст (`{NextSectionId: 0}`).

---

## 5. `Seeds` и `Situation.HandleSeed`

```
Seeds.PointsGroupArrayHandleSeed    = 1
Seeds.PatchArrayHandleSeed          = 1
Seeds.StructureLinesHandleSeed      = 0
Situation.HandleSeed                 = 85  (53)  /  102  (531)
```

`Seeds` — три счётчика handle-сидов (группы точек ЦММ, патчи, структурные линии);
в файлах без геометрии SFCX нулевые/единичные. `Situation.HandleSeed` — последний
выданный handle в поддереве `Situation`: в `53.railx` это 85 (= handle самой
`DwgBorderline`, максимум поддерева), в `531.railx` — 102 (= handle слоя
`Габариты опор контактной сети`, тоже максимум поддерева; handle границы — 89,
т.е. слои выдавались позже). Проверено на обоих файлах: `HandleSeed` == max Handle
в поддереве `Situation`. Следствие: **числовые `Handle` нестабильны между
сохранениями** (в 531 добавление 8 слоёв сдвинуло всё), поэтому слой при импорте
ищется по `StandardName` из `LayersLinks` → `LayerId` → `Layers[].@.Handle`
(единственный корректный join), а не по номеру или имени.

---

## 6. Слои: `Layers` ↔ `LayersLinks`

`Situation.Layers[i]` = `{Name, Handle, Transparency}` (имя — на русском, `Handle` — уникальный).
`LayersLinks` (в корне документа) = `{LayerId, StandardName}` — машинные имена.

`LayerId` в `LayersLinks` — это **`Handle` слоя**, не индекс. Часть ссылок указывает
на «служебный» слой `Handle 9` с именем `"0"` (`cutting` и `platform`), часть слоёв
(handle 42, 43, 84, 86) вообще не имеет `StandardName`-ссылки.

Полный расклад по эталону (`53` / `531`) — 29 строк; машинные имена:

```
axis  bridges  buffer_stop  control_points  crosssections  culvert  cutting
drain  design_land_allotment  ecs_clearences  ecs_masts  ecs_offsets  ecs_spans
elements  existent_land_allotment  grade_signs  inter_track_spaces  joint_block
joint_jointless  kilometres  line_segments  platform  rail_gabarits  signals
stationing  straightening  temp_land_allotment  turnouts  vertexes
```

Осторожно: `cutting` ссылается на `LayerId 9` (слой `"0"`) **в обоих** файлах, а
`platform` (только в 531) — тоже на 9; при импорте `StandardName` → слой надо
резолвить в `Name`, а не в позицию/Handle.

---

## 7. Офлайн-разбор (без Robur) — порядок и подводные камни

Файл читается без запуска Robur в три шага: заголовок SFCX → `stg_off/stg_len` →
BSTG. Практический читатель — локальный RE-инструмент `~/robur-re/robur_native`
(не в репозитории); декомпиляции формата — `Tools/Decomp/`, снимки IL — `Tools/IL/`.
Ключевые сложности, из-за которых `.railx` и не читается «на глаз»:

1. **Секция геометрии SFCX в `.railx` пустая** (все нули). Файл выглядит как ЦММ,
   но геометрии в нём нет — всё содержимое лежит в BSTG. `stg_off = 64` у всех
   проверенных файлов (зависит только от версии, не от размера модели).
2. **BSTG-словарь имён** (`name_count` 552/722) — все ключи вида `Situation`,
   `Alignment`, `Layers` лежат в общей строковой таблице с числовыми индексами.
   Без её разбора вместо имён приходят `#1234`; `codepage = 65001` (UTF-8).
   Второй путь к ключу — **числовой код в `Dictionary<,>`** (в `CrsRebar`,
   `B5-bstg-railx-map.md` §5): такой ключ в пуле имён не лежит вообще.
   На проверенных 16 `.dwp` + 9 `.railx` числовых ключей не встретилось — 0 случаев.
3. **Обфускация имён — только в DLL, не в файле.** В декомпиляции Robur ключи
   доступа выглядят как `dataNode.AddString(<обфус.константа>, …)`, но в файл
   пишутся уже расшифрованные строки: пул имён файла (`name_count`) содержит и
   имена узлов (`Situation`, `Layers`), и ключи свойств (`ModelUID`, `HandleSeed`,
   `StandardName`, `LayerId`), и значения-константы. Офлайн-разбор **не требует**
   ключа расшифровки; он нужен только при декомпиляции, чтобы понять, какой
   `stg`-ключ какому свойству соответствует.
4. **Строковые значения не входят в пул имён.** `Alias = "AlignmentBorderlineLink"`,
   `StandardName = "design_land_allotment"`, `Name` слоёв хранятся инлайн
   (длина + байты) и в `name_count` не ищутся. Обратное тоже верно: наличие
   строки в пуле означает, что она где-то использована как имя/ключ
   (`IsEditable` есть в пуле 531 и отсутствует в пуле 53 — поле реально новое).
5. **`@`-поддеревья** — метаданные узла (имя слоя, `Handle`, `class`, `tag`,
   `units` и т. п.) лежат в отдельном словаре атрибутов узла, а не в основном теле.
6. **Точки в `VisibleBoundaries` / `VisibleTrianglesVertices`** — координаты лежат
   в `@: {X, Y}` узлов-точек, а не в теле массива; в треугольниках пара = (пикет,
   смещение), а не (X, Y).
7. **Порядок триангуляции не байт-стабилен** (§3) — для сравнения «моделей» по
   смыслу нельзя сравнивать `VisibleTrianglesVertices`/`Triangles` построчно.
8. **Атрибут ≠ то, что видно в JSON.** Сериализатор **опускает** значения, равные
   дефолту (у `DwgLayer` это `Color` = White, `Lineweight` = ByLayer, `DwgObjectState`),
   поэтому «в файле нет цвета слоя» и «цвет есть, но равен дефолту» — неразличимы
   по файлу. При разборе в JSON (`Tools/ezdxf/dwp2json.py`) **данные не теряются** — теряются
   только коды типов (`attr_types`, `type_id`, `data_type`): `Int16`/`Int32`/`Byte`
   становятся неразличимым `int`, `Node`/`Array` неразличимы. Обратная сборка BSTG
   из такого JSON тип-точной не будет — держитесь `parse_stg()` напрямую.
   Что физически лежит в коллекциях чертежа — `dwg.md` §«Физическое хранение в `.dwp`».

Вывод для импортёра: **`.railx` — не формат обмена с плагинами.** Единственный
легитимный путь получения модели — открыть файл в Robur и забрать модель из
дерева проекта (см. `model-editor.md`). Импортёр (`RailModelImporter`,
`PyScripts/rim_*.py`) пишет BSTG-дерево целиком, а `ModelUID`/`Links` намеренно
не восстанавливает (см. `landallotment.md`).

---

## 8. Связанные разделы ApiNotes

| Раздел .railx | Где подробно |
|---|---|
| `Alignment/Plan`, `Sections`, `Transitions`, `Parameters`, `EgSurfaces` | `alignment.md`, `rail.md` |
| `Alignment/Plugins/{Gridiron,Its,Landallotment,WaterLinePlugin,…}` | `turnouts.md`, `landallotment.md` |
| `Situation/Layers`, `Collections`, `Blocks`, стили, лайты, ленты типов, таблицы | `dwg.md` |
| `Blocks[0].Entities[0]` = `DwgBorderline` (граница), `Links`/`LinkData`/`ModelUID` | `landallotment.md` §«Новый механизм — модуль `Topomatic.Borderline`» |
| SFCX-контейнер, семантика геометрии, `guard`-префикс | `surface.md` §«Формат SFCX» |
| Счётчики ID (вершины плана, секции, стрелки) | `alignment.md` §«Запись плана (PlanLine)», `turnouts.md` |

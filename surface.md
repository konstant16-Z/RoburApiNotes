# ApiNotes — Поверхности (ЦММ)

## Доступ к поверхности

```csharp
var layer = SurfaceLayer.GetSurfaceLayer(cadView);
var sfc = layer.Surface;
```
`[TUT]` (см. tutorial4).

## Чтение

| API | Назначение | Статус |
|---|---|---|
| `sfc.Points[index]` → `.Vertex.Elevation` | Точки поверхности и отметки | `[TUT]` |
| `sfc.GetExtensiveInformation(ind)` → `info` | Расширенная информация о точке | `[TUT]` |
| `info.Code`, `info.Semantic["CENTER"]`, `GetStringTags`, `sfc.RefreshPointSign(info)` | Код и семантика точки | `[TUT]` |
| `surface.Points[i].Vertex` → `Vector3D` | Прямое чтение вершин | `[CODE]` Runoff |
| `surface.GetElevation(new Vector2D(x, y))` → `double?` | Отметка в точке | `[CODE]` Runoff |
| `surface.Triangles[t]` → `.A/B/C`, `.IsRemoved` | Треугольники триангуляции (пропускать `IsRemoved`) | `[CODE]` Runoff |
| `surface.CreateSection(Vector2D[] pts, SectionFlags)` | Сечение поверхности по ломаной | `[CODE]` Runoff |
| `StructureLine.ToPolyline(list)`, `strLine[i].Index`, `IsClosed` | Структурная линия | `[TUT]` |
| `ILinearObject.GetPolyline(poly)`, `poly.GetArea2D()`, `EqualEps(v)` | Площадь замкнутой горизонтали | `[TUT]` |
| `SurfaceLayer.SurfaceSelectionSet.IsHorizontalSelectable`, `HorizontalsStyle.GetLayer()` | Горизонтали | `[TUT]` |

## Выбор точек

| API | Назначение | Статус |
|---|---|---|
| `layer.SelectPoints(...)`, `SelectedPointsCount`, `GetSelectedPoints()` | Выбор точек поверхности | `[TUT]` |
| `layer.SelectOneStructureLine(pred, ...)`, `layer.PickOnePoint(...)` | Выбор структурной линии/точки | `[TUT]` |

## Правка

| API | Назначение | Статус |
|---|---|---|
| `sfc.BeginUpdate("описание")/EndUpdate()` | Групповое изменение (обязательно парное) | `[TUT]`+`[CODE]` |
| `PointEditor(sfc).Add(...)` | Правка/добавление **существующих** точек — только через него | `[TUT]` |
| `sfc.StructureLines.Add(...)`, `structureLine.Add(index)` | Структурные линии из индексов точек | `[TUT]` |

⚠️ «Правка только через PointEditor» относится к существующим точкам; **создание с нуля** —
через прямой `Points.Add` (ниже).

## Создание ЦММ с нуля — `[CODE]` DemLoader

```csharp
IProjectModel node = PluginCoreOps.CreateModel(parent, TerrainModel.MODEL_TYPE, name);
node.LockWrite();
try
{
    var surface = node.Model as Surface;      // ⚠️ после LockWrite() node.Model ЕЩЁ null!
    node.LockRead();                          //   данные появляются только после LockRead()
    surface = node.Model as Surface;          //   теперь не null (без исключения — просто null)
    surface.BeginUpdate();
    try
    {
        foreach (var p in points)
            surface.Points.Add(new SurfacePoint(new Vector3D(p.X, p.Y, p.Z)));
        // поверхность без треугольников допустима; при необходимости:
        // surface.Triangles.Add(new SurfaceTriangle { … });
    }
    finally { surface.EndUpdate(); }
}
finally { node.UnlockWrite(); }
```

### Ловушки (см. также `pitfalls.md`)

1. **`node.Model` остаётся `null` после `LockWrite()`** до вызова `LockRead()` — без исключения.
2. **`surface.Points.Add` начинается с проверки лицензии** — без лицензии «успешно» молча
   ничего не делает (видна в текущей сессии, счётчики сходятся, но данные не пишутся).
3. **`BeginUpdate()` без парного `EndUpdate()`**: запись видна в текущей сессии — но это
   нештатный режим; всегда парный вызов.
4. **`node.GetChilds()` бросает `NullReferenceException`** — оборачивать в `try/catch`.

## Импорт из нативного SFCX — паттерн плагина `[CODE]` SurfaceIO (в разработке)

Канонический путь под подтверждённый API (агр. с `DemLoader` и внутренним `Clone` Robur):

```csharp
IProjectModel node = PluginCoreOps.CreateModel(root, TerrainModel.MODEL_TYPE, name);
node.LockWrite();
try
{
    node.LockRead();
    var surface = ((TerrainModel)node.Model).Surface;   // node.Model null до LockRead
    surface.BeginUpdate();                               // пакет уведомлений — UI не видит
    try                                                   // полузагруженную поверхность
    {
        using (var fs = File.OpenRead(path)) surface.LoadFromStream(fs);
    }
    finally { surface.EndUpdate(); }
    surface.Invalidate();
    surface.Regen();                                     // пересчёт пространственных ячеек
    // ⚠️ исключение Regen НЕ глотать: молчаливый брак выглядит как «Robur закрылся»
    // при ближайшей перерисовке (большая реальная поверхность).
}
finally { node.UnlockWrite(); }
node.Save(false);                                        // запись модели на диск
```

Статусы по шагам: `CreateModel/LockWrite/LockRead/UnlockWrite/Save` — `[CODE]` DemLoader;
`LoadFromStream/BeginUpdate/EndUpdate/Regen/Invalidate` — `[TUT]` (веб-справочник) + `[DECOMP]` (Sfc.il).

Ловушки импорта:

1. **Краш на больших поверхностях происходит ПОСЛЕ завершения команды** (лог плагина
   `sfc_import ok` есть, Robur умирает при отрисовке/обновлении дерева). Диагностика —
   пошаговый лог каждой операции; `try/catch` в телах команд managed-исключение превращает
   в диалог, но нативный AV так не ловится — лог обязателен.
2. **`Regen()` на SFCX-пути**: внутренний `Clone` Robur загружает `new Surface() +
   LoadFromStream` **без** Regen — при импорте Regen нужен для ячеек отрисовки, но любое
   его исключение логировать и показывать как ошибку импорта (не глотать).
3. **`LoadFromStream` вне BeginUpdate/EndUpdate** — риск отрисовки полузагруженной
   поверхности больших объёмов.
4. **Проверка лицензии молчалива** и в `LoadFromStream` (Smt/Jb-проверки в IL): счётчики
   после загрузки сверять — 0 точек = файл «прочитан», но данные не появились.

## Формат SFCX (.sfcx) — `[DECOMP]` монодизассемблирование `Topomatic.Sfc.dll`/`Topomatic.Smt.dll`

Формат восстановлен по сборкам `Topomatic.Sfc.dll` и `Topomatic.Smt.dll` (проверен на 9
тестовых файлах `.sfcx` версии 4).

### Контейнер (version = 4)

```
[0x00] 'SFCX'                       — сигнатура (4 байта)
[0x04] u16 version                  — версия (наблюдается 4; <=1 — старый формат)
[0x06] u64 stg_off                  — смещение Stg-документа (BSTG)
[0x0E] u32 stg_len                  — длина Stg-документа
[0x12] <геометрия>                  — всегда начинается с 0x12
[stg_off]      <BSTG … 'EOF'>       — документ (стиль, семантика-описания, слои)
[stg_off+stg_len] 'SFCX'            — терминатор
```

Для `version > 3` перед геометрией — **защитный префикс**: байт `g`; если `g != 0`,
накапливать байты суммой mod 256, пока сумма не сравняется с `g`. Если набралось <8 или
>16 байт — Robur считает файл «нелицензионным» и падает на чтение **старого формата
(version=1: точки полными тройками double)** — эвристика `v2` в парсере.

Геометрия (в порядке): `points`, `triangles`, `lines`, затем `u32 groups`, `u32 patches`,
`u32 directrix, u32 directrix`. Всё смещение-зависимое — после геометрии поток упирается
ровно в `stg_off` (проверка выравнивания парсера).

### Точки (`SurfacePointArray.LoadFromStreamSfcx`, sfc_full.il ~46476)

`u32 count`, затем на каждую точку:

1. **флаг f5** (`byte`):
   - `0x80` — удалённая точка: `Flags |= 0x4000` (PointFlags.Removed), индекс в список
     «активных дыр» (`ActiveHoles`); координат нет.
   - иначе:
     - `version == 1` — координаты полными `f64 x,y,z`;
     - `f5 & 0x01` — имя (`ReadString`);
     - `f5 & 0x02` — код (`ReadNegativeInteger` при version>1, иначе `ReadInteger`);
     - `f5 & 0x04` — `byte` флаги (PointFlags);
     - `f5 & 0x08` — поворот `f32` (Rotation, расширенная информация);
     - `f5 & 0x10` — **SemanticDataHolder** (см. ниже);
     - `f5 & 0x20` — слой (`ReadInteger` → uint32);
     - `f5 & 0x40` — код изыскания `ExplorationCode` (`ReadString`).
2. **флаг координат `cf`** (только `version > 1`):
   - биты `0–1` — X, `2–3` — Y, `4–5` — Z — код сжатия координаты относительно
     предыдущей точки (`read_coord`):
     - `0` — повторить предыдущее значение;
     - `1` — заменить младшие 4 байта (мантиссу);
     - `2` — заменить байты 4–5 (экспоненту) + младшие 4;
     - `3` — полные 8 байт.
   - `cf & 0x40` — **moving strings** (см. StringMove ниже);
   - `cf & 0x80` — знак `Sign` (`ReadInteger`).

### SemanticDataHolder (`Topomatic.Smt`, smt_full.il — LoadFromStream RVA 0x7924)

Холдер семантики точки/линии: `dict<int32, object>` пар ключ→значение.

```
count = ReadInteger();  если count <= 0 — пусто
служебный byte (статик-поле Robur сверяет с константой; в файлах = 1)
далее count пар:
  key = ReadInteger()
  type = byte: 0 → значение = ReadString()
               1 → значение = ReadInteger()
               2 → значение = ReadDouble()
               иначе → InvalidCastException
```

Наблюдения на реальных файлах: `(1, 1, 3)` — «код типа»; `(222, 2, 250.0)`,
`(68, 1, 24)` — параметры линий. Запись — `SaveToStream` (тип байта перед значением:
0/1/2; лицензионная проверка `Jb(80)`/`Jb(84)` — кто-то из путей читает/пишет только на
лицензионных конфигурациях).

### Moving strings / «плавающие строки» (`cf & 0x40`, sfc_full.il IL_0284–0336)

```
count = ReadInteger();  на каждую строку:
  b = byte
  b & 0x01 → x = f32      (иначе 0.0)
  b & 0x02 → y = f32
  b & 0x04 → r = f32      (поворот!)
  b & 0x08 → невидимость (visible = false)
  SetStringMoveing(m, x, y, r, visible)
```

Поля соответствуют официальной структуре **`StringMove { X, Y, R, Invisible }`**
(веб-справочник: `topomatic.sfc.stringmove`). Хранятся в `SurfacePointExtensiveInformation`
через `GetStringMoveing(index, out x, out y, out r[, out bool visible])` /
`SetStringMoveing` (Sfc.il IL_16892 — сигнатуры из веб-справочника `SurfacePoint`).

### Треугольники (`SurfaceTriangleArray.LoadFromStreamSfcx`)

```
u32 count;  prev = 0
на каждый треугольник:
  f = byte
  f & 0x20 → da = ±1 (бит 0x04 → -1)       иначе da = ∓ReadInteger
  f & 0x40 → db = ±1 (бит 0x08 → -1)       иначе db = ∓ReadInteger
  f & 0x80 → dc = ±1 (бит 0x10 → -1)       иначе dc = ∓ReadInteger
  a = prev + da; b = a + db; c = b + dc; prev = c
  f & 0x01 → patch = ReadInteger
  f & 0x02 → flags = byte
```

### Структурные линии (`StructureLine.LoadFromStreamSfcx`, sfc_full.il ~40286)

```
u32 count;  на каждую линию:
  v = ReadInteger() — битовая маска полей:
    v & 0x001 → linear_code = ReadNegativeInteger
    v & 0x002 → area_code   = ReadNegativeInteger
    v & 0x004 → linear SemanticDataHolder
    v & 0x008 → area   SemanticDataHolder     (оба — тот же формат, см. выше)
    v & 0x010 → linear_sign = ReadInteger
    v & 0x020 → area_sign   = ReadInteger
    v & 0x040 → flags = byte
    v & 0x080 → layer = ReadInteger
    v & 0x200 → density = ReadInteger
    v & 0x400 → description = ReadString
    v & 0x800 → elevation_behaviour = byte (enum ElevationBehaviour)
  n = ReadInteger() — число узлов; prev = 0:
    узел: prev += ReadNegativeInteger();  v & 0x100 → elevation = f64
```

Тестовые файлы: один — 86 линий, 4 с linear-семантикой, 1 точка с moving-строками;
другой — 148 линий, 3 точки с семантикой.

### Примитивы потока (`Topomatic.Sfc.StreamUtils` — `[TUT]` веб-справочник + `[DECOMP]`)

| StreamUtils | Реализация в парсере |
|---|---|
| `ReadInteger(BinaryReader[, bool])` | беззнаковый LEB128 (7-битные куски) |
| `ReadNegativeInteger(BinaryReader)` | LEB128; терминальный байт: бит `0x40` = знак |
| `ReadString(BinaryReader)` | `ReadInteger`-длина + байты UTF-8 + `string.Intern` |
| `WriteInteger/WriteNegativeInteger/WriteString` | обратные операции |

## Состав типов по веб-справочнику — `[TUT]` (help.topomatic.ru/next,
`developers:references:topomatic.sfc.*`, страницы без текстовых описаний — только перечни)

### `class Surface : UndoObject, INamedTransactable, ITransactable, IUpdatable, IDisposable, ISurfaceContainer, IOwned, IDrawingContainer, IElevationProvider` (sealed)

- **Конструкторы**: `Surface()`, `Surface(Object, Boolean)`.
- **Серийные/форматы**: `LoadFromStream(Stream)`, `LoadFromFile(String)`,
  `SaveToFileSfc(String[, UInt16])`, `SaveToStreamSfc(Stream[, UInt16])`,
  `SaveToFileSfcx(String)`, `SaveToStreamSfcx(Stream[, UInt16])`.
- **Служебные**: `Clone() → Surface` (внутри = `new Surface()` + `LoadFromStream`),
  `Clear()`, `ClearTriangulation()`, `CheckConnectivity()`, `Regen()`,
  `Invalidate()`, `Invalidate(Boolean)`, `BeginUpdate()` (переопределение),
  `CreateSection(...)`, `CreateSections(...)`, `Dispose()`,
  `FindPoint(Vector2D, Double)`, `FindPoints(...)`, `FindTriangle(Vector2D)`,
  `FindTriangles(...)`, `GetElevation(Vector2D)`.
- **Свойства**: `Points` (SurfacePointArray), `Triangles`, `StructureLines`, `Groups`,
  `Patchs`, `PointIndexer`, `TriangleIndexer`, `Style`, `Code`, `Codifier`,
  `SurfaceState`, `Bounds2d`, `Bounds3d`, `Owner`, `Designed`, `Hidden`, `Situation`,
  `LayersMapping`, `LinearSigns`, `PointSigns`, `HachureDirectrix`,
  `HorizontalDirectrix`, `ProxySourceProviders`, `TransactionManager`.
- **События**: `Invalidated`, `LoadFromStg`, `SaveToStg`, `PointAdd/Removed/Modify`,
  `PointCodeChanged/PointExplorationCodeChanged/PointLayerChanged/PointSignChanged`,
  `PointSemanticModify`, `TriangleAdd/Removed/Modify`, `PatchModify`, `PatchFlagsModify`,
  `PatchSemanticModify`; от `UndoObject`: `Changed`, `Undo`, `EndUpdate()`,
  `BeginUpdate(String)` (регистрирует undo-группу).

### `struct SurfacePoint : IEquatable<SurfacePoint>, IStgSerializable`

- Поля: `Vertex` (Vector3D), `Flags` (PointFlags).
- Свойства: `Code`, `Description`, `ExplorationCode`, `Layer`, `Number`, `Rotation`,
  `Scale`, `Semantic`, `Sign`, `HasExtensiveInformation`, `IsDrawLeader`, `IsDynamic`,
  `IsExtended`, `IsHighlighted`, `IsLocked`, `IsProxy`, `IsRemoved`, `IsSelected`,
  `IsSituation`, `IsUnconnected`.
- Методы: `Clone()`, `HasSemantic()`, `GetStringMoveing(int, out double, out double,
  out double[, out bool])`, `LoadFromStg(StgNode)`, `SaveToStg(StgNode)`.
- Конструктор: `SurfacePoint(Vector3D)`.

### `enum PointFlags` — «Флаги узла поверхности» (переводы из справочника)

| Флаг | Описание справочника |
|---|---|
| `Removed` | Удаленная |
| `Unconnected` | Точка отсоединена от источника данных, имеет смысл только при флаге Proxy |
| `Proxy` | Proxy-точка |
| `Situation` | Ситуационная |
| `Disable` | Точка неактивна |
| `Hidden` | Точка скрыта |
| `Locked` | Заморожена (не поворачивать по листу) |
| `Selected` | Выделенная |
| `Highlighted` | Подсвечена по коду |
| `DrawLeader` | Отображать/не отображать выноску к подписи |
| `Dynamic` | Динамическая точка, например точка, создаваемая под структурной линией |
| `Extended` | Дополнительная |
| `StatesCached` | Состояние точки кэшировано (Enable, Disable, Visible, Hidden) |
| `DataFlags`, `DataFlagsMask`, `Reserved1..3`, `None` | — |

### `enum SurfaceState` = { `None`, `HasUnconnectedPoints` }

Состояние **не** содержит «нужен Regen» — пересчёт ячеек отдельной операцией, флаги —
только про неподключённые точки.

### `struct StringMove` = поля `X`, `Y`, `R`, `Invisible`

### `abstract sealed class StreamUtils` — статические примитивы (см. таблицу выше)

## Обход поверхностей проекта — `[CODE]` SurfaceIO

```csharp
using Topomatic.ApplicationPlatform;   // PluginCoreOps
using Topomatic.Dtm;                  // TerrainModel
using Topomatic.Sfc;                  // Surface

// Все узлы проекта с моделью TerrainModel (FilterModels сам обходит дерево):
var result = new List<IProjectModel>();
PluginCoreOps.FilterModels(delegate (IProjectModel pm)
{
    var terrain = pm.Model as TerrainModel;
    if (terrain != null) result.Add(pm);
    return false; // continue
});

// Корневой узел проекта (родитель для CreateModel):
IProjectModel root = null;
PluginCoreOps.FilterModels(delegate (IProjectModel pm)
{
    var project = pm.Project;
    if (project != null && project.Model != null)
    {
        root = project.Model;
        return true; // stop
    }
    return false;
});

// Имя узла: PluginCoreOps.GetFileName(node), fallback — node.Uri, иначе "(без имени)".
string fileName = PluginCoreOps.GetFileName(node);
```

Все обходы «мягкие»: `node.Model`, `pm.Project` и сам `FilterModels` могут бросить
(известная ловушка `node.GetChilds()` → `NullReferenceException`) — оборачивать в try/catch.
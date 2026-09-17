# Стрелочные переводы / Путевое развитие (Topomatic.Turnouts)

Контейнер `Gridiron` и элементы путевого развития: стрелочные переводы (`SimpleTurnout`),
упоры (`BufferStop`), знаки/точки (`GridironElement`) и др.
Сборка: `Topomatic.Turnouts.dll`.

**Статус:** `[DECOMP]` (ilspycmd v11.0.0.9375) + `[REF]` (help.topomatic.ru/next).
Все имена и сигнатуры перекрыты декомпиляцией; справочник сверялся параллельно.
Декомпиляции типов — в `Tools/Decomp/Topomatic.Turnouts.*.cs`.

---

## Доступ к контейнеру

Контейнер привязан к оси как плагин. Основной путь доступа:

```csharp
var axis = ...;  // Alignment или axis из ActiveAlignmentReciver
// Способ 1 — через свойство Plugins коллекции:
object plugins = axis.Plugins;           // AlignmentPlugins
object gridironPlugin = plugins["Gridiron"];  // ключ строки
Gridiron gridiron = gridironPlugin.Gridiron;  // свойство .Gridiron

// Способ 2 — через IAlignmentContainer (элементы реализуют):
// gridironObject.Gridiron → тот же контейнер
// gridiron.Alignment → привязанная ось (IAlignmentContainer)
```

**Как экспортёр (RailJson.cs, [CODE]) находит контейнер:**
1. `axis.Plugins["Gridiron"]` по строковому ключу — самый быстрый.
2. Если не найден — `ReadKeyed(plugins, "Gridiron")` или `plugin.Gridiron` через `IEnumerable` перебор.
3. Детали поиска — метод `BuildTurnouts`, строки 3574–3711 `RailModel/RailModel/RailJson.cs`.

---

## Иерархия классов (подтверждена `[DECOMP]` + `[REF]`)

```
UndoObject
├── Gridiron                          (контейнер)
└── GridironObject                    (абстрактная база всех элементов)
    ├── BufferStop                    (упор)
    ├── GridironElement               (знак/точка/граница)
    ├── Joint (абстрактный)           (стык)
    │   ├── BlockJoint
    │   ├── JointlessJoint
    │   └── ConventionalJoint
    └── SwitchProduct                 (абстрактная база «продуктов стрелочного перевода»)
        ├── Balancer
        ├── DropArrow
        └── Turnout                   (абстрактная база переводов)
            ├── SimpleTurnout         (простой перевод)
            ├── AsymmetricTurnout
            ├── SymmetricTurnout
            ├── DeafCrossTurnout
            └── DoubleCrossTurnout
```

---

## Gridiron — контейнер элементов путевого развития

```csharp
// Синтаксис (илspycmd + справочник):
public class Gridiron : UndoObject, IAlignmentContainer, IGridironContainer
{
    public const uint EMPTY_ID;        // = 0

    public GridironStyle Style;
    public int Count { get; }
    public GridironObject this[int index] { get; }
    public Alignment Alignment { get; }
    public object Owner { get; }

    public Gridiron(object owner);
    public void Clear();
    public void Add(GridironObject item);      // ← Id присваивается АВТОМАТИЧЕСКИ (счётчик)
    public void RemoveAt(int index);
    public bool Remove(GridironObject value);
    public bool TryGetValue(uint key, out GridironObject value);
    public bool Contains(uint key);
    public void Invalidate();
}
```

**[DECOMP] Присвоение Id при Add:**
```csharp
// Gridiron.__nextId инициализируется в 1 (ctor).
// Add(...): item.Id = __nextId++;  (внутренний set)
// НЕЛЬЗЯ задавать Id вручную до Add — контейнер сам назначит.
```

**Undo-паттерн при добавлении:**
```csharp
gridiron.BeginUpdate();
try
{
    var item = new SimpleTurnout(gridiron, ...);
    gridiron.Add(item);   // Id автоматически присваивается
    // item.Id == 1, 2, 3... (порядок добавления)
}
finally { gridiron.EndUpdate(); }
```

---

## GridironObject — база всех элементов путевого развития

```csharp
// [DECOMP] + [REF]
public abstract class GridironObject : UndoObject, IOwned, IAlignmentContainer,
    IGridironContainer, INamedObject, IEquatable<GridironObject>
{
    public uint Id { get; internal set; }            // ← internal set! значение задаёт Add
    public Link Link { get; }                        // привязка к оси через Link
    public bool UserPosition { get; set; }           // true = позиция задана вручную
    public bool IsValid { get; }                     // Refresh() + cache
    public Vector2D Position { get; }                // вычисляется через Refresh → DoRefresh
    public Vector2D Direction { get; }               // вычисляется через Refresh → DoRefresh
    public Vector2D PositionValue { get; }           // кэш без Refresh
    public Vector2D DirectionValue { get; }          // кэш без Refresh
    public object Owner { get; }                     // Gridiron-контейнер
    public int ConnectorCount { get; }               // abstract
    public string Name { get; }                      // abstract (переопределён в подклассах)

    protected abstract bool DoRefresh(out Vector2D position, out Vector2D direction);
    public abstract GridironObject Clone(object parent);
    public abstract Connector GetConnector(int index);
}
```

---

## SwitchProduct — база «продуктов стрелочного перевода»

```csharp
// [DECOMP] + [REF]
public abstract class SwitchProduct : GridironObject
{
    public string Description { get; set; }
    public string ProjectName { get; set; }
    public string GroupName { get; set; }          // [DECOMP] — нет в [REF]
    public string ConventionName { get; set; }     // [DECOMP] — нет в [REF]
    public string GroupDescription { get; set; }   // [DECOMP] — нет в [REF]
    public bool CustomTextPosition { get; set; }
    public bool FlipText { get; set; }
    public Vector2D NameTextOffset { get; set; }
    public Vector2D TypeTextOffset { get; set; }
    public TypedObject RailType { get; set; }
    public Guid TurnoutModelId { get; set; }
    public SleeperMaterialType CantStuff { get; set; }    // [DECOMP] + [REF] CantStuff
    public TurnoutDirection TurnoutDirection { get; set; }
    public bool UseCustomProfileSign { get; set; }
    public int CustomProfileSign { get; set; }

    public override string Name { get; set; }

    // Конструкторы:
    public SwitchProduct(object owner, string name);
    public SwitchProduct(object owner, SwitchProduct obj);                // копирующий
    public SwitchProduct(object parent, string name, string description,
        string typeProjectName, TurnoutDirection turnoutDirection,
        bool customTextPosition, bool flipText,
        Vector2D nameTextOffset, Vector2D typeTextOffset,
        TypedObject railType, SleeperMaterialType cantStuff);  // полный
}
```

**[DECOMP] Примечание:** `GroupName`, `ConventionName`, `GroupDescription` присутствуют
в декомпиляции, но отсутствуют в справочнике (`[REF]`) — предположительно внутренние
поля, неэкспортируемые в JSON. Не используются экспортёром `[CODE]`.

---

## Turnout — абстрактный стрелочный перевод

```csharp
// [DECOMP] + [REF]
public abstract class Turnout : SwitchProduct
{
    // Свойства (с set, writable):
    public TurnoutType TurnoutType { get; set; }
    public TurnoutSideType TurnoutSideType { get; set; }
    public TurnoutCrossMark CrossMark { get; set; }
    public double CrossAngle { get; set; }
    public string CrossMarkDescription { get; set; }
    public bool Centralized { get; set; }
    public bool ShowCommonBeamDistance { get; set; }
    public double CommonBeamDistance { get; set; }
    public double AfterCommonBeamDistance { get; set; }
    public double FoulingPointOffset { get; set; }
    public double FoulingPointDeltaOffsetCurveMain { get; set; }
    public double FoulingPointDeltaOffsetCurveSecond { get; set; }
    public bool FoulingPointShow { get; set; }
    public Guid FoulingPointModelId { get; set; }     // [DECOMP]

    // Свойства (abstract → реализованы в SimpleTurnout):
    public abstract double StartStation { get; }
    public abstract double EndStation { get; }
    public abstract int StartConnectorIndex { get; }
    public abstract int EndConnectorIndex { get; }
    public abstract Vector2D CommonBeamMainWayPosition { get; }
    public abstract Vector2D CommonBeamSecondWayPosition { get; }
    public abstract int PointConnectorCount { get; }
    public abstract TurnoutWay[] Ways { get; }

    // Свойства (get-only, наследуются от GridironObject):
    // Id, Name, Link, UserPosition, IsValid, Position, Direction, Owner

    // Конструкторы:
    public Turnout(object parent, string name, string description,
        string typeProjectName, TurnoutType turnoutType, TurnoutDirection turnoutDirection,
        TurnoutSideType side, bool customTextPosition, bool flipText,
        Vector2D nameTextOffset, Vector2D typeTextOffset,
        TurnoutCrossMark crossMark, double crossAngle, string crossMarkDescription,
        TypedObject railType, SleeperMaterialType cantStuff,
        bool foulingPointShow, double foulingPointOffset,
        double foulingPointDeltaOffsetCurveMain, double foulingPointDeltaOffsetCurveSecond,
        bool centralized);

    public Turnout(object parent, Turnout turnout);  // копирующий

    // Методы:
    public abstract IEnumerable<Vector2D> GetFoulingPoints();
    public IEnumerable<string> GetSecondWays();
    public Connector GetPointConnector(int index);
}
```

**Структура `TurnoutWay`:**
```csharp
// [DECOMP]
public struct TurnoutWay
{
    public Vector2D Start;
    public Vector2D End;
    public double AfterCommonBeam;
    public bool BothCommonBeam;
    public string RelativePath;
    public bool MainWay;
    public Vector2D StartCommon;
    public Vector2D EndCommon;
}
```

---

## SimpleTurnout — конкретный простой перевод (самый частый)

```csharp
// [DECOMP] + [REF]
public class SimpleTurnout : Turnout
{
    // Геометрия (writable):
    public double M { get; set; }        // координата перевода по оси
    public double A0 { get; set; }       // длина остряка
    public double B0 { get; set; }       // длина башмака
    public double Q1 { get; set; }       // длина крестовины

    // Вычисляемые (get-only):
    public double A { get; }             // = M + A0
    public double B { get; }             // = B0 + Q1
    public double Length { get; }        // = A + B

    // Позиции на оси (Vector2D, writable):
    public Vector2D StartPosition { get; set; }
    public Vector2D EndPosition { get; set; }
    public Vector2D SecondPosition { get; set; }
    public Vector2D RotationMechDirectionPosition { get; set; }
    public Vector2D RampStartPosition { get; set; }

    // Ссылка на вторую ось:
    public string SecondAlignmentRelativePath { get; set; }  // путь .railx файла

    // Сторона и механизм:
    public TurnoutRotation RotationMechSide { get; set; }

    // Реализация abstract:
    public override double StartStation { get; }
    public override double EndStation { get; }
    public override int StartConnectorIndex { get; }  // = 1
    public override int EndConnectorIndex { get; }    // = 2
    public override Vector2D CommonBeamMainWayPosition { get; }
    public override Vector2D CommonBeamSecondWayPosition { get; }
    public override int ConnectorCount { get; }       // = 2
    public override int PointConnectorCount { get; }
    public override TurnoutWay[] Ways { get; }

    // Конструкторы:
    public SimpleTurnout(object parent);
    public SimpleTurnout(object parent, SimpleTurnout turnout);  // копирующий
    public SimpleTurnout(object parent,
        string name,
        string description,
        string typeProjectName,
        TurnoutType turnoutType,
        TurnoutDirection turnoutDirection,
        bool customTextPosition,
        bool flipText,
        Vector2D nameTextOffset,
        Vector2D typeTextOffset,
        string secondAlignmentRelativePath,
        TurnoutSideType turnoutSide,
        TypedObject railType,
        SleeperMaterialType cantMaterial,
        TurnoutCrossMark crossMark,
        double crossAngle,
        string crossMarkDescription,
        TurnoutRotation rotationMechSide,
        double m,
        double a0,
        double b0,
        double q1);

    // Методы:
    public override Connector GetConnector(int index);
    public override IEnumerable<Vector2D> GetFoulingPoints();
    public override GridironObject Clone(object parent);
}
```

**Важно для импорта:** `StartStation`/`EndStation` — get-only, вычисляются из `Link` (привязка
к оси). Запись в файл ставит значения как есть (см. экспортёр — `FormatScalar`),
но при импорте они пересчитаются при `Refresh()`. Если позиция задаётся через
`StartPosition`/`EndPosition` (Vector2D), `UserPosition` = true.

---

## BufferStop — упор

```csharp
// [DECOMP] + [REF]
public class BufferStop : GridironObject
{
    public Guid ModelId { get; set; }
    public bool UseCustomProfileSign { get; set; }
    public int CustomProfileSign { get; set; }
    public override int ConnectorCount { get; }     // = 1
    public override string Name { get; set; }

    public BufferStop(object parent, string name);
    public BufferStop(object parent);
    public BufferStop(object parent, BufferStop bufferStop);  // копирующий
    public override GridironObject Clone(object parent);
    public override Connector GetConnector(int index);
}
```

---

## GridironElement — знак/граница/точка путевого развития

```csharp
// [DECOMP] + [REF]
public class GridironElement : GridironObject
{
    public SemanticDataHolder DataHolder { get; }
    public bool IsDataHolderEmpty { get; }
    public SemanticDataSet Semantic { get; }
    public string ReferencedAlignment { get; set; }    // ссылка на ось
    public int SemanticCode { get; set; }
    public uint PointSign { get; set; }
    public bool DrawBackward { get; set; }
    public double Offset { get; set; }
    public override string Name { get; set; }
    public override int ConnectorCount { get; }
    public Guid ModelId { get; set; }

    public GridironElement(object parent, string name, double offset, bool drawBackward);
    public GridironElement(object parent);
    public GridironElement(object parent, GridironElement signal);  // копирующий
    public override GridironObject Clone(object parent);
    public override Connector GetConnector(int index);
}
```

---

## IGridironContainer

```csharp
// [DECOMP] + [REF]
public interface IGridironContainer
{
    Gridiron Gridiron { get; }
}
```

Реализован всеми элементами (`GridironObject`, `Gridiron`). Служит для доступа
от элемента к контейнеру: `element.Gridiron`.

---

## Перечисления (enums) — `[DECOMP]`

```csharp
public enum TurnoutType       { Exist, Project, Rebuild }
public enum TurnoutSideType   { LeftSideTurnout, RightSideTurnout }
public enum TurnoutDirection  { Forward, Backward }
public enum TurnoutCrossMark  { m1_9, m1_18, m1_11, m1_22, Other, m1_6, m2_6, m2_9, m2_11, m1_5 }
public enum TurnoutRotation   { Left, Right }
public enum SleeperMaterialType { Wood, Concrete, Other }
public enum BlockJointType    { Sectional, Glue }
public enum JointlessJointType { Aluminothermy, ElectricalContact }
```

**В JSON (формат экспортёра `[CODE]`):** enum-ы — полные имена вида `"TurnoutType.Project"`.
Булевы — `"да"/"нет"`.

---

## Структура JSON-файла turnouts.json (формат `[CODE]`)

Файл: `model/Turnouts/turnouts.json` внутри `.railx`.

```json
{
  "type": "Topomatic.Turnouts.Gridiron",
  "category": "Элементы путевого развития",
  "count": 3,
  "alignment": "Rail",
  "items": [
    {
      "type": "SimpleTurnout",
      "category": "стрелочный перевод",
      "name": "1А",
      "id": 1.0,
      "StartStation": 8.036766714605562,
      "EndStation": 39.07142086797964,
      "StartConnectorIndex": 1.0,
      "EndConnectorIndex": 2.0,
      "TurnoutType": "TurnoutType.Project",
      "TurnoutSideType": "TurnoutSideType.LeftSideTurnout",
      "TurnoutDirection": "TurnoutDirection.Forward",
      "CrossMark": "TurnoutCrossMark.m1_9",
      "CrossAngle": "0.11065872",
      "CrossMarkDescription": "",
      "Centralized": "нет",
      "FoulingPointShow": "да",
      "ShowCommonBeamDistance": "нет",
      "CommonBeamDistance": "0",
      "AfterCommonBeamDistance": "0",
      "FoulingPointOffset": "4.1",
      "SecondAlignmentRelativePath": "(Не задан)",
      "M": 2.765,
      "A0": 12.458,
      "A": 15.223,
      "B0": 13.722,
      "Q1": 2.09,
      "B": 15.812,
      "Length": 31.035,
      "StartPosition": "X:447,98... Y:1716,14...",
      "EndPosition": "X:470,36... Y:1694,63...",
      "SecondPosition": "X:471,50... Y:1695,96...",
      "CommonBeamMainWayPosition": "X:470,36... Y:1694,63...",
      "CommonBeamSecondWayPosition": "X:471,50... Y:1695,96..."
    },
    {
      "type": "BufferStop",
      "category": "упор",
      "name": "УП",
      "id": 4.0
    },
    {
      "type": "GridironElement",
      "category": "элемент путевого развития",
      "name": "Начало пути",
      "id": 5.0
    }
  ]
}
```

**Замечания по формату:**
- `Position` (Vector2D) — форматируется как `"X:... Y:..."` (русская локаль, запятая = десятичный разделитель).
- `CrossAngle` — строка (`FormatScalar` форматирует `double` в строку).
- Геометрические поля `M/A0/A/B0/Q1/B/Length` — числа с плавающей точкой (не строки в JSON).
- `id` — целое число, но в JSON записывается как `1.0` (double) из-за `FormatScalar`.
- **Опечатка экспортёра:** `FirstAlignmentRealtivePath` (баг, наследуется и в Python-порт).
  В JSON-файле поле не присутствует, если значение не задано.

---

## Соответствие JSON ↔ Свойства (таблица для импорта)

Источник: `BuildGridironTurnout` (RailJson.cs:3795–3869) + `BuildTurnouts` (3574–3711).

| JSON-ключ | C#-свойство | Тип | Статус |
|---|---|---|---|
| `type` | `GetType().Name` | string | `[CODE]` |
| `category` | `ElementTitle(name)` | string | `[CODE]` |
| `name` | `Name` | string | `[DECOMP]+[CODE]` |
| `id` | `Id` | uint (set **internal**) | `[DECOMP]` |
| `StartStation` | `StartStation` | double | `[DECOMP]+[CODE]` |
| `EndStation` | `EndStation` | double | `[DECOMP]+[CODE]` |
| `StartConnectorIndex` | `StartConnectorIndex` | int | `[DECOMP]+[CODE]` |
| `EndConnectorIndex` | `EndConnectorIndex` | int | `[DECOMP]+[CODE]` |
| `TurnoutType` | `TurnoutType` | enum | `[DECOMP]+[CODE]` |
| `TurnoutSideType` | `TurnoutSideType` | enum | `[DECOMP]+[CODE]` |
| `TurnoutDirection` | `TurnoutDirection` | enum | `[DECOMP]+[CODE]` |
| `CrossMark` | `CrossMark` | enum | `[DECOMP]+[CODE]` |
| `CrossAngle` | `CrossAngle` | double (как строка в JSON) | `[DECOMP]+[CODE]` |
| `CrossMarkDescription` | `CrossMarkDescription` | string | `[DECOMP]+[CODE]` |
| `Centralized` | `Centralized` | bool ("да"/"нет") | `[DECOMP]+[CODE]` |
| `FoulingPointShow` | `FoulingPointShow` | bool | `[DECOMP]+[CODE]` |
| `FoulingPointOffset` | `FoulingPointOffset` | double | `[DECOMP]+[CODE]` |
| `FoulingPointModelId` | `FoulingPointModelId` | Guid | `[DECOMP]+[CODE]` |
| `ShowCommonBeamDistance` | `ShowCommonBeamDistance` | bool | `[DECOMP]+[CODE]` |
| `CommonBeamDistance` | `CommonBeamDistance` | double | `[DECOMP]+[CODE]` |
| `AfterCommonBeamDistance` | `AfterCommonBeamDistance` | double | `[DECOMP]+[CODE]` |
| `SecondAlignmentRelativePath` | `SecondAlignmentRelativePath` | string | `[DECOMP]+[CODE]` |
| `M` | `M` | double | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `A0` | `A0` | double | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `A` | `A` | double (get-only) | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `B0` | `B0` | double | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `Q1` | `Q1` | double | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `B` | `B` | double (get-only) | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `Length` | `Length` | double (get-only) | `[DECOMP]+[CODE]` (SimpleTurnout) |
| `StartPosition` | `StartPosition` | Vector2D | `[DECOMP]+[CODE]` |
| `EndPosition` | `EndPosition` | Vector2D | `[DECOMP]+[CODE]` |
| `SecondPosition` | `SecondPosition` | Vector2D | `[DECOMP]+[CODE]` |
| `CommonBeamMainWayPosition` | `CommonBeamMainWayPosition` | Vector2D (get-only) | `[DECOMP]+[CODE]` |
| `CommonBeamSecondWayPosition` | `CommonBeamSecondWayPosition` | Vector2D (get-only) | `[DECOMP]+[CODE]` |

---

## Как воспроизвести декомпиляцию

```bash
# Список всех типов сборки (классы / интерфейсы / структуры / enum):
"/mnt/c/Users/zkons/.dotnet/tools/ilspycmd.exe" --list c "C:\\...\\Topomatic.Turnouts.dll"
"/mnt/c/Users/zkons/.dotnet/tools/ilspycmd.exe" --list i "C:\\...\\Topomatic.Turnouts.dll"
"/mnt/c/Users/zkons/.dotnet/tools/ilspycmd.exe" --list s "C:\\...\\Topomatic.Turnouts.dll"
"/mnt/c/Users/zkons/.dotnet/tools/ilspycmd.exe" --list e "C:\\...\\Topomatic.Turnouts.dll"

# Декомпиляция конкретного типа (pub-члены читаемы, приватные обфусцированы):
# результат сохранять в Tools/Decomp/ (см. Tools/DECOMPILATION.md):
"/mnt/c/Users/zkons/.dotnet/tools/ilspycmd.exe" \
  -t "Topomatic.Turnouts.SimpleTurnout" \
  "C:\\OpnCod_Proj\\PluginExample-main\\Development\\Out\\Bin\\Topomatic.Turnouts.dll" \
  > Tools/Decomp/Topomatic.Turnouts.SimpleTurnout.cs
```

**Важно:** ilspycmd v11 требует файл-аргумент как **полный Windows-путь** (из WSL
относительные пути не резолвятся). Подробности — `Tools/DECOMPILATION.md`.

---

## Заметки для реализации импорта

1. **Создание `SimpleTurnout`:** конструктор с 22 аргументами (см. выше). Все позиционные
   аргументы обязательны. После создания — `gridiron.Add(item)` (Id присваивается автоматически).

2. **Создание `BufferStop`:** конструктор `BufferStop(object parent, string name)`.
   Minimal: `new BufferStop(gridiron, "УП")`.

3. **Создание `GridironElement`:** конструктор `GridironElement(object parent, string name, double offset, bool drawBackward)`.
   Minimal: `new GridironElement(gridiron, "Начало пути", 0.0, false)`.

4. **Порядок��作аций:**
   ```
   gridiron.BeginUpdate();
   try {
       var turnout = new SimpleTurnout(gridiron, ...params...);
       gridiron.Add(turnout);     // ← Id присваивается здесь
       var stop = new BufferStop(gridiron, "УП");
       gridiron.Add(stop);
   } finally { gridiron.EndUpdate(); }
   ```

5. **Undo:** контейнер наследует `UndoObject`; `BeginUpdate()/EndUpdate()` обязательны.
   Откат — `Rollback()`.

6. **Link** (`gridironObject.Link`): содержит привязку `Alignment` + `Station` + `Offset`.
   Стартовая/конечная станция вычисляются из Link при `Refresh()`.
   При сохранении в JSON пишутся `StartPosition`/`EndPosition` как Vector2D (не станция).

7. **Формат Vector2D в JSON:** `"X:447,986505... Y:1716,140013..."` — локаль с запятой.
   Парсинг: после `X:` всё до пробела, после `Y:` — до конца строки. Локаль — `CultureInfo("ru-RU")`.

8. **Эталонные данные:** `Development/Out/Bin/Export_Rail1/Путь 1.railx/model/Turnouts/turnouts.json`
   — 3 элемента (SimpleTurnout «1А» id=1, BufferStop «УП» id=4, GridironElement «Начало пути» id=5).

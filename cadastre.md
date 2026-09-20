# ApiNotes — Кадастр: модель `Topomatic.Cadastre`, команды `Topomatic.Cadastre.Controller`

Модуль «Кадастр» Robur. Разбор выполнен декомпиляцией (ilspycmd 11, Windows)
эталонных сборок 16.0.62.x (`Development/Out/Bin`), статус всех записей — `[DECOMP]`,
если не указано иное. Декомпиляции типов лежат в `Tools/Decomp/Topomatic.Cadastre.*.cs`.

## Общая картина (важно прочитать первым)

API разделён на два слоя:

| Слой | Сборка | Ссылки | Что внутри |
|---|---|---|---|
| **Модель данных** | `Topomatic.Cadastre.dll` | 6: mscorlib, System, System.Core, System.Xml, `Topomatic.FoundationClasses`, `Topomatic.Cad.Foundation` — **никаких UI/платформенных зависимостей** | Домен кадастра, **команд `[cmd]` нет** |
| **Команды + UI** | `Topomatic.Cadastre.Controller.dll` | 24: ядро `Topomatic.Cadastre` + UI-стек (ApplicationPlatform, Controls, Cad.View, Stg, Sfc, Dtm, Alg.Layers, Planchet, Maps, Dwg, Tables…) | Все **82 команды `[cmd]`** (обфусцированы, но значения атрибутов целы), классы `CadastrePluginHost`, `CadastreSettingsFrame`, `CadastralObjectsSheetFrame`, `Wrappers.*` |

⚠️ **Главное правило:** все команды и UI живут в контроллере; ядро `Topomatic.Cadastre.dll` —
чистая модель (наследует `UpdatableObject` → undo), читаемая и из своих плагинов, и из
внешних. Контроллер **не вызывает чужие команды** (в IL нет `Plugins.Execute`
/`ApplicationHost`).

Модель загружается из **кадастровых XML-выписок Росреестра** (`LoadFromFile` разбирает
XML: записи о ЗУ, ЗОУИТ, объектах капитального строительства, правах, пространственных
частях; ~6900 строк приватных парсеров `<Read*Node>`).

---

### [Cadastre]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Корневой класс кадастра. Хранит все участки, границы, объекты
  недвижимости и права; умеет читать XML-выписку и отвечать на запросы «по кадастровому
  номеру», «по округу/району/кварталу».
- **Члены** (`sealed class Cadastre : UpdatableObject, IOwned`):
  - `Cadastre(object owner)` — конструктор; `owner` — узел-родитель модели.
  - `CadastralNumber`-запросы: `GetParcel(CadastralNumber)`, `GetParcel(string district, string area, string quarter, string number)`, `GetConstruction(CadastralNumber)`, `GetCadastralObject(CadastralNumber)`, `GetBound(string regNumber)`. Возвращают `null`, если объект не найден.
  - Дерево районирования: `Districts` (`string[]`), `GetAreasForDistrict(string district)`, `GetQuartersForArea(string district, string area)`.
  - Коллекции: `Parcels` (`IList<Parcel>`), `SpatialData` (`IList<EntitySpatial>` — все контуры напрямую), `Bounds` (`IList<Bound>`), `ObjectsRealty` (`IList<Construction>`), `RightRecords` (`IEnumerable<RightRecord>`).
  - Прочее: `RequestDate` (строка — дата запроса выписки), `Contains(CadastralObject)`, `LoadFromFile(string fullpath)`, `Owner` (object).
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - `Cadastre` — единственный `UpdatableObject` в модели. Любые изменения → в
    `BeginUpdate()`/`EndUpdate()` (иначе сломается undo). Дочерние классы — простые POCO.
  - Дата и площадь всюду — **строки** (`RequestDate`, `RegistrationDate`, `Area`), парсить
    вручную; `Cost` — `double?`.
  - Порядок загрузки: сначала `new Cadastre(owner)`, затем `LoadFromFile(path)`; до
    `LoadFromFile` коллекции пусты, а не `null`.
- **Пример использования (C#):**
```csharp
using Topomatic.Cadastre;

var cadastre = new Cadastre(/* узел-родитель модели */);
cadastre.LoadFromFile(xmlStatementPath);   // выписка Росреестра (XML)

// Все округа → районы → кварталы
foreach (var d in cadastre.Districts)
    foreach (var a in cadastre.GetAreasForDistrict(d))
        foreach (var q in cadastre.GetQuartersForArea(d, a))
            Console.WriteLine($"{d}:{a}:{q}");

// Участок по номеру
var cn = new CadastralNumber("50:20:0010118:25");
var parcel = cadastre.GetParcel(cn);
if (parcel != null)
    Console.WriteLine($"{parcel.CadastralNumber} — {parcel.Area} м², категория {parcel.Category.Value}");
```

---

### [CadastralNumber]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Типизированное кадастровое обозначение «Округ:Район:Квартал:Номер [/Часть]» с разбором из строки.
- **Члены:**
  - Конструкторы: `CadastralNumber(string district, string area, string quarter, string number)`,
    `CadastralNumber(CadastralNumber number, string part)` (часть наследует номер родителя),
    `CadastralNumber(string sourceText)` — парсит `"DD:AA:QQ:NN"` и `"DD:AA:QQ:NN/часть"`.
  - Свойства (только get): `District`, `Area`, `Quarter`, `Number`, `Part`.
  - `Equals(object)` — регистронезависимое сравнение **всех пяти** частей; `GetHashCode()`;
    `CompareTo(CadastralNumber)`; `ToString()`.
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - `CompareTo` **игнорирует `Part`**, а для `Number` сравнивает сначала длину, затем
    лексически — сортировка номеров 10 и 2 даёт 2 < 10.
  - `Equals/GetHashCode` и `CompareTo` ведут себя по-разному: Equals учитывает Part, CompareTo — нет.
  - Парсер `CadastralNumber(string)` — наивный `Split(':')`/`Split('/')`; на мусорной строке
    возможен `IndexOutOfRangeException` (обращение к `array[0]` до проверки длины).
- **Пример использования (C#):**
```csharp
var a = new CadastralNumber("50:20:0010118:25");
var b = new CadastralNumber(a, "1");          // часть участка
Console.WriteLine(b.ToString());              // "50:20:0010118:25/1"
Console.WriteLine(a.Equals(new CadastralNumber("50:20:0010118:025"))); // false — строковое сравнение
```

---

### [CadastralObject]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Базовый класс «кадастровый объект» — общее для ЗУ и объектов капитального строительства: номер, дата, площадь, старая нумерация, пространственная часть, разрешённые использования, «предки/потомки» по номеру.
- **Члены:**
  - Свойства: `CadastralNumber` (get, `internal set`), `RegistrationDate` (string), `Area` (string), `OldNumbers` (`IList<OldNumber>`), `Spatial` (`EntitySpatial`), `PermittedUses` (`IList<string>`), `AscendantCadNumbers` / `DescendantCadNumbers` (`IList<CadastralNumber>`).
  - Поля: `QuarterNumber` (`CadastralNumber`), `Cost` (`double?`).
- **⚠️ Ловушки и подводные камни (Pitfalls):** `Area` — строка (из XML), не `double`; пустые значения — `string.Empty`, а не `null`. `CadastralNumber` имеет `internal set` — менять извне нельзя, только пересоздать объект.
- **Пример использования (C#):**
```csharp
// Перебор объектов — только через коллекции/запросы Cadastre
foreach (var obj in cadastre.Parcels.Cast<CadastralObject>()
                             .Concat(cadastre.ObjectsRealty))
{
    Console.WriteLine($"{obj.CadastralNumber}: площадь {obj.Area}, дата {obj.RegistrationDate}");
    foreach (var old in obj.OldNumbers) Console.WriteLine($"  ранее: {old}");
}

---

### [Parcel]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Земельный участок (`Parcel : CadastralObject`): категория земель, адреса, части ЗУ (учётные части), обременения, «включённые» объекты.
- **Члены:**
  - `Category` (`CadastralType` — категория земель), `Addresses` (`IList<Address>`), `SubParcels` (`LandPlotPart[]`), `Restrictions` (`IList<Restriction>`), `IncludedObjects` (`IList<CadastralNumber>`).
  - `AddSubParcel(LandPlotPart)` — хранит по ключу `Number`; `GetSubParcel(string partNumber)` — вернёт `null` при отсутствии.
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - `SubParcels` отдаёт **копию-массив** (`Values.ToArray()`), добавление только через `AddSubParcel` (внутренний `Dictionary<string, LandPlotPart>`).
  - `Category` — `CadastralType` (см. ниже), пустой `Code`/`Value` — `string.Empty`.
- **Пример использования (C#):**
```csharp
var p = new Parcel();                       // обычно берётся из cadastre.Parcels
var part = new LandPlotPart(p) { Number = "1" };
p.AddSubParcel(part);
var restored = p.GetSubParcel("1");         // не null
Console.WriteLine(restored.CadastralNumber.ToString()); // "50:20:0010118:25/1"
```

---

### [Construction]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Объект капитального строительства / здание (`Construction : CadastralObject`): назначение, тип, адрес, год постройки, этажность, связь с ЗУ.
- **Члены:**
  - Свойства: `Assignation` (назначение, string), `ConstructionType` (`ConstructionType`, get/set), `Address` (`Address`), `Purpose` (`CadastralType`), `LandCadNumbers` (`IList<CadastralNumber>` — ЗУ, на которых стоит объект).
  - Поля: `Floors` (`byte?`), `UndergroundFloors` (`byte?`), `YearBuilt` (`ushort?`), **`YearCommisioning`** (`ushort?`).
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - **Внимание, в оригинальном API опечатка в названии поля: `YearCommisioning`** (одна `s`) вместо `YearCommissioning`. Пишем именно так — иначе компилятор не найдёт поле. Подтверждено декомпиляцией `Topomatic.Cadastre.dll`.
  - `Address` (свойство) — не `CadastralObject.Addresses`; у `Construction` личный адрес, у `Parcel` — список.
- **Пример использования (C#):**
```csharp
foreach (var c in cadastre.ObjectsRealty)
{
    if (c.ConstructionType == ConstructionType.Uncompleted)
    {
        Console.WriteLine($"{c.CadastralNumber}: {c.Assignation}, {c.YearBuilt}–{c.YearCommisioning}"); // опечатка API намеренно
        foreach (var ln in c.LandCadNumbers) Console.WriteLine($"  на ЗУ {ln}");
    }
}
```

---

### [Address]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Адрес (преимущественно ФИАС): простые строки + типизированные поля населённых пунктов.
- **Члены:**
  - Строки: `OKATO`, `KLADR`, `Region`, `PostalCode`, `Other`, `Note`, `ReadableAddress`.
  - `TypedString`-поля: `District`, `City`, `Locality`, `Street`, `Level1`, `Level2`, `Level3`, `Apartment`, `UrbanDistrict`, `SovietVillage`.
  - `ToString()` → `ReadableAddress`.
- **Суть `Address.TypedString`:** пара `Value` + `Type` (тип населённого пункта: «г.», «пос.» и т.п.), `ToString()` = тип + разделитель + значение.
- **⚠️ Ловушки и подводные камни (Pitfalls):** `TypedString` — класс, поля не `null` после `LoadFromFile`, но могут быть пустыми; на вручную созданном `Address` типизированные поля — `null` (инициализации в ctor нет).
- **Пример использования (C#):**
```csharp
var a = address.City; // TypedString
Console.WriteLine($"{a.Type} {a.Value}");   // например "г. Москва"
Console.WriteLine(address.ReadableAddress);  // полный читаемый адрес
```

---

### [EntitySpatial]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Пространственная часть объекта: набор контуров, разделённых на внешние/внутренние, плюс сведения о границах (`Borders`).
- **Члены:**
  - `EntitySpatial(object owner)`; `Owner` (object); поле `Sk_Id` (string).
  - `HasContours` (bool), `OuterContours` (`SpatialElement[]`), `InnerContours` (`SpatialElement[]`), `Elements` (`IList<SpatialElement>`), `Borders` (`IList<Borders>`).
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - Контуры **вычисляются лениво** и кэшируются: `OuterContours` сортирует замкнутые элементы по убыванию площади (`CadLibrary.PolygonArea`) и вкладывает меньшие в большие (полигон-в-полигоне); `InnerContours` — всё, что не попало во внешние. Работает корректно только при наличии замкнутых контуров.
  - `HasContours == true` — только если есть **замкнутый** элемент с точками.
- **Пример использования (C#):** см. `SpatialElement`.

---

### [SpatialElement]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Один контур. `SpatialElement : List<SpelementUnit>` — сам является списком точек.
- **Члены:**
  - `SpatialElement(EntitySpatial owner)`; свойства `EntitySpatial`, `IsClosed` (первая точка совпадает с последней, `EqualsEps`), `IsOuter`, `InnerContours` (`List<SpatialElement>`), `Contour` (`Vector2D[]`), `Id` (string).
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - `Id` строит `"{кадномер/рег.номер}:{индекс}"`, но если владелец не распознан (`owner` не `CadastralObject`/`Boundary`/`Cadastre`) — **бросает `Exception`** (не `null`!). Для свежесозданного элемента не читайте `Id` без owner-контекста.
  - `IsClosed` — по совпадению первой и последней точки, а не по флагу замкнутости: контур с 1 точкой тоже «замкнут» по этой логике.
- **Пример использования (C#):**
```csharp
var sfc = parcel.Spatial;                     // EntitySpatial
foreach (var el in sfc.OuterContours)
{
    Console.WriteLine($"Внешний контур {el.Id}, точек {el.Count}, замкнут {el.IsClosed}");
    Vector2D[] pts = el.Contour;              // Robur-координаты (восток, север)
}
```

---

### [SpelementUnit]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Точка контура в **кадастровой системе координат**.
- **Члены:** `Number` (int), `X` (double), `Y` (double), `R` (`double?`), `ToVector2D()` → `Vector2D`.
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - **Критично:** `ToVector2D()` возвращает `new Vector2D(Y, X)` — **оси переставлены**. Кадастровые выписки дают точки в порядке «север, восток» (`X` — на север), а Robur `Vector2D` — «восток, север». Всегда берите точки через `ToVector2D()` (или переставляйте вручную), иначе контур окажется отражённым относительно диагонали.
  - `R` — радиус (для криволинейных участков границы, `double?`).
- **Пример использования (C#):**
```csharp
foreach (var s in spatialElement)             // SpatialElement : List<SpelementUnit>
{
    Vector2D v = s.ToVector2D();              // (Y, X) → (X, Y) — единственно верный способ
    // далее v.X = восток, v.Y = север — можно рисовать линию/ломаные
}
```

---

### [Bound] / [ZoneBound] / [CoastlineBound] / [Boundary] / [Border] / [Borders]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Границы (ЗОУИТ, муниципальные/нас. пунктов, береговая линия) и их составные части.
- **Члены:**
  - `Bound(BoundType)`; поля `RegNumbBorder` (string), `RegistrationDate` (string); свойства `Boundaries` (`IList<Boundary>`), `Type` (`CadastralType`), `BoundType` (virtual).
  - `ZoneBound : Bound` — поля `Number`, `Index`, свойство `TypeZone` (`CadastralType`); пустой ctor → `BoundType.SpecialZone`.
  - `CoastlineBound : Bound` — поле `WaterObjectName`, свойство `WaterObjectType`; пустой ctor → `BoundType.Coastline`.
  - `Boundary : List<EntitySpatial>` — ctor `Boundary(Bound owner)`, свойство `Bound`.
  - `Border` — `Spatial` (int), `Point1` (int), `Point2` (int), `Neighbours` (`string[]`); `Borders : List<Border>`.
- **⚠️ Ловушки и подводные камни (Pitfalls):** `RegNumbBorder` — регистрационный номер границы, не кадастровый; `GetBound(string)` в `Cadastre` ищет именно по нему. Свойство `BoundType` объявлено `virtual`, подклассы задают тип в конструкторе через базу.
- **Пример использования (C#):**
```csharp
foreach (var b in cadastre.Bounds)
{
    if (b is ZoneBound zb)
        Console.WriteLine($"ЗОУИТ {zb.Index}: {zb.TypeZone.Value}");
    foreach (var boundary in b.Boundaries)    // List<EntitySpatial>
        foreach (var es in boundary)
            foreach (var el in es.OuterContours)
                Console.WriteLine($"контур {el.Id}");
}
```

---

### [LandPlotPart]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Учётная часть ЗУ (обременённая/переданная часть) со своей пространственной частью и обременением.
- **Члены:**
  - `LandPlotPart(Parcel owner)`; поля `Date`, `Number`, `Mnemonic` (string).
  - Свойства: `CadastralNumber` (строится как `new CadastralNumber(owner.CadastralNumber, Number)`), `Area` (string, **get/set**), `Parcel`, `Restriction` (см. ловушку), `Spatial` (`EntitySpatial`).
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - `Restriction` не хранится, а **вычисляется**: сначала поиск по `PartNumber == Number`, затем по `Mnemonic.StartsWith(RegNumberBorder)`, иначе возвращается **новый пустой** `Restriction` с `PartNumber = Number` (не `null`!). Не полагайтесь на не-null вложенности.
  - `Number` — ключ в `Dictionary` участка; уникален в пределах ЗУ.
- **Пример использования (C#):**
```csharp
var part = parcel.GetSubParcel("1");
if (part != null)
{
    Console.WriteLine($"{part.CadastralNumber}: {part.Area}, ограничение: {part.Restriction.Content}");
    foreach (var el in part.Spatial.OuterContours) { /* контуры части */ }
}
```

---

### [Restriction]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Обременение/ограничение по ЗУ.
- **Члены:** поля `PartNumber`, `Content`, `RegNumberBorder` (string); свойства `Type` (`CadastralType`), `IsEasement` (bool).
- **⚠️ Ловушки и подводные камни (Pitfalls):** `IsEasement` определяется сравнением `Type.Code` с внутренней ресурсной константой (обфусцирована, код не публикован) — не пытайтесь воспроизвести константу, используйте свойство.
- **Пример использования (C#):**
```csharp
foreach (var r in parcel.Restrictions)
    if (r.IsEasement)
        Console.WriteLine($"Сервитут: {r.Content} (№{r.RegNumberBorder})");
```

---

### [RightRecord] / [RightHolder]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Регистрационные записи о правах и правообладатели.
- **Члены:**
  - `RightRecord` — поля `RightType` (`CadastralType`), `RightNumber` (string), `RightHolders` (`List<RightHolder>`); свойство `RegistrationDate`.
  - `RightHolder` — поля `Name` (string), `Individual` (bool).
- **⚠️ Ловушки и подводные камни (Pitfalls):** `RightRecord.RightHolders` — публичное поле-список, инициализируется в ctor; `ToString()` перебирает правообладателей и **обращается к `RightHolders.Count`** — на нулевом списке безопасен (условие `> 0`).
- **Пример использования (C#):**
```csharp
foreach (var rec in cadastre.RightRecords)
    foreach (var holder in rec.RightHolders)
        Console.WriteLine($"{rec.RightType.Value}: {holder.Name} (физлицо: {holder.Individual})");
```

---

### [CadastralType]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Классификатор «код/значение» (категория земель, тип границы, тип права и т.д.).
- **Члены:** поля `Code` (string), `Value` (string); пустой ctor заполняет `string.Empty`.
- **⚠️ Ловушки и подводные камни (Pitfalls):** Значения — строки Росреестра (например, код категории земель); для отображения используйте `Value`, для сравнения — `Code`.
- **Пример использования (C#):**
```csharp
Console.WriteLine($"{parcel.Category.Code} — {parcel.Category.Value}"); // например "003001000000" — "Земли... "
```

---

### [OldNumber]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Прежний (условный) кадастровый/инвентарный номер объекта.
- **Члены:** поля `Number`, `AssignmentDate`, `Assigner` (string); свойство `Type` (`CadastralType`); `ToString()` (пустой `Number` → «нет данных»).
- **⚠️ Ловушки и подводные камни (Pitfalls):** `Number` может быть условным номером (не по формату кадастрового) — не парсить в `CadastralNumber`.
- **Пример использования (C#):**
```csharp
foreach (var old in obj.OldNumbers)
    Console.WriteLine(old.ToString());
```

---

### [BoundType]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Тип границы/территории.
- **Значения:** `Municipal = 0` (муниципальные), `InhabitedLocality = 1` (населённые пункты), `SpecialZone = 2` (ЗОУИТ), `Coastline = 3` (береговая линия).
- **⚠️ Ловушки и подводные камни (Pitfalls):** Порядок индексов совпадает со значениями `%1` в командах `cadastre_show_*`/`cadastre_hide_*` и манифесте `cadastre.plugin` (`cadastre_get_bounds,%0,0..3`).
- **Пример использования (C#):**
```csharp
var b = new ZoneBound();       // BoundType.SpecialZone
if (b.BoundType == BoundType.SpecialZone) { /* ЗОУИТ */ }
```

---

### [ConstructionType]
- **Пространство имен:** `Topomatic.Cadastre`
- **Статус исследования:** `[DECOMP]`
- **Суть компонента:** Тип объекта капитального строительства.
- **Значения:** `Building = 0` (здание), `Construction = 1` (сооружение), `Uncompleted = 2` (незавершённый).
- **⚠️ Ловушки и подводные камни (Pitfalls):** Индексы используются в манифесте (`cadastre_get_capital_construction_objects,%0,0..2`) — не меняйте порядок.
- **Пример использования (C#):** cм. `Construction`.

---

### Команды кадастра (слой Controller)
- **Пространство имен:** `Topomatic.Cadastre.Controller` (классы обфусцированы)
- **Статус исследования:** `[DECOMP]` (IL-дамп + манифест `cadastre.plugin`)
- **Суть компонента:** Все **82 команды `[cmd]`** зарегистрированы в `Topomatic.Cadastre.Controller.dll`; значения атрибутов не обфусцированы. Тот же список — в `actions`/`coreitems`/`broadcasts` манифеста `cadastre.plugin`.
- **Группы команд:**
  - Жизненный цикл: `int_add_new_cadastre`, `int_cadastre_remove`, `int_cadastre_rename`, `int_cadastre_on/off/-visible`.
  - Чтение для `$(...)`-макросов дерева: `cadastre_get_districts`, `cadastre_get_areas`, `cadastre_get_quarters`, `cadastre_get_bounds`, `cadastre_get_land_plots`, `cadastre_get_capital_construction_objects`, `cadastre_get_easements`, `cadastre_get_restrictions`, `cadastre_get_bound_caption`, `has_cadastres`, `project_has_cadastres`, `cadastral_object_icon` и др.
  - Отображение: `cadastre_show_*`/`cadastre_hide_*` (по каждому типу), `cadastre_areas_visible`, `cadastre_hilight_objects`, `cadastre_extract_contour`, `cadastre_align`.
  - Дерево: `cadastre_structure_select_item_{bound,cadastral_object,land_plot_part,spatial_element}`.
  - Ведомости/чертёж: `generate_cadastral_objects_sheet`, `cadastral_objects_sheet`, `cadastre_generate_planchet`, `cadastre_adddtmlayer`, `cadastre_removedtmlayer`.
- **⚠️ Ловушки и подводные камни (Pitfalls):**
  - Модель (ядро) команд не имеет — вызывать кадастровый UI из своих плагинов можно только через `ApplicationHost.Current.Plugins.Execute(...)` (внешние команды из контроллера сами не вызываются).
  - Классы контроллера обфусцированы (имена — `\u0086…`), но стабильно: хост `CadastrePluginHost` (по манифесту), окна `CadastreSettingsFrame`/`CadastralObjectsSheetFrame`, обёртки `Wrappers.AddressWrapper/CadastralObjectWrapper/BoundWrapper` — не ссылаться по именам обфускации в коде плагинов.
  - `ikdasm` на контроллер падает (обфускация ломает IKVM); рабочие инструменты — `ilspycmd` (Windows) и `monodis`.
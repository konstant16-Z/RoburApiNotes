# PropertyGrid — инспектор свойств Robur

**Статус:** `[DECOMP]` — снято `ilspycmd` с `Development/Out/Bin/Topomatic.ComponentModel.dll`
и `Topomatic.Controls.dll` (16.0.62.12); сверка публичной поверхности — `apiq`
(слои `Bin`/`Bin_16_50` — совпадают, и `Slayed_16_50` для приватных имён).
**Доказательства:**
`Tools/Decomp/Topomatic.ComponentModel.PropertyExplorer.cs` (свежая съёмка типа, обфусцированные
имена сохранены), `Tools/Decomp/Topomatic.ComponentModel.MultiProperty_Cleaned.cs`,
`Tools/Decomp/Topomatic.Controls.PropertyGridHeader_Cleaned.cs` (de4dot-слой — читаемые
`method_N`/`list_N`/`bool_N`), `Tools/Decomp/Topomatic.Controls/Topomatic.Controls.ObjectInspection.PropertyGrid/`
(съёмка всего пространства имён). Публичные имена в метаданных Robur **не обфусцированы**.

Суть: `Topomatic.Controls.ObjectInspection.PropertyGrid` — таблица «свойство × объект»
(в Robur это панель «Свойства» в инспекторе объектов, окна настроек динамических параметров,
окна статистики). Столбцы строятся **рефлексией по типам переданных объектов**, значения
живут в самих объектах (сеттеры), отсюда — главная ловушка всей темы.

---

## 1. Минимальное использование

```csharp
using Topomatic.Controls.ObjectInspection.PropertyGrid;

public class MyDlg : Form
{
    private PropertyGrid grid = new PropertyGrid();

    public MyDlg(IEnumerable items)   // items — объекты-редакторы (wrapper'ы)
    {
        grid.Dock = DockStyle.Fill;
        grid.AfterPropertyUpdate += (s, e) => { /* значение уже записано в модель */ };
        Controls.Add(grid);
        grid.SelectObjects(items);     // ВАЖНО: см. §3 — коллекция без null!
    }
}
```

`SelectObjects` **только запоминает** коллекцию и делает `Invalidate()`:

```csharp
public void SelectObjects(IEnumerable items)
{
    SelectedColumn = null;
    SelectedRow = -1;
    if (Header != null)
    {
        Header = null;          // сброс старого заголовка
        GC.Collect();
    }
    this._0086_0086_0086_000D_000A_0086_0086_0086_0086_0089_0092 = items;   // _items
    this._0086_0086_0086_000D_000A_0086_0086_0086_0086_0089_0091 = true;      // _needInit
    Invalidate();                                                              // ← работа отложена на Paint
}
```

То есть ошибки внутри вызова не будет — они всплывут позже, **на перерисовке** (отсюда
странные стектрейсы без указания на чужой код, см. §4).

## 2. Цепочка вызовов (декомпиляция `PropertyGrid`)

| Кадр стектрейса | Код | Что делает |
|---|---|---|
| `PropertyGrid.OnPaint` | `PropertyGrid.Initialize()` | ленивая инициализация: `if (_needInit) { Header = new PropertyGridHeader(_items); Header.ArrangeSize(HeaderDataSize, RowDataSize, …); _needInit = false; }` |
| `PropertyGrid.Initialize()` | `new PropertyGridHeader(_items)` | построение колонок |
| `PropertyGridHeader..ctor(IEnumerable instance)` | `PropertyExplorer.GetProperties(instance)` | свойства переданных объектов |
| `PropertyExplorer.GetProperties(IEnumerable)` | `smethod_0(collection, false)` | общий тип + общие свойства |
| `PropertyExplorer.smethod_0(IEnumerable, bool)` | `smethod_10(list, out type)` | **определение типа по элементам** |
| `PropertyExplorer.smethod_10(IList, out Type)` | `list[i].GetType()` | 💥 **`NullReferenceException` — нет проверки на null** |

`PropertyGridHeader..ctor(IEnumerable instance)` (снимок `PropertyGridHeader.cs`, строки 250–295;
`_0086…_0090` = `_properties : List<MultiProperty>`, `_0086…_0091` = `Rows : RecordsCollection`,
`_0086…87` = `method_11(object)` — построение дерева колонок, тело в
`Tools/Decomp/Topomatic.Controls.PropertyGridHeader_Cleaned.cs`):

```csharp
if (instance is IList && ((IList)instance).Count == 0 && instance is IActivator && ((IActivator)instance).CanCreateInstance)
{
    object obj = ((IActivator)instance).CreateInstance();          // ← может вернуть null!
    _properties = PropertyExplorer.GetProperties(new object[1] { obj });   // NRE, если obj == null
    method_11(instance);
    // «пустые» колонки: все MultiProperty заменяются на CreateEmptyProperty(),
    // значения вычищаются, временный obj Dispose(), если IDisposable
    MultiProperty value = MultiProperty.CreateEmptyProperty();
    for (int i = 0; i < _properties.Count; i++) { _properties[i] = value; }
    foreach (PropertyGridColumn dataColumn in GetDataColumns()) { dataColumn.Property = value; }
    if (obj is IDisposable) { ((IDisposable)obj).Dispose(); }
}
else
{
    _properties = PropertyExplorer.GetProperties(instance);        // ← NRE, если в списке null
    method_11(instance);
}
// строки = «экземпляры» первого MultiProperty
if (_properties.Count > 0)
{
    _rows = new RecordsCollection();
    _rows.Collection.Capacity = _properties[0].Count;              // Count = число объектов
    for (int j = 0; j < _properties[0].Count; j++) { _rows.Add(new PropertyGridRow(j)); }
}
```

Отсюда же: строки грида — это **объекты** (`PropertyGridRow(j)` на каждый инстанс), а
свойства-колонки — `MultiProperty`; `MultiProperty.GetInstance()` отдаёт исходный `IList`.

`method_11(object)` (тело — `Tools/Decomp/Topomatic.Controls.PropertyGridHeader_Cleaned.cs`, ~строка 107)
и есть «сборка колонок»:

```csharp
class7_0 = PropertyGridColumnsSettings.Current.method_0(object_0, list_2);   // видимость/порядок по настройкам
for (int i = 0; i < list_2.Count; i++)
{
    if (!((CustomProperty)list_2[i]).IsBrowsable || !class7_0.method_1(i)) continue;   // скрыто настройками
    string category = ((CustomProperty)list_2[i]).Category;                            // «Категория/Подкатегория»
    PropertyGridColumn column = this;
    if (category != string.Empty)                                        // вложенные колонки-категории
    {
        foreach (var s in category.Split(PropertyExplorer.CategoryDelimiter))
        {
            // method_0() -> List<PropertyGridColumn> (internal) = дочерние колонки
            var parent = column.method_0().Find(obj => string.Compare(s, obj.Text, true) == 0 && column.RowsCount == 0);
            if (parent == null)                                     // уровень категории ещё не создан
            {
                parent = new PropertyGridColumn(column) { Text = s };
                column.method_0().Add(parent);
            }
            column = parent;
        }
    }
    var dataColumn = new PropertyGridColumn(column) { Text = ((CustomProperty)list_2[i]).DisplayName, … };
    …
}
```

Практический смысл: `PropertyGridColumnsSettings.Current` (public static; `SaveToStg/LoadFromStg`,
внутренне `method_0(object instance, IList<MultiProperty>)`) может **спрятать** свойство —
тогда колонки не будет, и это не ошибка. `PropertyExplorer.CategoryDelimiter` — public static
**char**-поле (в базе `CategoryDelimiter -> prim:3`, есть и в 16.0.50.8, и в 16.0.62.12),
задаёт разделитель уровней категорий.

## 3. Ловушка №1: **null в коллекции → NRE на `Object.GetType()`** `[DECOMP]`

Метод `PropertyExplorer.smethod_10(IList, out Type) -> void` (`private`; по базе
`smethod_10(System.Collections.IList,System.Type&) -> prim:1`, где `prim:1` = void),
тело целиком — цикл без null-проверок (снимок `Tools/Decomp/Topomatic.ComponentModel.PropertyExplorer.cs`, ~строка 737):

```csharp
List<Type> list = new List<Type>();
P_1 = null;                                   // out commonType
for (int i = 0; i < P_0.Count; i++)
{
    Type type = P_0[i].GetType();             // ← строка падения: элемент коллекции == null
    if (P_1 == null) { P_1 = type; list.Add(type); }
    else if (!list.Contains(type)) { list.Add(type); smethod_11(P_1, type, out P_1); }
}
```

Вызывающий `smethod_0(IEnumerable, bool)` (снимок, ~строка 299) — отсюда видно, что
проверяются все элементы, а не только первый, и что `null`-коллекция/пустая безопасны:

```csharp
IList list = default(IList);
if (P_0 != null)
{
    list = ((P_0 is IList) ? (P_0 as IList) : new EnumerableList(P_0));
    if (list.Count > 0)
    {
        smethod_10(list, out var type);                       // ← NRE внутри
        object[] customAttributes = type.GetCustomAttributes(...InspectDescendantTypesAttribute..., false);
        if (!P_1 && customAttributes != null && customAttributes.Length > 0
            && ((InspectDescendantTypesAttribute)customAttributes[0]).Inspect)
            return smethod_1(list);                          // разбор потомков — тот же цикл
        list2 = smethod_2(type, list[0], list);              // общие свойства; list[0] — первый элемент
        ...
    }
}
return new List<MultiProperty>();
```

Следствия, которые надо знать:

- Падает **любой** null в коллекции — не только первый: цикл идёт по всем элементам
  (`P_0[i]`), а не по `list[0]`. Список из 10 объектов с одним `null` на позиции 7 упадёт.
  Второй путь — `smethod_1(list)` (разбор потомков, если у типа стоит
  `[InspectDescendantTypes(Inspect = true)]`) перебирает ту же коллекцию.
- Коллекция из **одного** `null` тоже падает (`P_0[0].GetType()`).
- **Пустая** коллекция безопасна: `if (list.Count > 0)` → возвращается пустой `List<MultiProperty>`.
- **Ссылка на саму коллекцию `null`** безопасна: `if (P_0 != null)`.
- `IList`-обёртка не спасает: `list = (P_0 as IList) ?? new EnumerableList(P_0)` — `EnumerableList`
  лишь оборачивает перечисление, `null`-элементы остаются.
- Вторая точка входа: пустой `IList` + `IActivator.CanCreateInstance` → `CreateInstance()`,
  если он вернул `null`, падает тот же `GetProperties(new object[1]{ null })`.

> **Про имена в стектрейсе.** В дистрибутиве Robur приватные члены обфусцированы, поэтому в
> реальном трейсе вместо `smethod_10` / `smethod_0` видны пустые кадры
> `PropertyExplorer.(IList , Type& )` и `PropertyExplorer.(IEnumerable , Boolean )`.
> `smethod_10`/`smethod_0`/`smethod_1`/`smethod_2`/`smethod_11` — имена из слоя `Slayed`
> (de4dot) по `Development/Out/api-base.db`; сигнатуры совпадают с кадрами трейса один в один.

**Симптом у пользователя Robur (типовой стектрейс, 16.0.62.x):**

```
System.NullReferenceException
   в System.Object.GetType()
   в Topomatic.ComponentModel.PropertyExplorer.(IList , Type& )          // = smethod_10
   в Topomatic.ComponentModel.PropertyExplorer.(IEnumerable , Boolean )   // = smethod_0
   в Topomatic.ComponentModel.PropertyExplorer.GetProperties(IEnumerable collection)
   в Topomatic.Controls.ObjectInspection.PropertyGrid.PropertyGridHeader..ctor(IEnumerable instance)
   в Topomatic.Controls.ObjectInspection.PropertyGrid.PropertyGrid.Initialize()
   в Topomatic.Controls.ObjectInspection.PropertyGrid.PropertyGrid.OnPaint(PaintEventArgs e)
   в System.Windows.Forms.Control.PaintWithErrorHandling(PaintEventArgs e, Int16 layer)
```

Это **баг Robur** (нет `if (P_0[i] == null) continue;`), а не ошибка вашего кода, если `SelectObjects`
вы не вызываете сами. Лечится на стороне вызова: не отдавать в грид коллекцию с `null`.

**Рецепт безопасной передачи:**

```csharp
// 1. Всегда фильтровать null (и сам объект, и контейнер, если он IEnumerable)
var items = raw.Where(x => x != null).ToList();
if (items.Count == 0) { grid.SelectObjects(new object[0]); return; }   // пусто — безопасно
grid.SelectObjects(items);

// 2. Не отдавать «сырые» списки моделей, где элемент может быть не создан:
foreach (var node in model.Nodes) { var m = node.Model; if (m != null) list.Add(m); }
```

Отдельно про источники `null` (внутри Robur):

- `node.Model == null` — известная ловушка: сразу после `LockWrite()` свойство ещё `null`,
  данные появляются только после `LockRead()` (см. `surface.md` §создание с нуля, `pitfalls.md`);
- `IActivator.CreateInstance()` может вернуть `null` для неполного набора данных;
- обёртки (`wrapper`), у которых владелец не создан — всплывает как NRE, если такой
  `wrapper` положить в список инспектора.

## 4. Ловушка №2: ошибка приходит на Paint, а не на вызов

`SelectObjects` → `Invalidate()` → `OnPaint` → `Initialize()`. Отсюда:

- исключение «в воздухе»: в стектрейсе нет кадра вызывающего кода — ищите последний
  `SelectObjects` в своём коде;
- достаточно **одного** `SelectObjects` с плохой коллекцией, чтобы окно падало на каждой
  перерисовке (скролл, resize, смена вкладки), даже если сетка невидима;
- поэтому чинить надо коллекцию, а не «обрабатывать исключение при отрисовке».

## 5. Ловушка №3: колонки строятся по типам, значения — в объектах

- Набор колонок = общий набор свойств типов переданных объектов (рефлексия,
  `GetCustomAttributes`, `InspectDescendantTypesAttribute`);
- если объекты разнородных типов — колонки строятся по общему предку;
- **редактирование = вызов сеттера** на объекте. Нет публичного сеттера — ячейка только чтение;
  `SharedProperty` у колонки означает «одно значение на все выбранные строки»;
- значение в ячейке читается рефлексией при каждой перерисовке, поэтому после правки модели
  вручную (в обход грида) грид сам не обновится — зовите `Invalidate()` / `SelectObjects(...)`.

Программный доступ к значениям без грида — через `Topomatic.ComponentModel.MultiProperty`
(public, `Topomatic.ComponentModel.dll`):

```csharp
foreach (var mp in PropertyExplorer.GetProperties(items))
{
    if (!mp.GetIsEditable(0)) continue;              // prim:8 = int (индекс строки = номер объекта)
    string name = mp.GetDisplayName(0);
    object v   = mp.GetValue();                      // «общее» значение, см. ниже
    object[] all = mp.GetValues();
    mp.SetValue(newValue, i => /* предикат по строке */ true);
    // вспомогательное: GetStringValue/SetStringValue, ConvertValueToString/ConvertStringToValue,
    //                  GetIsReadOnly, GetIsBrowsable, GetToolTipString, GetCategory, GetDescription,
    //                  GetPropertyInfo, GetPropertyType, GetUpdateSequence→PropertyUpdateSequence,
    //                  GetVisualStyle→VisualStyle, GetConverter→PropertyTypeConverter,
    //                  GetEditor→PropertyEditor, GetInstance()→IList, GetProperty→CustomProperty,
    //                  CreateEmptyProperty()  (всё public, сверка — apiq sig по MultiProperty)
}
```

`MultiProperty` держит список `CustomProperty` (по одному на инстанс, индексатор `this[int]`
→ `GetProperty(index)`) и умеет отдавать «общее» значение. Точная семантика
(`Tools/Decomp/Topomatic.ComponentModel.MultiProperty_Cleaned.cs`, строки 456–513):

```csharp
public object GetValue(int index) => GetProperty(index).GetValue();     // значение конкретного объекта
public void  SetValue(object value, int index) { object_1 = null; GetProperty(index).SetValue(value); }

public override object GetValue()          // «общее» — что показывать в ячейке
{
    if (Count == 0) return null;
    if (bool_3 && IsReadOnly)              // bool_3 = есть [Summarize] у свойства (ctor, строки 269–283)
    {
        if (object_1 == null)              // object_1 = кэш сводки
        {
            object_1 = GetValue(0);
            for (int i = 1; i < Count; i++)
            {
                var v = GetValue(i);
                if (v == null) return null;
                object_1 = SummarizeAttribute.Summarize(object_1, v);
            }
        }
        return object_1;
    }
    object first = GetValue(0);
    for (int i = 1; i < Count; i++)
    {
        var v = GetValue(i);
        if (v == null) return null;
        if (!first.Equals(v)) return null;                     // значения различаются → null
    }
    return first;
}
```

Т.е. `GetValue()` без индекса — это **не** «первое значение»: для `SharedProperty`/агрегатных
колонок это сводка (`SummarizeAttribute.Summarize`), а для обычных — значение только если
все строки совпадают, иначе `null`. В нотации базы: `prim:8` = `int` (индекс строки),
`prim:2` = `bool`, `prim:14` = `string`, `prim:28` = `object`, `prim:1` = `void`.

## 6. Публичная поверхность `PropertyGrid` (16.0.62.x) `[DECOMP]`

| Члены | Назначение |
|---|---|
| `SelectObjects(IEnumerable)` | показать объекты (основной вход) |
| `Header` (`PropertyGridHeader`), `Header.Rows` | строки-свойства, `RecordsCollection : IList<PropertyGridRow>` |
| `Header.GetColumns()`, `Header.GetDataColumns()` | колонки (в т.ч. служебные) — методы **заголовка**, не грида |
| `CommitEdit()` | записать редактируемое значение в объект |
| `EditValue(int button)`, `SetStringValue(PropertyGridColumn, string)` | программная правка значения |
| `AppendInstance(object)`, `InsertItem(...)`, `InsertInterpolateItem(...)`, `DeleteSelected()` | изменение набора объектов |
| `CreateInstance()` | создать объект через `IActivator` коллекции |
| `SelectAll([bool])`, `SelectedRow`, `SelectedColumn`, `SelectionCount`, `ScrollToRow(int)`, `StartRow` | навигация/выделение |
| `Undo()`, `Redo()`, `CanUndo`, `CanRedo`, `Modified`, `ClearUndo()`, `PermitUndoEditValue` | undo/redo грида (свой стек, **не** undo модели) |
| `BeginChange()`, `EndChange()` | группировка изменений (для `Modified`/undo) |
| `CopyRows()`, `PasteRows()`, `CanCopyRows`, `CanPasteRows` | буфер обмена строк |
| `ReadOnlyMode`, `FixedSizeMode`, `Sortable`, `CanAppendItem`, `CanMoveUp/Down` | режимы |
| `DisplayNumerator`, `DisplaySequenceNumber`, `Permitted_HotKeys` (`PermittedHotKeys`), `HScrollBar`/`VScrollBar`, `HorizontalScrollBarVisible`/`VerticalScrollBarVisible`, `LeftOffset`, `Font`, `Focused` | отображение/прокрутка |
| `AfterPropertyUpdate`, `SelectedRowChanged`, `SelectedRowsChanged`, `SelectedColumnChanged`, `BeginUpdate`, `EndUpdate`, `UpdateScrolls`, `CreateMenu` | события |
| `Initialize()` | принудительная пересборка заголовка (то, что зовётся из `OnPaint`) |

`PropertyGridHeader : PropertyGridColumn, ICloneable` — `Rows` (`RecordsCollection`),
`ArrangeSize(...)`, `Clone()`. `PropertyGridRow` — только `Index` и `Selected`.

Смежная публичная поверхность (обе в 16.0.50.8 и 16.0.62.12):

| Тип | Что полезно знать |
|---|---|
| `Topomatic.ComponentModel.CustomProperty` | описание одного свойства: `DisplayName`, `Category`, `Description`, `IsBrowsable`, `IsEditable`, `IsReadOnly`, `Editor` (`PropertyEditor`), `Converter` (`PropertyTypeConverter`), `VisualStyle`, `UpdateSequence`, `NullValue`, `Instance`, `PropertyInfo`, `PropertyType`, `Attributes` |
| `Topomatic.ComponentModel.MultiProperty` | свойство × инстансы; чтение/запись без грида — см. §5 |
| `Topomatic.ComponentModel.InspectDescendantTypesAttribute` | на типе/свойстве: `Inspect` — разворачивать ли свойства потомков (иначе колонок не будет) |
| `Topomatic.ComponentModel.IActivator` | `bool CanCreateInstance { get; }` + `object CreateInstance()` — у пустой коллекции грид спросит «шаблон» типа; `CreateInstance` обязан вернуть **не-null** |
| `PropertyGridColumn` | `Text`, `Parent`, `Property` (`MultiProperty`), `SharedProperty`, `Selected`, `ChildCount`, `RowsCount`, индексатор `Item[int]`, `GetValue(int)`/`SetValue(object,int)`, `GetStringValue(int)`/`SetStringValue(int,string)`, `IsReadOnly(int)`, `EditValue(IPropertyWindowsFormsEditorService,int,int)`, `ClickEdit`/`DoubleClickEdit(IPropertyWindowsFormsEditorService,int)`, `GetEditor(int)`, `GetEditStyle(int)`, `GetCustomButtons(int,int)`, `GetBackGroundColor(int,Color,bool)`, `GetTextColor(int,Color,bool)`, `GetTextAlign(int,VisualStyleAlign,bool)`, `PaintValue(Rectangle,Graphics,int)`, `PaintSupport(int)`, `ClearCache()`, `RefreshCache(int)`, `PrefferedPaintWidth(int,int)` (опечатка в Robur) |
| `PropertyGridRow` | только `Index` (номер инстанса) и `Selected` |

Публичная поверхность `PropertyGridColumn`/`CustomProperty`/`MultiProperty` в 16.0.50.8 и
16.0.62.12 **идентична** (сверено с api-base) — версии можно не различать.

### Свои редакторы, конвертеры, стиль — расширение грида

`PropertyGrid` сам реализует `IPropertyWindowsFormsEditorService`, поэтому кастомный
редактор из плагина подхватывается штатно:

| Тип (public, `Topomatic.ComponentModel`) | Виртуальные/ключевые члены |
|---|---|
| `PropertyEditor` | `EditValue(ITypeDescriptorContext, IServiceProvider, object)`, `ClickEdit`, `DoubleClickEdit`, `GetEditStyle(...) -> PropertyTypeEditorEditStyle`, `GetPaintValueSupported`, `PaintValue`, `GetPreferedPaintWidth`, `GetCustomButtons`, `IsDropDownResizable` |
| `PropertyTypeConverter` | `CanConvertToString`, `CanConvertFromString`, `ConvertToString`, `ConvertFromString`, `ToObject` |
| `VisualStyle` | `Default`, `LeftAligned`, `RightAligned`, `GetTextAlign`, `GetTextColor`, `GetBackGroundColor` |
| `InspectDescendantTypesAttribute` | ctor `(bool inspect)` + `Inspect` — повесить на свойство, чтобы грид развернул потомков |
| `PropertyUpdateSequence` | enum — порядок применения правок при пакетном редактировании |

Вешается это атрибутами на свойство модели (`CustomProperty.Editor/Converter/VisualStyle/
UpdateSequence` читаются рефлексией), т.е. расширяется **модель**, а не грид.

> Ссылки: `Topomatic.Controls` (сам грид), `Topomatic.ComponentModel` (`PropertyExplorer`,
> `MultiProperty`, `IActivator`, `InspectDescendantTypesAttribute`) — обе `Private=False`.
> В `Tools/Decomp` лежит съёмка **всего** пространства
> `Topomatic.Controls.ObjectInspection.PropertyGrid` (файлы `PropertyGrid*.cs`,
> `GridHeader.cs`, `GridNumerator.cs`) — можно дочитывать тела методов.

## 7. Где PropertyGrid встречается в самом Robur

Ссылку на `SelectObjects` содержат **45 сборок** корпуса (`Topomatic.Alg[.Rail/.Road/.Project].Controller`,
`Topomatic.Analysis.Controller`, `Topomatic.ApplicationPlatform`, `Topomatic.Culverts/Glg/Pipes/
Road.Trays/Turnouts/...Controller`, `Topomatic.Cad.View`, `Topomatic.Its/Sites/Sfc/...`) —
проверено поиском строк `SelectObjects` + `ObjectInspection` в метаданных
`Development/Out/Bin/*.dll` (без декомпиляции, поэтому список — верхняя оценка).
Подтверждённые окна в `Topomatic.Analysis.Controller` (de4dot-дамп):

- `RailProjectProfileDynamicControlSettingsDlg` / `RoadProjectProfileDynamicControlSettingsDlg` —
  «Динамические параметры профиля»: `roburPropertyGrid.SelectObjects(m_Statistic)` (список наборов
  параметров профиля на вкладке «Статистика»);
- `PowerLineSagsEditor` — «Провисание проводов»: `SelectObjects(m_Wrapper)` (список провисаний);
- `Topomatic.Alg.Controller`, `Topomatic.Alg.Road.Controller`, `Topomatic.Alg.Rail.Controller`,
  `Topomatic.Alg.Project.Controller`, `Topomatic.Alg.Crossing/Straightening.Controller` — входят
  в те же 45 сборок, т.е. грид показывается и в инспекторах объектов плана/трассы.

Практический вывод: если стектрейс из §3 появился в диалоге Robur (не в вашем окне) — ищите
момент, когда список инспектора содержал не созданный/удалённый объект; ускорить поиск можно
условной точкой останова на `Topomatic.ComponentModel.PropertyExplorer.GetProperties` и стеком
вызовов вверх до `SelectObjects`.

## 8. Связи

- Свойства объектов: `PropertyExplorer` (`Tools/Decomp/Topomatic.ComponentModel.PropertyExplorer.cs`).
- Окна плагина: `plugin.md` §окна; ошибки пользователю — через `MessageDlg.Show`, не `MessageBox`.
- `null`-модели, структуры, undo: `pitfalls.md`.

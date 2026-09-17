# ApiNotes — Каркас плагина

3 обязательных элемента: класс модуля, хост-класс, манифест `.plugin`. Паттерны `[TUT]`
(официальные туториалы), команды-мосты `[CODE]` (боевые плагины).

## Модуль и команды

| API | Назначение | Статус |
|---|---|---|
| `PluginInitializator` — базовый класс модуля, всегда `partial`, может быть `internal` | `internal partial class Module : PluginInitializator` | `[TUT]` |
| `[cmd("имя")] public void M(string prms)` | Команда из `.plugin` (макровызов `$(имя, ...)`); атрибут всегда коротко, через `using` | `[TUT]` |
| `[cmd("имя")] public bool P(string prms)` | Команда-предикат для `flags` | `[TUT]` |
| `public override void Initialize(PluginFactory factory) { base.Initialize(factory); }` | Точка инициализации; здесь регистрируют типы моделей, подписки | `[TUT]` |
| `PluginHostInitializator` — хост, обязан быть `public` | `public class ModulePluginHost : PluginHostInitializator { protected override Type[] GetTypes() => new Type[] { typeof(Module) }; }` | `[TUT]` |

## Мост к хост-приложению

| API | Назначение | Статус |
|---|---|---|
| `ApplicationHost.Current.Plugins.Execute("команда", new object[]{...})` | Вызов чужой/штатной команды (`"mkitem"`, `"getname"`) — не ссылаться на `*.Controller.dll` | `[TUT]` |
| `ApplicationHost.Current.ActiveProject` → `ModelProject` | Текущий активный проект | `[TUT]` |
| `project.TransactionManager.BeginUpdate()/EndUpdate()` | Групповое изменение проекта (в `try/finally`) | `[TUT]` |
| `factory.RegisterModelEditor("type", new ModelEditorInfo(...))` | Регистрация типа модели в `Initialize` | `[TUT]` |

## Манифест `.plugin`

Имя файла **обязательно совпадает** с именем сборки; «Копировать в выходной каталог» = Всегда.

```json
{
  "assemblies": {
    "MyPlugin": { "assembly": "MyPlugin.dll, MyPlugin.ModulePluginHost" }
  }
}
```

Секции (используемые примерами): `actions`, `menubars` (корень — `rbproj`), `contexts`, `cores`,
`broadcasts`, `hotkeys`. Полный перечень верхнего уровня (веб core.plugin) — также `name`, `version`,
`priority`, `variables`, `environments`, `coreitems`, `dynamics`, `toolbars`, `statusbar`, `ribbon`.

- `%0` в `cmd` — параметр из пункта меню.
- Видимость: `"flags": "$(if, $(check_state_cmd,name), 0, 1)"`.

Известные баги upstream `[TUT]` (не повторять): `tutorial1.plugin` — ключ `"tutroial1"`;
`tutorial9.plugin` — ключ `"tutorial8"`; в PascalCase-проектах не хватает `<Private>False</Private>`.

## Ограничения окон

```csharp
protected override bool ValidateWindow(string cmd, IDocumentWindow window)
```

`Consts.PlanWindow` (план), `Consts.ProfileWindow` (профиль), `Consts.CrossWindow` (поперечники);
иначе — текущее окно. `[TUT]`

## Правила кода (сквозные)

- Сообщения пользователю по-русски, `MessageDlg.Show(...)`, не `MessageBox`.
- Все команды в UI-потоке; модели не менять из фоновых потоков.
- Copy Local на ссылках на сборки Robur **обязательно False** (перезапись DLL ломает хост).
- После смены DLL в хосте — команда `clearcache` в командной строке Robur.
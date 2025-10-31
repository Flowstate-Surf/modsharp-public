# Menu Manager Module for ModSharp

This module is a port of [CS2MenuManager](https://github.com/schwarper/CS2MenuManager) by schwarper, adapted to work with the ModSharp framework.

## Status

### Completed
- ✅ Module structure created
- ✅ All enums ported (PostSelectAction, DisableOption, CastVote, YesNoVoteAction, YesNoVoteEndReason)
- ✅ Basic data classes ported (ItemOption, YesNoVoteInfo, Buttons)
- ✅ IMenu and IMenuInstance interfaces created
- ✅ Module entry point created and compiles successfully

### In Progress
- ⚠️ BaseMenu and menu implementations need adaptation
- ⚠️ Command registration system needs ModSharp equivalent
- ⚠️ Timer system needs adaptation
- ⚠️ Event handling needs adaptation

### Architectural Differences

The main challenge in porting CS2MenuManager to ModSharp is that they use different plugin architectures:

**CounterStrikeSharp (Original)**:
- Uses `BasePlugin` for plugin lifecycle
- Uses `CCSPlayerController` for players
- Has `AddCommand`/`RemoveCommand` for dynamic command registration
- Uses `AddTimer` for timers
- Has `RegisterEventHandler`/`DeregisterEventHandler` for events

**ModSharp (Target)**:
- Uses `IModSharpModule` for module lifecycle
- Uses `IPlayerController` for players
- Needs integration with `Sharp.Extensions.CommandManager`
- Has `IModSharp.PushTimer` for timers  
- Has listeners pattern for events

### Usage (Planned)

```csharp
// Example usage once fully implemented
var menu = new ChatMenu("Test Menu");
menu.AddItem("Option 1", (player, option) => {
    player.Print(HudPrintChannel.Chat, "You selected option 1");
});
menu.AddItem("Option 2", (player, option) => {
    player.Print(HudPrintChannel.Chat, "You selected option 2");
});
menu.Display(player, 30);
```

## Credits

- Original CS2MenuManager: [schwarper](https://github.com/schwarper)
- ModSharp Port: Flowstate-Surf

## License

AGPL-3.0-only (same as ModSharp)

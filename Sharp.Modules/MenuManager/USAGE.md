# Menu Manager Module - Usage Examples

## Basic Chat Menu

```csharp
using Sharp.Modules.MenuManager.API.Menu;
using Sharp.Modules.MenuManager.API.Enum;
using Sharp.Shared;
using Sharp.Shared.Enums;
using Sharp.Shared.GameEntities;

public class ExampleUsage
{
    private readonly IModSharp _modSharp;
    
    public ExampleUsage(IModSharp modSharp)
    {
        _modSharp = modSharp;
    }
    
    public void ShowPlayerMenu(IPlayerController player)
    {
        // Create a new chat menu
        var menu = new ChatMenu("Main Menu", _modSharp);
        
        // Add menu items with callbacks
        menu.AddItem("Option 1", (p, option) => 
        {
            p.Print(HudPrintChannel.Chat, "You selected Option 1");
        });
        
        menu.AddItem("Option 2", (p, option) => 
        {
            p.Print(HudPrintChannel.Chat, "You selected Option 2");
        });
        
        menu.AddItem("Option 3", (p, option) => 
        {
            p.Print(HudPrintChannel.Chat, "You selected Option 3");
            // Reopen menu after selection
            option.PostSelectAction = PostSelectAction.Reset;
        });
        
        // Add a disabled item (shown but not selectable)
        menu.AddItem("Coming Soon", DisableOption.DisableShowNumber);
        
        // Display the menu to the player (30 second timeout)
        menu.Display(player, 30);
    }
}
```

## Menu Item Actions

```csharp
// Close menu after selection (default)
menu.AddItem("Close Menu", (p, option) => 
{
    p.Print(HudPrintChannel.Chat, "Menu closed");
    option.PostSelectAction = PostSelectAction.Close;
});

// Reset menu to first page after selection
menu.AddItem("Refresh", (p, option) => 
{
    p.Print(HudPrintChannel.Chat, "Menu refreshed");
    option.PostSelectAction = PostSelectAction.Reset;
});

// Do nothing - keep menu open
menu.AddItem("Info Only", (p, option) => 
{
    p.Print(HudPrintChannel.Chat, "Information displayed");
    option.PostSelectAction = PostSelectAction.Nothing;
});
```

## Disabled Items

```csharp
// Show disabled item with number
menu.AddItem("Locked Feature", DisableOption.DisableShowNumber);

// Show disabled item without number
menu.AddItem("--- Separator ---", DisableOption.DisableHideNumber);
```

## Nested/Submenu (Planned)

```csharp
// This feature will be available once navigation is fully implemented
var mainMenu = new ChatMenu("Main Menu", _modSharp);
var subMenu = new ChatMenu("Sub Menu", _modSharp);

subMenu.PrevMenu = mainMenu; // Link back to main menu

mainMenu.AddItem("Open Submenu", (p, option) => 
{
    subMenu.Display(p, 30);
});
```

## Display to All Players (Planned)

```csharp
// This will be available once player iteration is implemented
menu.DisplayToAll(30);
```

## Current Limitations

1. **No Command Integration**: Players cannot yet type !1-!9 to select items (needs CommandManager integration)
2. **No Pagination**: Menus are limited to 7 items currently
3. **No Timer Auto-Close**: The timeout parameter is accepted but not yet functional
4. **Manual Navigation**: Prev/Next page navigation not yet implemented
5. **No Disconnect Handling**: Menus are not automatically closed when players disconnect

## Future Features

These features from the original CS2MenuManager will be added in future updates:

- Full command integration with !1-!9 selection
- Pagination for menus with >7 items
- Timer-based auto-close
- Additional menu types:
  - ConsoleMenu (console-based selection)
  - CenterHtmlMenu (center screen HTML)
  - WasdMenu (WASD navigation)
- Vote system (PanoramaVote)
- Menu persistence across round changes
- Player preference storage (via database)

## Contributing

To help improve the MenuManager module:

1. Test the basic menu functionality in a live server
2. Report any bugs or issues
3. Suggest improvements or additional features
4. Contribute code for missing features

## Credits

Original CS2MenuManager: [schwarper](https://github.com/schwarper/CS2MenuManager)

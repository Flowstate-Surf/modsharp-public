/*
 * ModSharp - Menu Manager Module
 * Copyright (C) 2025 Flowstate-Surf
 * Ported from CS2MenuManager by schwarper (https://github.com/schwarper/CS2MenuManager)
 *
 * This file is part of ModSharp.
 * ModSharp is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 *
 * ModSharp is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with ModSharp. If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using Sharp.Modules.MenuManager.API.Class;
using Sharp.Modules.MenuManager.API.Enum;
using Sharp.Modules.MenuManager.API.Interface;
using Sharp.Shared;
using Sharp.Shared.Enums;
using Sharp.Shared.GameEntities;

namespace Sharp.Modules.MenuManager.API.Menu;

/// <summary>
/// Represents a simple chat-based menu.
/// This is a simplified implementation for ModSharp.
/// </summary>
public class BaseMenu : IMenu
{
    public string Title { get; set; }
    public List<ItemOption> ItemOptions { get; internal set; } = [];
    public bool ExitButton { get; set; } = true;
    public int MenuTime { get; set; }
    public IMenu? PrevMenu { get; set; }

    private readonly IModSharp _modSharp;

    public BaseMenu(string title, IModSharp modSharp)
    {
        Title = title;
        _modSharp = modSharp;
    }

    public virtual ItemOption AddItem(string display, Action<IPlayerController, ItemOption> onSelect, DisableOption disableOption = DisableOption.None)
    {
        var option = new ItemOption(display, disableOption, onSelect);
        ItemOptions.Add(option);
        return option;
    }

    public virtual ItemOption AddItem(string display, DisableOption disableOption)
    {
        var option = new ItemOption(display, disableOption, null);
        ItemOptions.Add(option);
        return option;
    }

    public virtual void Display(IPlayerController player, int time)
    {
        MenuTime = time;
        DisplayMenu(player);
    }

    public virtual void DisplayAt(IPlayerController player, int firstItem, int time)
    {
        MenuTime = time;
        // Simplified - just display from start
        DisplayMenu(player);
    }

    public void DisplayToAll(int time)
    {
        MenuTime = time;
        // TODO: Iterate through all players via ClientManager
        // For now, this is a placeholder
    }

    public void DisplayAtToAll(int firstItem, int time)
    {
        MenuTime = time;
        // TODO: Iterate through all players via ClientManager
        // For now, this is a placeholder
    }

    protected virtual void DisplayMenu(IPlayerController player)
    {
        if (ItemOptions.Count == 0)
        {
            player.Print(HudPrintChannel.Chat, "Menu is empty");
            return;
        }

        // Display menu title
        player.Print(HudPrintChannel.Chat, $" {Title}");
        player.Print(HudPrintChannel.Chat, "---");

        // Display menu items (simplified - no pagination for now)
        int maxItems = Math.Min(7, ItemOptions.Count);
        for (int i = 0; i < maxItems; i++)
        {
            var option = ItemOptions[i];
            string prefix = option.DisableOption == DisableOption.None ? "!{0}" : " {0}";
            
            if (option.DisableOption != DisableOption.DisableHideNumber)
            {
                player.Print(HudPrintChannel.Chat, $" {string.Format(prefix, i + 1)} {option.Text}");
            }
            else
            {
                player.Print(HudPrintChannel.Chat, $" {option.Text}");
            }
        }

        if (ExitButton)
        {
            player.Print(HudPrintChannel.Chat, " !0 -> Exit");
        }
    }
}

/// <summary>
/// Chat menu implementation
/// </summary>
public class ChatMenu : BaseMenu
{
    public ChatMenu(string title, IModSharp modSharp) : base(title, modSharp)
    {
    }
}

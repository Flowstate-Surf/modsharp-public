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
using Sharp.Modules.MenuManager.API.Interface;
using Sharp.Shared.GameEntities;
using Sharp.Shared.Units;

namespace Sharp.Modules.MenuManager.API.Class;

/// <summary>
/// Manages active menus for players.
/// Simplified version for ModSharp.
/// </summary>
public static class MenuManager
{
    private static readonly Dictionary<SteamID, (IMenuInstance Instance, Guid? TimerId)> ActiveMenus = [];

    /// <summary>
    /// Gets the active menu for the specified player.
    /// </summary>
    public static IMenuInstance? GetActiveMenu(IPlayerController player)
    {
        return ActiveMenus.TryGetValue(player.SteamId, out var value) ? value.Instance : null;
    }

    /// <summary>
    /// Closes the active menu for the specified player.
    /// </summary>
    public static void CloseActiveMenu(IPlayerController player)
    {
        if (!ActiveMenus.TryGetValue(player.SteamId, out var value))
            return;

        value.Instance.Close(true);
        ActiveMenus.Remove(player.SteamId);
    }

    /// <summary>
    /// Opens a menu for the specified player.
    /// </summary>
    public static void OpenMenu(IPlayerController player, IMenu menu, IMenuInstance instance)
    {
        if (menu.ItemOptions.Count == 0)
        {
            // TODO: Use localization
            return;
        }

        CloseActiveMenu(player);
        ActiveMenus[player.SteamId] = (instance, null);
        instance.Display();
    }

    /// <summary>
    /// Handles key press events for the active menu of the specified player.
    /// </summary>
    public static void OnKeyPress(IPlayerController player, int key)
    {
        GetActiveMenu(player)?.OnKeyPress(player, key);
    }
}

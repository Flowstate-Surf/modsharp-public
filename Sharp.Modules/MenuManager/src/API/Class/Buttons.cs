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

using System.Collections.Generic;
using Sharp.Shared.Enums;

namespace Sharp.Modules.MenuManager.API.Class;

/// <summary>
/// Represents a collection of button mappings for player controls.
/// </summary>
public static class Buttons
{
    /// <summary>
    /// Gets the dictionary mapping button names to their corresponding <see cref="UserCommandButtons"/> values.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, UserCommandButtons> ButtonMapping = new Dictionary<string, UserCommandButtons>
    {
        { "Attack", UserCommandButtons.Attack },
        { "Attack2", UserCommandButtons.Attack2 },
        { "Bullrush", UserCommandButtons.BullRush },
        { "Duck", UserCommandButtons.Duck },
        { "Space", UserCommandButtons.Jump },
        { "TurnLeft", UserCommandButtons.TurnLeft },
        { "W", UserCommandButtons.Forward },
        { "A", UserCommandButtons.MoveLeft },
        { "S", UserCommandButtons.Back },
        { "D", UserCommandButtons.MoveRight },
        { "E", UserCommandButtons.Use },
        { "R", UserCommandButtons.Reload },
        { "Shift", UserCommandButtons.Speed },
        { "TurnRight", UserCommandButtons.TurnRight },
        { "Zoom", UserCommandButtons.Zoom },
        { "Tab", UserCommandButtons.Scoreboard },
        { "LookAtWeapon", UserCommandButtons.LookAtWeapon }
    };
}

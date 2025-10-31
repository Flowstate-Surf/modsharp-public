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

namespace Sharp.Modules.MenuManager.API.Enum;

/// <summary>
/// Defines the options for disabling menu items.
/// </summary>
public enum DisableOption
{
    /// <summary>
    /// No disabling option is applied.
    /// </summary>
    None,

    /// <summary>
    /// Disables the item and displays it's number.
    /// </summary>
    DisableShowNumber,

    /// <summary>
    /// Disables the item and hides it's number.
    /// </summary>
    DisableHideNumber
}

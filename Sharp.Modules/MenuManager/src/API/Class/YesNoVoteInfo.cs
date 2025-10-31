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

namespace Sharp.Modules.MenuManager.API.Class;

/// <summary>
/// Contains information about the result of a vote.
/// </summary>
public class YesNoVoteInfo
{
    /// <summary>
    /// Gets or sets the total number of votes tallied.
    /// </summary>
    public int TotalVotes;

    /// <summary>
    /// Gets or sets the number of votes for yes.
    /// </summary>
    public int YesVotes;

    /// <summary>
    /// Gets or sets the number of votes for no.
    /// </summary>
    public int NoVotes;

    /// <summary>
    /// Gets or sets the number of clients who could vote.
    /// </summary>
    public int TotalClients;

    /// <summary>
    /// Gets or sets the client voting information.
    /// </summary>
    public Dictionary<int, (int, int)> ClientInfo = [];
}

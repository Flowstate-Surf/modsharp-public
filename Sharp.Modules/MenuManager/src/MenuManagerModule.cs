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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sharp.Shared;

namespace Sharp.Modules.MenuManager;

/// <summary>
/// Menu Manager Module for ModSharp - Provides a flexible menu system for CS2
/// Ported from CS2MenuManager by schwarper
/// </summary>
public sealed class MenuManagerModule : IModSharpModule
{
    public string DisplayName   => "Menu Manager";
    public string DisplayAuthor => "Flowstate-Surf (port by schwarper)";

    private readonly ILogger<MenuManagerModule> _logger;
    private readonly IModSharp                  _modSharp;

    public MenuManagerModule(ISharedSystem sharedSystem,
        string                               dllPath,
        string                               sharpPath,
        Version                              version,
        IConfiguration                       coreConfiguration,
        bool                                 hotReload)
    {
        _logger   = sharedSystem.GetLoggerFactory().CreateLogger<MenuManagerModule>();
        _modSharp = sharedSystem.GetModSharp();

        _logger.LogInformation("Menu Manager Module initializing...");
    }

    public bool Init()
    {
        _logger.LogInformation("Menu Manager Module initialized");
        return true;
    }

    public void PostInit()
    {
        _logger.LogInformation("Menu Manager Module post-initialization complete");
    }

    public void Shutdown()
    {
        _logger.LogInformation("Menu Manager Module shutting down");
    }
}

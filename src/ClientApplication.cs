// <copyright file="AggregateFactory.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.Client;

using System;
using System.Collections.Generic;

using Hexalith.Application.Modules.Applications;
using Hexalith.Projects.Client.Modules;
using Hexalith.EasyAuthentication.Client;

using HexalithApp.Shared;

/// <summary>
/// Represents a client application.
/// </summary>
public class ClientApplication : HexalithClientApplication
{
    /// <inheritdoc/>
    public override IEnumerable<Type> ClientModules
        => [
            typeof(ProjectClientModule),
            typeof(HexalithEasyAuthenticationClientModule)];

    /// <inheritdoc/>
    public override Type SharedApplicationType => typeof(SharedApplication);
}
// <copyright file="AggregateFactory.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.Server;

using System;
using System.Collections.Generic;

using Hexalith.Application.Modules.Applications;
using Hexalith.Projects.Server.Modules;
using Hexalith.EasyAuthentication.Server;

using HexalithApp.Client;
using HexalithApp.Shared;

/// <summary>
/// Represents a server application.
/// </summary>
public class ServerApplication : HexalithServerApplication
{
    /// <inheritdoc/>
    public override Type ClientApplicationType => typeof(ClientApplication);

    /// <inheritdoc/>
    public override IEnumerable<Type> ServerModules => [
        typeof(ProjectServerModule),
        typeof(HexalithEasyAuthenticationServerModule)];

    /// <inheritdoc/>
    public override Type SharedApplicationType => typeof(SharedApplication);
}
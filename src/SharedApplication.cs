// <copyright file="AggregateFactory.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.Shared;

using Hexalith.Application.Modules.Applications;
using Hexalith.Projects.Shared.Modules;
using Hexalith.EasyAuthentication.Shared;
using Hexalith.Extensions.Helpers;
using Hexalith.UI.Components.Modules;

/// <summary>
/// Represents a shared application.
/// </summary>
public class SharedApplication : HexalithSharedApplication
{
    /// <inheritdoc/>
    public override string HomePath => "Project";

    /// <inheritdoc/>
    public override string Id => "Project";

    /// <inheritdoc/>
    public override string LoginPath => "/.auth/login/aad";

    /// <inheritdoc/>
    public override string LogoutPath => "/.auth/logout";

    /// <inheritdoc/>
    public override string Name => "Projects";

    /// <inheritdoc/>
    public override IEnumerable<Type> SharedModules =>
    [
        typeof(ProjectSharedModule),
        typeof(HexalithUIComponentsSharedModule),
        typeof(HexalithEasyAuthenticationSharedModule),
    ];

    /// <inheritdoc/>
    public override string Version => VersionHelper.ProductVersion<ProjectSharedModule>() ?? "?.?.?";
}
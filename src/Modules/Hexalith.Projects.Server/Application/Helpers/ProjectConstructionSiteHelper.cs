// ***********************************************************************
// Assembly         : Hexalith.Application.Project
// Author           : Jérôme Piquot
// Created          : 09-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-04-2023
// ***********************************************************************
// <copyright file="ProjectHelper.cs" company="Hexalith SAS Paris France">
//     Copyright (c) Hexalith SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Projects.Server.Application.Helpers;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Class ProjectHelper.
/// </summary>
public static class ProjectHelper
{
    /// <summary>
    /// Adds the parties command handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddProjectCommandHandlers(this IServiceCollection services) =>

        // services.TryAddScoped<ICommandHandler<>, >();
        services.AddProjectEventValidators();

    /// <summary>
    /// Adds the parties event validators.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddProjectEventValidators(this IServiceCollection services) =>

        // services.TryAddSingleton<IValidator<>, >();
        services;
}
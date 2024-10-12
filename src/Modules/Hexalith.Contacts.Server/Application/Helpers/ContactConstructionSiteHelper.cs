// ***********************************************************************
// Assembly         : Hexalith.Application.Contact
// Author           : Jérôme Piquot
// Created          : 09-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-04-2023
// ***********************************************************************
// <copyright file="ContactHelper.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Contacts.Server.Application.Helpers;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Class ContactHelper.
/// </summary>
public static class ContactConstructionSiteHelper
{
    /// <summary>
    /// Adds the parties command handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddContactCommandHandlers(this IServiceCollection services) =>

        // services.TryAddScoped<ICommandHandler<>, >();
        services.AddContactEventValidators();

    /// <summary>
    /// Adds the parties event validators.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddContactEventValidators(this IServiceCollection services) =>

        // services.TryAddSingleton<IValidator<>, >();
        services;
}
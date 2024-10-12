// <copyright file="ContactConstructionSiteSharedModule.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Contacts.Shared.Modules;

using System.Collections.Generic;
using System.Reflection;

using Hexalith.Application.Modules.Modules;
using Hexalith.Contacts.Application;
using Hexalith.Contacts.Commands.Extensions;
using Hexalith.Contacts.Events.Extensions;
using Hexalith.Contacts.Shared.Contacts.Services;
using Hexalith.PolymorphicSerialization;
using Hexalith.UI.Components;
using Hexalith.UI.Components.Icons;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
/// <summary>
/// The contact construction site shared module.
/// </summary>
public class ContactConstructionSiteSharedModule : ISharedApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => ["Hexalith.Oidc"];

    /// <inheritdoc/>
    public string Description => "Contact construction site shared module";

    /// <inheritdoc/>
    public string Id => "ContactConstructionSite.Shared";

    /// <inheritdoc/>
    public string Name => "Contact construction site shared";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public string Path => "Contact";

    /// <inheritdoc/>
    public IEnumerable<Assembly> PresentationAssemblies => [GetType().Assembly];

    /// <inheritdoc/>
    public string Version => "1.0";

    /// <summary>
    /// Adds services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        PolymorphicSerializationResolver.DefaultMappers = PolymorphicSerializationResolver.DefaultMappers
            .AddHexalithContactsEventsMappers()
            .AddHexalithContactsCommandsMappers();

        _ = services
            .AddContactApplication()
            .AddSingleton<IContactQueryService, DemoContactQueryService>()
            .AddSingleton<IContactQueryService, DemoContactQueryService>()
            .AddSingleton(new MenuItemInformation(
                "Home",
                "/",
                new IconInformation("Home", 20, IconStyle.Regular, IconSource.Fluent, $"{nameof(Contact)}.{nameof(Shared)}"),
                true,
                0,
                []))
            .AddTransient(p => ContactMenu.Menu);
    }

    /// <inheritdoc/>
    public void UseModule(object builder)
    {
    }
}
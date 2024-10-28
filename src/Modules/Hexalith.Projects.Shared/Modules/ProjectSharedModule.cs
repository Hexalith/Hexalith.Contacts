namespace Hexalith.Contacts.Shared.Modules;

using System.Collections.Generic;
using System.Reflection;


using Hexalith.Application.Aggregates;
using Hexalith.Application.Commands;
using Hexalith.Application.Modules.Modules;
using Hexalith.Contacts.Application.CommandHandlers;
using Hexalith.Contacts.Commands;
using Hexalith.Contacts.Commands.Extensions;
using Hexalith.Contacts.Domain;
using Hexalith.Contacts.Events.Extensions;
using Hexalith.Contacts.Shared.Contacts.Services;
using Hexalith.UI.Components;
using Hexalith.UI.Components.Icons;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// The contact construction site shared module.
/// </summary>
public class ContactSharedModule : ISharedApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => ["Hexalith.Oidc"];

    /// <inheritdoc/>
    public string Description => "Contact shared module";

    /// <inheritdoc/>
    public string Id => "Contact.Shared";

    /// <inheritdoc/>
    public string Name => "Contact shared";

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
        HexalithContactsEvents.RegisterPolymorphicMappers();
        HexalithContactsCommands.RegisterPolymorphicMappers();

        // Add domain aggregate providers
        services.TryAddSingleton<IDomainAggregateProvider, DomainAggregateProvider<Contact>>();

        // Add command handlers
        services.TryAddSingleton<IDomainCommandHandler<AddContact>, AddContactHandler>();

        _ = services
            .AddSingleton<IContactQueryService, DemoContactQueryService>()
            .AddSingleton<IContactQueryService, DemoContactQueryService>()
            .AddSingleton(new MenuItemInformation(
                "Home",
                "/",
                new IconInformation("Home", 20, IconStyle.Regular, IconSource.Fluent, $"{nameof(Hexalith.Contact)}.{nameof(Shared)}"),
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
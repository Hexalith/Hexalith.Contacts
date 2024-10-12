namespace Hexalith.Contacts.Application;

using Hexalith.Application.Aggregates;
using Hexalith.Application.Commands;
using Hexalith.Contacts.Application.CommandHandlers;
using Hexalith.Contacts.Commands;
using Hexalith.Contacts.Commands.Extensions;
using Hexalith.Contacts.Domain;
using Hexalith.Contacts.Events.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Helper class for adding contact application services.
/// </summary>
public static class ContactApplicationHelper
{
    /// <summary>
    /// Add the contact application services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddContactApplication(this IServiceCollection services)
    {
        _ = services.AddHexalithContactsCommandsMappers();
        _ = services.AddHexalithContactsEventsMappers();

        services.TryAddSingleton<IDomainAggregateFactory, DomainAggregateFactory>();

        // Add domain aggregate providers
        services.TryAddSingleton<IDomainAggregateProvider, DomainAggregateProvider<Contact>>();

        // Add command handlers
        services.TryAddSingleton<IDomainCommandHandler<AddContact>, AddContactHandler>();
        return services;
    }
}
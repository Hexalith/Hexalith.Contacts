namespace Hexalith.Contacts.Server.Infrastructure.Helpers;

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Actors.Runtime;

using Hexalith.Application.Aggregates;
using Hexalith.Application.Commands;
using Hexalith.Application.Projections;
using Hexalith.Application.Tasks;
using Hexalith.Contact.Domain;
using Hexalith.Contacts.Server.Application.Helpers;
using Hexalith.Contacts.Server.Infrastructure.Configurations;
using Hexalith.Extensions.Configuration;
using Hexalith.Infrastructure.DaprRuntime.Actors;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Infrastructure.DaprRuntime.Helpers;
using Hexalith.PolymorphicSerialization;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

/// <summary>
/// Class ContactHelper.
/// </summary>
public static class ContactConstructionSiteHelper
{
    /// <summary>
    /// Adds the parties.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddDaprContact([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        _ = services
            .AddContactCommandHandlers()
            .ConfigureSettings<ContactConstructionSiteSettings>(configuration);
        return services;
    }

    /// <summary>
    /// Adds the customer projections.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="applicationId">Name of the application.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static IServiceCollection AddEnvironmentDatabaseProjections(this IServiceCollection services, string applicationId)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(applicationId);
        return services;
    }

    /// <summary>
    /// Adds the parties.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static ActorRegistrationCollection AddContactAggregates([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<DomainAggregateActor>(DomainAggregateActorBase.GetAggregateActorName(ContactDomainHelper.ContactAggregateName));
        return actors;
    }

    /// <summary>
    /// Adds the dapr parties client.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static IServiceCollection AddContactClient([NotNull] this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // services.TryAddScoped<IEnvironmentDatabaseQueryService, ActorEnvironmentDatabaseQueryService>();
        return services;
    }

    /// <summary>
    /// Adds the external systems integration event handlers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddContactCommandsSubmission([NotNull] this IServiceCollection services)
    {
        services.TryAddSingleton<IDomainCommandDispatcher, DependencyInjectionDomainCommandDispatcher>();
        services
            .AddContactCommandHandlers()
            .TryAddSingleton<IDomainCommandProcessor>((s) => new DomainActorCommandProcessor(
                ActorProxy.DefaultProxyFactory,
                s.GetRequiredService<JsonSerializerOptions>(),
                s.GetRequiredService<ILogger<DomainActorCommandProcessor>>()));

        services.TryAddSingleton<IDomainAggregateFactory, DomainAggregateFactory>();
        return services;
    }

    /// <summary>
    /// Adds the parties projections.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <param name="applicationId">Name of the application.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static ActorRegistrationCollection AddContactProjections([NotNull] this ActorRegistrationCollection actors, string applicationId)
    {
        ArgumentNullException.ThrowIfNull(actors);

        // actors.RegisterProjectionActor<>(applicationId);
        return actors;
    }

    /// <summary>
    /// Add Contact server services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddContactServer(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services
            .ConfigureSettings<Hexalith.Infrastructure.CosmosDb.Configurations.CosmosDbSettings>(configuration);

        services
            .AddDaprBuses(configuration)
            .AddDaprStateStore(configuration)
            .AddActors(options =>
            {
                _ = options.Actors.AddContactAggregates();
                _ = options.Actors.AddContactProjections("Contact");

                // Register actor types and configure actor settings
                options.DrainOngoingCallTimeout = TimeSpan.FromMinutes(10);
                options.ReentrancyConfig = new ActorReentrancyConfig { Enabled = true };
                options.RemindersStoragePartitions = 10;
            });

        services.TryAddSingleton<IResiliencyPolicyProvider, ResiliencyPolicyProvider>();
        services.TryAddScoped<IProjectionUpdateProcessor, DependencyInjectionProjectionUpdateProcessor>();

        _ = services.AddContactCommandsSubmission();
        _ = services.AddContactCommandHandlers();
        _ = services.AddContactEventValidators();
        _ = services
            .AddControllers()
            .AddDapr((c) => c.UseJsonSerializationOptions(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                TypeInfoResolver = new PolymorphicSerializationResolver(),
            }));
        return services;
    }
}
namespace Hexalith.Projects.Server.Modules;

using System.Collections.Generic;
using System.Reflection;

using Dapr.Actors.Runtime;

using Hexalith.Application.Modules.Modules;
using Hexalith.Project.Domain;
using Hexalith.Projects.Domain;
using Hexalith.Projects.Server.Application.Helpers;
using Hexalith.Extensions.Configuration;
using Hexalith.Infrastructure.DaprRuntime.Actors;
using Hexalith.Infrastructure.DaprRuntime.Helpers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The project construction site client module.
/// </summary>
public sealed class ProjectServerModule : IServerApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => [];

    /// <inheritdoc/>
    public string Description => "Project server module";

    /// <inheritdoc/>
    public string Id => "Project.Server";

    /// <inheritdoc/>
    public string Name => "Hexalith Project server";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public IEnumerable<Assembly> PresentationAssemblies => [GetType().Assembly];

    /// <inheritdoc/>
    public string Version => "1.0";

    /// <inheritdoc/>
    string IApplicationModule.Path => Path;

    private static string Path => "Project";

    /// <summary>
    /// Adds services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        _ = services
            .ConfigureSettings<Hexalith.Infrastructure.CosmosDb.Configurations.CosmosDbSettings>(configuration);

        _ = services.AddProjectCommandHandlers();
        _ = services.AddProjectEventValidators();
    }

    /// <summary>
    /// Registers the actors associated with the module.
    /// </summary>
    /// <param name="actorCollection">The actor collection.</param>
    public static void RegisterActors(object actorCollection)
    {
        ArgumentNullException.ThrowIfNull(actorCollection);
        if (actorCollection is not ActorRegistrationCollection actorRegistrations)
        {
            throw new ArgumentException($"{nameof(RegisterActors)} parameter must be an {nameof(ActorRegistrationCollection)}. Actual type : {actorCollection.GetType().Name}.", nameof(actorCollection));
        }

        actorRegistrations.RegisterActor<DomainAggregateActor>(DomainAggregateActorBase.GetAggregateActorName(ProjectDomainHelper.ProjectAggregateName));
        actorRegistrations.RegisterProjectionActor<Project>("Project");
    }

    /// <inheritdoc/>
    public void UseModule(object builder)
    {
    }
}
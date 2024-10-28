namespace Hexalith.Projects.Shared.Modules;

using System.Collections.Generic;
using System.Reflection;


using Hexalith.Application.Aggregates;
using Hexalith.Application.Commands;
using Hexalith.Application.Modules.Modules;
using Hexalith.Projects.Application.CommandHandlers;
using Hexalith.Projects.Commands;
using Hexalith.Projects.Commands.Extensions;
using Hexalith.Projects.Domain;
using Hexalith.Projects.Events.Extensions;
using Hexalith.Projects.Shared.Projects.Services;
using Hexalith.UI.Components;
using Hexalith.UI.Components.Icons;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// The project construction site shared module.
/// </summary>
public class ProjectSharedModule : ISharedApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => ["Hexalith.Oidc"];

    /// <inheritdoc/>
    public string Description => "Project shared module";

    /// <inheritdoc/>
    public string Id => "Project.Shared";

    /// <inheritdoc/>
    public string Name => "Project shared";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public string Path => "Project";

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
        HexalithProjectsEvents.RegisterPolymorphicMappers();
        HexalithProjectsCommands.RegisterPolymorphicMappers();

        // Add domain aggregate providers
        services.TryAddSingleton<IDomainAggregateProvider, DomainAggregateProvider<Project>>();

        // Add command handlers
        services.TryAddSingleton<IDomainCommandHandler<AddProject>, AddProjectHandler>();

        _ = services
            .AddSingleton<IProjectQueryService, DemoProjectQueryService>()
            .AddSingleton<IProjectQueryService, DemoProjectQueryService>()
            .AddSingleton(new MenuItemInformation(
                "Home",
                "/",
                new IconInformation("Home", 20, IconStyle.Regular, IconSource.Fluent, $"{nameof(Hexalith.Project)}.{nameof(Shared)}"),
                true,
                0,
                []))
            .AddTransient(p => ProjectMenu.Menu);
    }

    /// <inheritdoc/>
    public void UseModule(object builder)
    {
    }
}
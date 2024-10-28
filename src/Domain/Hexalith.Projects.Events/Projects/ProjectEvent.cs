namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;
using Hexalith.Project.Domain;

/// <summary>
/// Represents a base class for project commands.
/// </summary>
[PolymorphicSerialization]
public abstract partial record ProjectEvent(string Id)
{
    /// <summary>
    /// Gets the aggregate ID of the project command.
    /// </summary>
    public string AggregateId => Id;

    /// <summary>
    /// Gets the aggregate name of the project command.
    /// </summary>
    public static string AggregateName => ProjectDomainHelper.ProjectAggregateName;
}
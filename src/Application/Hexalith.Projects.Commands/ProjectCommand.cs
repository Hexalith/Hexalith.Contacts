namespace Hexalith.Projects.Commands;

using Hexalith.Project.Domain;
using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a base class for project commands.
/// </summary>
[PolymorphicSerialization]
public abstract partial record ProjectCommand(string Id)
{
    /// <summary>
    /// Gets the aggregate ID of the project command.
    /// </summary>
    public string AggregateId => AggregateName + "-" + Id;

    /// <summary>
    /// Gets the aggregate name of the project command.
    /// </summary>
    public static string AggregateName => ProjectDomainHelper.ProjectAggregateName;
}
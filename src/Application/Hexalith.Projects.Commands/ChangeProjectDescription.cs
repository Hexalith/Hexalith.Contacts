namespace Hexalith.Projects.Commands;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a change of the name of a project.
/// </summary>
/// <param name="Id">The project identifier.</param>
/// <param name="Name">The project name.</param>
/// <param name="Description">The project description.</param>
[PolymorphicSerialization]
public partial record ChangeProjectDescription(string Id, string Name, string Description) : ProjectCommand(Id)
{
}
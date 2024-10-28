namespace Hexalith.Projects.Commands;

/// <summary>
/// Represents a project enabled event.
/// </summary>
public partial record EnableProject(string Id) : ProjectCommand(Id)
{
}
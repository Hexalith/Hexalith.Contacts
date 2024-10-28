namespace Hexalith.Projects.Commands;
/// <summary>
/// Represents a project disabled event.
/// </summary>
public partial record DisableProject(string Id) : ProjectCommand(Id)
{
}
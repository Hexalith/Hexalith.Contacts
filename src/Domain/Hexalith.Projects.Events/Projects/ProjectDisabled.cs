namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a project disabled event.
/// </summary>
[PolymorphicSerialization]
public partial record ProjectDisabled(string Id) : ProjectEvent(Id)
{
}
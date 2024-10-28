namespace Hexalith.Projects.Events.ProjectTypes;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a project disabled event.
/// </summary>
[PolymorphicSerialization]
public partial record ProjectTypeDisabled(string Id) : ProjectTypeEvent(Id)
{
}
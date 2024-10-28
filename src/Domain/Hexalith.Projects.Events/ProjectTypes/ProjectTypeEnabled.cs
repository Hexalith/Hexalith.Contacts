namespace Hexalith.Projects.Events.ProjectTypes;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a project enabled event.
/// </summary>
[PolymorphicSerialization]
public partial record ProjectTypeEnabled(string Id) : ProjectTypeEvent(Id)
{
}
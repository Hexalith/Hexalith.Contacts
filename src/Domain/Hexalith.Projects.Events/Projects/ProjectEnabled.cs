namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a project enabled event.
/// </summary>
[PolymorphicSerialization]
public partial record ProjectEnabled(string Id) : ProjectEvent(Id)
{
}
namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectCommentsChanged(string Id, string? Comments) : ProjectEvent(Id)
{
}
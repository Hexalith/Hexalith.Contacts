namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectActorRemoved(string Id, string ContactId)
    : ProjectEvent(Id)
{
}
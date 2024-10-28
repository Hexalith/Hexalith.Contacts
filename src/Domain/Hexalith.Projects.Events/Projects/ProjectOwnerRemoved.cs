namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectOwnerRemoved(string Id, string OwnerId)
    : ProjectEvent(Id)
{
}
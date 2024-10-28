namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectOwnerAdded(string Id, string OwnerId)
    : ProjectEvent(Id)
{
}
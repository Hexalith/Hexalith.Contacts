namespace Hexalith.Projects.Events.ProjectTypes;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectTypeAdded(
    string Id,
    string Name,
    string Division)
    : ProjectTypeEvent(Id)
{
}
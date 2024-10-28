namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectCreated(
    string Id,
    string Name,
    string ProjectTypeId,
    string OwnerId,
    DateTimeOffset CreatedOn,
    string? Description)
    : ProjectEvent(Id)
{
}
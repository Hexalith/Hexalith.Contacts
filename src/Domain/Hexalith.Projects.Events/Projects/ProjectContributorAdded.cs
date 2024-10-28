namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectContributorAdded(string Id, string ContactId)
    : ProjectEvent(Id)
{
}
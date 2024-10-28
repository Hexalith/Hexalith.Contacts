namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectContributorRemoved(string Id, string ContactId)
    : ProjectEvent(Id)
{
}
namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectReaderRemoved(string Id, string ContactId)
    : ProjectEvent(Id)
{
}
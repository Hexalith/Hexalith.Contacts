namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectReaderAdded(string Id, string ContactId)
    : ProjectEvent(Id)
{
}
namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectDocumentAdded(string Id, string DocumentId)
    : ProjectEvent(Id)
{
}
namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectDocumentRemoved(string Id, string DocumentId)
    : ProjectEvent(Id)
{
}
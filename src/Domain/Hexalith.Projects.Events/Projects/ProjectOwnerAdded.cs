namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectOwnerAdded(string Id, string ContactId) : ProjectEvent(Id);
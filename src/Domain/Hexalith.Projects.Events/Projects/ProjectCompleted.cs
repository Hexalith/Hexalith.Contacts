namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectCompleted(string Id, DateTimeOffset CompletedDate) : ProjectEvent(Id);
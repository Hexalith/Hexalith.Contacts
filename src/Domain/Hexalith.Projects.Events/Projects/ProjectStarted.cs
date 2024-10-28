namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectStarted(string Id, DateTimeOffset StartDate) : ProjectEvent(Id);
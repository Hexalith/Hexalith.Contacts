namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectResumed(string Id, DateTimeOffset ResumedDate) : ProjectEvent(Id);
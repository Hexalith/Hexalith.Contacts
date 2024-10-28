namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectSuspended(string Id, DateTimeOffset SuspendedDate, DateTimeOffset? PostponedToDate) : ProjectEvent(Id);
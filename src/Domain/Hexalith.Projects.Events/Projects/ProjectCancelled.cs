namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ProjectCancelled(string Id, DateTimeOffset CancelledDate) : ProjectEvent(Id);
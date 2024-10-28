namespace Hexalith.Projects.Events.Projects;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a cancelled project event.
/// </summary>
/// <param name="Event">The original project event that was cancelled.</param>
/// <param name="Reason">The reason for cancelling the event.</param>
[PolymorphicSerialization]
public partial record ProjectEventCancelled(ProjectEvent Event, string Reason)
    : ProjectEvent(Event.Id);
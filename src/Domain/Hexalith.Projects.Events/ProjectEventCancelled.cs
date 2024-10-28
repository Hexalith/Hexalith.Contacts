namespace Hexalith.Contacts.Events;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a cancelled contact event.
/// </summary>
/// <param name="Event">The original contact event that was cancelled.</param>
/// <param name="Reason">The reason for cancelling the event.</param>
[PolymorphicSerialization]
public partial record ContactEventCancelled(ContactEvent Event, string Reason)
    : ContactEvent(Event.Id);
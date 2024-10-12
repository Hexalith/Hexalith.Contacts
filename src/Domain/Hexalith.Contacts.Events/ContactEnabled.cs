using Hexalith.Contacts.Events.Contacts;

namespace Hexalith.Contacts.Events;

/// <summary>
/// Represents a contact enabled event.
/// </summary>
public partial record ContactEnabled(string Id) : ContactEvent(Id)
{
}
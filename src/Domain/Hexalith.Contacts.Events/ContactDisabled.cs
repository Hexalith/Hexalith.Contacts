namespace Hexalith.Contacts.Events;

using Hexalith.Contacts.Events.Contacts;

/// <summary>
/// Represents a contact disabled event.
/// </summary>
public partial record ContactDisabled(string Id) : ContactEvent(Id)
{
}
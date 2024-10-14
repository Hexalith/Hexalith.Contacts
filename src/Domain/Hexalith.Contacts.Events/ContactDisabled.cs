namespace Hexalith.Contacts.Events;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a contact disabled event.
/// </summary>
[PolymorphicSerialization]
public partial record ContactDisabled(string Id) : ContactEvent(Id)
{
}
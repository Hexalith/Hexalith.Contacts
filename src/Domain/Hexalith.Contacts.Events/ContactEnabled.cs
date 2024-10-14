namespace Hexalith.Contacts.Events;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a contact enabled event.
/// </summary>
[PolymorphicSerialization]
public partial record ContactEnabled(string Id) : ContactEvent(Id)
{
}
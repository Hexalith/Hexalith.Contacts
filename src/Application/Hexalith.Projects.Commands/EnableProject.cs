namespace Hexalith.Contacts.Commands;

/// <summary>
/// Represents a contact enabled event.
/// </summary>
public partial record EnableContact(string Id) : ContactCommand(Id)
{
}
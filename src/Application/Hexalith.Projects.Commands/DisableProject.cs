namespace Hexalith.Contacts.Commands;
/// <summary>
/// Represents a contact disabled event.
/// </summary>
public partial record DisableContact(string Id) : ContactCommand(Id)
{
}
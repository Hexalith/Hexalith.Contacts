namespace Hexalith.Contacts.Commands;

using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a change of the name of a contact.
/// </summary>
/// <param name="Id">The contact identifier.</param>
/// <param name="Name">The contact name.</param>
/// <param name="Description">The contact description.</param>
[PolymorphicSerialization]
public partial record ChangeContactDescription(string Id, string Name, string Description) : ContactCommand(Id)
{
}
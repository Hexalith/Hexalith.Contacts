namespace Hexalith.Contacts.Commands;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record AddContact(string Id, string Name, string Description, Person Person)
    : ContactCommand(Id)
{
}
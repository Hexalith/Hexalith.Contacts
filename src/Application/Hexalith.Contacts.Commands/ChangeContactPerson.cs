namespace Hexalith.Contacts.Commands;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ChangeContactPerson(string Id, Person Person)
    : ContactCommand(Id)
{
}
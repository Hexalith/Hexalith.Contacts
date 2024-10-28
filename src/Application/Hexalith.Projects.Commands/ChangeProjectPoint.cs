namespace Hexalith.Contacts.Commands;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ChangeContactPoint(string Id, ContactPoint ContactPoint)
    : ContactCommand(Id)
{
}
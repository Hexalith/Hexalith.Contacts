namespace Hexalith.Contacts.Events;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactPersonChanged(string Id, Person Person)
    : ContactEvent(Id)
{
}
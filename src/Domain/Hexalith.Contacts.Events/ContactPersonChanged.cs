namespace Hexalith.Contacts.Events.Contacts;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactPersonChanged(string Id, Person Person)
    : ContactEvent(Id)
{
}
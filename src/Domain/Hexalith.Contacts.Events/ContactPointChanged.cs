namespace Hexalith.Contacts.Events;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactPointChanged(string Id, ContactPoint ContactPoint)
    : ContactEvent(Id)
{
}
namespace Hexalith.Contacts.Events;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactPointRemoved(string Id, string Name)
    : ContactEvent(Id)
{
}
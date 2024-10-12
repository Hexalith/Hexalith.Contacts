namespace Hexalith.Contacts.Events.Contacts;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactPointRemoved(string Id, string Name)
    : ContactEvent(Id)
{
}
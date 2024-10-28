namespace Hexalith.Contacts.Commands;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record RemoveContactPoint(string Id, string Name)
    : ContactCommand(Id)
{
}
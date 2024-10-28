namespace Hexalith.Projects.Commands;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record RemoveProjectPoint(string Id, string Name)
    : ProjectCommand(Id)
{
}
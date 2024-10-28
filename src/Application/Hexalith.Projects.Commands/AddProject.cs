namespace Hexalith.Projects.Commands;

using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record AddProject(string Id, string Name, string? Comments, Person Person)
    : ProjectCommand(Id)
{
}
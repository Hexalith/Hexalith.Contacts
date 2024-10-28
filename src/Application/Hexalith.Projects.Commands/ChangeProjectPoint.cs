namespace Hexalith.Projects.Commands;

using Hexalith.Project.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ChangeProjectPoint(string Id, ProjectPoint ProjectPoint)
    : ProjectCommand(Id)
{
}
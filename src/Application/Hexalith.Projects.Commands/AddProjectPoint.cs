namespace Hexalith.Projects.Commands;

using Hexalith.Project.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record AddProjectPoint(string Id, ProjectPoint ProjectPoint)
    : ProjectCommand(Id)
{
}
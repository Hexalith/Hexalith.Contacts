﻿namespace Hexalith.Projects.Commands;

using Hexalith.Project.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ChangeProjectPerson(string Id, Person Person)
    : ProjectCommand(Id)
{
}
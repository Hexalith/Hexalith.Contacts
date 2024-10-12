﻿namespace Hexalith.Contacts.Events.Contacts;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactAdded(string Id, string Name, string Description, Person Person)
    : ContactEvent(Id)
{
}
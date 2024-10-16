﻿namespace Hexalith.Contacts.Events;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.PolymorphicSerialization;

[PolymorphicSerialization]
public partial record ContactPointAdded(string Id, ContactPoint ContactPoint)
    : ContactEvent(Id)
{
}
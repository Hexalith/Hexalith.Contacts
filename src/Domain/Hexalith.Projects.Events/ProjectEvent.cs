namespace Hexalith.Contacts.Events;

using Hexalith.Contact.Domain;
using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents a base class for contact commands.
/// </summary>
[PolymorphicSerialization]
public abstract partial record ContactEvent(string Id)
{
    /// <summary>
    /// Gets the aggregate ID of the contact command.
    /// </summary>
    public string AggregateId => Id;

    /// <summary>
    /// Gets the aggregate name of the contact command.
    /// </summary>
    public static string AggregateName => ContactDomainHelper.ContactAggregateName;
}
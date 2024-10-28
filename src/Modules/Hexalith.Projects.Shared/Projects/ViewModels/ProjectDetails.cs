namespace Hexalith.Contacts.Shared.Contacts.ViewModels;

using Hexalith.Contact.Domain.ValueObjects;

/// <summary>
/// Represents the details of a contact in the system.
/// </summary>
/// <param name="Id">The unique identifier of the contact.</param>
/// <param name="Name">The name of the contact.</param>
/// <param name="Description">A description of the contact.</param>
/// <param name="Person">The person associated with this contact.</param>
/// <param name="ContactPoints">A collection of contact points for this contact.</param>
/// <param name="Disabled">A flag indicating whether the contact is disabled.</param>
public record ContactDetails(
    string Id,
    string Name,
    string Description,
    Person Person,
    IEnumerable<ContactPoint> ContactPoints,
    bool Disabled);


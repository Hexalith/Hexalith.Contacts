namespace Hexalith.Contacts.Shared.Contacts.ViewModels;

using Hexalith.Contact.Domain.Helpers;

/// <summary>
/// Represents a summary of contact information.
/// </summary>
/// <param name="Id">The unique identifier of the contact.</param>
/// <param name="Name">The name of the contact.</param>
/// <param name="Phone">The phone number of the contact.</param>
/// <param name="Mobile">The mobile number of the contact.</param>
/// <param name="Email">The email address of the contact.</param>
/// <param name="Disabled">A flag indicating whether the contact is disabled.</param>
public record ContactSummary(
    string Id,
    string Name,
    string? Phone,
    string? Mobile,
    string? Email,
    bool Disabled)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactSummary"/> class from ContactDetails.
    /// </summary>
    /// <param name="details">The ContactDetails object to create the summary from.</param>
    /// <exception cref="ArgumentNullException">Thrown when details is null.</exception>
    public ContactSummary(ContactDetails details)
        : this(
              (details ?? throw new ArgumentNullException(nameof(details))).Id,
              details.Name,
              details.ContactPoints.GetPhone(),
              details.ContactPoints.GetMobile(),
              details.ContactPoints.GetEmail(),
              details.Disabled)
    {
    }
}

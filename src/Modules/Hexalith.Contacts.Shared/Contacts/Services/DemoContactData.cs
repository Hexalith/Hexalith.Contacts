namespace Hexalith.Contacts.Shared.Contacts.Services;

using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.Contacts.Shared.Contacts.ViewModels;

/// <summary>
/// Provides demo contact data for testing and demonstration purposes.
/// </summary>
internal static class DemoContactData
{
    /// <summary>
    /// Gets a demo contact for PJ (Piquot Jérôme).
    /// </summary>
    /// <value>
    /// A <see cref="ContactDetails"/> object representing PJ's contact information.
    /// </value>
    internal static ContactDetails PJ => new(
        "PJ",
        "Piquot Jérôme",
        "AI Technical architect",
        new Person(),
        [
            new("Mobile", ContactPointType.Mobile, "+33651818181"),
            new("Office phone", ContactPointType.Phone, "+33145453333"),
            new("Email", ContactPointType.Email, "jpiquot@hexalith.com")],
        false);

    /// <summary>
    /// Gets a demo contact for JB (Jean Bernard).
    /// </summary>
    /// <value>
    /// A <see cref="ContactDetails"/> object representing JB's contact information.
    /// </value>
    internal static ContactDetails JB => new(
        "JB",
        "Jean Bernard",
        "Pediatric Doctor",
        new Person(),
        [
            new("Mobile", ContactPointType.Mobile, "+33651717171"),
            new("Office phone", ContactPointType.Phone, "+33145456666"),
            new("Email", ContactPointType.Email, "jbernard@hexalith.com")],
        false);

    /// <summary>
    /// Gets a collection of all demo contacts.
    /// </summary>
    /// <value>
    /// An <see cref="IEnumerable{T}"/> of <see cref="ContactDetails"/> containing all demo contacts.
    /// </value>
    internal static IEnumerable<ContactDetails> Data => [PJ, JB];
}

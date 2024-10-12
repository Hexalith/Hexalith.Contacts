namespace Hexalith.Contacts.Shared.Contacts.ViewModels;
/// <summary>
/// Represents the summary of a factory.
/// </summary>
public record ContactSummary(

    /// <summary>
    /// Gets the ID of the factory.
    /// </summary>
    string Id,

    /// <summary>
    /// Gets the name of the factory.
    /// </summary>
    string Name,

    /// <summary>
    /// Gets a value indicating whether the factory is disabled.
    /// </summary>
    bool Disabled)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactSummary"/> class.
    /// </summary>
    /// <param name="details">The factory details.</param>
    public ContactSummary(ContactDetails details)
        : this((details ?? throw new ArgumentNullException(nameof(details))).Id, details.Name, details.Disabled)
    {
    }
}
namespace Hexalith.Contacts.Shared.Contacts.ViewModels;

/// <summary>
/// Represents the details of a factory.
/// </summary>
public record ContactDetails(

    /// <summary>
    /// Gets the ID of the factory.
    /// </summary>
    string Id,

    /// <summary>
    /// Gets the name of the factory.
    /// </summary>
    string Name,

    /// <summary>
    /// Gets the description of the factory.
    /// </summary>
    string Description,

    /// <summary>
    /// Gets a value indicating whether the factory is disabled.
    /// </summary>
    bool Disabled)
{
}
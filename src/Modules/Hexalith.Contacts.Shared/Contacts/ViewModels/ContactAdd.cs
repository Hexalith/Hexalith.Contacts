namespace Hexalith.Contacts.Shared.Contacts.ViewModels;

/// <summary>
/// Represents the information needed to create a factory.
/// </summary>
public class ContactAdd
{
    /// <summary>
    /// Gets or sets the description of the factory.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the ID of the factory.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the factory.
    /// </summary>
    public string Name { get; set; } = string.Empty;

}
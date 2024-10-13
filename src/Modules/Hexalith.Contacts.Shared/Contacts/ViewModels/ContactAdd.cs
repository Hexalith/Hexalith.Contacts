namespace Hexalith.Contacts.Shared.Contacts.ViewModels;

/// <summary>
/// Represents the information needed to add a new contact.
/// </summary>
public class ContactAdd(string id, string name, string firstName, string lastName, string? phone, string? mobile, string? email, string? comments)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactAdd"/> class.
    /// </summary>
    public ContactAdd() : this(string.Empty, string.Empty, string.Empty, string.Empty, null, null, null, null)
    {
    }

    /// <summary>
    /// Gets or sets the ID of the contact.
    /// </summary>
    public string Id { get; set; } = id;

    /// <summary>
    /// Gets or sets the first name of the contact.
    /// </summary>
    public string FirstName { get; set; } = firstName;

    /// <summary>
    /// Gets or sets the name of the contact.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the last name of the contact.
    /// </summary>
    public string LastName { get; set; } = lastName;

    /// <summary>
    /// Gets or sets the phone number of the contact.
    /// </summary>
    public string? Phone { get; set; } = phone;

    /// <summary>
    /// Gets or sets the mobile number of the contact.
    /// </summary>
    public string? Mobile { get; set; } = mobile;

    /// <summary>
    /// Gets or sets the email address of the contact.
    /// </summary>
    public string? Email { get; set; } = email;

    /// <summary>
    /// Gets or sets comments of the contact.
    /// </summary>
    public string? Comments { get; set; } = comments;
}

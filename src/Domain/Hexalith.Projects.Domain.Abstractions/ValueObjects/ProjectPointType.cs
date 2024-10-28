namespace Hexalith.Contact.Domain.ValueObjects;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the type of contact point in the contact management system.
/// </summary>
/// <remarks>
/// This enum is used to categorize different types of contact information.
/// It allows for consistent classification of contact points throughout the application,
/// enabling proper handling and validation of different contact information types.
/// The [JsonConverter(typeof(JsonStringEnumConverter))] attribute is applied to this enum to ensure that
/// when serialized to JSON, the enum values are represented as strings rather than integer values.
/// This improves readability and maintainability of the JSON output, especially when working with APIs
/// or storing data in JSON format.
/// 
/// Example JSON representation:
/// {
///     "contactPointType": "Email"
/// }
/// Instead of:
/// {
///     "contactPointType": 2
/// }
/// 
/// When using this enum, consider implementing appropriate validation for each contact point type
/// to ensure the integrity of the stored data.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContactPointType
{
    /// <summary>
    /// Represents a phone number contact point.
    /// </summary>
    /// <remarks>
    /// This can include various types of phone numbers such as landline or work numbers.
    /// Example: +1 (555) 123-4567.
    /// </remarks>
    Phone = 1,

    /// <summary>
    /// Represents a mobile phone number contact point.
    /// </summary>
    /// <remarks>
    /// This is specifically used for mobile or cellular phone numbers.
    /// Example: +1 (555) 987-6543.
    /// </remarks>
    Mobile = 2,

    /// <summary>
    /// Represents an email address contact point.
    /// </summary>
    /// <remarks>
    /// This is used for electronic mail addresses.
    /// Example: "example@email.com"
    /// </remarks>
    Email = 3,

    /// <summary>
    /// Represents a postal address contact point.
    /// </summary>
    /// <remarks>
    /// This is used for physical mailing addresses.
    /// Example: "123 Main St, Anytown, ST 12345, Country".
    /// </remarks>
    PostalAddress = 4,

    /// <summary>
    /// Represents a social media contact point.
    /// </summary>
    /// <remarks>
    /// This can include various social media platforms such as Twitter, Facebook, LinkedIn, etc.
    /// Example: "@username" or "https://www.linkedin.com/in/username".
    /// </remarks>
    SocialMedia = 5,

    /// <summary>
    /// Represents any other type of contact point not covered by the specific categories.
    /// </summary>
    /// <remarks>
    /// This can be used for custom or less common types of contact information.
    /// Example: "Skype: username" or "Fax: +1 (555) 987-6543".
    /// </remarks>
    Other = 0,
}

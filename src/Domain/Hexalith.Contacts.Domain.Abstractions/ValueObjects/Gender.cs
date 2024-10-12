namespace Hexalith.Contact.Domain.ValueObjects;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the gender of a person in the contact management system.
/// </summary>
/// <remarks>
/// This enum is used to categorize individuals by gender, providing options for standard gender identities
/// as well as accommodating for undefined or other gender identities. The use of an enum ensures type safety
/// and consistency when working with gender data throughout the application.
/// The [JsonConverter(typeof(JsonStringEnumConverter))] attribute is applied to this enum to ensure that
/// when serialized to JSON, the enum values are represented as strings rather than integer values.
/// This improves readability and maintainability of the JSON output, especially when working with APIs
/// or storing data in JSON format.
/// Example JSON representation:
/// {
///     "gender": "Female"
/// }
/// Instead of:
/// {
///     "gender": 1
/// }.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    /// <summary>
    /// Represents an undefined or unspecified gender.
    /// </summary>
    /// <remarks>
    /// This option can be used when gender information is not available or not provided.
    /// </remarks>
    Undefined = 0,

    /// <summary>
    /// Represents the female gender.
    /// </summary>
    Female = 1,

    /// <summary>
    /// Represents the male gender.
    /// </summary>
    Male = 2,

    /// <summary>
    /// Represents any gender identity that doesn't fall into the categories of male, female, or undefined.
    /// </summary>
    /// <remarks>
    /// This option allows for inclusivity of diverse gender identities beyond the binary male/female classification.
    /// </remarks>
    Other = 3,
}

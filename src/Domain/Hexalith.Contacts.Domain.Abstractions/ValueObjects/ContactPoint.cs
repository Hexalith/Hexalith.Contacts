namespace Hexalith.Contact.Domain.ValueObjects;

using System.Runtime.Serialization;

/// <summary>
/// Represents a contact point for a person or entity.
/// This is a value object that encapsulates the details of a single point of contact.
/// </summary>
/// <remarks>
/// A ContactPoint can represent various types of contact information such as phone numbers,
/// email addresses, or physical addresses. The specific type is determined by the PointType property.
/// </remarks>
[DataContract]
public record ContactPoint(
    /// <summary>
    /// Gets or sets the name or identifier of the contact point.
    /// </summary>
    /// <remarks>
    /// This could be used to distinguish between multiple contact points of the same type,
    /// e.g., "Home Phone" vs "Work Phone".
    /// </remarks>
    [property: DataMember(Order = 1)]
    string Name,

    /// <summary>
    /// Gets or sets the type of the contact point.
    /// </summary>
    /// <remarks>
    /// This property uses the ContactPointType enum to specify the nature of the contact information,
    /// such as Phone, Email, or PostalAddress.
    /// </remarks>
    [property: DataMember(Order = 2)]
    ContactPointType PointType,

    /// <summary>
    /// Gets or sets the actual value of the contact point.
    /// </summary>
    /// <remarks>
    /// This contains the specific contact information, such as a phone number, email address, or physical address.
    /// The format of this value should correspond to the PointType.
    /// </remarks>
    [property: DataMember(Order = 3)]
    string Value)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactPoint"/> class.
    /// </summary>
    public ContactPoint()
        : this(string.Empty, ContactPointType.Phone, string.Empty)
    {
    }
}

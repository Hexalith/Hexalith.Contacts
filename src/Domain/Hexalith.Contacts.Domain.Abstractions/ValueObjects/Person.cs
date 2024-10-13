namespace Hexalith.Contact.Domain.ValueObjects;

using System.Runtime.Serialization;

/// <summary>
/// Represents a person in the contact management system.
/// </summary>
[DataContract]
public record Person(
    /// <summary>
    /// The full name of the person.
    /// </summary>
    [property: DataMember(Order = 1)] string Name,

    /// <summary>
    /// The first name of the person.
    /// </summary>
    [property: DataMember(Order = 2)] string FirstName,

    /// <summary>
    /// The last name of the person.
    /// </summary>
    [property: DataMember(Order = 3)] string LastName,

    /// <summary>
    /// The birth date of the person.
    /// </summary>
    [property: DataMember(Order = 4)] DateOnly? BirthDate,

    /// <summary>
    /// The gender of the person.
    /// </summary>
    [property: DataMember(Order = 5)] Gender Gender)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    public Person()
        : this(string.Empty, string.Empty, string.Empty, DateOnly.MinValue, Gender.Undefined)
    {
    }
}


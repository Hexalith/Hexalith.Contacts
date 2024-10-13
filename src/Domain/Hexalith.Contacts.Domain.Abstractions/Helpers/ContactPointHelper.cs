namespace Hexalith.Contact.Domain.Helpers;

using System.Collections.Generic;
using System.Linq;

using Hexalith.Contact.Domain.ValueObjects;

/// <summary>
/// Provides helper methods for working with ContactPoint collections.
/// </summary>
public static class ContactPointHelper
{
    /// <summary>
    /// Gets the value of a contact point of a specific type from a collection of contact points.
    /// </summary>
    /// <param name="contactPoints">The collection of contact points to search.</param>
    /// <param name="type">The type of contact point to find.</param>
    /// <returns>The value of the first contact point matching the specified type, or null if not found.</returns>
    public static string? GetContactPointValue(this IEnumerable<ContactPoint> contactPoints, ContactPointType type)
        => contactPoints.FirstOrDefault(p => p.PointType == type)?.Value;

    /// <summary>
    /// Gets the email address from a collection of contact points.
    /// </summary>
    /// <param name="contactPoints">The collection of contact points to search.</param>
    /// <returns>The email address, or null if not found.</returns>
    public static string? GetEmail(this IEnumerable<ContactPoint> contactPoints)
        => contactPoints.GetContactPointValue(ContactPointType.Email);

    /// <summary>
    /// Gets the mobile number from a collection of contact points.
    /// </summary>
    /// <param name="contactPoints">The collection of contact points to search.</param>
    /// <returns>The mobile number, or null if not found.</returns>
    public static string? GetMobile(this IEnumerable<ContactPoint> contactPoints)
        => contactPoints.GetContactPointValue(ContactPointType.Mobile);

    /// <summary>
    /// Gets the phone number from a collection of contact points.
    /// </summary>
    /// <param name="contactPoints">The collection of contact points to search.</param>
    /// <returns>The phone number, or null if not found.</returns>
    public static string? GetPhone(this IEnumerable<ContactPoint> contactPoints)
        => contactPoints.GetContactPointValue(ContactPointType.Phone);
}

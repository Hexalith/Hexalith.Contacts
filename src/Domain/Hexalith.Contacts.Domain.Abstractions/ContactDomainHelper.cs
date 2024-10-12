namespace Hexalith.Contact.Domain;

/// <summary>
/// Helper class for the Contact domain.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Critical Code Smell",
    "S2339:Public constant members should not be used",
    Justification = "Const values are needed for attributes")]
public static class ContactDomainHelper
{
    /// <summary>
    /// The name of the contact aggregate.
    /// </summary>
    public const string ContactAggregateName = "Contact";

}
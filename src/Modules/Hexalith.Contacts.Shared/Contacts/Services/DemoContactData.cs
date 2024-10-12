namespace Hexalith.Contacts.Shared.Contacts.Services;

using Hexalith.Contacts.Shared.Contacts.ViewModels;

/// <summary>
/// Represents the details of a factory.
/// </summary>
internal static class DemoContactData
{
    internal static ContactDetails PJ => new("PJ", "Piquot Jérôme", string.Empty, false);

    internal static ContactDetails JB => new("JB", "Jean Bernard", string.Empty, false);

    internal static IEnumerable<ContactDetails> Data => [PJ, JB];

}
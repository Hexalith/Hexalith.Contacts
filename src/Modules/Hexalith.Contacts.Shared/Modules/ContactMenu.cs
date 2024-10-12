namespace Hexalith.Contacts.Shared.Modules;

using Hexalith.UI.Components;
using Hexalith.UI.Components.Icons;

using Labels = Resources.Modules.ContactMenu;

/// <summary>
/// Represents the Contact menu.
/// </summary>
public static class ContactMenu
{
    private const string _iconLibraryName = $"{nameof(Contact)}.{nameof(Shared)}";

    /// <summary>
    /// Gets the menu information.
    /// </summary>
    public static MenuItemInformation Menu => new(
                    Labels.ContactMenuItem,
                    string.Empty,
                    new IconInformation("BookContacts", 20, IconStyle.Regular, IconSource.Fluent, _iconLibraryName),
                    true,
                    10,
                    [
                        new MenuItemInformation(
                            Labels.ContactMenuItem,
                            "Contact/Contact",
                            new IconInformation("ContactCard", 20, IconStyle.Regular, IconSource.Fluent, _iconLibraryName),
                            false,
                            10,
                            []),
                        new MenuItemInformation(
                            "test",
                            "/Contact/AuthorizeTest",
                            new IconInformation("DocumentKey", 20, IconStyle.Regular, IconSource.Fluent, _iconLibraryName),
                            false,
                            30,
                            []),
                    ]);
}
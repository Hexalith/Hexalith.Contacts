namespace Hexalith.Contacts.Shared.Modules.Icons;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Provides extension methods for setting the size of a FontAwesomeIcon.
/// </summary>
public static class FontAwesomeIconSizeHelper
{
    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 10.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 10.</returns>
    public static FontAwesomeIcon Size10([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 10 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 12.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 12.</returns>
    public static FontAwesomeIcon Size12([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 12 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 16.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 16.</returns>
    public static FontAwesomeIcon Size16([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 16 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 20.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 20.</returns>
    public static FontAwesomeIcon Size20([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 20 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 24.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 24.</returns>
    public static FontAwesomeIcon Size24([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 24 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 28.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 28.</returns>
    public static FontAwesomeIcon Size28([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 28 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 32.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 32.</returns>
    public static FontAwesomeIcon Size32([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 32 };
    }

    /// <summary>
    /// Sets the size of the FontAwesomeIcon to 48.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the size for.</param>
    /// <returns>The FontAwesomeIcon with the size set to 48.</returns>
    public static FontAwesomeIcon Size48([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Size = 48 };
    }
}
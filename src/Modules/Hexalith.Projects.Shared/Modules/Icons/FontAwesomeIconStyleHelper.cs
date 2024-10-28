namespace Hexalith.Projects.Shared.Modules.Icons;

using System.Diagnostics.CodeAnalysis;

using Hexalith.UI.Components.Icons;

using Microsoft.FluentUI.AspNetCore.Components;

/// <summary>
/// Provides extension methods for setting the style an name of a FontAwesomeIcon.
/// </summary>
public static class FontAwesomeIconStyleHelper
{
    /// <summary>
    /// Creates a new Fluent UI navigation icon with the given name for the specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the name for.</param>
    /// <returns>The FontAwesome Icon with the specified name.</returns>
    public static Icon CreateNavIcon([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return FontAwesomeIcons.GetNavIcon(icon);
    }

    /// <summary>
    /// Creates a new Fluent UI tab icon with the given name for the specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the name for.</param>
    /// <returns>The FontAwesome Icon with the specified name.</returns>
    public static Icon CreateTabIcon([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return FontAwesomeIcons.GetTabIcon(icon);
    }

    /// <summary>
    /// Sets the regular style for the specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the style for.</param>
    /// <returns>The FontAwesomeIcon with the regular style.</returns>
    public static FontAwesomeIcon Regular([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Style = IconStyle.Regular };
    }

    /// <summary>
    /// Sets the filled style for the specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the style for.</param>
    /// <returns>The FontAwesomeIcon with the filled style.</returns>
    public static FontAwesomeIcon Filled([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Style = IconStyle.Filled };
    }

    /// <summary>
    /// Sets the light style for the specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the style for.</param>
    /// <returns>The FontAwesomeIcon with the light style.</returns>
    public static FontAwesomeIcon Light([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Style = IconStyle.Light };
    }

    /// <summary>
    /// Sets the thin style for the specified FontAwesomeIcon.
    /// </summary>
    /// <param name="icon">The FontAwesomeIcon to set the style for.</param>
    /// <returns>The FontAwesomeIcon with the thin style.</returns>
    public static FontAwesomeIcon Thin([NotNull] this FontAwesomeIcon icon)
    {
        ArgumentNullException.ThrowIfNull(icon);
        return icon with { Style = IconStyle.Thin };
    }
}
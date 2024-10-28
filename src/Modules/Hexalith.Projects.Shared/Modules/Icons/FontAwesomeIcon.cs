namespace Hexalith.Projects.Shared.Modules.Icons;

using Hexalith.UI.Components.Icons;

/// <summary>
/// Represents an icon from the FontAwesome icon set.
/// </summary>
public record FontAwesomeIcon : IconInformation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FontAwesomeIcon"/> class.
    /// </summary>
    /// <param name="name">The name of the icon.</param>
    /// <param name="size">The size of the icon.</param>
    /// <param name="style">The style of the icon.</param>
    public FontAwesomeIcon(string name, int size, IconStyle style)
        : base(name, size, style, IconSource.FontAwesome, $"{nameof(Project)}.{nameof(Shared)}")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FontAwesomeIcon"/> class.
    /// </summary>
    /// <param name="name">The name of the icon.</param>
    /// <param name="size">The size of the icon.</param>
    /// <param name="style">The style of the icon.</param>
    public FontAwesomeIcon(string name)
        : this(name, 20, IconStyle.Regular)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FontAwesomeIcon"/> class with default values.
    /// </summary>
    public FontAwesomeIcon()
        : this(string.Empty, 20, IconStyle.Regular)
    {
    }
}
namespace Hexalith.Projects.Shared.Modules;

using Hexalith.UI.Components;
using Hexalith.UI.Components.Icons;

using Labels = Resources.Modules.ProjectMenu;

/// <summary>
/// Represents the Project menu.
/// </summary>
public static class ProjectMenu
{
    private const string _iconLibraryName = $"{nameof(Project)}.{nameof(Shared)}";

    /// <summary>
    /// Gets the menu information.
    /// </summary>
    public static MenuItemInformation Menu => new(
                    Labels.ProjectMenuItem,
                    string.Empty,
                    new IconInformation("BookProjects", 20, IconStyle.Regular, IconSource.Fluent, _iconLibraryName),
                    true,
                    10,
                    [
                        new MenuItemInformation(
                            Labels.ProjectMenuItem,
                            "Project/Project",
                            new IconInformation("ProjectCard", 20, IconStyle.Regular, IconSource.Fluent, _iconLibraryName),
                            false,
                            10,
                            []),
                        new MenuItemInformation(
                            "test",
                            "/Project/AuthorizeTest",
                            new IconInformation("DocumentKey", 20, IconStyle.Regular, IconSource.Fluent, _iconLibraryName),
                            false,
                            30,
                            []),
                    ]);
}
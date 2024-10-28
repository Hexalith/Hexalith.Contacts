namespace Hexalith.Projects.Shared.Projects.Services;

using Hexalith.Project.Domain.ValueObjects;
using Hexalith.Projects.Shared.Projects.ViewModels;

/// <summary>
/// Provides demo project data for testing and demonstration purposes.
/// </summary>
public static class DemoProjectData
{
    /// <summary>
    /// Gets a demo project for PJ (Piquot Jérôme).
    /// </summary>
    /// <value>
    /// A <see cref="ProjectDetails"/> object representing PJ's project information.
    /// </value>
    internal static ProjectDetails PJ => new(
        "PJ",
        "Piquot Jérôme",
        "AI Technical architect",
        new Person(),
        [
            new("Mobile", ProjectPointType.Mobile, "+33651818181"),
            new("Office phone", ProjectPointType.Phone, "+33145453333"),
            new("Email", ProjectPointType.Email, "jpiquot@hexalith.com")],
        false);

    /// <summary>
    /// Gets a demo project for JB (Jean Bernard).
    /// </summary>
    /// <value>
    /// A <see cref="ProjectDetails"/> object representing JB's project information.
    /// </value>
    internal static ProjectDetails JB => new(
        "JB",
        "Jean Bernard",
        "Pediatric Doctor",
        new Person(),
        [
            new("Mobile", ProjectPointType.Mobile, "+33651717171"),
            new("Office phone", ProjectPointType.Phone, "+33145456666"),
            new("Email", ProjectPointType.Email, "jbernard@hexalith.com")],
        false);

    /// <summary>
    /// Gets a collection of all demo projects.
    /// </summary>
    /// <value>
    /// An <see cref="IEnumerable{T}"/> of <see cref="ProjectDetails"/> containing all demo projects.
    /// </value>
    internal static IEnumerable<ProjectDetails> Data => [PJ, JB];
}

namespace Hexalith.Projects.Shared.Projects.ViewModels;

using Hexalith.Project.Domain.Helpers;

/// <summary>
/// Represents a summary of project information.
/// </summary>
/// <param name="Id">The unique identifier of the project.</param>
/// <param name="Name">The name of the project.</param>
/// <param name="Phone">The phone number of the project.</param>
/// <param name="Mobile">The mobile number of the project.</param>
/// <param name="Email">The email address of the project.</param>
/// <param name="Disabled">A flag indicating whether the project is disabled.</param>
public record ProjectSummary(
    string Id,
    string Name,
    string? Phone,
    string? Mobile,
    string? Email,
    bool Disabled)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectSummary"/> class from ProjectDetails.
    /// </summary>
    /// <param name="details">The ProjectDetails object to create the summary from.</param>
    /// <exception cref="ArgumentNullException">Thrown when details is null.</exception>
    public ProjectSummary(ProjectDetails details)
        : this(
              (details ?? throw new ArgumentNullException(nameof(details))).Id,
              details.Name,
              details.ProjectPoints.GetPhone(),
              details.ProjectPoints.GetMobile(),
              details.ProjectPoints.GetEmail(),
              details.Disabled)
    {
    }
}

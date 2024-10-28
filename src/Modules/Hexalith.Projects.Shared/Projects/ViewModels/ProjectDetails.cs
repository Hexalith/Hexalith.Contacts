namespace Hexalith.Projects.Shared.Projects.ViewModels;

using Hexalith.Project.Domain.ValueObjects;

/// <summary>
/// Represents the details of a project in the system.
/// </summary>
/// <param name="Id">The unique identifier of the project.</param>
/// <param name="Name">The name of the project.</param>
/// <param name="Description">A description of the project.</param>
/// <param name="Person">The person associated with this project.</param>
/// <param name="ProjectPoints">A collection of project points for this project.</param>
/// <param name="Disabled">A flag indicating whether the project is disabled.</param>
public record ProjectDetails(
    string Id,
    string Name,
    string Description,
    Person Person,
    IEnumerable<ProjectPoint> ProjectPoints,
    bool Disabled);


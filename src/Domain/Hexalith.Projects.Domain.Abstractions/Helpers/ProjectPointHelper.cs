namespace Hexalith.Project.Domain.Helpers;

using System.Collections.Generic;
using System.Linq;

using Hexalith.Project.Domain.ValueObjects;

/// <summary>
/// Provides helper methods for working with ProjectPoint collections.
/// </summary>
public static class ProjectPointHelper
{
    /// <summary>
    /// Gets the value of a project point of a specific type from a collection of project points.
    /// </summary>
    /// <param name="projectPoints">The collection of project points to search.</param>
    /// <param name="type">The type of project point to find.</param>
    /// <returns>The value of the first project point matching the specified type, or null if not found.</returns>
    public static string? GetProjectPointValue(this IEnumerable<ProjectPoint> projectPoints, ProjectPointType type)
        => projectPoints.FirstOrDefault(p => p.PointType == type)?.Value;

    /// <summary>
    /// Gets the email address from a collection of project points.
    /// </summary>
    /// <param name="projectPoints">The collection of project points to search.</param>
    /// <returns>The email address, or null if not found.</returns>
    public static string? GetEmail(this IEnumerable<ProjectPoint> projectPoints)
        => projectPoints.GetProjectPointValue(ProjectPointType.Email);

    /// <summary>
    /// Gets the mobile number from a collection of project points.
    /// </summary>
    /// <param name="projectPoints">The collection of project points to search.</param>
    /// <returns>The mobile number, or null if not found.</returns>
    public static string? GetMobile(this IEnumerable<ProjectPoint> projectPoints)
        => projectPoints.GetProjectPointValue(ProjectPointType.Mobile);

    /// <summary>
    /// Gets the phone number from a collection of project points.
    /// </summary>
    /// <param name="projectPoints">The collection of project points to search.</param>
    /// <returns>The phone number, or null if not found.</returns>
    public static string? GetPhone(this IEnumerable<ProjectPoint> projectPoints)
        => projectPoints.GetProjectPointValue(ProjectPointType.Phone);
}

namespace Hexalith.Projects.Shared.Projects.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Hexalith.Projects.Shared.Projects.ViewModels;
using Hexalith.UI.Components.Services;

/// <summary>
/// Defines the contract for a service that provides query operations for projects.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IIdDescriptionService"/> and provides methods
/// for retrieving and searching project information asynchronously.
/// </remarks>
public interface IProjectQueryService : IIdDescriptionService
{
    /// <summary>
    /// Retrieves the detailed information for a project with the specified ID.
    /// </summary>
    /// <param name="id">The unique identifier of the project.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the project details.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the project with the specified ID is not found.</exception>
    Task<ProjectDetails> GetDetailsAsync(string id);

    /// <summary>
    /// Retrieves summaries for all projects.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of project summaries.</returns>
    /// <remarks>
    /// This method is equivalent to calling <see cref="GetSummariesAsync(int, int)"/> with skip = 0 and count = 0.
    /// </remarks>
    Task<IEnumerable<ProjectSummary>> GetSummariesAsync()
        => GetSummariesAsync(0, 0);

    /// <summary>
    /// Retrieves a paginated list of project summaries.
    /// </summary>
    /// <param name="skip">The number of projects to skip.</param>
    /// <param name="count">The maximum number of projects to return. If 0, returns all projects.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of project summaries.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skip"/> is negative.</exception>
    Task<IEnumerable<ProjectSummary>> GetSummariesAsync(int skip, int count);

    /// <summary>
    /// Searches for projects based on the provided search text.
    /// </summary>
    /// <param name="searchText">The text to search for in project information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of matching project summaries.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="searchText"/> is null or empty.</exception>
    /// <remarks>
    /// The search is typically performed on fields such as name, email, or phone number.
    /// The exact fields and search algorithm may vary based on the implementation.
    /// </remarks>
    Task<IEnumerable<ProjectSummary>> SearchSummariesAsync(string searchText);
}

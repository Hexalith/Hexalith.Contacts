namespace Hexalith.Contacts.Shared.Contacts.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Hexalith.Contacts.Shared.Contacts.ViewModels;
using Hexalith.UI.Components.Services;

/// <summary>
/// Defines the contract for a service that provides query operations for contacts.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IIdDescriptionService"/> and provides methods
/// for retrieving and searching contact information asynchronously.
/// </remarks>
public interface IContactQueryService : IIdDescriptionService
{
    /// <summary>
    /// Retrieves the detailed information for a contact with the specified ID.
    /// </summary>
    /// <param name="id">The unique identifier of the contact.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the contact details.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the contact with the specified ID is not found.</exception>
    Task<ContactDetails> GetDetailsAsync(string id);

    /// <summary>
    /// Retrieves summaries for all contacts.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of contact summaries.</returns>
    /// <remarks>
    /// This method is equivalent to calling <see cref="GetSummariesAsync(int, int)"/> with skip = 0 and count = 0.
    /// </remarks>
    Task<IEnumerable<ContactSummary>> GetSummariesAsync()
        => GetSummariesAsync(0, 0);

    /// <summary>
    /// Retrieves a paginated list of contact summaries.
    /// </summary>
    /// <param name="skip">The number of contacts to skip.</param>
    /// <param name="count">The maximum number of contacts to return. If 0, returns all contacts.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of contact summaries.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skip"/> is negative.</exception>
    Task<IEnumerable<ContactSummary>> GetSummariesAsync(int skip, int count);

    /// <summary>
    /// Searches for contacts based on the provided search text.
    /// </summary>
    /// <param name="searchText">The text to search for in contact information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of matching contact summaries.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="searchText"/> is null or empty.</exception>
    /// <remarks>
    /// The search is typically performed on fields such as name, email, or phone number.
    /// The exact fields and search algorithm may vary based on the implementation.
    /// </remarks>
    Task<IEnumerable<ContactSummary>> SearchSummariesAsync(string searchText);
}

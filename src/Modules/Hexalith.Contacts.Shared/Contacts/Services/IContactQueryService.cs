namespace Hexalith.Contacts.Shared.Contacts.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Hexalith.Contacts.Shared.Contacts.ViewModels;
using Hexalith.UI.Components.Services;

/// <summary>
/// Represents a factory service.
/// </summary>
public interface IContactQueryService : IIdDescriptionService
{
    /// <summary>
    /// Gets the details of a factory asynchronously based on the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the factory.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the factory details.</returns>
    Task<ContactDetails> GetDetailsAsync(string id);

    /// <summary>
    /// Gets all factories asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of factory summaries.</returns>
    Task<IEnumerable<ContactSummary>> GetSummariesAsync()
        => GetSummariesAsync(0, 0);

    /// <summary>
    /// Gets a range of factories asynchronously.
    /// </summary>
    /// <param name="skip">The number of factories to skip.</param>
    /// <param name="count">The number of factories to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of factory summaries.</returns>
    Task<IEnumerable<ContactSummary>> GetSummariesAsync(int skip, int count);

    /// <summary>
    /// Searches for factories asynchronously based on the specified search text.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of factory summaries.</returns>
    Task<IEnumerable<ContactSummary>> SearchSummariesAsync(string searchText);
}
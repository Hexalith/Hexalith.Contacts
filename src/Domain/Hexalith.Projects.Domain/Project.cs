namespace Hexalith.Projects.Domain;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Project.Domain;
using Hexalith.Project.Domain.ValueObjects;
using Hexalith.Projects.Events.Projects;

/// <summary>
/// Represents a project in the domain.
/// </summary>
[DataContract]
public record Project(
    [property: DataMember(Order = 1)] string Id,
    [property: DataMember(Order = 2)] string Name,
    [property: DataMember(Order = 3)] string ProjectTypeId,
    [property: DataMember(Order = 4)] DateTimeOffset CreatedOn,
    [property: DataMember(Order = 4)] ProjectStatus Status,
    [property: DataMember(Order = 5)] string? Description,
    [property: DataMember(Order = 6)] string? Comments,
    [property: DataMember(Order = 7)] IEnumerable<string> OwnerIds,
    [property: DataMember(Order = 8)] IEnumerable<string> ReaderIds,
    [property: DataMember(Order = 9)] IEnumerable<string> ContributorsIds,
    [property: DataMember(Order = 10)] IEnumerable<string> Tags,
    [property: DataMember(Order = 11)] bool Disabled) : IDomainAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    public Project()
        : this(string.Empty, string.Empty, string.Empty, DateTimeOffset.MinValue, ProjectStatus.Draft, null, null, [], [], [], [], false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class based on the <see cref="ProjectCreated"/> event.
    /// </summary>
    /// <param name="added">The <see cref="ProjectCreated"/> event.</param>
    public Project(ProjectCreated added)
        : this(
              (added ?? throw new ArgumentNullException(nameof(added))).Id,
              added.Name,
              added.ProjectTypeId,
              added.CreatedOn,
              ProjectStatus.Draft,
              added.Description,
              null,
              [added.OwnerId],
              [],
              [],
              [],
              false)
    {
    }

    /// <inheritdoc/>
    public string AggregateId => Id;

    /// <inheritdoc/>
    public string AggregateName => ProjectDomainHelper.ProjectAggregateName;

    /// <inheritdoc/>
    public ApplyResult Apply([NotNull] object domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        if (domainEvent is ProjectEvent ev && domainEvent is not ProjectEnabled && Disabled)
        {
            return new ApplyResult(
                this,
                [new ProjectEventCancelled(ev, "Project is disabled.")],
                true);
        }

        return domainEvent switch
        {
            ProjectCancelled e => ApplyEvent(e),
            ProjectCommentsChanged e => ApplyEvent(e),
            ProjectContributorAdded e => ApplyEvent(e),
            ProjectContributorRemoved e => ApplyEvent(e),
            ProjectCreated e => ApplyEvent(e),
            ProjectDescriptionChanged e => ApplyEvent(e),
            ProjectDisabled e => ApplyEvent(e),
            ProjectDocumentAdded e => ApplyEvent(e),
            ProjectDocumentRemoved e => ApplyEvent(e),
            ProjectEnabled e => ApplyEvent(e),
            ProjectOwnerAdded e => ApplyEvent(e),
            ProjectOwnerRemoved e => ApplyEvent(e),
            ProjectReaderAdded e => ApplyEvent(e),
            ProjectReaderRemoved e => ApplyEvent(e),
            ProjectResumed e => ApplyEvent(e),
            ProjectStarted e => ApplyEvent(e),
            ProjectSuspended e => ApplyEvent(e),
            ProjectEvent e => new ApplyResult(
                this,
                [new ProjectEventCancelled(e, "Event not implemented")],
                true),
            _ => new ApplyResult(
                this,
                [InvalidEventApplied.CreateNotSupportedAppliedEvent(AggregateName, AggregateId, domainEvent)],
                true),
        };
    }

    /// <inheritdoc/>
    public bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    /// <summary>
    /// Applies the ProjectAdded event.
    /// </summary>
    /// <param name="e">The ProjectAdded event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectCancelled e) => new(
        this with { Disabled = true },
        [e],
        false);

    /// <summary>
    /// Applies the ProjectDescriptionChanged event.
    /// </summary>
    /// <param name="e">The ProjectDescriptionChanged event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectDescriptionChanged e) => Comments == e.Comments && Name == e.Name
            ? new ApplyResult(this, [], true)
            : new ApplyResult(
            this with { Comments = e.Comments, Name = e.Name },
            [e],
            false);

    /// <summary>
    /// Applies the ProjectDisabled event.
    /// </summary>
    /// <param name="e">The ProjectDisabled event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectDisabled e) => Disabled
            ? new ApplyResult(this, [], true)
            : new ApplyResult(
            this with { Disabled = true },
            [e],
            false);

    /// <summary>
    /// Applies the ProjectEnabled event.
    /// </summary>
    /// <param name="e">The ProjectEnabled event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectEnabled e) => Disabled
            ? new ApplyResult(
            this with { Disabled = false },
            [e],
            false)
            : new ApplyResult(this, [], true);
}
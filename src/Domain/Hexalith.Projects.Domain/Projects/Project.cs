namespace Hexalith.Projects.Domain.Projects;

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
    [property: DataMember(Order = 5)] ProjectStatus Status,
    [property: DataMember(Order = 6)] IEnumerable<ProjectActor> Actors,
    [property: DataMember(Order = 7)] IEnumerable<ProjectRequirement> Requirements,
    [property: DataMember(Order = 8)] string? Description,
    [property: DataMember(Order = 9)] string? Comments,
    [property: DataMember(Order = 10)] IEnumerable<string> Tags,
    [property: DataMember(Order = 11)] bool Disabled) : IDomainAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    public Project()
        : this(
              string.Empty,
              string.Empty,
              string.Empty,
              DateTimeOffset.MinValue,
              ProjectStatus.Draft,
              [],
              [],
              null,
              null,
              [],
              false)
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
              [],
              [],
              added.Description,
              null,
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
            ProjectActorRemoved e => ApplyEvent(e),
            ProjectCreated e => ApplyEvent(e),
            ProjectDescriptionChanged e => ApplyEvent(e),
            ProjectDisabled e => ApplyEvent(e),
            ProjectDocumentAdded e => ApplyEvent(e),
            ProjectDocumentRemoved e => ApplyEvent(e),
            ProjectEnabled e => ApplyEvent(e),
            ProjectOwnerAdded e => ApplyEvent(e),
            ProjectReaderAdded e => ApplyEvent(e),
            ProjectResumed e => ApplyEvent(e),
            ProjectStarted e => ApplyEvent(e),
            ProjectSuspended e => ApplyEvent(e),
            ProjectEvent e => new ApplyResult(
                this,
                [new ProjectEventCancelled(e, "Event not implemented")],
                true),
            _ => new ApplyResult(
                this,
                [InvalidEventApplied.CreateNotSupportedAppliedEvent(
                    AggregateName,
                    AggregateId,
                    domainEvent)],
                true),
        };
    }

    /// <inheritdoc/>
    public bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    private ApplyResult ValidateStatusAndApply(ProjectEvent e, Func<ProjectEvent, ApplyResult> apply, IEnumerable<ProjectStatus> validStatus, string actionName)
    {
        if (validStatus.Contains(Status))
        {
            return apply(e);
        }

        string message = $"The current project status is {Status}. Action {actionName} project can only be applied in the following statuses : " +
            string.Join(", ", validStatus.Select(p => p.ToString())) + ".";
        return new ApplyResult(
            this,
            [new ProjectEventCancelled(e, message)],
            true);
    }

    private ApplyResult ApplyEvent(ProjectCancelled e) => ValidateStatusAndApply(
        e,
        p => new(this with { Status = ProjectStatus.Canceled }, [e], false),
        [ProjectStatus.Draft, ProjectStatus.Active, ProjectStatus.Suspended],
        "cancel");

    private ApplyResult ApplyEvent(ProjectDescriptionChanged e) => new(
            this with { Description = e.Description, Name = e.Name },
            [e],
            false);

    private ApplyResult ApplyEvent(ProjectCommentsChanged e) => new(
            this with { Comments = e.Comments },
            [e],
            false);

    private ApplyResult ApplyEvent(ProjectEnabled e) => Disabled
            ? new ApplyResult(
            this with { Disabled = false },
            [e],
            false)
            : new ApplyResult(this, [new ProjectEventCancelled(e, "The project is already enabled.")], true);

    private ApplyResult ApplyEvent(ProjectDisabled e) => !Disabled
            ? new ApplyResult(
            this with { Disabled = true },
            [e],
            false)
            : new ApplyResult(this, [new ProjectEventCancelled(e, "The project is already disabled.")], true);

    private ApplyResult ApplyEvent(ProjectCreated e) => !IsInitialized() ?
        new(
            this with
            {
                Id = e.Id,
                Name = e.Name,
                ProjectTypeId = e.ProjectTypeId,
                CreatedOn = e.CreatedOn,
                Description = e.Description,
                Actors = [new (e.OwnerId, ProjectActorRole.Owner)],
            },
            [e],
            false)
            : new ApplyResult(this, [new ProjectEventCancelled(e, "The project is already created.")], true);

    private ApplyResult ApplyEvent(ProjectDocumentAdded e) 
        => new ProjectActors(Actors).ApplyEvent(this, e);

    private ApplyResult ApplyEvent(ProjectDocumentRemoved e) => new(
            this with { ContributorsIds = ContributorsIds.Where(id => id != e.ContactId) },
            [e],
            false);

    private ApplyResult ApplyEvent(ProjectOwnerAdded e)         
        => new ProjectActors(Actors).ApplyEvent(this, e);

    private ApplyResult ApplyEvent(ProjectContributorAdded e)         
        => new ProjectActors(Actors).ApplyEvent(this, e);



    private ApplyResult ApplyEvent(ProjectReaderAdded e) 
        => new ProjectActors(Actors).ApplyEvent(this, e);


    private ApplyResult ApplyEvent(ProjectActorRemoved e) 
        => new ProjectActors(Actors).ApplyEvent(this, e);


    private ApplyResult ApplyEvent(ProjectResumed e) => ValidateStatusAndApply(
        e,
        p => new(this with { Status = ProjectStatus.Active }, [e], false),
        [ProjectStatus.Suspended],
        "resume");

    private ApplyResult ApplyEvent(ProjectStarted e) => ValidateStatusAndApply(
        e,
        p => new(this with { Status = ProjectStatus.Active }, [e], false),
        [ProjectStatus.Draft],
        "start");

    private ApplyResult ApplyEvent(ProjectSuspended e) => ValidateStatusAndApply(
        e,
        p => new(this with { Status = ProjectStatus.Suspended }, [e], false),
        [ProjectStatus.Active],
        "suspend");
}
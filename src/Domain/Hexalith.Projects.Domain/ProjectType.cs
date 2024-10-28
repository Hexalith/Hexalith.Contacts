namespace Hexalith.Projects.Domain;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json;

using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Project.Domain;
using Hexalith.Projects.Events.Projects;
using Hexalith.Projects.Events.ProjectTypes;

/// <summary>
/// Represents a project type in the domain.
/// </summary>
[DataContract]
public record ProjectType(
    [property: DataMember(Order = 1)] string Id,
    [property: DataMember(Order = 2)] string Name,
    [property: DataMember(Order = 3)] string Division,
    [property: DataMember(Order = 4)] string? Description,
    [property: DataMember(Order = 5)] bool Disabled) : IDomainAggregate
{
    public ProjectType()
        : this(string.Empty, string.Empty, string.Empty, null, false)
    {
    }

    public ProjectType(ProjectTypeAdded added)
        : this(
              (added ?? throw new ArgumentNullException(nameof(added))).Id,
              added.Name,
              added.Division,
              null,
              false)
    {
    }

    /// <inheritdoc/>
    public string AggregateId => Id;

    /// <inheritdoc/>
    public string AggregateName => ProjectDomainHelper.ProjectTypeAggregateName;

    /// <inheritdoc/>
    public ApplyResult Apply([NotNull] object domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        if (domainEvent is ProjectCreated added)
        {
            if (!IsInitialized())
            {
                return ApplyEvent(added);
            }

            return new ApplyResult(
                this,
                [new ProjectEventCancelled(added, $"Aggregate {Id}/{Name} already initialized")],
                true);
        }

        if (domainEvent is ProjectEvent projectEvent)
        {
            if (projectEvent.AggregateId != AggregateId)
            {
                return new ApplyResult(this, [new ProjectEventCancelled(projectEvent, $"Invalid aggregate identifier for {Id}/{Name} : {projectEvent.AggregateId}")], true);
            }
        }
        else
        {
            return new ApplyResult(
                this,
                [new InvalidEventApplied(
                    AggregateName,
                    AggregateId,
                    domainEvent.GetType().FullName ?? "Unknown",
                    JsonSerializer.Serialize(domainEvent),
                    $"Unexpected event applied.")],
                true);
        }

        return projectEvent switch
        {
            ProjectPersonChanged e => ApplyEvent(e),
            ProjectDescriptionChanged e => ApplyEvent(e),
            ProjectDisabled e => ApplyEvent(e),
            ProjectEnabled e => ApplyEvent(e),
            ProjectPointAdded e => ApplyEvent(e),
            ProjectPointChanged e => ApplyEvent(e),
            ProjectDocumentRemoved e => ApplyEvent(e),
            _ => new ApplyResult(
                this,
                [new ProjectEventCancelled(projectEvent, "Event not implemented")],
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
    private static ApplyResult ApplyEvent(ProjectCreated e) => new(
        new Project(e),
        [e],
        false);

    /// <summary>
    /// Applies the ProjectPointAdded event.
    /// </summary>
    /// <param name="e">The ProjectPointAdded event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectPointAdded e)
    {
        if (ProjectPoints.Any(p => p.Name == e.ProjectPoint.Name))
        {
            return new ApplyResult(this, [new ProjectEventCancelled(e, $"Project point {e.ProjectPoint.Name} already exists for {Id}/{Name}")], true);
        }

        return new ApplyResult(
            this with { ProjectPoints = ProjectPoints.Union([e.ProjectPoint]).OrderBy(p => p.Name).ToList() },
            [e],
            false);
    }

    /// <summary>
    /// Applies the ProjectPointChanged event.
    /// </summary>
    /// <param name="e">The ProjectPointChanged event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectPointChanged e)
    {
        List<ProjectPoint> points = ProjectPoints.ToList();
        ProjectPoint? oldValue = points.FirstOrDefault(p => p.Name == e.ProjectPoint.Name);
        if (oldValue == null)
        {
            return new ApplyResult(this, [new ProjectEventCancelled(e, $"Project point {e.ProjectPoint.Name} does not exist for {Id}/{Name}")], true);
        }

        if (oldValue != e.ProjectPoint)
        {
            return new ApplyResult(
                this with { ProjectPoints = points.Where(p => p.Name != e.ProjectPoint.Name).Union([e.ProjectPoint]).OrderBy(p => p.Name).ToList() },
                [e],
                false);
        }

        return new ApplyResult(this, [], false);
    }

    /// <summary>
    /// Applies the ProjectPointRemoved event.
    /// </summary>
    /// <param name="e">The ProjectPointRemoved event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectDocumentRemoved e)
    {
        if (ProjectPoints.Any(p => p.Name == e.Name) == false)
        {
            return new ApplyResult(this, [new ProjectEventCancelled(e, $"Project point {e.Name} does not exist for {Id}/{Name}")], true);
        }

        return new ApplyResult(
            this with { ProjectPoints = ProjectPoints.Where(p => p.Name != e.Name).ToList() },
            [e],
            false);
    }

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
    /// Applies the ProjectPersonChanged event.
    /// </summary>
    /// <param name="e">The ProjectPersonChanged event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ProjectPersonChanged e) => new(
            this with { Person = e.Person },
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
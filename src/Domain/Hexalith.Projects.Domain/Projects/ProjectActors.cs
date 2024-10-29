namespace Hexalith.Projects.Domain.Projects;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Hexalith.Domain.Aggregates;
using Hexalith.Project.Domain.ValueObjects;
using Hexalith.Projects.Events.Projects;

/// <summary>
/// Manages the collection of actors (participants) in a project and handles actor-related events.
/// </summary>
/// <param name="actors">The initial collection of project actors.</param>
public class ProjectActors(IEnumerable<ProjectActor> actors)
{
    /// <summary>
    /// Finds an actor in the project by their contact ID.
    /// </summary>
    /// <param name="contactId">The contact ID to search for.</param>
    /// <returns>The found ProjectActor if it exists; otherwise, null.</returns>
    public ProjectActor? FindActor(string contactId)
        => actors.FirstOrDefault(a => a.ContactId == contactId);

    /// <summary>
    /// Applies a ProjectOwnerAdded event to add a new owner to the project.
    /// </summary>
    /// <param name="project">The current project state.</param>
    /// <param name="e">The ProjectOwnerAdded event to apply.</param>
    /// <returns>An ApplyResult containing the updated project state and any resulting events.</returns>
    /// <remarks>
    /// If the contact already exists in the project, the event is cancelled.
    /// Otherwise, adds the contact as a new owner to the project.
    /// </remarks>
    internal ApplyResult ApplyEvent(Project project, ProjectOwnerAdded e)
    {
        ProjectActor? projectActor = FindActor(e.ContactId);
        if (projectActor != null)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not add the owner. The contact {e.ContactId} already exists in the project with role {projectActor.Role}.")], true);
        }

        return new(
            project with
            {
                Actors = actors
                    .Append(new(e.ContactId, ProjectActorRole.Owner))
                    .DistinctBy(x => x.ContactId)
                    .ToImmutableList(),
            },
            [e],
            false);
    }

    /// <summary>
    /// Applies a ProjectReaderAdded event to add a new reader to the project.
    /// </summary>
    /// <param name="project">The current project state.</param>
    /// <param name="e">The ProjectReaderAdded event to apply.</param>
    /// <returns>An ApplyResult containing the updated project state and any resulting events.</returns>
    /// <remarks>
    /// If the contact already exists in the project, the event is cancelled.
    /// Otherwise, adds the contact as a new reader to the project.
    /// </remarks>
    internal ApplyResult ApplyEvent(Project project, ProjectReaderAdded e)
    {
        ProjectActor? projectActor = FindActor(e.ContactId);
        if (projectActor != null)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not add the reader. The actor {e.ContactId} already exists in the project with role {projectActor.Role}.")], true);
        }

        return new(
            project with
            {
                Actors = actors
                    .Append(new(e.ContactId, ProjectActorRole.Reader))
                    .DistinctBy(x => x.ContactId)
                    .ToImmutableList(),
            },
            [e],
            false);
    }

    /// <summary>
    /// Applies a ProjectContributorAdded event to add a new contributor to the project.
    /// </summary>
    /// <param name="project">The current project state.</param>
    /// <param name="e">The ProjectContributorAdded event to apply.</param>
    /// <returns>An ApplyResult containing the updated project state and any resulting events.</returns>
    /// <remarks>
    /// If the contact already exists in the project, the event is cancelled.
    /// Otherwise, adds the contact as a new contributor to the project.
    /// </remarks>
    internal ApplyResult ApplyEvent(Project project, ProjectContributorAdded e)
    {
        ProjectActor? projectActor = FindActor(e.ContactId);
        if (projectActor != null)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not add the contributor. The actor {e.ContactId} already exists in the project with role {projectActor.Role}.")], true);
        }

        return new(
            project with
            {
                Actors = actors
                    .Append(new(e.ContactId, ProjectActorRole.Contributor))
                    .DistinctBy(x => x.ContactId)
                    .ToImmutableList(),
            },
            [e],
            false);
    }

    /// <summary>
    /// Applies a ProjectActorRemoved event to remove an actor from the project.
    /// </summary>
    /// <param name="project">The current project state.</param>
    /// <param name="e">The ProjectActorRemoved event to apply.</param>
    /// <returns>An ApplyResult containing the updated project state and any resulting events.</returns>
    /// <remarks>
    /// The event is cancelled if:
    /// - The actor does not exist in the project
    /// - The actor is the last owner in the project (at least one owner must remain)
    /// Otherwise, removes the actor from the project.
    /// </remarks>
    internal ApplyResult ApplyEvent(Project project, ProjectActorRemoved e)
    {
        ProjectActor? projectActor = FindActor(e.ContactId);
        if (projectActor == null)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not remove the actor {e.ContactId}. The contact does not exist in the project.")], true);
        }

        if (projectActor.Role == ProjectActorRole.Owner && actors.Count(p => p.Role == ProjectActorRole.Owner) < 2)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not remove the owner {e.ContactId}. The project must have at least one owner.")], true);
        }

        return new(
            project with { Actors = actors.Where(p => p.ContactId != e.ContactId).ToImmutableList() },
            [e],
            false);
    }
}

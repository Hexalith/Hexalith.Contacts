namespace Hexalith.Projects.Domain.Projects;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Hexalith.Domain.Aggregates;
using Hexalith.Project.Domain.ValueObjects;
using Hexalith.Projects.Events.Projects;

public class ProjectDocuments(IEnumerable<ProjectDocument> documents)
{
    public ProjectDocument? FindDocument(string documentId)
        => documents.FirstOrDefault(a => a.Id == documentId);

    internal ApplyResult ApplyEvent(Project project, ProjectDocumentAdded e)
    {
        ProjectDocument? projectDocument = FindDocument(e.DocumentId);
        if (projectDocument != null)
        {
            return new(project, [new ProjectEventCancelled(e, $"The document {e.DocumentId} already exists in the project with name {projectDocument.Name}.")], true);
        }

        return new(
            project with
            {
                Documents = documents
                    .Append(new(e.DocumentId, ProjectDocumentRole.Owner))
                    .DistinctBy(x => x.DocumentId)
                    .ToImmutableList(),
            },
            [e],
            false);
    }

    internal ApplyResult ApplyEvent(Project project, ProjectDocumentRemoved e)
    {
        ProjectDocument? projectDocument = FindDocument(e.DocumentId);
        if (projectDocument == null)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not remove the actor {e.DocumentId}. The contact does not exist in the project.")], true);
        }

        if (projectDocument.Role == ProjectDocumentRole.Owner && documents.Count(p => p.Role == ProjectDocumentRole.Owner) < 2)
        {
            return new(project, [new ProjectEventCancelled(e, $"Could not remove the owner {e.DocumentId}. The project must have at least one owner.")], true);
        }

        return new(
            project with { Documents = documents.Where(p => p.DocumentId != e.DocumentId).ToImmutableList() },
            [e],
            false);
    }
}
namespace Hexalith.Projects.Application.CommandHandlers;

using Hexalith.Application.Commands;
using Hexalith.Application.Metadatas;
using Hexalith.Projects.Commands;
using Hexalith.Projects.Domain;
using Hexalith.Domain.Aggregates;
using Hexalith.Projects.Events.Projects;

/// <summary>
/// Command handler for adding a new factory.
/// </summary>
public class AddProjectHandler : DomainCommandHandler<AddProject>
{
    /// <inheritdoc/>
    public override Task<ExecuteCommandResult> DoAsync(AddProject command, Metadata metadata, IDomainAggregate? aggregate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        ProjectCreated ev = new(command.Id, command.Name, command.Comments, command.Person);
        if (aggregate is null)
        {
            return Task.FromResult(new ExecuteCommandResult(new Project(ev), [ev], [ev]));
        }

        if (aggregate is Project factory)
        {
            ApplyResult result = factory.Apply(ev);
            return Task.FromResult(new ExecuteCommandResult(aggregate, result.Failed ? [] : [ev], result.Messages));
        }

        return Task.FromException<ExecuteCommandResult>(new InvalidAggregateTypeException<Project>(aggregate));
    }

    /// <inheritdoc/>
    public override Task<ExecuteCommandResult> UndoAsync(AddProject command, Metadata metadata, IDomainAggregate? aggregate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        return Task.FromException<ExecuteCommandResult>(new NotSupportedException("Undo operation is not supported for adding a project."));
    }
}
namespace Hexalith.Contacts.Application.CommandHandlers;

using Hexalith.Application.Commands;
using Hexalith.Application.MessageMetadatas;
using Hexalith.Contacts.Commands;
using Hexalith.Contacts.Domain;
using Hexalith.Contacts.Events;
using Hexalith.Domain.Aggregates;

/// <summary>
/// Command handler for adding a new factory.
/// </summary>
public class AddContactHandler : DomainCommandHandler<AddContact>
{
    /// <inheritdoc/>
    public override Task<ExecuteCommandResult> DoAsync(AddContact command, Metadata metadata, IDomainAggregate? aggregate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        ContactAdded ev = new(command.Id, command.Name, command.Comments, command.Person);
        if (aggregate is null)
        {
            return Task.FromResult(new ExecuteCommandResult(new Contact(ev), [ev], [ev]));
        }

        if (aggregate is Contact factory)
        {
            ApplyResult result = factory.Apply(ev);
            return Task.FromResult(new ExecuteCommandResult(aggregate, result.Failed ? [] : [ev], result.Messages));
        }

        return Task.FromException<ExecuteCommandResult>(new InvalidAggregateTypeException<Contact>(aggregate));
    }

    /// <inheritdoc/>
    public override Task<ExecuteCommandResult> UndoAsync(AddContact command, Metadata metadata, IDomainAggregate? aggregate, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        return Task.FromException<ExecuteCommandResult>(new NotSupportedException("Undo operation is not supported for adding a contact."));
    }
}
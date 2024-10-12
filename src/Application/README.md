# Hexalith Contacts - Application Layer

The Application layer in the Hexalith Contacts project serves as an intermediary between the external world (such as user interfaces or external systems) and the domain layer. It orchestrates the execution of business logic and manages the flow of data between the outside world and the domain.

## Structure

The Application layer consists of the following projects:

1. `Hexalith.Contacts.Application`: Contains the main application services and command handlers.
2. `Hexalith.Contacts.Commands`: Defines the commands that can be executed in the system.

## Key Components

### Application Services

Application services implement use cases by coordinating the execution of domain logic. They typically:

- Accept input from the presentation layer
- Validate input
- Coordinate with one or more domain entities or aggregates
- Persist changes
- Return results

Example (pseudo-code):
```csharp
public class ContactApplicationService
{
    public async Task AddContact(AddContactCommand command)
    {
        // Validate command
        // Create Contact entity
        // Save Contact
        // Raise ContactAdded event
    }
}
```

### Commands

Commands represent user intentions and are typically used to modify the system state. They are handled by command handlers in the application layer.

Examples of commands:

- `AddContactBaseType`
- `ChangeContactBaseTypeDescription`
- `DisableContactBaseType`
- `EnableContactBaseType`

### Command Handlers

Command handlers are responsible for executing the business logic associated with a specific command. They typically:

- Validate the command
- Retrieve necessary data from repositories
- Execute domain logic
- Persist changes
- Raise domain events

Example (pseudo-code):
```csharp
public class AddContactBaseTypeHandler : ICommandHandler<AddContactBaseType>
{
    public async Task Handle(AddContactBaseType command)
    {
        // Validate command
        // Create ContactBaseType
        // Save ContactBaseType
        // Raise ContactBaseTypeAdded event
    }
}
```

### Validators

Validators ensure that commands and queries are valid before they are processed. They help to maintain data integrity and improve system reliability.

Example (using FluentValidation):
```csharp
public class AddContactBaseTypeValidator : AbstractValidator<AddContactBaseType>
{
    public AddContactBaseTypeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
    }
}
```

## Best Practices

When working with the Application layer:

1. Keep application services thin. They should delegate complex business logic to the domain layer.
2. Use commands and queries to represent all operations that can be performed by the system.
3. Implement proper validation for all incoming commands and queries.
4. Use dependency injection to manage dependencies and improve testability.
5. Handle exceptions and implement proper logging to aid in debugging and monitoring.
6. Use asynchronous programming patterns where appropriate to improve scalability.

## Testing

The application layer should be thoroughly tested with unit tests and integration tests:

- Unit test individual command handlers and application services.
- Use mocks or stubs for external dependencies (like repositories) in unit tests.
- Implement integration tests that cover the full flow from command input to persistence and event raising.

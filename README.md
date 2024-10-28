# Hexalith Projects

Hexalith Projects is a domain-driven design (DDD) project for managing project information. This project is structured to separate concerns and maintain a clear domain model.

## Project Structure

The project is organized into several key directories:

- `src/`: Contains the main source code for the project
  - `Application/`: Application layer, containing command handlers and application services
  - `Domain/`: Domain layer, containing the core business logic and domain models
  - `Modules/`: Modular components of the application (Client, Server, Shared)

For more detailed information about each component, please refer to their respective README files:

- [Domain Layer Documentation](src/Domain/README.md)
- [Application Layer Documentation](src/Application/README.md)
- [Modules Documentation](src/Modules/README.md)

## Core Concepts

### Person

The `Person` record is a central value object in the domain, representing an individual's basic information:

- Name
- FirstName
- LastName
- BirthDate
- Gender

The `Person` record now includes built-in validation logic and an `IsValid()` method to ensure data integrity. It uses a constructor with parameter validation to guarantee that Person objects are always created in a valid state.

### Gender

The `Gender` enum represents the possible gender values for a person:

- Undefined
- Female
- Male
- Other

### ProjectPointType

The `ProjectPointType` enum represents the various types of project points:

- Phone
- Email
- PostalAddress
- SocialMedia
- Other

### ProjectPoint

The `ProjectPoint` record represents a single point of project for a person or entity, including:

- Name
- PointType (of type ProjectPointType)
- Value

## Documentation

The project, especially the Domain layer, is thoroughly documented with XML comments and detailed README files. This documentation provides insights into:

- The purpose and usage of each class and enum
- The meaning and expected values of properties and parameters
- Important implementation details and constraints
- Best practices for working with each layer
- Validation logic and data integrity measures

Recent improvements include enhanced documentation for the `Person` record, emphasizing its validation logic and the importance of maintaining data integrity in the domain model.

We encourage all contributors to maintain and update this documentation as the project evolves. For more detailed information about the domain concepts and their implementation, please refer to the [Domain Layer Documentation](src/Domain/README.md).

## Getting Started

To get started with the Hexalith Projects project:

1. Clone the repository:
   ```
   git clone https://github.com/your-repo/hexalith-projects.git
   ```

2. Navigate to the project directory:
   ```
   cd hexalith-projects
   ```

3. Restore the NuGet packages:
   ```
   dotnet restore
   ```

4. Build the solution:
   ```
   dotnet build
   ```

5. Run the tests:
   ```
   dotnet test
   ```

6. Run the application (replace `Hexalith.Projects.Server` with the appropriate startup project):
   ```
   dotnet run --project src/Modules/Hexalith.Projects.Server
   ```

## Contributing

We welcome contributions to the Hexalith Projects project. Please read our [Contributing Guidelines](CONTRIBUTING.md) for details on how to submit pull requests, report issues, and suggest improvements. When contributing, please ensure that you maintain the existing documentation standards and update the relevant documentation for any changes you make.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

If you encounter any issues or have questions about the project, please [open an issue](https://github.com/your-repo/hexalith-projects/issues) on GitHub.

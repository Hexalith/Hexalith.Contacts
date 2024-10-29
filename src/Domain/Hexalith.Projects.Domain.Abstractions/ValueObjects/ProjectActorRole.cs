namespace Hexalith.Project.Domain.ValueObjects;

/// <summary>
/// Represents the role of an actor (user or system) within a project.
/// </summary>
public enum ProjectActorRole
{
    /// <summary>
    /// The actor has full control and administrative rights over the project.
    /// </summary>
    Owner,

    /// <summary>
    /// The actor has read-only access to project information.
    /// </summary>
    Reader,

    /// <summary>
    /// The actor can contribute to the project with limited administrative rights.
    /// </summary>
    Contributor,
}

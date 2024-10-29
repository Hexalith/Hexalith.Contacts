namespace Hexalith.Project.Domain.ValueObjects;

using System.Runtime.Serialization;

/// <summary>
/// Represents an actor (participant) in a project with their associated role.
/// </summary>
/// <param name="ContactId">The unique identifier of the contact associated with this project actor.</param>
/// <param name="Role">The role of the actor in the project.</param>
[DataContract]
public record ProjectActor(
    [property: DataMember(Order = 1)] string ContactId,
    [property: DataMember(Order = 2)] ProjectActorRole Role)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectActor"/> class.
    /// </summary>
    public ProjectActor()
        : this(string.Empty, ProjectActorRole.Reader)
    {
    }
}
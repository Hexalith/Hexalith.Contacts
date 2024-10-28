namespace Hexalith.Project.Domain.ValueObjects;

using System;
using System.Runtime.Serialization;

/// <summary>
/// Represents a requirement or task within a project.
/// </summary>
[DataContract]
public record ProjectRequirement(
    /// <summary>
    /// Gets the name or title of the requirement.
    /// </summary>
    [property: DataMember(Order = 1)] string Name,

    /// <summary>
    /// Gets the detailed description of the requirement.
    /// </summary>
    [property: DataMember(Order = 2)] string Description,

    /// <summary>
    /// Gets the identifier of the user who created or owns the requirement.
    /// </summary>
    [property: DataMember(Order = 3)] string OwnerId,

    /// <summary>
    /// Gets the identifier of the user assigned to work on this requirement.
    /// </summary>
    [property: DataMember(Order = 4)] string AssignedTo,

    /// <summary>
    /// Gets the type of document associated with this requirement.
    /// </summary>
    [property: DataMember(Order = 5)] string DocumentType,

    /// <summary>
    /// Gets the optional identifier of the associated document.
    /// </summary>
    [property: DataMember(Order = 6)] string? DocumentId,

    /// <summary>
    /// Gets the optional expected completion date for this requirement.
    /// </summary>
    [property: DataMember(Order = 7)] DateTimeOffset? ExpectedDate,

    /// <summary>
    /// Gets the optional deadline by which this requirement must be completed.
    /// </summary>
    [property: DataMember(Order = 8)] DateTimeOffset? Deadline,

    /// <summary>
    /// Gets the collection of tags associated with this requirement for categorization and filtering.
    /// </summary>
    [property: DataMember(Order = 9)] IEnumerable<string> Tags,

    /// <summary>
    /// Gets the collection of work item identifiers linked to this requirement.
    /// </summary>
    [property: DataMember(Order = 10)] IEnumerable<string> WorkItemIds);

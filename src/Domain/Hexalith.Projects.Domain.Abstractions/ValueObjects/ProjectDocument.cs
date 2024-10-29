namespace Hexalith.Project.Domain.ValueObjects;

using System.Collections.Generic;
using System.Runtime.Serialization;

/// <summary>
/// Represents a document associated with a project, containing metadata and reference information.
/// </summary>
[DataContract]
public record ProjectDocument(
    /// <summary>
    /// Gets the unique identifier of the document.
    /// </summary>
    /// <value>The document's unique identifier string.</value>
    [property: DataMember(Order = 1)] string Id,

    /// <summary>
    /// Gets the name of the document.
    /// </summary>
    /// <value>The document's display name.</value>
    [property: DataMember(Order = 2)] string Name,

    /// <summary>
    /// Gets the detailed description of the document.
    /// </summary>
    /// <value>The document's description text.</value>
    [property: DataMember(Order = 3)] string Description,

    /// <summary>
    /// Gets the type identifier of the document.
    /// </summary>
    /// <value>The document's type identifier string.</value>
    [property: DataMember(Order = 4)] string TypeId,

    /// <summary>
    /// Gets the URL where the document can be accessed.
    /// </summary>
    /// <value>The document's location URL.</value>
    [property: DataMember(Order = 4)] Uri LocationUrl,

    /// <summary>
    /// Gets the collection of tags associated with the document.
    /// </summary>
    /// <value>An enumerable collection of tag strings.</value>
    [property: DataMember(Order = 5)] IEnumerable<string> Tags);
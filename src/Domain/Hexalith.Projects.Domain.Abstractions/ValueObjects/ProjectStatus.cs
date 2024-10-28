namespace Hexalith.Project.Domain.ValueObjects;

/// <summary>
/// Represents the current status of a project in its lifecycle.
/// </summary>
public enum ProjectStatus
{
    /// <summary>
    /// The project is in draft state and not yet officially started.
    /// </summary>
    Draft,

    /// <summary>
    /// The project is currently active and in progress.
    /// </summary>
    Active,

    /// <summary>
    /// The project has been temporarily suspended or put on hold.
    /// </summary>
    Suspended,

    /// <summary>
    /// The project has been successfully completed.
    /// </summary>
    Completed,

    /// <summary>
    /// The project has been permanently canceled before completion.
    /// </summary>
    Canceled,
}

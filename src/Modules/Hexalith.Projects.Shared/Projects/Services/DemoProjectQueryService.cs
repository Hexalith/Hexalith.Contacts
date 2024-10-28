namespace Hexalith.Projects.Shared.Projects.Services;

/// <summary>
/// Represents a demo implementation of the project query service that uses pre-defined data.
/// </summary>
/// <remarks>
/// This class extends the MemoryProjectQueryService and initializes it with demo data,
/// making it useful for testing, demonstrations, or development scenarios where a
/// fully functional backend is not required.
/// </remarks>
public class DemoProjectQueryService() : MemoryProjectQueryService(DemoProjectData.Data)
{
}

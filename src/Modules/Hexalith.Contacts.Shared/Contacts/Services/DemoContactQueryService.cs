namespace Hexalith.Contacts.Shared.Contacts.Services;

/// <summary>
/// Represents a demo implementation of the contact query service that uses pre-defined data.
/// </summary>
/// <remarks>
/// This class extends the MemoryContactQueryService and initializes it with demo data,
/// making it useful for testing, demonstrations, or development scenarios where a 
/// fully functional backend is not required.
/// </remarks>
public class DemoContactQueryService(DemoContactData.Data data) : MemoryContactQueryService(data)
{
}

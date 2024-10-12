namespace Hexalith.Contacts.Shared.Contacts.Services;
/// <summary>
/// The Demo factory service.
/// </summary>
public class DemoContactQueryService : MemoryContactQueryService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DemoContactQueryService"/> class.
    /// </summary>
    public DemoContactQueryService()
        : base(DemoContactData.Data)
    {
    }
}
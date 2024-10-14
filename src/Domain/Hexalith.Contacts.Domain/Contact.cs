namespace Hexalith.Contacts.Domain;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json;

using Hexalith.Contact.Domain;
using Hexalith.Contact.Domain.ValueObjects;
using Hexalith.Contacts.Events;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;

/// <summary>
/// Represents a contact in the domain.
/// </summary>
[DataContract]
public record Contact(
    [property: DataMember(Order = 1)] string Id,
    [property: DataMember(Order = 2)] string Name,
    [property: DataMember(Order = 3)] string? Comments,
    [property: DataMember(Order = 4)] Person Person,
    [property: DataMember(Order = 5)] IEnumerable<ContactPoint> ContactPoints,
    [property: DataMember(Order = 6)] bool Disabled) : IDomainAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Contact"/> class.
    /// </summary>
    public Contact()
        : this(string.Empty, string.Empty, null, new Person(), [], false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Contact"/> class based on the <see cref="ContactAdded"/> event.
    /// </summary>
    /// <param name="added">The <see cref="ContactAdded"/> event.</param>
    public Contact(ContactAdded added)
        : this(
              (added ?? throw new ArgumentNullException(nameof(added))).Id,
              added.Name,
              added.Description,
              added.Person,
              [],
              false)
    {
    }

    /// <inheritdoc/>
    public string AggregateId => Id;

    /// <inheritdoc/>
    public string AggregateName => ContactDomainHelper.ContactAggregateName;

    /// <inheritdoc/>
    public ApplyResult Apply([NotNull] object domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        if (domainEvent is ContactAdded added)
        {
            if (!IsInitialized())
            {
                return ApplyEvent(added);
            }

            return new ApplyResult(
                this,
                [new ContactEventCancelled(added, $"Aggregate {Id}/{Name} already initialized")],
                true);
        }

        if (domainEvent is ContactEvent contactEvent)
        {
            if (contactEvent.AggregateId != AggregateId)
            {
                return new ApplyResult(this, [new ContactEventCancelled(contactEvent, $"Invalid aggregate identifier for {Id}/{Name} : {contactEvent.AggregateId}")], true);
            }
        }
        else
        {
            return new ApplyResult(
                this,
                [new InvalidEventApplied(
                    AggregateName,
                    AggregateId,
                    domainEvent.GetType().FullName ?? "Unknown",
                    JsonSerializer.Serialize(domainEvent),
                    $"Unexpected event applied.")],
                true);
        }

        return contactEvent switch
        {
            ContactPersonChanged e => ApplyEvent(e),
            ContactDescriptionChanged e => ApplyEvent(e),
            ContactDisabled e => ApplyEvent(e),
            ContactEnabled e => ApplyEvent(e),
            ContactPointAdded e => ApplyEvent(e),
            ContactPointChanged e => ApplyEvent(e),
            ContactPointRemoved e => ApplyEvent(e),
            _ => new ApplyResult(
                this,
                [new ContactEventCancelled(contactEvent, "Event not implemented")],
                true),
        };
    }

    /// <inheritdoc/>
    public bool IsInitialized() => !string.IsNullOrWhiteSpace(Id);

    /// <summary>
    /// Applies the ContactAdded event.
    /// </summary>
    /// <param name="e">The ContactAdded event.</param>
    /// <returns>ApplyResult.</returns>
    private static ApplyResult ApplyEvent(ContactAdded e) => new(
        new Contact(e),
        [e],
        false);

    /// <summary>
    /// Applies the ContactPointAdded event.
    /// </summary>
    /// <param name="e">The ContactPointAdded event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactPointAdded e)
    {
        if (ContactPoints.Any(p => p.Name == e.ContactPoint.Name))
        {
            return new ApplyResult(this, [new ContactEventCancelled(e, $"Contact point {e.ContactPoint.Name} already exists for {Id}/{Name}")], true);
        }

        return new ApplyResult(
            this with { ContactPoints = ContactPoints.Union([e.ContactPoint]).OrderBy(p => p.Name).ToList() },
            [e],
            false);
    }

    /// <summary>
    /// Applies the ContactPointChanged event.
    /// </summary>
    /// <param name="e">The ContactPointChanged event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactPointChanged e)
    {
        List<ContactPoint> points = ContactPoints.ToList();
        ContactPoint? oldValue = points.FirstOrDefault(p => p.Name == e.ContactPoint.Name);
        if (oldValue == null)
        {
            return new ApplyResult(this, [new ContactEventCancelled(e, $"Contact point {e.ContactPoint.Name} does not exist for {Id}/{Name}")], true);
        }

        if (oldValue != e.ContactPoint)
        {
            return new ApplyResult(
                this with { ContactPoints = points.Where(p => p.Name != e.ContactPoint.Name).Union([e.ContactPoint]).OrderBy(p => p.Name).ToList() },
                [e],
                false);
        }

        return new ApplyResult(this, [], false);
    }

    /// <summary>
    /// Applies the ContactPointRemoved event.
    /// </summary>
    /// <param name="e">The ContactPointRemoved event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactPointRemoved e)
    {
        if (ContactPoints.Any(p => p.Name == e.Name) == false)
        {
            return new ApplyResult(this, [new ContactEventCancelled(e, $"Contact point {e.Name} does not exist for {Id}/{Name}")], true);
        }

        return new ApplyResult(
            this with { ContactPoints = ContactPoints.Where(p => p.Name != e.Name).ToList() },
            [e],
            false);
    }

    /// <summary>
    /// Applies the ContactDescriptionChanged event.
    /// </summary>
    /// <param name="e">The ContactDescriptionChanged event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactDescriptionChanged e) => Comments == e.Comments && Name == e.Name
            ? new ApplyResult(this, [], true)
            : new ApplyResult(
            this with { Comments = e.Comments, Name = e.Name },
            [e],
            false);

    /// <summary>
    /// Applies the ContactDisabled event.
    /// </summary>
    /// <param name="e">The ContactDisabled event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactDisabled e) => Disabled
            ? new ApplyResult(this, [], true)
            : new ApplyResult(
            this with { Disabled = true },
            [e],
            false);

    /// <summary>
    /// Applies the ContactPersonChanged event.
    /// </summary>
    /// <param name="e">The ContactPersonChanged event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactPersonChanged e) => new(
            this with { Person = e.Person },
            [e],
            false);

    /// <summary>
    /// Applies the ContactEnabled event.
    /// </summary>
    /// <param name="e">The ContactEnabled event.</param>
    /// <returns>ApplyResult.</returns>
    private ApplyResult ApplyEvent(ContactEnabled e) => Disabled
            ? new ApplyResult(
            this with { Disabled = false },
            [e],
            false)
            : new ApplyResult(this, [], true);
}
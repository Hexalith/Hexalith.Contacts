namespace Hexalith.Contacts.Events.Contacts;

using System;

using Hexalith.Domain.Events;
using Hexalith.PolymorphicSerialization;

/// <summary>
/// Represents an invalid contact event applied.
/// </summary>
/// <param name="AggregateName">The aggregate name.</param>
/// <param name="AggregateId">The aggregate identifier.</param>
/// <param name="EventName">The event name.</param>
/// <param name="EventContent">The event content serialized in JSON.</param>
[PolymorphicSerialization]
public partial record InvalidContactEventCancelled(string AggregateName, string AggregateId, string EventName, string EventContent, string Reason)
    : InvalidEventApplied(AggregateName, AggregateId, EventName, EventContent)
{
    /// <summary>
    /// Creates an instance of InvalidContactEventApplied.
    /// </summary>
    /// <param name="aggregateName">The aggregate name.</param>
    /// <param name="aggregateId">The aggregate identifier.</param>
    /// <param name="event">The event object.</param>
    /// <param name="reason">The reason why the event is invalid.</param>
    /// <returns>An instance of InvalidContactEventApplied.</returns>
    public static InvalidContactEventCancelled Create(string aggregateName, string aggregateId, object @event, string reason)
    {
        ArgumentNullException.ThrowIfNull(@event);

        return InvalidContactEventCancelled.Create<InvalidContactEventCancelled>(
            aggregateName,
            aggregateId,
            @event,
            (string aggregateName, string aggregateId, string eventName, string eventContent)
                => new InvalidContactEventCancelled(aggregateName, aggregateId, eventName, eventContent, reason));
    }
}
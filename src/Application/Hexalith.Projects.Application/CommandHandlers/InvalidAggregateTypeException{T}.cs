namespace Hexalith.Projects.Application.CommandHandlers;

using System;
using System.Text.Json;

using Hexalith.Domain.Aggregates;

/// <summary>
/// Exception thrown when an invalid aggregate type is encountered.
/// </summary>
/// <typeparam name="T">The expected aggregate type.</typeparam>
[Serializable]
public class InvalidAggregateTypeException<T> : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidAggregateTypeException{T}"/> class.
    /// </summary>
    public InvalidAggregateTypeException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidAggregateTypeException{T}"/> class.
    /// </summary>
    /// <param name="aggregate">The aggregate.</param>
    public InvalidAggregateTypeException(IDomainAggregate aggregate)
        : base($"The exected type is {typeof(T).GetType().Name} but aggregate is {aggregate?.GetType().Name ?? "null"}: {JsonSerializer.Serialize(aggregate)}")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidAggregateTypeException{T}"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public InvalidAggregateTypeException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidAggregateTypeException{T}"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    public InvalidAggregateTypeException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
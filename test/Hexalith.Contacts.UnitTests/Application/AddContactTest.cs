namespace Hexalith.Contacts.UnitTests.Application;

using System;
using System.Text.Json;

using FluentAssertions;

using Hexalith.Application.MessageMetadatas;
using Hexalith.Contacts.Commands;
using Hexalith.Infrastructure.DaprRuntime.Actors;
using Hexalith.PolymorphicSerialization;

public class AddContactTest
{
    [Fact]
    public void AddContactBaseTypeInEnvelopeShouldBeSameAsOriginal()
    {
        // Arrange
        JsonSerializerOptions jsonOptions = new()
        {
            TypeInfoResolver = new PolymorphicSerializationResolver([new AddContactMapper()]),
        };
        AddContact message = new("1", "Test AddContactBaseType", "This is a test AddContactBaseType", new Contact.Domain.ValueObjects.Person());
        Metadata metadata = Metadata.CreateNew(message, "test", DateTime.UtcNow);
        ActorMessageEnvelope envelope = ActorMessageEnvelope.Create(message, metadata, jsonOptions);

        // Act
        string json = JsonSerializer.Serialize(envelope, jsonOptions);
        ActorMessageEnvelope deserializedEnvelope = JsonSerializer.Deserialize<ActorMessageEnvelope>(json, jsonOptions);
        (object deserializedMessage, Metadata deserializedMetadata) = deserializedEnvelope.Deserialize(jsonOptions);

        // Assert
        _ = deserializedMessage.Should().BeEquivalentTo(message);
        _ = deserializedMetadata.Should().BeEquivalentTo(metadata);
    }
}
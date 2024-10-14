namespace Hexalith.Contacts.UnitTests.Application;

using System;
using System.Text.Json;


using FluentAssertions;

using Hexalith.Application;
using Hexalith.Application.MessageMetadatas;
using Hexalith.Contacts.Commands;
using Hexalith.Contacts.Commands.Extensions;
using Hexalith.Infrastructure.DaprRuntime.Actors;
using Hexalith.PolymorphicSerialization;

public class AddContactTest
{
    [Fact]
    public void AddContactBaseTypeInEnvelopeShouldBeSameAsOriginal()
    {
        // Arrange
        PolymorphicSerializationResolver.DefaultMappers = PolymorphicSerializationResolver.DefaultMappers.AddHexalithContactsCommandsMappers();
        JsonSerializerOptions jsonOptions = ApplicationConstants.DefaultJsonSerializerOptions;
        AddContact message = new("1", "Test AddContactBaseType", "This is a test AddContactBaseType", new Contact.Domain.ValueObjects.Person());
        Metadata metadata = Metadata.CreateNew(message, "test", "part1", DateTime.UtcNow);
        ActorMessageEnvelope envelope = ActorMessageEnvelope.Create(message, metadata);

        // Act
        string json = JsonSerializer.Serialize(envelope, jsonOptions);
        ActorMessageEnvelope deserializedEnvelope = JsonSerializer.Deserialize<ActorMessageEnvelope>(json, jsonOptions);
        (object deserializedMessage, Metadata deserializedMetadata) = deserializedEnvelope.Deserialize();

        // Assert
        _ = deserializedMessage.Should().BeEquivalentTo(message);
        _ = deserializedMetadata.Should().BeEquivalentTo(metadata);
    }
}
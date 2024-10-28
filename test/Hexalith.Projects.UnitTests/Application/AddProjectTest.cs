namespace Hexalith.Projects.UnitTests.Application;

using System;
using System.Text.Json;

using FluentAssertions;

using Hexalith.Application.Metadatas;
using Hexalith.Projects.Commands;
using Hexalith.Projects.Commands.Extensions;
using Hexalith.Infrastructure.DaprRuntime.Actors;
using Hexalith.PolymorphicSerialization;

public class AddProjectTest
{
    [Fact]
    public void AddProjectBaseTypeInEnvelopeShouldBeSameAsOriginal()
    {
        // Arrange
        HexalithProjectsCommands.RegisterPolymorphicMappers();
        JsonSerializerOptions jsonOptions = PolymorphicHelper.DefaultJsonSerializerOptions;
        AddProject message = new("1", "Test AddProjectBaseType", "This is a test AddProjectBaseType", new Project.Domain.ValueObjects.Person());
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
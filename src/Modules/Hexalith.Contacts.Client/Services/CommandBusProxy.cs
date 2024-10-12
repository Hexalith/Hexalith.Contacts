﻿// <copyright file="CommandBusProxy.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Contacts.Client.Services;

using System.Net.Http.Json;

using Hexalith.Application.Commands;
using Hexalith.Application.Envelopes;
using Hexalith.Application.Metadatas;
using Hexalith.Application.States;

/// <summary>
/// Represents a proxy for the command bus.
/// </summary>
public class CommandBusProxy : ICommandBus
{
    private readonly HttpClient _httpClient;
    private readonly TimeProvider _timeProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandBusProxy"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client used for sending commands.</param>
    /// <param name="timeProvider">The time provider used for getting the current time.</param>
    public CommandBusProxy(HttpClient httpClient, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(timeProvider);
        _httpClient = httpClient;
        _timeProvider = timeProvider;
    }

    /// <inheritdoc/>
    /// <exception cref="NotImplementedException">This method is not implemented.</exception>
    public async Task PublishAsync(IEnvelope<BaseCommand, BaseMetadata> envelope, CancellationToken cancellationToken)
    {
        await PublishAsync(
                new CommandState(
                    _timeProvider.GetLocalNow(),
                    (envelope ?? throw new ArgumentNullException(nameof(envelope))).Message,
                    envelope.Metadata),
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    /// <exception cref="NotImplementedException">This method is not implemented.</exception>
    public async Task PublishAsync(BaseCommand command, BaseMetadata metadata, CancellationToken cancellationToken)
    {
        await PublishAsync(
                new CommandState(
                    _timeProvider.GetLocalNow(),
                    command,
                    metadata),
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task PublishAsync(CommandState commandState, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient
            .PostAsJsonAsync("/Command/Publish", commandState, cancellationToken)
            .ConfigureAwait(false);
        _ = response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task PublishAsync(object command, Hexalith.Application.MessageMetadatas.Metadata metadata, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient
            .PostAsJsonAsync("/api/command/publish", new Hexalith.Application.MessageMetadatas.MessageState(command, metadata), cancellationToken)
            .ConfigureAwait(false);
        _ = response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task PublishAsync(Hexalith.Application.MessageMetadatas.MessageState message, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message);
        await PublishAsync(
                    message.Message,
                    message.Metadata,
                    cancellationToken)
            .ConfigureAwait(false);
    }
}
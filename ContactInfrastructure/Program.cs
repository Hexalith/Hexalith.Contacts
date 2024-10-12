// <copyright file="Program.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

using Hexalith.Infrastructure.AspireService.Hosting.Helpers;

using Microsoft.Extensions.Configuration;

HexalithDistributedApplication app = new(args);

app.Builder.AddForwardedHeaders();

if (!app.Builder.ExecutionContext.IsRunMode)
{
    Console.WriteLine($"Starting environment {app.Builder.Environment.EnvironmentName}");
    _ = app
        .Builder
        .AddExecutable("dapr-dashboard", "dapr", ".", "dashboard")
        .WithHttpEndpoint(port: 8080, targetPort: 8080, name: "dashboard-http", isProxied: false);
}

app.Builder.Configuration.AddUserSecrets<Program>();

if (app.IsProjectEnabled<Projects.HexalithApp_Server>())
{
    _ = app
        .AddProject<Projects.HexalithApp_Server>("contact")
        .WithEnvironment("Hexalith__EasyAuthentication__Enabled", "true")
        .WithOrganization("STRADAL", "FR", "ContactApp");
}

await app
    .Builder
    .Build()
    .RunAsync()
    .ConfigureAwait(false);
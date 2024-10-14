namespace HexalithApp.Server;

using System;
using System.Collections.Generic;

using Hexalith.Application.Modules.Applications;
using Hexalith.Contacts.Server.Modules;
using Hexalith.EasyAuthentication.Server;

using HexalithApp.Client;
using HexalithApp.Shared;

/// <summary>
/// Represents a server application.
/// </summary>
public class ServerApplication : HexalithServerApplication
{
    /// <inheritdoc/>
    public override Type ClientApplicationType => typeof(ClientApplication);

    /// <inheritdoc/>
    public override IEnumerable<Type> ServerModules => [
        typeof(ContactServerModule),
        typeof(HexalithEasyAuthenticationServerModule)];

    /// <inheritdoc/>
    public override Type SharedApplicationType => typeof(SharedApplication);
}
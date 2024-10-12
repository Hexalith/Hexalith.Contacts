namespace HexalithApp.Client;

using System;
using System.Collections.Generic;

using Hexalith.Application.Modules.Applications;
using Hexalith.EasyAuthentication.Client;

using HexalithApp.Shared;
using Hexalith.Contacts.Client.Modules;

/// <summary>
/// Represents a client application.
/// </summary>
public class ClientApplication : HexalithClientApplication
{
    /// <inheritdoc/>
    public override IEnumerable<Type> ClientModules
        => [
            typeof(ContactClientModule),
            typeof(HexalithEasyAuthenticationClientModule)];

    /// <inheritdoc/>
    public override Type SharedApplicationType => typeof(SharedApplication);
}
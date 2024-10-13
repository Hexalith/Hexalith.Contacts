namespace HexalithApp.Shared;

using Hexalith.Application.Modules.Applications;
using Hexalith.EasyAuthentication.Shared;
using Hexalith.Extensions.Helpers;
using Hexalith.UI.Components.Modules;
using Hexalith.Contacts.Shared.Modules;

/// <summary>
/// Represents a shared application.
/// </summary>
public class SharedApplication : HexalithSharedApplication
{
    /// <inheritdoc/>
    public override string HomePath => "Contact";

    /// <inheritdoc/>
    public override string Id => "ContactConstructionSite";

    /// <inheritdoc/>
    public override string LoginPath => "/.auth/login/aad";

    /// <inheritdoc/>
    public override string LogoutPath => "/.auth/logout";

    /// <inheritdoc/>
    public override string Name => "Contacts";

    /// <inheritdoc/>
    public override IEnumerable<Type> SharedModules =>
    [
        typeof(ContactConstructionSiteSharedModule),
        typeof(HexalithUIComponentsSharedModule),
        typeof(HexalithEasyAuthenticationSharedModule),
    ];

    /// <inheritdoc/>
    public override string Version => VersionHelper.ProductVersion<ContactConstructionSiteSharedModule>() ?? "?.?.?";
}
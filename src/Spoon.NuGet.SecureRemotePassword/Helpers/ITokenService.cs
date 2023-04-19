namespace Spoon.NuGet.SecureRemotePassword.Helpers;

/// <summary>
/// Represents a service that provides methods for retrieving information about authentication tokens.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Gets the issuer of the token.
    /// </summary>
    /// <returns>The issuer of the token.</returns>
    string GetIssuer();

    /// <summary>
    /// Gets the audience of the token.
    /// </summary>
    /// <returns>The audience of the token.</returns>
    string GetAudience();

    /// <summary>
    /// Gets the lifetime of the token.
    /// </summary>
    /// <returns>The lifetime of the token.</returns>
    int GetTokenLifetime();

    /// <summary>
    /// Determines whether to include the IP address origin ID in the token.
    /// </summary>
    /// <returns>True if the IP address origin ID should be included in the token; otherwise, false.</returns>
    bool IncludeIpAddressOriginId();

    /// <summary>
    /// Gets the IP address origin ID to include in the token.
    /// </summary>
    /// <returns>The IP address origin ID to include in the token.</returns>
    string GetIpAddressOriginId();

    /// <summary>
    /// Determines whether to include the window origin ID in the token.
    /// </summary>
    /// <returns>True if the window origin ID should be included in the token; otherwise, false.</returns>
    bool IncludeWindowOriginId();

    /// <summary>
    /// Gets the window origin ID to include in the token.
    /// </summary>
    /// <returns>The window origin ID to include in the token.</returns>
    string WindowOriginId();

    /// <summary>
    /// Determines whether to include the browser origin ID in the token.
    /// </summary>
    /// <returns>True if the browser origin ID should be included in the token; otherwise, false.</returns>
    bool IncludeBrowserOriginId();

    /// <summary>
    /// Gets the browser origin ID to include in the token.
    /// </summary>
    /// <returns>The browser origin ID to include in the token.</returns>
    string GetBrowserOriginId();

    /// <summary>
    /// Gets the IP address restriction to use for token validation.
    /// </summary>
    /// <returns>The IP address restriction to use for token validation.</returns>
    string GetUseIpAddressRestriction();
}
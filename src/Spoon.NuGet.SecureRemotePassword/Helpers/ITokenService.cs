namespace Spoon.NuGet.SecureRemotePassword.Helpers;

public interface ITokenService
{
    string GetIssuer();
    string GetAudience();
    TimeSpan GetTokenLifetime();
    bool IncludeIpAddressOriginId();
    string GetIpAddressOriginId();
    bool IncludeWindowOriginId();
    string WindowOriginId();
    bool IncludeBrowserOriginId();
    string GetBrowserOriginId();
    string GetUseIpAddressRestriction();
    string GetUserId();
}
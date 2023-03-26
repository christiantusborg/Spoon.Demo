namespace Spoon.NuGet.SecureRemotePassword.Extensions;

using System.Security.Claims;
using Contracts;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var claim = principal?.FindFirst(ClaimTypes.NameIdentifier);
        return !Guid.TryParse(claim?.Value, out var userId) ? Guid.Empty : userId;
    }
    
    public static Guid GetSessionId(this ClaimsPrincipal? principal)
    {
        var claim = principal?.FindFirst("SessionId");
        return !Guid.TryParse(claim?.Value, out var userId) ? Guid.Empty : userId;
    }
}
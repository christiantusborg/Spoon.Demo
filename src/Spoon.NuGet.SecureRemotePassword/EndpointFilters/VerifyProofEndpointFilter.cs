namespace Spoon.NuGet.SecureRemotePassword.EndpointFilters;

using Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

public class VerifyProofEndpointFilter : IEndpointFilter
{
    private readonly IMemoryCache _cache;


    public VerifyProofEndpointFilter(IMemoryCache cache)
    {
        this._cache = cache;
    }
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var userId = context.HttpContext.User.GetUserId();
        
        if ( !this._cache.TryGetValue("VerifyProof_" + userId, out string verifyProofCache) )
        // if ( !this._cache.TryGetValue("VerifyProof_" + userId, out VerifyProoCache verifyProofCache) )
        {
            return Results.Json("VerifyProof_NotFound", null, null, 401);
        }

        var result = await next.Invoke(context);
        return result;
    }
}
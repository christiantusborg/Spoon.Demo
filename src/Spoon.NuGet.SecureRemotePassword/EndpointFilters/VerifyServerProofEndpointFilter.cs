﻿namespace Spoon.NuGet.SecureRemotePassword.EndpointFilters;

using Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

public class VerifyServerProofEndpointFilter : IEndpointFilter
{
    private readonly IMemoryCache _cache;


    public VerifyServerProofEndpointFilter(IMemoryCache cache)
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
        
        context.HttpContext.Response.Headers.Add("VerifyServerProof","9a65ceac-59c3-4be6-a4b4-84482212979e");

        var result = await next.Invoke(context);
        return result;
    }
}
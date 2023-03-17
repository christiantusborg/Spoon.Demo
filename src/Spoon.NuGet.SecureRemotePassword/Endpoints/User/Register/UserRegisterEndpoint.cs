namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using System.Security.Claims;
using Application.User.UserRegister;
using EitherCore.Extensions;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using SecureRemotePassword.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

public static class UserRegisterEndpoint
{
     /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserRegister(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Register.Endpoint,  async ([FromBody] UserRegisterRequest request, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.MapToCommand(claimsPrincipal.GetUserId());

                var commandResult = await sender.Send(command, cancellationToken);
                var result = commandResult.ToResult(typeof(UserSetAsPrimaryEmailResult));

                return result;
            })
            .WithName(nameof(ApiUserEndpoints.Register))
            .Produces<UserRegisterResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserRegisterResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Register.Summary, ApiUserEndpoints.Register.Description));
        
        return app;
    }
     
     private static UserRegisterCommand MapToCommand(this UserRegisterRequest request, Guid userId)
     {
         var command = new UserRegisterCommand
         {
             UserId = userId,
             Email = request.Email,
             Verifier = request.Verifier,
             Salt = request.Salt,
         };
         return command;
     }
}
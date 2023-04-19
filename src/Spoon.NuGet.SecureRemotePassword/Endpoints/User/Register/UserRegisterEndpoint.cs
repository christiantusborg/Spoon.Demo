namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Register;

using System.Security.Claims;
using Application.Commands.Users.UserRegister;
using Contracts;
using Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

public class UserRegisterEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Register.Endpoint, async ([FromBody] UserRegisterRequest request, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = this.MapToCommand(request, claimsPrincipal.GetUserId());

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

    private UserRegisterCommand MapToCommand(UserRegisterRequest request, Guid userId)
    {
        var command = new UserRegisterCommand
        {
            UserId = userId,
            Email = request.Email,
            Verifier = request.Verifier,
            Salt = request.Salt,
            UsernameHash = request.UsernameHash,
        };
        return command;
    }
}
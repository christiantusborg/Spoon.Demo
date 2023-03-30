namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.CreateUser
{
    using Core.Presentation;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Spoon.NuGet.EitherCore.Extensions;
    using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
    using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
    using Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser;
    using Spoon.NuGet.SecureRemotePassword.Contracts;
    using Swashbuckle.AspNetCore.Annotations;

    //public static class GetChallengeAuthentication
    /// <summary>
    /// </summary>
    public class AdministrationCreateUserEndpoint : IEndpointMarker
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
        {
            app.MapPost(ApiAdministrationEndpoints.CreateUser.Endpoint, CreateUser)
                .WithName(ApiAdministrationEndpoints.CreateUser.Name)
                .Produces(204)
                .Produces<PermissionFailed<AdministrationCreateUserResult>>(403)
                .Produces<Validationfailures>(406)
                .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.CreateUser.Summary, ApiAdministrationEndpoints.CreateUser.Description));

            return app;
        }

        public static AdministrationCreateUserCommand MapToCommand(AdministrationCreateUserRequest request)
        {
            var command = new AdministrationCreateUserCommand
            {
                Email = request.Email,
                Salt = request.Salt,
                Verifier = request.Verifier,
            };
            return command;
        }
        
        public static async Task<IResult> CreateUser([FromBody] AdministrationCreateUserRequest request, ISender sender, CancellationToken cancellationToken)
        {
            var command = MapToCommand(request);
            var commandResult = await sender.Send(command, cancellationToken);

            var result = commandResult.ToNoContent();
            return result;
        }        
    }
}
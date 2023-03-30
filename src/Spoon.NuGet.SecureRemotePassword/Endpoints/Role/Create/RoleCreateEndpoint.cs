namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.Create
{
    using Administration;
    using Administration.CreateUser;
    using Application.Roles.Create;
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
    public class RoleCreateEndpoint : IEndpointMarker
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
        {
            app.MapPost(ApiRoleEndpoints.Create.Endpoint, CreateUser)
                .WithName(ApiRoleEndpoints.Create.Name)
                .Produces(204)
                .Produces<PermissionFailed<AdministrationCreateUserResult>>(403)
                .Produces<Validationfailures>(406)
                .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.Create.Summary, ApiRoleEndpoints.Create.Description));

            return app;
        }

        private static RoleCreateCommand MapToCommand(RoleCreateRequest request)
        {
            var command = new RoleCreateCommand
            {
                Name = request.Name,
            };
            return command;
        }
        
        private static async Task<IResult> CreateUser([FromBody] RoleCreateRequest request, ISender sender, CancellationToken cancellationToken)
        {
            var command = MapToCommand(request);
            var commandResult = await sender.Send(command, cancellationToken);

            var result = commandResult.ToNoContent();
            return result;
        }        
    }
}
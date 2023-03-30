namespace Spoon.NuGetAll.SecureRemotePassword.Endpoints.Role.GetAllAll
{
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using NuGet.Core.Presentation;
    using NuGet.EitherCore.Extensions;
    using NuGet.Mediator.PipelineBehaviors.Validation;
    using NuGet.SecureRemotePassword.Application.Roles.GetAll;
    using NuGet.SecureRemotePassword.Endpoints;
    using NuGet.SecureRemotePassword.Endpoints.Role;
    using Swashbuckle.AspNetCore.Annotations;

    //public static class GetAllChallengeAuthentication
    /// <summary>
    /// </summary>
    public class RoleGetAllEndpoint : IEndpointMarker
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
        {
            app.MapGet(ApiRoleEndpoints.DeleteSoft.Endpoint, GetAll)
                .WithName(ApiRoleEndpoints.DeleteSoft.Name)
                .Produces(204)
                .Produces<Validationfailures>(406)
                .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.DeleteSoft.Summary, ApiRoleEndpoints.DeleteSoft.Description));

            return app;
        }

        private static RoleGetAllCommand MapToCommand(Guid roleId)
        {
            var command = new RoleGetAllCommand
            {
            };
            return command;
        }
        
        private static async Task<IResult> GetAll(Guid ruleId, ISender sender, CancellationToken cancellationToken)
        {
            var command = MapToCommand(ruleId);
            var commandResult = await sender.Send(command, cancellationToken);

            var result = commandResult.ToNoContent();
            return result;
        }        
    }
}
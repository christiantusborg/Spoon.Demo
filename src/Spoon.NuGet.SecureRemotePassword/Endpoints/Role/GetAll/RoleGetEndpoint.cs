/*
namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.GetAll
{
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Spoon.NuGet.EitherCore.Extensions;
    using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
    using Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll;
    using Spoon.NuGet.SecureRemotePassword.Endpoints.Role;
    using Swashbuckle.AspNetCore.Annotations;

    //public static class GetAllChallengeAuthentication
    /// <summary>
    /// </summary>
    public class RoleGetAllEndpoint //: IEndpointMarker
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
        {
            app.MapGet(ApiRoleEndpoints.GetAll.Endpoint, GetAll)
                .WithName(ApiRoleEndpoints.DeleteSoft.Name)
                .Produces(204)
                .Produces<Validationfailures>(406)
                .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.GetAll.Summary, ApiRoleEndpoints.GetAll.Description));

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
*/
namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.DeletePermanent
{
    using Application.Roles.DeletePermanent;
    using Core.Presentation;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Spoon.NuGet.EitherCore.Extensions;
    using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
    using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
    using Spoon.NuGet.SecureRemotePassword.Contracts;
    using Swashbuckle.AspNetCore.Annotations;

    //public static class GetChallengeAuthentication
    /// <summary>
    /// </summary>
    public class RoleDeletePermanentEndpoint: IEndpointMarker
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
        {
            app.MapDelete(ApiRoleEndpoints.DeletePermanent.Endpoint, DeletePermanentUser)
                .WithName(ApiRoleEndpoints.DeletePermanent.Name)
                .Produces(204)
                .Produces<Validationfailures>(406)
                .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.DeletePermanent.Summary, ApiRoleEndpoints.DeletePermanent.Description));

            return app;
        }

        private static RoleDeletePermanentCommand MapToCommand(Guid roleId)
        {
            var command = new RoleDeletePermanentCommand
            {
                RoleId = roleId,
            };
            return command;
        }
        
        private static async Task<IResult> DeletePermanentUser(Guid ruleId, ISender sender, CancellationToken cancellationToken)
        {
            var command = MapToCommand(ruleId);
            var commandResult = await sender.Send(command, cancellationToken);

            var result = commandResult.ToNoContent();
            return result;
        }        
    }
}
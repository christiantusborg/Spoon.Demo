﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.Get
{
    using Application.Role.Get;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Spoon.NuGet.EitherCore.Extensions;
    using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
    using Spoon.NuGet.SecureRemotePassword.Application.Role.DeleteSoft;
    using Swashbuckle.AspNetCore.Annotations;

    //public static class GetChallengeAuthentication
    /// <summary>
    /// </summary>
    public static class RoleGetEndpoint
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapRoleGet(this IEndpointRouteBuilder app)
        {
            app.MapGet(ApiRoleEndpoints.DeleteSoft.Endpoint, Get)
                .WithName(ApiRoleEndpoints.DeleteSoft.Name)
                .Produces(204)
                .Produces<Validationfailures>(406)
                .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.DeleteSoft.Summary, ApiRoleEndpoints.DeleteSoft.Description));

            return app;
        }

        private static RoleGetCommand MapToCommand(Guid roleId)
        {
            var command = new RoleGetCommand
            {
                RoleId = roleId,
            };
            return command;
        }
        
        private static async Task<IResult> Get(Guid ruleId, ISender sender, CancellationToken cancellationToken)
        {
            var command = MapToCommand(ruleId);
            var commandResult = await sender.Send(command, cancellationToken);

            var result = commandResult.ToNoContent();
            return result;
        }        
    }
}
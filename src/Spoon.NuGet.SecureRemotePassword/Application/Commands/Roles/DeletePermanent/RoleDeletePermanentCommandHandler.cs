namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.DeletePermanent;

using Core.Application;
using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class RoleDeletePermanentCommandHandler : IRequestHandler<RoleDeletePermanentCommand, Either<RoleDeletePermanentCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public RoleDeletePermanentCommandHandler(ISecureRemotePasswordRepository repository)
    {
        this._repository = repository;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
    public async Task<Either<RoleDeletePermanentCommandResult>> Handle(
        RoleDeletePermanentCommand request,
        CancellationToken cancellationToken)
    {
        var existingRole = await this._repository.Roles.GetAsync(new DefaultGetSpecification<Role>(request.RoleId), cancellationToken);

        if (existingRole == null)
            return EitherHelper<RoleDeletePermanentCommandResult>.EntityNotFound(typeof(User));

        if (existingRole.Name == "root")
            return EitherHelper<RoleDeletePermanentCommandResult>.Create("CannotNotDeleteTheRootRole", BaseHttpStatusCodes.Status403Forbidden);


        this._repository.Roles.Remove(existingRole);

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<RoleDeletePermanentCommandResult>(new RoleDeletePermanentCommandResult());
    }
}
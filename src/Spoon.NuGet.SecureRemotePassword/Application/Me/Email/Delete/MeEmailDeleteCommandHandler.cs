namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Delete;

using Administration.RemoveUserEmail;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Enums;
using EitherCore.Helpers;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class MeEmailDeleteCommandHandler : IRequestHandler<MeEmailDeleteCommand, Either<MeEmailDeleteCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public MeEmailDeleteCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<MeEmailDeleteCommandResult>> Handle(
        MeEmailDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserEmail = await this._repository.UserEmails.GetAsync(new GetUserEmailSpecification(request.UserId, request.EmailId), cancellationToken);

        if (existingUserEmail == null)
            return EitherHelper<MeEmailDeleteCommandResult>.EntityNotFound(typeof(UserEmail));

        if (existingUserEmail.IsPrimary == 1)
        {
            return EitherHelper<MeEmailDeleteCommandResult>.Create("BadPermissions_CannotRemovePrimary", BaseHttpStatusCodes.Status423Locked);
        }


        this._repository.UserEmails.Remove(existingUserEmail);

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<MeEmailDeleteCommandResult>(new MeEmailDeleteCommandResult());
    }
}
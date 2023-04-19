namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserEmailVerified;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     A MediatR command handler that adds an email address for a user in the administration context.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global - instantiated by MediatR
public sealed class AdministrationSetUserEmailVerifiedCommandHandler : IRequestHandler<AdministrationSetUserEmailVerifiedCommand, Either<AdministrationSetUserEmailVerifiedCommandResult>>
{
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;


    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserEmailVerifiedCommandHandler" /> class.
    /// </summary>
    /// <param name="mockbleDateTime">The mockable date/time service.</param>
    /// <param name="repository">The repository for accessing data.</param>
    public AdministrationSetUserEmailVerifiedCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository)
    {
        this._mockbleDateTime = mockbleDateTime;
        this._repository = repository;
    }

    /// <summary>
    ///     Handles the specified request to add an email address for a user.
    /// </summary>
    /// <param name="request">The command to add an email address for a user.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>
    ///     An Either instance indicating either the success or failure of the operation, and containing additional
    ///     information if it succeeded.
    /// </returns>
    public async Task<Either<AdministrationSetUserEmailVerifiedCommandResult>> Handle(
        AdministrationSetUserEmailVerifiedCommand request,
        CancellationToken cancellationToken)
    {
        // Check if the email address already exists. If it does, return an error.
        var emailExists = await this._repository.UserEmails.GetAsync(new DefaultGetSpecification<UserEmail>(request.EmailId), cancellationToken);

        if (emailExists == null)
            return EitherHelper<AdministrationSetUserEmailVerifiedCommandResult>.EntityNotFound(typeof(UserEmail));

        emailExists.EmailAddressVerifiedAt = request.Verified ? this._mockbleDateTime.UtcNow : null;

        await this._repository.SaveChangesAsync(cancellationToken);

        // Return a new AdministrationAddUserEmailCommandResult with the generated email ID
        var result = new Either<AdministrationSetUserEmailVerifiedCommandResult>(new AdministrationSetUserEmailVerifiedCommandResult
        {
            Success = true,
        });

        return result;
    }
}
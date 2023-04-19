// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserEmailAsPrimary;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserEmailAsPrimaryCommandHandler : IRequestHandler<AdministrationSetUserEmailAsPrimaryCommand, Either<AdministrationSetUserEmailAsPrimaryCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public AdministrationSetUserEmailAsPrimaryCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<AdministrationSetUserEmailAsPrimaryCommandResult>> Handle(
        AdministrationSetUserEmailAsPrimaryCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserEmails = await this._repository.UserEmails.SearchAsync(new GetSetUserEmailAsPrimarySpecification(request.UserId), cancellationToken);

        var newPrimaryUserEmail = existingUserEmails.FirstOrDefault(x => x.EmailId == request.EmailId);

        if (newPrimaryUserEmail == null)
        {
            return EitherHelper<AdministrationSetUserEmailAsPrimaryCommandResult>.EntityNotFound(typeof(UserEmail));
        }

        foreach (var userEmail in existingUserEmails)
        {
            userEmail.IsPrimary = 0;
        }

        existingUserEmails.First(x => x.EmailId == request.EmailId).IsPrimary = 1;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<AdministrationSetUserEmailAsPrimaryCommandResult>(new AdministrationSetUserEmailAsPrimaryCommandResult());
    }
}
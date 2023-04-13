namespace Spoon.NuGet.SecureRemotePassword.Application.UserClaim.RemoveBulk;

using Core.Domain;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using MediatR;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserClaimRemoveBulkCommandHandler : IRequestHandler<UserClaimRemoveBulkCommand, Either<UserClaimRemoveBulkCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public UserClaimRemoveBulkCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<UserClaimRemoveBulkCommandResult>> Handle(
        UserClaimRemoveBulkCommand request,
        CancellationToken cancellationToken)
    {
        var userFilters = new List<Filter>
        {
            new ()
            {
                Operation = Operation.Equals,
                Value = request.UserId,
                PropertyName = "UserId",
            },
        };

        var existingUser = await this._repository.Users.GetAsync(new GetUserWithClaimsSpecification(userFilters), cancellationToken);

        if (existingUser is null)
            return EitherHelper<UserClaimRemoveBulkCommandResult>.EntityNotFound(typeof(User));

        var filters = new List<Filter>
        {
            new ()
            {
                Operation = Operation.Contains,
                Value = request.Claims,
                PropertyName = "ClaimId",
            },
        };

        var existingClaims = await this._repository.Claims.SearchAsync(new GetWhereContainsClaimIdContainsSpecification(filters), cancellationToken);

        var newClaims = existingClaims.Intersect(existingUser.Claims).ToList();

        foreach (var claim in newClaims)
        {
            existingUser.Claims.Remove(claim);
        }

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<UserClaimRemoveBulkCommandResult>(new UserClaimRemoveBulkCommandResult());
    }
}
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.UserClaim.AddBulk;

using Core.Domain;
using Domain.Entities;
using Domain.Repositories;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserClaimAddBulkCommandHandler : IRequestHandler<UserClaimAddBulkCommand, Either<UserClaimAddBulkCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public UserClaimAddBulkCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<UserClaimAddBulkCommandResult>> Handle(
        UserClaimAddBulkCommand request,
        CancellationToken cancellationToken)
    {
        var roleFilters = new List<Filter>
        {
            new ()
            {
                Operation = Operation.Equals,
                Value = request.UserId,
                PropertyName = "UserId",
            },
        };

        var existingUser = await this._repository.Users.GetAsync(new GetUserWithClaimsSpecification(roleFilters), cancellationToken);

        if (existingUser is null)
            return EitherHelper<UserClaimAddBulkCommandResult>.EntityNotFound(typeof(User));


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

        var newClaims = existingClaims.Except(existingUser.Claims!).ToList();


        foreach (var claim in newClaims)
        {
            existingUser.Claims!.Add(claim);
        }

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<UserClaimAddBulkCommandResult>(new UserClaimAddBulkCommandResult());
    }
}
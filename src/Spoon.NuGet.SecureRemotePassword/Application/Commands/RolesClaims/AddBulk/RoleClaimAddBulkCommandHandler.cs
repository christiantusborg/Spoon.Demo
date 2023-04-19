namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.RolesClaims.AddBulk;

using Core.Domain;
using Domain.Entities;
using Domain.Repositories;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class RoleClaimAddBulkCommandHandler : IRequestHandler<RoleClaimAddBulkCommand, Either<RoleClaimAddBulkCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public RoleClaimAddBulkCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<RoleClaimAddBulkCommandResult>> Handle(
        RoleClaimAddBulkCommand request,
        CancellationToken cancellationToken)
    {
        var roleFilters = new List<Filter>
        {
            new ()
            {
                Operation = Operation.Equals,
                Value = request.RoleId,
                PropertyName = "RoleId",
            },
        };

        var existingRole = await this._repository.Roles.GetAsync(new GetRoleSpecification(roleFilters), cancellationToken);

        if (existingRole is null)
            return EitherHelper<RoleClaimAddBulkCommandResult>.EntityNotFound(typeof(Role));


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

        var newClaims = existingClaims.Except(existingRole.Claims).ToList();


        foreach (var claim in newClaims)
        {
            existingRole.Claims.Add(claim);
        }

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<RoleClaimAddBulkCommandResult>(new RoleClaimAddBulkCommandResult());
    }
}
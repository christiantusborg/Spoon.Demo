// ReSharper disable ClassNeverInstantiated.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Claim.GetAll;

using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ClaimGetAllCommandHandler : IRequestHandler<ClaimGetAllCommand, Either<ClaimGetAllCommandUserCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public ClaimGetAllCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<ClaimGetAllCommandUserCommandResult>> Handle(
        ClaimGetAllCommand request,
        CancellationToken cancellationToken)
    {
        var claims = await this._repository.Claims.SearchAsync(
            new DefaultSearchSpecification<Claim>(request.Filters.ToList(), request.SortField.ToList(), request.Skip, request.Take, request.IncludeDeleted), cancellationToken);

        if (claims.Count == 0)
            return EitherHelper<ClaimGetAllCommandUserCommandResult>.EntityNotFound(typeof(Claim));

        return new Either<ClaimGetAllCommandUserCommandResult>(new ClaimGetAllCommandUserCommandResult
        {
            Claims = claims,
        });
    }
}
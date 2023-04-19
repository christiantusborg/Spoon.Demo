namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.SharedSpecification;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class GetEmailByHashSpecification. This class cannot be inherited.
/// </summary>
public class GetWhereContainsClaimIdContainsSpecification : Specification<Claim>
{
    /// <inheritdoc />
    public GetWhereContainsClaimIdContainsSpecification(List<Filter> filters)
    {
        this.AddFilters(filters);


        this.AddSkip(0);
        this.AddTake(int.MaxValue);
    }
}
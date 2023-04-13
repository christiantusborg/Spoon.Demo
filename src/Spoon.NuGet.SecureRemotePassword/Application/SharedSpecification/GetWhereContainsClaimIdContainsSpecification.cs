namespace Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification;

using Spoon.NuGet.Core.Domain;
using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

/// <summary>
///   Class GetEmailByHashSpecification. This class cannot be inherited.
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
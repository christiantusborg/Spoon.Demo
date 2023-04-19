namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.SharedSpecification;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class GetEmailByHashSpecification. This class cannot be inherited.
/// </summary>
public class GetUserWithClaimsSpecification : Specification<User>
{
    /// <inheritdoc />
    public GetUserWithClaimsSpecification(List<Filter> filters)
    {
        this.AddFilters(filters);

        this.AddInclude(x => x.Claims);

        this.AddSkip(0);
        this.AddTake(int.MaxValue);
    }
}
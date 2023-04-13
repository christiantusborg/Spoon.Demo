namespace Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification;

using Spoon.NuGet.Core.Domain;
using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

/// <summary>
///     Class GetEmailByHashSpecification. This class cannot be inherited.
/// </summary>
public class GetRoleSpecification : Specification<Role>
{
    /// <inheritdoc />
    public GetRoleSpecification(List<Filter> filters)
    {
        this.AddFilters(filters);
        
        this.AddInclude(x => x.Claims);
        
        this.AddSkip(0);
        this.AddTake(int.MaxValue);
    }
}
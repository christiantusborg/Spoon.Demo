namespace Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class GetEmailByHashSpecification. This class cannot be inherited.
/// </summary>
public class GetWhereContainsRoleIdContainsSpecification : Specification<Role>
{
    /// <inheritdoc />
    public GetWhereContainsRoleIdContainsSpecification(List<Filter> filters)
    {
        this.AddFilters(filters);
        
        
        this.AddSkip(0);
        this.AddTake(int.MaxValue);
    }
}
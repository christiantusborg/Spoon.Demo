namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.SharedSpecification;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class GetEmailByHashSpecification. This class cannot be inherited.
/// </summary>
public class GetUserWithCRolesSpecification : Specification<User>
{
    /// <inheritdoc />
    public GetUserWithCRolesSpecification(List<Filter> filters)
    {
        this.AddFilters(filters);

        this.AddInclude(x => x.Roles);

        this.AddSkip(0);
        this.AddTake(int.MaxValue);
    }
}
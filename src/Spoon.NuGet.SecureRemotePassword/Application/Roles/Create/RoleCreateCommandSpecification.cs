namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Create;

using Domain.Entities;
using Spoon.NuGet.Core.Domain;

/// <summary>
///  
/// </summary>
public class RoleCreateCommandSpecification : Specification<Role>
{
    /// <inheritdoc />
    public RoleCreateCommandSpecification(string roleName)
    {

        var filters = new List<Filter>
        {
            new Filter
            {
                Operation = Operation.Equals,
                Value = roleName,
                PropertyName = "Name",
            }
        };
        this.AddFilters(filters);

        this.AddSkip(0);

        this.AddTake(1);
    }
}
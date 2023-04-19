namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Create;

using Core.Domain;
using Domain.Entities;

/// <summary>
/// </summary>
public class RoleCreateCommandSpecification : Specification<Role>
{
    /// <inheritdoc />
    public RoleCreateCommandSpecification(string roleName)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = roleName,
                PropertyName = "Name",
            },
        };
        this.AddFilters(filters);

        this.AddSkip(0);

        this.AddTake(1);
    }
}
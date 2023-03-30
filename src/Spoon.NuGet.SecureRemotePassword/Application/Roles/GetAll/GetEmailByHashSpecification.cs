namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll;

using Spoon.NuGet.Core.Domain;
using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

public class RoleGetAllCommandSpecification :  Specification<Role>
{
/// <inheritdoc />
public RoleGetAllCommandSpecification()
{
    this.AddSkip(0);

    this.AddTake(9999);
}
}


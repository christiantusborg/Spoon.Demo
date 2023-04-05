namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

public class RoleRepository : RootRepository<Role>, IRoleRepository
{
    // No need to implement anything here as RoleRepository
    // already inherits all the required methods and properties from RootRepository.
    public RoleRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
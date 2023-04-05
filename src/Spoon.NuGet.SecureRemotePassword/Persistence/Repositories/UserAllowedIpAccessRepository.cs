namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserAllowedIpAccessRepository : RootRepository<UserAllowedIpAccess>, IUserAllowedIpAccessRepository
{
    // No need to implement anything here as ClaimRepository
    // already inherits all the required methods and properties from RootRepository.
    public UserAllowedIpAccessRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
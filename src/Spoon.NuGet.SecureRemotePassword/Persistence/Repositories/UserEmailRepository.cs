namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserEmailRepository : RootRepository<UserEmail>, IUserEmailRepository
{
    // No need to implement anything here as ClaimRepository
    // already inherits all the required methods and properties from RootRepository.
    public UserEmailRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
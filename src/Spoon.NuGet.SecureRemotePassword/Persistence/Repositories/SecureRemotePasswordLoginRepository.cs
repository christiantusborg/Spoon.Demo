namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class SecureRemotePasswordLoginRepository. This class cannot be inherited.
/// </summary>
public class SecureRemotePasswordLoginRepository : RootRepository<SecureRemotePasswordLogin>, ISecureRemotePasswordLoginRepository
{
    // No need to implement anything here as ClaimRepository
    // already inherits all the required methods and properties from RootRepository.
    /// <summary>
    /// Initializes a new instance of the <see cref="SecureRemotePasswordLoginRepository"/> class.
    /// </summary>
    /// <param name="dbContext"></param>
    public SecureRemotePasswordLoginRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class SecureRemotePasswordByRecoveryEmailRepository. This class cannot be inherited.
/// </summary>
public class SecureRemotePasswordByRecoveryEmailRepository : RootRepository<SecureRemotePasswordByRecoveryEmail>, ISecureRemotePasswordByRecoveryEmailRepository
{
    // No need to implement anything here as ClaimRepository
    // already inherits all the required methods and properties from RootRepository.
    /// <summary>
    ///  Initializes a new instance of the <see cref="SecureRemotePasswordByRecoveryEmailRepository"/> class.
    /// </summary>
    /// <param name="dbContext"></param>
    public SecureRemotePasswordByRecoveryEmailRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
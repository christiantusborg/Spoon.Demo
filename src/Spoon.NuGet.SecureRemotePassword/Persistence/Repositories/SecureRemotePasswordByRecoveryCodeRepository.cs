namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

/// <summary>
///  Class SecureRemotePasswordByRecoveryCodeRepository. This class cannot be inherited.
/// </summary>
public class SecureRemotePasswordByRecoveryCodeRepository : RootRepository<SecureRemotePasswordByRecoveryCode>, ISecureRemotePasswordByRecoveryCodeRepository
{
    // No need to implement anything here as SecureRemotePasswordByRecoveryCodeRepository
    // already inherits all the required methods and properties from RootRepository.
    /// <summary>
    /// Initializes a new instance of the <see cref="SecureRemotePasswordByRecoveryCodeRepository"/> class.
    /// </summary>
    /// <param name="dbContext"></param>
    public SecureRemotePasswordByRecoveryCodeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

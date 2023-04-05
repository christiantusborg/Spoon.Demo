namespace Spoon.NuGet.SecureRemotePassword.Persistence.Repositories;

using Core.Domain;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.EntityFrameworkCore;

public class SecureRemotePasswordByRecoveryCodeRepository : RootRepository<SecureRemotePasswordByRecoveryCode>, ISecureRemotePasswordByRecoveryCodeRepository
{
    // No need to implement anything here as SecureRemotePasswordByRecoveryCodeRepository
    // already inherits all the required methods and properties from RootRepository.
    public SecureRemotePasswordByRecoveryCodeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

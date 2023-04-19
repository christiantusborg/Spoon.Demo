namespace Spoon.Demo.Persistence.Repositories;

using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using NuGet.Core.Domain;

/// <summary>
/// Class ProductRepository.
/// </summary>
/// <seealso cref="IRepositoryRepository" />
public class RepositoryRepository : RootRepository<Product>, IRepositoryRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public RepositoryRepository(DbContext dbContext)
        : base(dbContext)
    {
    }
}
namespace Spoon.Demo.Persistence.Repositories;

using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using NuGet.Core.Domain;

/// <summary>
/// Class ProductRepository.
/// </summary>
/// <seealso cref="IProductRepository" />
public class ProductRepository : RootRepository<Product>, IProductRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public ProductRepository(DbContext dbContext)
        : base(dbContext)
    {
    }
}
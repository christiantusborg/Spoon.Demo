namespace Spoon.Demo.Persistence.Contexts;

using Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NuGet.SecureRemotePassword;

public class DemoContext : DbContext
{
    public DbSet<Color> Colors { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FeatureType> FeatureTypes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Size> Sizes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblePersistence).Assembly);

    }
}
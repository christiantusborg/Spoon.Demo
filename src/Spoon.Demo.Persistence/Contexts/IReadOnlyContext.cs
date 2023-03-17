namespace Spoon.Demo.Persistence.Contexts
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public interface IReadOnlyContext
    {
        /// <summary>
        /// 
        /// </summary>
        DbSet<Product>? Products { get; set; }
    }
}
namespace Spoon.Demo.Persistence.Contexts
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public class WriteContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public WriteContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "server=mysql88.unoeuro.com;uid=sager_sft_dk;pwd=6rxpecBgDwAk;database=sager_sft_dk_db",
                    ServerVersion.Parse("5.7.29-mysql"));
            }
        }


        /// <summary>
        /// </summary>
        public virtual DbSet<Product>? Products { get; set; }
    }
}
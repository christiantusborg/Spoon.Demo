namespace Spoon.Demo.Domain.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWriteRepository
    {
        /// <inheritdoc cref="IWriteRepository" />
        public IProductRepository Products { get; set; }

        /// <inheritdoc cref="IWriteRepository" />
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
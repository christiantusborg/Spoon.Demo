namespace Spoon.Demo.Domain.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReadOnlyRepository
    {
        /// <inheritdoc cref="IReadOnlyRepository" />
        public IProductRepository Products { get; set; }

        /// <inheritdoc cref="IReadOnlyRepository" />
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
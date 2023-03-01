namespace Spoon.Demo.Persistence.Repositories
{
    using Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public class WriteRepository : IWriteRepository
    {
        private readonly DbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public WriteRepository(DbContext context)
        {
            this._context = context;
            this.Products = new ProductRepository(this._context);
        }

        /// <summary>
        /// </summary>
        public IProductRepository Products { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task SaveChanges(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
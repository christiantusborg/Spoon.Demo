namespace Spoon.Demo.Persistence.Repositories;

using Domain.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    public IAddressesRepository Addresses { get; }
    public ICategoryRepository Categories { get; }
    public IColorRepository Colors { get; }
    public IContactRepository Contacts { get; }
    public ICustomerRepository Customers { get; }
    public ICustomerTypeRepository CustomerTypes { get; }
    public IFeatureRepository Features { get; }
    public IFeatureTypeRepository FeatureTypes { get; }
    public IGenderRepository Gender { get; }
    public INoteRepository Notes { get; }
    public IOrderItemRepository OrderItems { get; }
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    public IProductImageRepository ProductImages { get; }
    public ISizeRepository Sizes { get; }
    public ISupplierRepository Suppliers { get; }
    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
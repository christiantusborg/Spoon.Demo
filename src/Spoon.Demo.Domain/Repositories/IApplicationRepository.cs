namespace Spoon.Demo.Domain.Repositories;

public class IApplicationRepository
{
    public IAddressesRepository Addresses { get; }
    public IProductRepository Products { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
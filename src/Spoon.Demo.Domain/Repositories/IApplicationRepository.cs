namespace Spoon.Demo.Domain.Repositories;

public class IApplicationRepository
{
    public IAddressesRepository Addresses { get; }
    public IRepositoryRepository Products { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
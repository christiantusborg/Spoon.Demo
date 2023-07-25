﻿namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeCreateCommandV1Handler : IRequestHandler<CustomerTypeCreateCommandV1, Either<CustomerTypeCreateCommandV1Result>>
{
    private readonly ICustomerTypeRepository _repository;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeCreateCommandV1Handler" /> class.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="mockbleDateTime"></param>
    public CustomerTypeCreateCommandV1Handler(IApplicationRepository repository, IMockbleGuidGenerator mockbleGuidGenerator, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.CustomerTypes;
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Either<CustomerTypeCreateCommandV1Result>> Handle(
        CustomerTypeCreateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getByNameSpecification = new GetByNameSpecification<CustomerType>(request.Name);

        var existing = await this._repository.GetAsync(getByNameSpecification, cancellationToken);

        if (existing is not null)
            return EitherHelper<CustomerTypeCreateCommandV1Result>.EntityAlreadyExists(typeof(CustomerTypeCreateCommandV1));

        var newId = this._mockbleGuidGenerator.NewId();

        var next = new CustomerType
        {
            Name = request.Name,
            Description = request.Description,
            CustomerTypeId = newId,
            CreatedAt = this._mockbleDateTime.UtcNow,
            ModifiedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        this._repository.Add(next);

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new CustomerTypeCreateCommandV1Result
        {
            ColorId = newId,
        };

        return new Either<CustomerTypeCreateCommandV1Result>(result);
    }
}
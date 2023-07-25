#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Command;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CustomerTypeCreateCommandV1 : MediatorBaseCommand, IHandleableRequest<CustomerTypeCreateCommandV1, CustomerTypeCreateCommandV1Handler, Either<CustomerTypeCreateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeCreateCommandV1" /> class.
    ///     Handled by <see cref="CustomerTypeCreateCommandV1Handler" /> class.
    /// </summary>
    public CustomerTypeCreateCommandV1() : base(typeof(CustomerTypeCreateCommandV1))
    {
    }

    /// <inheritdoc cref="CustomerTypeCreateCommandV1" />
    public required string Name { get; init; }

    /// <inheritdoc cref="CustomerTypeCreateCommandV1" />
    public required string Description { get; init; }
}
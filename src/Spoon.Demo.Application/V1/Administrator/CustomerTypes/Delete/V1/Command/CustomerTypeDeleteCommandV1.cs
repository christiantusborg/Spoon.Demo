namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Delete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CustomerTypeDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<CustomerTypeDeleteCommandV1,
    CustomerTypeDeleteCommandV1Handler,
    Either<CustomerTypeDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeDeleteCommandV1" /> class.
    /// </summary>
    public CustomerTypeDeleteCommandV1()
        : base(typeof(CustomerTypeDeleteCommandV1))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public required Guid CustomerTypeId { get; set; }
}
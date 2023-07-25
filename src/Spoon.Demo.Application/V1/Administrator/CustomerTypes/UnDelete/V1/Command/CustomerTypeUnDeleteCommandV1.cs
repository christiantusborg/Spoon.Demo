namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.UnDelete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CustomerTypeUnDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<CustomerTypeUnDeleteCommandV1,
    CustomerTypeUnDeleteCommandV1Handler,
    Either<CustomerTypeUnDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeUnDeleteCommandV1" /> class.
    /// </summary>
    public CustomerTypeUnDeleteCommandV1()
        : base(typeof(CustomerTypeUnDeleteCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />

    public Guid CustomerTypeId { get; set; }
}
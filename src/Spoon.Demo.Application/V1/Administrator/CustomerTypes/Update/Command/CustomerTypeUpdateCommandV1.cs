#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Update.Command;

/// <summary>
///     Class ProductUpdateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CustomerTypeUpdateCommandV1 : MediatorBaseCommand, IHandleableRequest<CustomerTypeUpdateCommandV1,
    CustomerTypeUpdateCommandV1Handler,
    Either<CustomerTypeUpdateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeUpdateCommandV1" /> class.
    /// </summary>
    public CustomerTypeUpdateCommandV1()
        : base(typeof(CustomerTypeUpdateCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid CustomerTypeId { get; init; }

    /// <inheritdoc cref="CustomerTypeUpdateCommandV1" />
    public string? Name { get; init; }

    /// <inheritdoc cref="CustomerTypeUpdateCommandV1" />
    public string? Description { get; init; }

}
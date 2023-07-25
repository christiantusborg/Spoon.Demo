namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Get.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CustomerTypeGetCommandV1 : MediatorBaseCommand, IHandleableRequest<CustomerTypeGetCommandV1,
    CustomerTypeGetCommandV1Handler, Either<CustomerTypeGetCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeGetCommandV1" /> class.
    /// </summary>
    public CustomerTypeGetCommandV1()
        : base(typeof(CustomerTypeGetCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid CustomerTypeId { get; set; }

}
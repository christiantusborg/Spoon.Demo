namespace Spoon.Demo.Application.V1.Administrator.Addresses.Get.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AddressGetCommandV1 : MediatorBaseCommand, IHandleableRequest<AddressGetCommandV1,
    AddressGetCommandV1Handler, Either<AddressGetCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressGetCommandV1" /> class.
    /// </summary>
    public AddressGetCommandV1()
        : base(typeof(AddressGetCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid AddressId { get; set; }

}
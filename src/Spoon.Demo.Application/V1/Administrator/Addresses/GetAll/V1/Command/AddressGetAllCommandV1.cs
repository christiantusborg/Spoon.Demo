namespace Spoon.Demo.Application.V1.Administrator.Addresses.GetAll.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
/// </summary>
public sealed class AddressGetAllCommandV1 : MediatorBaseCommandSearch, IHandleableRequest<AddressGetAllCommandV1,
    AddressGetAllCommandV1Handler, Either<BaseSearchCommandResult<AddressGetAllCommandV1Result>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressGetAllCommandV1" /> class.
    /// </summary>
    public AddressGetAllCommandV1()
        : base(typeof(AddressGetAllCommandV1))
    {
    }
}
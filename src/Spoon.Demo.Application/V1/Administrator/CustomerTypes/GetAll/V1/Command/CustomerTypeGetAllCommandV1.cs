namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.GetAll.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeGetAllCommandV1 : MediatorBaseCommandSearch, IHandleableRequest<CustomerTypeGetAllCommandV1,
    CustomerTypeGetAllCommandV1Handler, Either<BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerTypeGetAllCommandV1" /> class.
    /// </summary>
    public CustomerTypeGetAllCommandV1()
        : base(typeof(CustomerTypeGetAllCommandV1))
    {
    }
}
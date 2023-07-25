namespace Spoon.Demo.Application.V1.Administrator.Contacts.GetAll.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
/// </summary>
public sealed class ContactGetAllCommandV1 : MediatorBaseCommandSearch, IHandleableRequest<ContactGetAllCommandV1,
    ContactGetAllCommandV1Handler, Either<BaseSearchCommandResult<ContactGetAllCommandV1Result>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactGetAllCommandV1" /> class.
    /// </summary>
    public ContactGetAllCommandV1()
        : base(typeof(ContactGetAllCommandV1))
    {
    }
}
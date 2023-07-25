namespace Spoon.Demo.Application.V1.Administrator.Contacts.Get.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ContactGetCommandV1 : MediatorBaseCommand, IHandleableRequest<ContactGetCommandV1,
    ContactGetCommandV1Handler, Either<ContactGetCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactGetCommandV1" /> class.
    /// </summary>
    public ContactGetCommandV1()
        : base(typeof(ContactGetCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid ContactId { get; set; }

}
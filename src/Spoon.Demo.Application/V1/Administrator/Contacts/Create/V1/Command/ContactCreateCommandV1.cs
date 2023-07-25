#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Command;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ContactCreateCommandV1 : MediatorBaseCommand, IHandleableRequest<ContactCreateCommandV1, ContactCreateCommandV1Handler, Either<ContactCreateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ContactCreateCommandV1" /> class.
    ///     Handled by <see>
    ///         <cref>ContactCreateCommandV1Handler</cref>
    ///     </see>
    ///     class.
    /// </summary>
    public ContactCreateCommandV1() : base(typeof(ContactCreateCommandV1))
    {
    }

    /// <inheritdoc cref="ContactCreateCommandV1" />
    public string Email { get; set; }
    /// <inheritdoc cref="ContactCreateCommandV1" />
    public string Mobil { get; set; }
    /// <inheritdoc cref="ContactCreateCommandV1" />
    public string Name { get; set; }
    /// <inheritdoc cref="ContactCreateCommandV1" />
    public string Phone { get; set; }
    /// <inheritdoc cref="ContactCreateCommandV1" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="ContactCreateCommandV1" />
    public bool NewsLetterSignupDate { get; set; }
}
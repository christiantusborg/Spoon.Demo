namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Endpoint;

/// <summary>
///    Represents the request to create a category.
/// </summary>
public class ContactCreateEndpointV1Request 
{
    /// <inheritdoc cref="ContactCreateEndpointV1Request" />
    public required string Email { get; set; }
    /// <inheritdoc cref="ContactCreateEndpointV1Request" />
    public required string Mobil { get; set; }
    /// <inheritdoc cref="ContactCreateEndpointV1Request" />
    public required string Name { get; set; }
    /// <inheritdoc cref="ContactCreateEndpointV1Request" />
    public required string Phone { get; set; }
    /// <inheritdoc cref="ContactCreateEndpointV1Request" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="ContactCreateEndpointV1Request" />
    public bool NewsLetterSignupDate { get; set; }
}
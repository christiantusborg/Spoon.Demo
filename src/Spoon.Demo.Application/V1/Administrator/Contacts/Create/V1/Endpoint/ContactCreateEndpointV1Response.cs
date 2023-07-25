namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Endpoint;

/// <summary>
///  Represents the response to create a Contact.
/// </summary>
public class ContactCreateEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the Contact identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Guid ContactId { get; init; }
}
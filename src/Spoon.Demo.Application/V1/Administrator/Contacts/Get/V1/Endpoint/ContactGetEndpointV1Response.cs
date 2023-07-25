namespace Spoon.Demo.Application.V1.Administrator.Contacts.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a Contact.
/// </summary>
public class ContactGetEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the Contact identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public required Guid ContactId { get; init; }
}
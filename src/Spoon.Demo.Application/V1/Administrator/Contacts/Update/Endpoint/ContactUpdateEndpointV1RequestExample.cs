namespace Spoon.Demo.Application.V1.Administrator.Contacts.Update.Endpoint;

/// <summary>
///  Represents the request to create a Color.
/// </summary>
public sealed class ContactUpdateEndpointV1RequestExample : IExamplesProvider<ContactUpdateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ContactUpdateEndpointV1Request GetExamples()
    {
        return new ContactUpdateEndpointV1Request
        {
            Name = "Color name",
            Description = "Color description",
        };
    }
}
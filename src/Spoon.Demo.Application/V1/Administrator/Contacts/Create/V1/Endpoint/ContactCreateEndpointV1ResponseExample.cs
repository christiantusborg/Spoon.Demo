namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Endpoint;

/// <summary>
///  Represents the response to create a Contact.
/// </summary>
public class ContactCreateEndpointV1ResponseExample: IExamplesProvider<ContactCreateEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ContactCreateEndpointV1Response GetExamples()
    {
        return new ContactCreateEndpointV1Response
        {
            ContactId = EndpointExample.ExampleGuid,
        };
    }
}
namespace Spoon.Demo.Application.V1.Administrator.Contacts.GetAll.V1.Endpoint;

/// <summary>
///  Represents the response to create a Contact.
/// </summary>
public class ContactGetAllEndpointV1ResponseExample: IExamplesProvider<ContactGetAllEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ContactGetAllEndpointV1Response GetExamples()
    {
        return new ContactGetAllEndpointV1Response
        {
            ContactId = EndpointExample.ExampleGuid,
        };
    }
}
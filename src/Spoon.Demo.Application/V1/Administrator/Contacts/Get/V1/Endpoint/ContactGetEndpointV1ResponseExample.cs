namespace Spoon.Demo.Application.V1.Administrator.Contacts.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a Contact.
/// </summary>
public class ContactGetEndpointV1ResponseExample: IExamplesProvider<ContactGetEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ContactGetEndpointV1Response GetExamples()
    {
        return new ContactGetEndpointV1Response
        {
            ContactId = EndpointExample.ExampleGuid,
        };
    }
}
namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Endpoint;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class ContactCreateEndpointV1RequestExample : IExamplesProvider<ContactCreateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ContactCreateEndpointV1Request GetExamples()
    {
        return new ContactCreateEndpointV1Request
        {
            Name = "Category name",
            Email = "Email",
            Mobil = "Mobil",
            Phone = "Phone",
            CustomerId = EndpointExample.ExampleGuid,
            NewsLetterSignupDate = true,
        };
    }
}
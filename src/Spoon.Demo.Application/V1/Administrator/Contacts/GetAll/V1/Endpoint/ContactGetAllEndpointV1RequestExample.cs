namespace Spoon.Demo.Application.V1.Administrator.Contacts.GetAll.V1.Endpoint;

using Spoon.NuGet.Core.Domain;

/// <summary>
///  Represents the request to create a Contact.
/// </summary>
public sealed class ContactGetAllEndpointV1RequestExample : IExamplesProvider<ContactGetAllEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ContactGetAllEndpointV1Request GetExamples()
    {
        return new ContactGetAllEndpointV1Request
        {
           Filters = new List<Filter>
           {
               new Filter
               {
                   Operation = Operation.Contains,
                   Value = "Name",
                   PropertyName = "TheValue",
               },
           },
           Page = 1,
           PageLength = 10,
           SortField = new List<Sorting>
           {
               new Sorting
               {
                   Direction = SortDirection.Ascending,
                   SortField = "Name",
               },
           },
           IncludeDeletedSoft = false,
        };
    }
}
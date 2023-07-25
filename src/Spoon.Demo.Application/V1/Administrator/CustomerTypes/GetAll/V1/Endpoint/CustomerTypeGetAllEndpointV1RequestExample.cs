namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.GetAll.V1.Endpoint;

using Spoon.NuGet.Core.Domain;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class CustomerTypeGetAllEndpointV1RequestExample : IExamplesProvider<CustomerTypeGetAllEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CustomerTypeGetAllEndpointV1Request GetExamples()
    {
        return new CustomerTypeGetAllEndpointV1Request
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
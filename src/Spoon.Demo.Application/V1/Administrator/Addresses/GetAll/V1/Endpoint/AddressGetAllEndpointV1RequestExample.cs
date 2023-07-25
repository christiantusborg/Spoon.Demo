namespace Spoon.Demo.Application.V1.Administrator.Addresses.GetAll.V1.Endpoint;

using Spoon.NuGet.Core.Domain;

/// <summary>
///  Represents the request to create a Address.
/// </summary>
public sealed class AddressGetAllEndpointV1RequestExample : IExamplesProvider<AddressGetAllEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public AddressGetAllEndpointV1Request GetExamples()
    {
        return new AddressGetAllEndpointV1Request
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
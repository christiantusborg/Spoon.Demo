namespace Spoon.Demo.Application.V1.Administrator.Categories.GetAll.V1.Endpoint;

using NuGet.Core.Domain;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class CategoryGetAllEndpointV1RequestExample : IExamplesProvider<CategoryGetAllEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CategoryGetAllEndpointV1Request GetExamples()
    {
        return new CategoryGetAllEndpointV1Request
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
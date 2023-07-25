namespace Spoon.Demo.Application.V1.Administrator.Colors.GetAll.V1.Endpoint;

using NuGet.Core.Domain;

/// <summary>
///  Represents the request to create a Color.
/// </summary>
public sealed class ColorGetAllEndpointV1RequestExample : IExamplesProvider<ColorGetAllEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ColorGetAllEndpointV1Request GetExamples()
    {
        return new ColorGetAllEndpointV1Request
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
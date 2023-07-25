namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Endpoint;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class ColorCreateEndpointV1RequestExample : IExamplesProvider<ColorCreateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ColorCreateEndpointV1Request GetExamples()
    {
        return new ColorCreateEndpointV1Request
        {
            Name = "Category name",
            Description = "Category description",
            Discount = 10,
            ProfitMargin = 10,
        };
    }
}
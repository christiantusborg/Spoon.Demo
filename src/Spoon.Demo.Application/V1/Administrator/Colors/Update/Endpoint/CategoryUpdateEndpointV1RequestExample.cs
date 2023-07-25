namespace Spoon.Demo.Application.V1.Administrator.Colors.Update.Endpoint;

/// <summary>
///  Represents the request to create a Color.
/// </summary>
public sealed class ColorUpdateEndpointV1RequestExample : IExamplesProvider<ColorUpdateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ColorUpdateEndpointV1Request GetExamples()
    {
        return new ColorUpdateEndpointV1Request
        {
            Name = "Color name",
            Description = "Color description",
        };
    }
}
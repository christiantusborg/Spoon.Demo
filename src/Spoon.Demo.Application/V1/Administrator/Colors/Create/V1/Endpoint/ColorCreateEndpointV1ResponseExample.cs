namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Endpoint;

/// <summary>
///  Represents the response to create a Color.
/// </summary>
public class ColorCreateEndpointV1ResponseExample: IExamplesProvider<ColorCreateEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ColorCreateEndpointV1Response GetExamples()
    {
        return new ColorCreateEndpointV1Response
        {
            ColorId = EndpointExample.ExampleGuid,
        };
    }
}
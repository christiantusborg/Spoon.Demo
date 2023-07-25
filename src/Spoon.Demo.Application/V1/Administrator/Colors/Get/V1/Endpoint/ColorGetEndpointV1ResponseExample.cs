namespace Spoon.Demo.Application.V1.Administrator.Colors.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a Color.
/// </summary>
public class ColorGetEndpointV1ResponseExample: IExamplesProvider<ColorGetEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ColorGetEndpointV1Response GetExamples()
    {
        return new ColorGetEndpointV1Response
        {
            ColorId = EndpointExample.ExampleGuid,
        };
    }
}
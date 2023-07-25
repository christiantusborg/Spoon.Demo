namespace Spoon.Demo.Application.V1.Administrator.Colors.GetAll.V1.Endpoint;

/// <summary>
///  Represents the response to create a Color.
/// </summary>
public class ColorGetAllEndpointV1ResponseExample: IExamplesProvider<ColorGetAllEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public ColorGetAllEndpointV1Response GetExamples()
    {
        return new ColorGetAllEndpointV1Response
        {
            ColorId = EndpointExample.ExampleGuid,
        };
    }
}
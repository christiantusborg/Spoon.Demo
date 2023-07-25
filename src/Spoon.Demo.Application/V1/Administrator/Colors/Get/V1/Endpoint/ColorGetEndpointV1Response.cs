namespace Spoon.Demo.Application.V1.Administrator.Colors.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a Color.
/// </summary>
public class ColorGetEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the Color identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public required Guid ColorId { get; init; }
}
namespace Spoon.Demo.Application.V1.Administrator.Colors.Update.Endpoint;

/// <summary>
///    Represents the request to create a Color.
/// </summary>
public class ColorUpdateEndpointV1Request 
{
    /// <inheritdoc cref="ColorUpdateEndpointV1Request" />
    public string? Name { get; init; }

    /// <inheritdoc cref="ColorUpdateEndpointV1Request" />
    public string? Description { get; init; }


}
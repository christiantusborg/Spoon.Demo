namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Endpoint;

/// <summary>
///    Represents the request to create a category.
/// </summary>
public class ColorCreateEndpointV1Request 
{
    /// <inheritdoc cref="ColorCreateEndpointV1Request" />
    public required string Name { get; init; }

    /// <inheritdoc cref="ColorCreateEndpointV1Request" />
    public required string Description { get; init; }

    /// <inheritdoc cref="ColorCreateEndpointV1Request" />
    public int Discount { get; init; }

    /// <inheritdoc cref="ColorCreateEndpointV1Request" />
    public int ProfitMargin { get; init; }
}
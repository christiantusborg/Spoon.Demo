namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Endpoint;

/// <summary>
///    Represents the request to create a category.
/// </summary>
public class CustomerTypeCreateEndpointV1Request 
{
    /// <inheritdoc cref="CustomerTypeCreateEndpointV1Request" />
    public required string Name { get; init; }

    /// <inheritdoc cref="CustomerTypeCreateEndpointV1Request" />
    public required string Description { get; init; }
}
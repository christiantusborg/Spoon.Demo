namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Endpoint;

using System.Text.Json.Serialization;

/// <summary>
///    Represents the request to create a category.
/// </summary>
public class CategoryCreateEndpointV1Request 
{
    /// <inheritdoc cref="CategoryCreateEndpointV1Request" />
    public required string Name { get; init; }

    /// <inheritdoc cref="CategoryCreateEndpointV1Request" />
    public required string Description { get; init; }

    /// <inheritdoc cref="CategoryCreateEndpointV1Request" />
    public int Discount { get; init; }

    /// <inheritdoc cref="CategoryCreateEndpointV1Request" />
    public int ProfitMargin { get; init; }
}
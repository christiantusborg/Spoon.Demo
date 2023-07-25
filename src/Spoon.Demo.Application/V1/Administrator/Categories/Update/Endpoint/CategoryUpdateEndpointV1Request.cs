namespace Spoon.Demo.Application.V1.Administrator.Categories.Update.Endpoint;

/// <summary>
///    Represents the request to create a category.
/// </summary>
public class CategoryUpdateEndpointV1Request 
{
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public string? Name { get; init; }

    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public string? Description { get; init; }

    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public int? Discount { get; init; }

    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public int? ProfitMargin { get; init; }
}
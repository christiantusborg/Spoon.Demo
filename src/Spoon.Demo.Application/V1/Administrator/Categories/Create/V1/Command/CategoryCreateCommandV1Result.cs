namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Command
{
    /// <summary>
    ///     Category create command V1 Result. This class cannot be inherited. Used for result from <see cref="CategoryCreateCommandV1Handler" /> class handling command <see cref="CategoryCreateCommandV1" />.
    /// </summary>
    public sealed class CategoryCreateCommandV1Result
    {
        /// <inheritdoc cref="CategoryCreateCommandV1" />
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public required Guid CategoryId { get; init; }
    }
}
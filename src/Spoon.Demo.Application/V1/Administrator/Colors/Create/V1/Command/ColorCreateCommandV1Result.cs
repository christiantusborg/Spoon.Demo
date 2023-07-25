namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Command
{
    /// <summary>
    ///     Category create command V1 Result. This class cannot be inherited. Used for result from <see cref="ColorCreateCommandV1Handler" /> class handling command <see cref="ColorCreateCommandV1" />.
    /// </summary>
    public sealed class ColorCreateCommandV1Result
    {
        /// <inheritdoc cref="ColorCreateCommandV1" />
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public required Guid ColorId { get; init; }
    }
}
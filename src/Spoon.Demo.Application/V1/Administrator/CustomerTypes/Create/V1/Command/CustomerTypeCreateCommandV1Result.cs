namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Command
{
    /// <summary>
    ///     Category create command V1 Result. This class cannot be inherited. Used for result from <see cref="CustomerTypeCreateCommandV1Handler" /> class handling command <see cref="CustomerTypeCreateCommandV1" />.
    /// </summary>
    public sealed class CustomerTypeCreateCommandV1Result
    {
        /// <inheritdoc cref="CustomerTypeCreateCommandV1" />
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public required Guid ColorId { get; init; }
    }
}
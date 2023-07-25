namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Command
{
    /// <summary>
    ///     Address create command V1 Result. This class cannot be inherited. Used for result from <see cref="AddressCreateCommandV1Handler" /> class handling command <see cref="AddressCreateCommandV1" />.
    /// </summary>
    public sealed class AddressCreateCommandV1Result
    {
        /// <inheritdoc cref="AddressCreateCommandV1" />
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public required Guid AddressId { get; init; }
    }
}
namespace Spoon.Demo.Application.V1.Administrator.Contacts.Create.V1.Command
{
    /// <summary>
    ///     Category create command V1 Result. This class cannot be inherited. Used for result from <see>
    ///         <cref>ContactCreateCommandV1Handler</cref>
    ///     </see>
    ///     class handling command <see cref="ContactCreateCommandV1" />.
    /// </summary>
    public sealed class ContactCreateCommandV1Result
    {
        /// <inheritdoc cref="ContactCreateCommandV1" />
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public required Guid ContactId { get; init; }
    }
}
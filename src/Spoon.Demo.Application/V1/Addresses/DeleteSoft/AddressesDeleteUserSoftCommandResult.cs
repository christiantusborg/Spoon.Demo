namespace Spoon.Demo.Application.V1.Addresses.DeleteSoft
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AddressesDeleteUserSoftCommandResult
    {
        /// <inheritdoc cref="AddressesDeleteUserSoftCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AddressesDeleteUserSoftCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AddressesDeleteUserSoftCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}
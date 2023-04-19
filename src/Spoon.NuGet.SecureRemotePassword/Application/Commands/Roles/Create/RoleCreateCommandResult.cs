// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Create
{
    /// <summary>
    /// Represents the result of creating a new role using a <see cref="RoleCreateCommandHandler"/>.
    /// </summary>
    public sealed class RoleCreateCommandResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created role.
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
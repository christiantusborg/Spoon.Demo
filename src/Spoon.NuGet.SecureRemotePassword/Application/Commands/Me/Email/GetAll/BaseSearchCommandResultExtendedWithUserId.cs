// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.GetAll;

using Spoon.NuGet.Core.Application;

/// <summary>
///   Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public class BaseSearchCommandResultExtendedWithUserId<T> : BaseSearchCommandResult<T>
{
    /// <inheritdoc cref="BaseSearchCommandResult{T}"/>
    public Guid UserId { get; set; }
}

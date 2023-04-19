namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.GetAll;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     A specification for retrieving all email addresses associated with a specific user.
/// </summary>
public sealed class MeEmailGetAllCommandSpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public MeEmailGetAllCommandSpecification(Guid userId)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = userId,
                PropertyName = "UserId",
            },
        };

        this.AddFilters(filters);

        this.AddSkip(0);
        this.AddTake(int.MaxValue);
    }
}
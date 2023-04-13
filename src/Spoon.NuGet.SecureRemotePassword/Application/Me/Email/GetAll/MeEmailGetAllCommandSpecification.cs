namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll;

using Domain.Entities;
using Spoon.NuGet.Core.Domain;

/// <summary>
/// A specification for retrieving all email addresses associated with a specific user.
/// </summary>
public sealed class MeEmailGetAllCommandSpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public MeEmailGetAllCommandSpecification(Guid userId)
    {
        var filters = new List<Filter>
        {
            new Filter
            {
                Operation = Operation.Equals,
                Value = userId,
                PropertyName = "UserId",
            }
        };

        this.AddFilters(filters);

        this.AddSkip(0);
        this.AddTake(Int32.MaxValue);
    }
}
namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll;

using Domain.Entities;
using Spoon.NuGet.Core.Domain;

public class MeEmailGetAllCommandSpecification : Specification<UserEmail>
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

        this.AddTake(9999);
    }
}
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.SetAsPrimaryEmail;

using Core.Domain;
using Domain.Entities;

/// <inheritdoc />
public class MeEmailSetAsPrimaryCommandSpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public MeEmailSetAsPrimaryCommandSpecification(Guid userId)
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

        this.AddTake(9999);
    }
}
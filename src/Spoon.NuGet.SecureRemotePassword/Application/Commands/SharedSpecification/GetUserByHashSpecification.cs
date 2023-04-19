namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.SharedSpecification;

using Core.Domain;
using Domain.Entities;

/// <inheritdoc />
public class GetUserByHashSpecification : Specification<User>
{
    /// <inheritdoc />
    public GetUserByHashSpecification(string usernameHash)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = usernameHash,
                PropertyName = "UsernameHash",
            },
        };
        this.AddFilters(filters);


        this.AddSkip(0);

        this.AddTake(1);
    }
}
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.SharedSpecification;

using Core.Domain;
using Domain.Entities;

/// <inheritdoc />
public class GetEmailByHashSpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public GetEmailByHashSpecification(string emailAddressHash)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = emailAddressHash,
                PropertyName = "EmailAddressHash",
            },
        };
        this.AddFilters(filters);


        this.AddSkip(0);

        this.AddTake(1);
    }
}
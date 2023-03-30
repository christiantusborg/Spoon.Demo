namespace Spoon.NuGet.SecureRemotePassword.Application.Me.VerifyChallenge;

using Core.Domain;
using Domain.Entities;

public class GetEmailByHashSpecification :  Specification<UserEmail>
{
/// <inheritdoc />
public GetEmailByHashSpecification(string emailHash)
{
    var filters = new List<Filter>
    {
        new Filter
        {
            Operation = Operation.Equals,
            Value = emailHash,
            PropertyName = "EmailAddressHash",
        }
    };
            
    this.AddFilters(filters);



    this.AddSkip(0);

    this.AddTake(1);
}
}


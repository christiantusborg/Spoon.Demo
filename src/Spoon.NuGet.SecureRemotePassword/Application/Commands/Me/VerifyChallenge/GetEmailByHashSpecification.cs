namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.VerifyChallenge;

using Core.Domain;
using Domain.Entities;

/// <summary>
///     Class GetEmailByHashSpecification. This class cannot be inherited.
/// </summary>
public class GetEmailByHashSpecification : Specification<UserEmail>
{
    /// <inheritdoc />
    public GetEmailByHashSpecification(string emailHash)
    {
        var filters = new List<Filter>
        {
            new()
            {
                Operation = Operation.Equals,
                Value = emailHash,
                PropertyName = "EmailAddressHash",
            },
        };

        this.AddFilters(filters);


        this.AddSkip(0);

        this.AddTake(1);
    }
}
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.RemoveUserEmail
{
    using Spoon.NuGet.Core.Domain;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

    /// <inheritdoc />
    public class GetUserEmailSpecification : Specification<UserEmail>
    {
        /// <inheritdoc />
        public GetUserEmailSpecification(Guid userId, Guid EmailId)
        {
            var filters = new List<Filter>
            {
                new Filter
                {
                    Operation = Operation.Equals,
                    Value = userId,
                    PropertyName = "UserId",
                },
                new Filter
                {
                    Operation = Operation.Equals,
                    Value = EmailId,
                    PropertyName = "EmailId",
                }
            };
            
            this.AddFilters(filters);
            

                this.AddSkip(0);

                this.AddTake(1);
            }
        }
    }
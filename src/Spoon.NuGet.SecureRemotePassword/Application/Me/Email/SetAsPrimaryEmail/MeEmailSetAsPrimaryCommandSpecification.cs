namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.SetAsPrimaryEmail
{
    using Spoon.NuGet.Core.Domain;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

    /// <inheritdoc />
    public class MeEmailSetAsPrimaryCommandSpecification : Specification<UserEmail>
    {
        /// <inheritdoc />
        public MeEmailSetAsPrimaryCommandSpecification(Guid userId)
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
    }
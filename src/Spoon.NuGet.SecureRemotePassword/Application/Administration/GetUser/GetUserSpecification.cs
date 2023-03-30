namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser
{
    using Spoon.NuGet.Core.Domain;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;

    /// <inheritdoc />
    public class GetUserSpecification : Specification<User>
    {
        /// <inheritdoc />
        public GetUserSpecification(Guid userId)
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


                this.AddInclude(x => x.Claims);
                this.AddInclude(x => x.Roles);
                //TODO : Add this to the specification (ThenInclude)    
                //.ThenInclude(x => x.Claims);

                this.AddSkip(0);

                this.AddTake(1);
            }
        }
    }

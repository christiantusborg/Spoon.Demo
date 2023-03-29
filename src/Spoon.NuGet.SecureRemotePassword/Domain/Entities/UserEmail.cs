﻿namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class UserEmail : SignedEntity<UserEmail>
{
    public Guid UserId { get; set; }
    public Guid EmailId { get; set; }
    public string EmailAddressHash { get; set; }
    public string EmailAddressEncrypted { get; set; }
    
    public DateTime? EmailAddressVerifiedAt { get; set; }
    public int IsPrimary { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
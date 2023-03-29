﻿namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class TwoFactorAuthenticationTOTP  : Entity   
{
    public Guid UserId { get; set; }
    public string SecretKeyEncrypted { get; set; }
    public string SignedHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
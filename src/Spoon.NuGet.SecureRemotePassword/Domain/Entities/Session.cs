﻿namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class Session : Entity
{
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
    public string RefreshTokenHash { get; set; }
    public string IpAddressHash { get; set; }
    public string UserAgentHash { get; set; }
    public string SignedHash { get; set; }
    public DateTime CreatedAt { get; set; }
}
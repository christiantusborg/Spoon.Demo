﻿namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class Role : Entity
{
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public virtual IEnumerable<Claim> Claims { get; set; }
    public virtual IEnumerable<User> Users { get; set; }
}
﻿namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserConfirmEmailRequest
{
    public string? ConfirmCode { get; init; }
    public Guid EmailId { get; set; }
}
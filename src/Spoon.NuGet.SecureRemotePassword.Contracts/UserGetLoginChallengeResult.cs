namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserGetLoginChallengeResult
{
    /// <inheritdoc cref="UserGetLoginChallengeResult" />
    public required Guid UserId { get; set; }
 
    /// <inheritdoc cref="UserGetLoginChallengeResult" />
    public required string Salt { get; init; }
    
    /// <inheritdoc cref="UserGetLoginChallengeResult" />
    public required string Challenge { get; init; }    
}
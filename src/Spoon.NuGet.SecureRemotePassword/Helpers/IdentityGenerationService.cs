namespace Spoon.NuGet.SecureRemotePassword.Helpers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

/// <summary>
///     Class IdentityGeneration. This class cannot be inherited.
/// </summary>
public class IdentityGenerationService : IIdentityGenerationService
{
    private readonly ITokenService _tokenService;

    private readonly ITokenSecretService _tokenSecretService;
    // private const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisSecurely";
    // private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);

    /// <summary>
    ///   Initializes a new instance of the <see cref="IdentityGenerationService" /> class.
    /// </summary>
    /// <param name="tokenService"></param>
    /// <param name="tokenSecretService"></param>
    public IdentityGenerationService(ITokenService tokenService, ITokenSecretService tokenSecretService)
    {
        this._tokenService = tokenService;
        this._tokenSecretService = tokenSecretService;
    }

    /// <summary>
    ///     Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="emailId"></param>
    /// <param name="iat"></param>
    /// <param name="expirationTime"></param>
    /// <param name="customClaims"></param>
    /// <param name="sessionId"></param>
    /// <param name="refreshTokenVerifier"></param>
    /// <returns></returns>
    public string GenerateToken(Guid userId, Guid emailId, Guid sessionId, string refreshTokenVerifier, long iat, DateTime expirationTime, Dictionary<string, object>? customClaims = null)
    {
        var tokenHandler = new JwtSecurityTokenHandler();


        var claims = this.GetBaseClaims(userId, emailId, refreshTokenVerifier, iat,sessionId, expirationTime);

        if (this._tokenService.IncludeIpAddressOriginId())
            claims.Add(new Claim("IpAddressOriginId", this._tokenService.GetIpAddressOriginId()));

        if (this._tokenService.IncludeWindowOriginId())
            claims.Add(new Claim("windowOriginId", this._tokenService.WindowOriginId()));

        if (this._tokenService.IncludeBrowserOriginId())
            claims.Add(new Claim("browserOriginId", this._tokenService.GetBrowserOriginId()));

        claims.Add(new Claim("UseIpAddressRestriction", this._tokenService.GetUseIpAddressRestriction()));

        if (this._tokenService.IncludeIpAddressOriginId())
            claims.Add(new Claim("IpAddressOriginId", this._tokenService.GetIpAddressOriginId()));

        SetCustomClaims(customClaims, claims);

        var tokenDescriptor = this.CreateSecurityTokenDescriptor(claims);

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);

        return jwt;
    }

    /// <summary>
    ///   Generates a refresh token.
    /// </summary>
    /// <returns></returns>
    public string GenerateRefreshToken()
    {
        byte[] randomBytes = new byte[32]; // 33 bytes = 265 bits
        RandomNumberGenerator.Create().GetBytes(randomBytes);
        string base64String = Convert.ToBase64String(randomBytes);

        return base64String;
    }

    private static void SetCustomClaims(Dictionary<string, object>? customClaims, List<Claim> claims)
    {
        if(customClaims is null)
            return;
        
        foreach (var claimPair in customClaims)
        {
            var jsonElement = (JsonElement)claimPair.Value;
            var valueType = jsonElement.ValueKind switch
            {
                JsonValueKind.True => ClaimValueTypes.Boolean,
                JsonValueKind.False => ClaimValueTypes.Boolean,
                JsonValueKind.Number => ClaimValueTypes.Double,
                _ => ClaimValueTypes.String,
            };

            var claim = new Claim(claimPair.Key, claimPair.Value.ToString()!, valueType);
            claims.Add(claim);
        }
    }

    private SecurityTokenDescriptor CreateSecurityTokenDescriptor(List<Claim> claims)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(this._tokenService.GetTokenLifetime()),
            Issuer = this._tokenService.GetIssuer(),
            Audience = this._tokenService.GetAudience(),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this._tokenSecretService.GetTokenSecret()), SecurityAlgorithms.HmacSha256Signature),
        };
        return tokenDescriptor;
    }

    private List<Claim> GetBaseClaims(Guid userId, Guid emailId, string refreshTokenVerifier, long iat, Guid sessionId,DateTime expirationTime)
    {
        var claims = new List<Claim>
        {
            
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, emailId.ToString()),
            new (JwtRegisteredClaimNames.Email, emailId.ToString()),
            new ("userId", userId.ToString()),
            new ("refreshTokenVerifier", refreshTokenVerifier),
            new ("iat", iat.ToString()),
            new ("expireAt",expirationTime.ToString("o")),
            new ("sessionId",sessionId.ToString()),
        };
        return claims;
    }
    
    /// <summary>
    ///  Converts a string to a GUID.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    static Guid StringToGuid(string value)
    {
        // Create a new instance of the MD5CryptoServiceProvider object.
        MD5 md5Hasher = MD5.Create();
        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        return new Guid(data);
    }


    /// <summary>
    ///  Generates a refresh token.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="emailId"></param>
    /// <param name="iat"></param>
    /// <returns></returns>
    public string GenerateRefreshToken(Guid userId, Guid emailId, long iat)
    {
            var value = $"{userId}{emailId}{iat}";
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data).ToString();

    }
}
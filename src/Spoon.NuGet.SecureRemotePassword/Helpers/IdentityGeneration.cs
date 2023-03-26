namespace Spoon.NuGet.SecureRemotePassword.Helpers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;

public class IdentityGeneration
{
    private readonly ITokenService _tokenService;
    private readonly ITokenSecretService _tokenSecretService;
   // private const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisSecurely";
   // private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);

    public IdentityGeneration(ITokenService tokenService, ITokenSecretService tokenSecretService )
    {
        this._tokenService = tokenService;
        this._tokenSecretService = tokenSecretService;
    }
    
    
    public string GenerateToken(Guid userId, string email, Dictionary<string, object> customClaims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        
        var claims = GetBaseClaims(userId, email);        
        
        if (this._tokenService.IncludeIpAddressOriginId())
            claims.Add(new Claim("IpAddressOriginId",this._tokenService.GetIpAddressOriginId()));
        
        if (this._tokenService.IncludeWindowOriginId())
            claims.Add(new Claim("windowOriginId",this._tokenService.WindowOriginId()));
        
        if (this._tokenService.IncludeBrowserOriginId())
            claims.Add(new Claim("browserOriginId",this._tokenService.GetBrowserOriginId()));        
        
        claims.Add(new Claim("UseIpAddressRestriction",this._tokenService.GetUseIpAddressRestriction())); 
        
        
        
        SetCustomClaims(customClaims, claims);
        
        var tokenDescriptor = this.CreateSecurityTokenDescriptor(claims);
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);

        return jwt;

    }

    private static void SetCustomClaims(Dictionary<string, object> customClaims, List<Claim> claims)
    {
        foreach (var claimPair in customClaims)
        {
            var jsonElement = (JsonElement)claimPair.Value;
            var valueType = jsonElement.ValueKind switch
            {
                JsonValueKind.True => ClaimValueTypes.Boolean,
                JsonValueKind.False => ClaimValueTypes.Boolean,
                JsonValueKind.Number => ClaimValueTypes.Double,
                _ => ClaimValueTypes.String
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
            Expires = DateTime.UtcNow.Add(this._tokenService.GetTokenLifetime()),
            Issuer = this._tokenService.GetIssuer(),
            Audience = this._tokenService.GetAudience(),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this._tokenSecretService.GetTokenSecret()), SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenDescriptor;
    }

    private List<Claim> GetBaseClaims(Guid userId, string email)
    {
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, email),
            new (JwtRegisteredClaimNames.Email, email),
            new ("userId", userId.ToString()),
            new ("refreshToken", userId.ToString()),
           // new ("IpAddressOriginId", userId.ToString()),
           // new ("originWindowId", userId.ToString()),
            //new ("originBrowserId", userId.ToString()),
           // new ("UseIpAddressRestriction", "true"),
        };
        return claims;
    }
}
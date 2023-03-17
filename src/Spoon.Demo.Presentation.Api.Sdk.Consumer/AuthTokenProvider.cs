namespace Spoon.Demo.Presentation.Api.Sdk.Consumer;

using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;

public class AuthTokenProvider
{
    private readonly HttpClient _httpClient;
    private string _cachedToken = string.Empty;
    private static readonly SemaphoreSlim Lock = new(1, 1);

    public AuthTokenProvider(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<string> GetTokenAsync()
    {
        if (!string.IsNullOrEmpty(this._cachedToken))
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(this._cachedToken);
            var expiryTimeText = jwt.Claims.Single(claim => claim.Type == "exp").Value;
            var expiryDateTime = UnixTimeStampToDateTime(int.Parse(expiryTimeText));
            if (expiryDateTime > DateTime.UtcNow)
            {
                return this._cachedToken;
            }
        }

        await Lock.WaitAsync();
        var response = await this._httpClient.PostAsJsonAsync("https://localhost:5003/token", new
        {
            userid = "d8566de3-b1a6-4a9b-b842-8e3887a82e41",
            email = "email",
            customClaims = new Dictionary<string, object>
            {
                { "admin", true },
                { "trusted_member", true }
            }
        });
        var newToken = await response.Content.ReadAsStringAsync();
        this._cachedToken = newToken;
        Lock.Release();
        return newToken;
    }
    
    private static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }
}



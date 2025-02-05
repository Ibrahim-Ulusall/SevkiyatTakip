namespace Sevkiyat.Takip.Application.Utilities.Security.JWT;

public class TokenOptions
{
    public string? Audience { get; set; }
    public string? Issuer { get; set; }
    public string SecurityKey { get; set; } = null!;
    public int AccessTokenExpiration { get; set; }
}

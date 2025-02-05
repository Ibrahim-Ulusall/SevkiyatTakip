using Microsoft.IdentityModel.Tokens;

namespace Sevkiyat.Takip.Application.Utilities.Security.Encryption;

public static class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512);
    }
}
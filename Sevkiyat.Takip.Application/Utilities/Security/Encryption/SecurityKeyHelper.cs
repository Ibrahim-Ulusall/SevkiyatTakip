using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Sevkiyat.Takip.Application.Utilities.Security.Encryption;
public static class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}

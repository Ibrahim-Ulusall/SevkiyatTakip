using System.Security.Claims;

namespace Sevkiyat.Takip.Core.Extensions;

public static class ClaimPrincipalExtension
{
    public static List<string> Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
    {
        var result = claimsPrincipal.FindAll(claimType).Select(i=> i.Value).ToList();
        return result;
    }

    public static List<string> ClaimRoles(this ClaimsPrincipal principal)
    {
        return principal.Claims(ClaimTypes.Role);
    }
}
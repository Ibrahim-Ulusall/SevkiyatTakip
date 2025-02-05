using System.Security.Claims;

namespace Sevkiyat.Takip.Core.Extensions;
public static class ClaimExtensions
{
    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }

    public static void AddEmail(this ICollection<Claim> claims, string email)
    {
        claims.Add(new Claim(ClaimTypes.Email, email));
    }

    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(ClaimTypes.GivenName, name));
    }

    public static void AddSurname(this ICollection<Claim> claims, string surname)
    {
        claims.Add(new Claim(ClaimTypes.Surname, surname));
    }

    public static void AddFullName(this ICollection<Claim> claims, string fullName)
    {
        claims.Add(new Claim(ClaimTypes.Name, fullName));
    }

    public static void AddRoles(this ICollection<Claim> claims, string[]? names)
    {
        if (names != null)
            foreach (var name in names)
                claims.Add(new Claim(ClaimTypes.Role, name));
    }
}

using System.Security.Cryptography;
using System.Text;

namespace Sevkiyat.Takip.Application.Utilities.Security.Hashing;
public static class HashingHelper
{

    public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
    {
        using (HMACSHA512 hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {

        using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
        {
            byte[] hashingPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < hashingPassword.Length; i++)
                if (hashingPassword[i] != passwordHash[i])
                    return false;
            return true;
        }

    }
}

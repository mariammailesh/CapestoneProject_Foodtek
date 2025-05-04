using System.Security.Cryptography;
using System.Text;

namespace CapestoneProject.Helpers.HashPassword_UserName
{
    public class HashPassword_UserName
    {
        public static string ComputeSHA512Hash(string input)
        {
            using (var sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}

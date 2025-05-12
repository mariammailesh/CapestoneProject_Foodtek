using System.Security.Cryptography;
using System.Text;

namespace CapestoneProject.Helpers.HashValues
{
    public static class HashValues
    {
        public static string ComputeHashValues(string input)
        {
            // Convert string to array of bytes
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // Initialization hashing algorithm object
            var hasher = SHA512.Create(); // Based on BRD doc.
            // Compute hash
            var hashedBytes = hasher.ComputeHash(inputBytes);
            // return the hashed value after convert it into string
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

    }
}

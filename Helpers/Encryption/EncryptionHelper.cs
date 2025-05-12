using System.Security.Cryptography;
using System.Text;
using CapestoneProject.DTOs.Encryption;

namespace CapestoneProject.Helpers.Encrypt_Payment_Card_info
{
    public static class EncryptionHelper
    {
        public static EncryptDataDTO Encrypt(string value, byte[] key)
        {
            //create an object of the encryption algorithm
            using var aesGcm= new AesGcm(key);
            //create a random nonce
            var nonce = RandomNumberGenerator.GetBytes(12);
            //encode the value to array of bytes
            var valueBytes = Encoding.UTF8.GetBytes(value);
            //prepare the tag array
            var tag = new byte[16];
            //create an array to hold the encrypted data
            var cipherByte = new byte[valueBytes.Length];

            aesGcm.Encrypt(nonce, valueBytes, cipherByte, tag);

            return new EncryptDataDTO
            {
                CipherText = Convert.ToBase64String(cipherByte),
                Nonce = Convert.ToBase64String(nonce),
                Tag = Convert.ToBase64String(tag)
            };

        }

        //not needed for now
        public static string Decrypt(string CipherText, string Nonce, string Tag, byte[] key)
        {
            using var aesGcm = new AesGcm(key);
            //decode the base64 strings to byte arrays
            var cipherByte = Convert.FromBase64String(CipherText);
            var nonce = Convert.FromBase64String(Nonce);
            var tag = Convert.FromBase64String(Tag);

            var plainByte = new byte[cipherByte.Length];
            aesGcm.Decrypt(nonce, cipherByte, tag, plainByte);

            return Encoding.UTF8.GetString(plainByte);
        }
    }
}

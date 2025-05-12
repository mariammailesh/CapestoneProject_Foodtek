 namespace CapestoneProject.DTOs.Encryption
{
    public class EncryptDataDTO
    {
        public string Nonce { get; set; }
        public string Tag { get; set; }//encryption key
        public string CipherText { get; set; }//encrypted value
    }
}

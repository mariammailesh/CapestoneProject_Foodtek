namespace CapestoneProject.DTOs.PaymentCardDTO.Response
{
    public class PaymentCardOutputDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }  // VISA/MasterCard/LocalWallet
        public string LastFourDigits { get; set; }
        public string MaskedNumber { get; set; }  // "xxxxxxxxxxxx1234"
        public bool IsDefault { get; set; }
    }
}

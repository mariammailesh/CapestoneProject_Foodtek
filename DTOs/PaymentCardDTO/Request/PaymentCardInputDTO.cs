using System.ComponentModel.DataAnnotations;

namespace CapestoneProject.DTOs.PaymentCardDTO.Request
{
    public class PaymentCardInputDTO
    {
        [Required]
        [StringLength(100)]
        public string HolderName { get; set; }

        [Required]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string LastFourDigits { get; set; } // Last 4 digits of the card number

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-9]{2})$")]
        public string ExpiryDate { get; set; }  // MM/YY format

        [Required]
        [RegularExpression(@"^[0-9]{3,4}$")]
        public string CVC { get; set; }

        public bool IsDefault { get; set; } = true;



    }
}

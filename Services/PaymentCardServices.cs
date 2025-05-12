using System.Security.Cryptography;
using CapestoneProject.DTOs.PaymentCardDTO.Request;
using CapestoneProject.DTOs.PaymentCardDTO.Response;
using CapestoneProject.Helpers.Encrypt_Payment_Card_info;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;

namespace CapestoneProject.Services
{
    public class PaymentCardServices : IPaymentCardService
    {
        private readonly ESingleRestaurantManagementSystemContext _context;
        public PaymentCardServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<bool> AddPaymentCardAsync(PaymentCardInputDTO paymentCardInputDTO)

        {
            try
            {
                if (paymentCardInputDTO == null)
                    return false;

                
                if (string.IsNullOrWhiteSpace(paymentCardInputDTO.CardNumber) ||
                    string.IsNullOrWhiteSpace(paymentCardInputDTO.HolderName) ||
                    string.IsNullOrWhiteSpace(paymentCardInputDTO.ExpiryDate) ||
                    string.IsNullOrWhiteSpace(paymentCardInputDTO.CVC))
                    return false;                

                // 1. Hash/encrypt sensitive data
                byte[] key = new byte[32]; // Example key, should be securely generated
                RandomNumberGenerator.Fill(key);

                string[] expiryParts = paymentCardInputDTO.ExpiryDate.Split('/');
                string month = expiryParts[0];
                string year = expiryParts[1];
                var newCVC = EncryptionHelper.Encrypt(paymentCardInputDTO.CVC, key); // Placeholder for actual encryption
                var newCardNumber = EncryptionHelper.Encrypt(paymentCardInputDTO.CardNumber, key); // Placeholder for actual encryption
                PaymentCard paymentCard = new PaymentCard
                {
                    CardHolderName = paymentCardInputDTO.HolderName,
                    CardNumber = newCardNumber.CipherText, // Placeholder for actual encryption
                    LastFourDigits = paymentCardInputDTO.CardNumber.Substring(paymentCardInputDTO.CardNumber.Length - 4),
                    ExpirationMonth = month,
                    ExpirationYear = year,
                    CVC =newCVC.CipherText,// Placeholder for actual encryption
                    IsDefault = paymentCardInputDTO.IsDefault,
                };

                // 2. Store in database
                _context.PaymentCards.Add(paymentCard);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
    
}

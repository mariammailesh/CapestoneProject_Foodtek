using CapestoneProject.DTOs.PaymentCardDTO.Request;

namespace CapestoneProject.Interfaces
{
    public interface IPaymentCardService
    {
        Task<bool> AddPaymentCardAsync(PaymentCardInputDTO paymentCardInputDTO);
        
    }
}

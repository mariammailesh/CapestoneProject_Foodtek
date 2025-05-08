using CapestoneProject.DTOs.Discount.Response;

namespace CapestoneProject.Interfaces
{
    public interface IDiscountServices
    {
        Task<List<DiscountResponseDTO>> GetAllDiscountsAsync();
        
        //future work
        //Task<Discount> GetDiscountByIdAsync(int id);
        //Task<bool> AddDiscountAsync(Discount discount);
        //Task<bool> UpdateDiscountAsync(Discount discount);
        //Task<bool> DeleteDiscountAsync(int id);
        //Task<bool> IsCodeExistsAsync(int code);
        //Task<bool> IsCodeExistsForUpdateAsync(int code, int id);
    }
}

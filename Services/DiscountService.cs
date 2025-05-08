using CapestoneProject.DTOs.Discount.Response;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class DiscountService : IDiscountServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;

        public DiscountService(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }

        public Task<List<DiscountOutputDTO>> GetAllDiscountsAsync()
        {
            var discounts = _context.Discounts
                .Where(d => d.IsActive == true)
                .Select(d => new DiscountOutputDTO
                {
                    Id = d.DiscountId,
                    TitleEn = d.TitleEn,
                    TitleAr = d.TitleAr,
                    DescriptionEn = d.DescriptionEn,
                    DescriptionAr = d.DescriptionAr,
                    ImageURL = d.ImageURL
                })
                .ToListAsync();
            return discounts;
        }
    }
}

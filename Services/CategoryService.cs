using CapestoneProject.DTOs.CategoryDTO.Response;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;
namespace CapestoneProject.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ESingleRestaurantManagementSystemContext _context;
        public CategoryService(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryResponseDTO>> GetAllActiveCategory()
        {
            var categories = await _context.Categories
                .Where(c => c.IsActive == true)
                .Select(c => new CategoryResponseDTO
                {
                    Id = c.CategoryId,
                    NameAr = c.CategoryNameAr,
                    NameEn = c.CategoryNameEn,
                    ImageLogoURL = c.Image != null ? c.Image : "https://static.vecteezy.com/system/resources/previews/022/059/000/non_2x/no-image-available-icon-vector.jpg" 
                }).ToListAsync();

            return categories;
        }

       
    }

}

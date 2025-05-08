using CapestoneProject.DTOs.CategoryDTO.Response;

namespace CapestoneProject.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryOutputDTO>> GetAllActiveCategory();
        
    }
}

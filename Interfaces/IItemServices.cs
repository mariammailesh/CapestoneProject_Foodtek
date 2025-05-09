using CapestoneProject.DTOs.Item.Request;
using CapestoneProject.DTOs.Item.Response;

namespace CapestoneProject.Interfaces
{
    public interface IItemServices
    {
        // Hebah-Afaneh-Dev
        Task<ItemOutputDTO> GetItemDetailsByIdAsync(int itemId);

        //Mariam:
        Task<IEnumerable<ItemOutputDTO>> GetTopRatedItems();
        Task<IEnumerable<ItemOutputDTO>> GetTopRecommendedItems();
        Task<IEnumerable<ItemOutputDTO>> GetItemsByCategoryId(int categoryId);

    }
}

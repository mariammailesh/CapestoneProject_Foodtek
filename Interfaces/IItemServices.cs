using CapestoneProject.DTOs.Item.Request;
using CapestoneProject.DTOs.Item.Response;

namespace CapestoneProject.Interfaces
{
    public interface IItemServices
    {
        Task<ItemOutputDTO> GetItemDetailsByIdAsync(int itemId);
        Task CreateItemAsync(ItemInputDTO item);
        Task<string> UpdateItemAsync(int id, ItemInputDTO item);
        Task<string> DeleteItemAsync(int id);

        //Mariam:
        Task<IEnumerable<ItemOutputDTO>> GetTopRatedItems();
        Task<IEnumerable<ItemOutputDTO>> GetTopRecommendedItems();
        Task<IEnumerable<ItemOutputDTO>> GetItemsByCategoryId(int categoryId);

    }
}

using CapestoneProject.DTOs.Item.Request;
using CapestoneProject.DTOs.Item.Response;

namespace CapestoneProject.Interfaces
{
    public interface IItemServices
    {
        Task<IEnumerable<ItemOutputDTO>> GetItemsByCategoryIdAsync(int categoryId);
        Task<ItemOutputDTO> GetItemByIdAsync(int itemId);
        Task CreateItemAsync(ItemInputDTO item);
        Task<string> UpdateItemAsync(int id, ItemInputDTO item);
        Task<string> DeleteItemAsync(int id);
    }
}

using CapestoneProject.DTOs.Favorite.Request;
using CapestoneProject.DTOs.Favorite.Response;
using CapestoneProject.DTOs.Item.Response;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class FavoriteServices : IFavoriteServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;

        public FavoriteServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<string> AddItemToFavoriteAsync(FavoriteItemInputDTO FavoriteItem)
        {
            var exists = await _context.Favorites
                    .AnyAsync(f => f.UserId == FavoriteItem.UserId && f.ItemId == FavoriteItem.ItemId);

            if (exists)
                return "Item already in favorites.";

            var fav = new Favorite
            {
                UserId = FavoriteItem.UserId,
                ItemId = FavoriteItem.ItemId,
                CreatedAt = DateTime.Now
            };

            _context.Favorites.Add(fav);
            await _context.SaveChangesAsync();

            return "Item added to favorites.";
        }

        public async Task<string> DeleteFavoriteAsync(int UserId)
        {
            var FavoriteItem = await _context.Favorites.Where(x => x.UserId == UserId).SingleOrDefaultAsync();
            if (FavoriteItem == null)
                return "Favorite Not Found!";

            _context.Remove(FavoriteItem);
            await _context.SaveChangesAsync();
            return "Item Removed Successfully!";
        }

        public async Task<string> DeleteItemFromFavoriteAsync(FavoriteItemInputDTO input)
        {
            var item = await _context.Favorites.FirstOrDefaultAsync(f => f.UserId == input.UserId && f.ItemId == input.ItemId);
            if (item == null)
                return "Item Not Found in Your Favorites!";
            _context.Favorites.Remove(item);
            await _context.SaveChangesAsync();
            return "Item Removed Successfully!";
        }

        public async Task<FavoriteItemOutputDTO> GetFavoriteItemByIdAsync(int itemId)
        {
            var Favoriteitem = await _context.Favorites
                                .Where(i => i.ItemId == itemId)
                                .Select(i => new FavoriteItemOutputDTO
                                {
                                    ItemId = i.ItemId,
                                    CreatedAt = Convert.ToDateTime(i.CreatedAt)
                                }).FirstOrDefaultAsync();
            return Favoriteitem;
        }

        public async Task<IEnumerable<FavoriteItemOutputDTO>> GetFavoriteItemByUserIdAsync(int UserId)
        {
            var favoriteItems = await _context.Favorites
                    .Where(f => f.UserId == UserId)
                    .Include(f => f.Item) //Include here act as JOIN 
                    .Select(f => new FavoriteItemOutputDTO
                    {
                        ItemId = f.Item.ItemId,
                        NameAr = f.Item.NameAr,
                        NameEn = f.Item.NameEn,
                        DescriptionAr = f.Item.DescriptionAr,
                        DescriptionEn = f.Item.DescriptionEn,
                        Price = Convert.ToDecimal(f.Item.Price),
                        CreatedAt = Convert.ToDateTime(f.CreatedAt)
                    })
                    .ToListAsync();

            return favoriteItems;
        }
    }
}

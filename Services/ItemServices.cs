using System;
using Microsoft.EntityFrameworkCore;
using CapestoneProject.DTOs.Item.Request;
using CapestoneProject.DTOs.Item.Response;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CapestoneProject.Services
{
    public class ItemServices : IItemServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;

        public ItemServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        // Hebah-Afaneh-Dev
        public async Task<ItemOutputDTO> GetItemDetailsByIdAsync(int itemId)
        {
            var item = await _context.Items
                    .Where(i => i.ItemId == itemId)
                    .Select(i => new ItemOutputDTO
                    {
                        Id = i.ItemId,
                        NameAr = i.NameAr,
                        NameEn = i.NameEn,
                        DescriptionAr = i.DescriptionAr,
                        DescriptionEn = i.DescriptionEn,
                        Price = Convert.ToDecimal(i.Price),
                        ViewCount = i.ViewCount,
                        NumberOfReview = _context.Ratings.Count(x => x.ItemId == itemId),
                        Rate = _context.Ratings.Where(x => x.ItemId == itemId).Average(x => (decimal?) x.RatingAmount)?? 0
                    }).FirstOrDefaultAsync();

            if (item == null) return null;
            var IncrementViewCount = await _context.Items.FindAsync(itemId);
            IncrementViewCount.ViewCount++;         // Increase each time the user review the item
            await _context.SaveChangesAsync();
            
            return item;
        }

        //Mariam:
        public async Task<IEnumerable<ItemOutputDTO>> GetTopRatedItems()
        {
            return await _context.Items
                .GroupJoin(
                    _context.Ratings,
                    item => item.ItemId,
                    rating => rating.ItemId,
                    (item, ratings) => new
                    {
                        Item = item,
                        AverageRating = ratings.Average(r => r.RatingAmount) ?? 0
                    })
                .OrderByDescending(x => x.AverageRating)
                .Take(10)
                .Select(x => new ItemOutputDTO
                {
                    Id = x.Item.ItemId,
                    NameAr = x.Item.NameAr,
                    NameEn = x.Item.NameEn,
                    DescriptionAr = x.Item.DescriptionAr,
                    DescriptionEn = x.Item.DescriptionEn,
                    Price = Convert.ToDecimal(x.Item.Price),
                    Image = x.Item.Image,
                    Rate = Convert.ToDecimal(x.AverageRating)
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<ItemOutputDTO>> GetTopRecommendedItems()
        {
            return await _context.Items
                .OrderBy(i => i.SoldCount)
                .Take(10)
                .Select(i => new ItemOutputDTO
                {
                    Id = i.ItemId,
                    NameAr = i.NameAr,
                    NameEn = i.NameEn,
                    DescriptionAr = i.DescriptionAr,
                    DescriptionEn = i.DescriptionEn,
                    Price = Convert.ToDecimal(i.Price),
                    Image = i.Image,
                    SoldCount = i.SoldCount
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemOutputDTO>> GetItemsByCategoryId(int categoryId)
        {
            var item = await _context.Items.Where(i => i.CategoryId == categoryId)
                .Select(i => new ItemOutputDTO
                {
                    Id = i.ItemId,
                    NameAr = i.NameAr,
                    NameEn = i.NameEn,
                    DescriptionAr = i.DescriptionAr,
                    DescriptionEn = i.DescriptionEn,
                    Price = Convert.ToDecimal(i.Price),
                    Image = i.Image
                }).ToListAsync();

            return item;
        }


    }
}

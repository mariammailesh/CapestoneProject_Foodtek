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
        public async Task CreateItemAsync(ItemInputDTO input)
        {
            var item = new Item
            {
                NameAr = input.NameAr,
                NameEn = input.NameEn,
                DescriptionAr = input.DescriptionAr,
                DescriptionEn = input.DescriptionEn,
                Price = input.Price,
                Image = input.Image,
                CategoryId = input.CategoryId
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return "Item Not Found!";
            
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return "Item Removed Successfully!";
        }

        public async Task<ItemOutputDTO> GetItemByIdAsync(int itemId)
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
                        Image = i.Image
                    }).FirstOrDefaultAsync();

            Item UpdatedItem = _context.Items.Where(i => i.ItemId == itemId).FirstOrDefault();
            if (!(item == null))
            {
                UpdatedItem.ViewCount++;
                _context.Items.Update(UpdatedItem);
                await _context.SaveChangesAsync();
            }
            return item;
        }
        public async Task<string> UpdateItemAsync(int id, ItemInputDTO input)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return "Item Not Found.";

            item.NameAr = input.NameAr;
            item.NameEn = input.NameEn;
            item.DescriptionAr = input.DescriptionAr;
            item.DescriptionEn = input.DescriptionEn;
            item.Price = input.Price;
            item.Image = input.Image;
            item.CategoryId = input.CategoryId;

            await _context.SaveChangesAsync();
            return "Item Updated Successfully.";
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

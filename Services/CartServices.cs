using CapestoneProject.DTOs.Cart.Response;
using CapestoneProject.DTOs.Request;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class CartServices : ICartServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;
        public CartServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<string> ClearCart(int cartId)
        {
            var cartItems = await _context.CartItems.Where(c => c.CartId == cartId).ToListAsync();
            if (!cartItems.Any())
            {
                return "Cart is already empty";
            }
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return "Cart Cleared Successfully";
        }
        public async Task<string> CreateCart(int personId)
        {
            var isCartExist = await _context.Carts.AnyAsync(c => c.UserId == personId);
            if (isCartExist)
                return "Cart Already Exists";


            var cart = new Cart { UserId = personId};
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return "Cart Created Successfully";
        }

        public async Task<List<CartItemOutputDTO>> GetCartByUserIdAsync(int userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems) // First JOIN
                .ThenInclude(ci => ci.Item).FirstOrDefaultAsync(c => c.UserId == userId); // Secon JOIN
            // Validate if carts empty or not
            if (cart == null || cart.CartItems == null || !cart.CartItems.Any())
                return new List<CartItemOutputDTO>(); // Empty List (No Items) 

            return cart.CartItems.Select(ci => new CartItemOutputDTO
            {
                CartItemId = ci.CartItemId,
                ItemId = ci.ItemId,
                ItemNameAr = ci.Item.NameAr,
                ItemNameEn = ci.Item.NameEn,
                DescriptionAr = ci.Item.DescriptionAr,
                DescriptionEn = ci.Item.DescriptionEn,
                Quantity = ci.Quantity
            }).ToList();
        }
    }
}

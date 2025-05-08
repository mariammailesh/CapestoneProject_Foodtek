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
        public async Task<string> AddUpdateCart(CartItemInputDTO itemDTO)
        {
            var cart = await _context.Carts.Where(i => i.CartId == itemDTO.CartId && i.UserId == itemDTO.UserId).FirstOrDefaultAsync();
            if (cart == null)
            {
                return "Cart Not Found or Does Not Belong to This User!";
            }

            var cartItem = await _context.CartItems.Where(i => i.CartId == itemDTO.CartId && i.ItemId == itemDTO.ItemId).FirstOrDefaultAsync();
            if (cartItem == null)
            {
                var newItem = new CartItem
                {
                    CartId = cart.CartId,
                    ItemId = itemDTO.ItemId,
                    Quantity = itemDTO.Quantity,
                    Price = Convert.ToDecimal(itemDTO.TotalPrice),
                };
                _context.CartItems.Add(newItem);
            }
            else
            {
                cartItem.Quantity += itemDTO.Quantity;
                cartItem.Price = Convert.ToDecimal(itemDTO.TotalPrice);
            }
            await _context.SaveChangesAsync();
            return "Cart Updated Successfully";
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
        public async Task<string> RemoveFromCart(int CartitemId)
        {

            var cartItem = await _context.CartItems.Where(c => c.CartItemId == CartitemId).FirstOrDefaultAsync();
            if (cartItem == null)
            {
                return "Cart Item Does Not Exist";
            }


            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return "Cart Item Removed Successfully";
        }
    }
}

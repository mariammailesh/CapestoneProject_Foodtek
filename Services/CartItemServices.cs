using CapestoneProject.DTOs.Request;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class CartItemServices : ICartItemServices
    {
        private readonly ESingleRestaurantManagementSystemContext _context;
        public CartItemServices(ESingleRestaurantManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<string> AddOrUpdateItemAsync(CartItemInputDTO itemDTO)
        {
            var cart = await _context.Carts.Where(i => i.CartId == itemDTO.CartId && i.UserId == itemDTO.UserId).FirstOrDefaultAsync();
            if (cart == null)
            {
                return "Cart Not Found or Does Not Belong to This User!";
            }

            var cartItem = await _context.CartItems.Where(i => i.CartId == itemDTO.CartId && i.ItemId == itemDTO.ItemId).FirstOrDefaultAsync();
            // Add a new item
            if (cartItem == null)
            {
                var item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == itemDTO.ItemId);
                if (item == null)
                    return "Item Not Found!";   // Get Item Price Instead of Allowing Client to Enter it

                var newItem = new CartItem
                {
                    CartId = cart.CartId,
                    ItemId = itemDTO.ItemId,
                    Quantity = itemDTO.Quantity,
                    Price = Convert.ToDecimal(item.Price)
                };
                _context.CartItems.Add(newItem);
            }
            // If item exists then increase quantity
            else
            {
                cartItem.Quantity += itemDTO.Quantity;
                cartItem.Price = cartItem.Price; // Keep it as same
            }
            await _context.SaveChangesAsync();
            return "Cart Item Added/Updated Successfully";
        }

        public async Task<string> RemoveItemAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return "Cart Item Does Not Exist";
            }


            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return "Cart Item Removed Successfully";
        }

        public async Task<string> RemoveOnePieceAsync(int userId, int itemId)
        {
            var cart = await _context.Carts.Where(c => c.UserId == userId && c.IsActive == true).FirstOrDefaultAsync();
            if (cart == null)
            {
                return "Cart Not Found For This User!";
            }
            var cartitem = await _context.CartItems.Where(ci => ci.CartId == cart.CartId && ci.ItemId == itemId).FirstOrDefaultAsync();
            if (cartitem == null)
                return "Item Not Found in Cart!";
            if (cartitem.Quantity > 1)
                cartitem.Quantity -= 1;
            else
                _context.CartItems.Remove(cartitem);
            await _context.SaveChangesAsync();
            return "Item Quantity Updated Successfully!";
        }
    }
}

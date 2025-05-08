namespace CapestoneProject.DTOs.Cart.Response
{
    public class CartItemOutputDTO
    {
        public int CartItemId { get; set; }
        public int ItemId { get; set; }
        public string ItemNameAr { get; set; }
        public string ItemNameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string? ItemImage { get; set; } 
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}

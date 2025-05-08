namespace CapestoneProject.DTOs.Request
{
    public class CartItemInputDTO
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public int? CartItemID { get; set; }
    }
}

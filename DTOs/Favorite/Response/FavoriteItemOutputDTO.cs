namespace CapestoneProject.DTOs.Favorite.Response
{
    public class FavoriteItemOutputDTO
    {
        public int ItemId { get; set; } 
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } // Favorite.CreatedAt
    }
}

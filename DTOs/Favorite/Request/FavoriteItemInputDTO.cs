namespace CapestoneProject.DTOs.Favorite.Request
{
    public class FavoriteItemInputDTO
    {
        public int UserId { get; set; }

        public int ItemId { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}

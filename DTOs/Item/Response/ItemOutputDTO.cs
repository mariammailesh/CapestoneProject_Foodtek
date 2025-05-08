namespace CapestoneProject.DTOs.Item.Response
{
    public class ItemOutputDTO
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int ViewCount { get; set; }
        public int? NumberOfReview { get; set; }
        public decimal Rate { get; set; } = 0;
        public int SoldCount { get; set; } = 0;
    }
}

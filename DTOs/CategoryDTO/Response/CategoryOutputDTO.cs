namespace CapestoneProject.DTOs.CategoryDTO.Response
{
    public class CategoryOutputDTO
    {
        public int Id { get; set; } 
        public string NameEn { get; set; }
        public string? ImageLogoURL { get; set; }
        public string NameAr { get; internal set; }
    }
}

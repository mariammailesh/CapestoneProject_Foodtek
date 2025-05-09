namespace CapestoneProject.DTOs.OrderHistory.Rseponse
{
    public class OrderHistoryOutputDTO
    {
        public int Id { get; set; }               // Order Id
        // We don`t have address directly 
        public string Region { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Date { get; set; }        
        public decimal TotalPrice { get; set; }
    }
}

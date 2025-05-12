namespace CapestoneProject.DTOs.Login.Response
{
    public class LoginOutputDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Role_Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}

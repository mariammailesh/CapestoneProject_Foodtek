namespace CapestoneProject.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string to, string subject, string body);
        //Task SendLoginTokenAsync(string email, string token);
        //Task SendOtpAsync(string email, string otpCode);
    }

}

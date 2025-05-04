namespace CapestoneProject.Interfaces
{
    public interface IEmailServices
    {
        Task SendLoginTokenAsync(string email, string token);
        Task SendOtpAsync(string email, string otpCode);
    }

}

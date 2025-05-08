using CapestoneProject.Interfaces;

namespace CapestoneProject.Services
{
    public class DummyEmailServices : IEmailServices
    {
        public Task SendLoginTokenAsync(string email, string token)
        {
            Console.WriteLine($"[EMAIL MOCK] Sent login link with token to {email}: https://yourfrontend.com/confirm-login?token={token}");
            return Task.CompletedTask;
        }

        public Task SendOtpAsync(string email, string otpCode)
        {
            Console.WriteLine($"[EMAIL MOCK] Sent OTP {otpCode} to {email}");
            return Task.CompletedTask;
        }
    }
}

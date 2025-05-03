namespace CapestoneProject.DTOs.ResetPassword.Request
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string NewPasswordHash { get; set; }
        public string OTPCode { get; set; }

    }
}

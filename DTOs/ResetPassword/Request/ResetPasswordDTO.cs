namespace CapestoneProject.DTOs.ResetPassword.Request
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OTP { get; set; }

    }
}

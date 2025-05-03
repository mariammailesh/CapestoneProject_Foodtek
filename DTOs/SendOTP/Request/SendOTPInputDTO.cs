namespace CapestoneProject.DTOs.SendOTP.Request
{
    public class SendOTPInputDTO
    {
        public string Email { get; set; }
        public string OTPCode { get; set; }
        public DateTime? ExpireOTP { get; set; }

    }
}

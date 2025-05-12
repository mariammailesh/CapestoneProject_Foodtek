using System.IO.Pipes;
using CapestoneProject.DTOs.Login.Request;
using CapestoneProject.DTOs.Login.Response;
using CapestoneProject.DTOs.ResetPassword.Request;
using CapestoneProject.DTOs.SignUp.Request;
using CapestoneProject.DTOs.Verification.Request;

namespace CapestoneProject.Interfaces
{
    public interface IUserAuthentication
    {
        //define sigature for the targeted method 
        Task<string> SignUp(SignUpInputDTO input);
        Task<LoginOutputDTO> SignIn(LoginInputDTO input);
        Task<string> Verification(VerificationInputDTO input);
        Task<bool> SendOTP(string email);
        Task<bool> ResetUserPassword(ResetPasswordDTO input);
        Task<bool> SignOut(int userId);
    }
}

using CapestoneProject.DTOs.Login.Request;
using CapestoneProject.DTOs.ResetPassword.Request;
using CapestoneProject.DTOs.SignUp.Request;
using CapestoneProject.DTOs.Verification.Request;
using CapestoneProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthentication _userAuthentication;

        public AuthenticationController(IUserAuthentication userAuthentication)
        {
            _userAuthentication = userAuthentication;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpInputDTO input)
        {
            try
            {
                var token = await _userAuthentication.SignUp(input);
                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] LoginInputDTO input)
        {
            try
            {
                var user = await _userAuthentication.SignIn(input);
                if (user == null)
                    return Unauthorized(new { message = "Invalid credentials." });

                return Ok(new { user = user });
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Verification(VerificationInputDTO input)
        {
            try
            {
                var response = await _userAuthentication.Verification(input);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendOTP(string email)
        {
            try
            {
                var response = await _userAuthentication.SendOTP(email);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetUserPassword(ResetPasswordDTO input)
        {
            try
            {
                var response = await _userAuthentication.ResetUserPassword(input);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignOut(int userId)
        {
            try
            {
                var response = await _userAuthentication.SignOut(userId);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
    }
}

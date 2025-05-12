using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapestoneProject.DTOs.SignUp.Request;
using CapestoneProject.Helpers.Validations;
using Microsoft.Data.SqlClient;
using CapestoneProject.DTOs.Login.Request;
using CapestoneProject.DTOs.Login.Response;
using CapestoneProject.DTOs.ResetPassword.Request;
using System.Data;
using CapestoneProject.DTOs.SendOTP.Request;
using System;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using CapestoneProject.Helpers.JWT;
using CapestoneProject.Interfaces;
using Microsoft.Extensions.Configuration.UserSecrets;
using CapestoneProject.Helpers.HashValues;



namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ESingleRestaurantManagementSystemContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailServices _emailService;

        public AuthController(ESingleRestaurantManagementSystemContext context, IEmailServices emailService, IConfiguration configuration)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")] 
        public async Task<IActionResult> Signup([FromBody] SignUpInputDTO input)
        {
            input.Email = HashValues.ComputeHashValues(input.Email);
            input.UserName = HashValues.ComputeHashValues(input.UserName);
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == input.Email || u.PhoneNumber == input.PhoneNumber || u.UserName == input.UserName))
                    return BadRequest("Email, phone, or username already exists.");

                var user = new User
                {
                    FullName = input.FullName,
                    UserName = HashValues.ComputeHashValues(input.UserName),
                    Email = HashValues.ComputeHashValues(input.Email),
                    PhoneNumber = input.PhoneNumber,
                    PasswordHash = HashValues.ComputeHashValues(input.Password),
                    BirthDate = input.BirthDate,
                    CreatedAt = DateTime.Now,
                    RoleId = 2 //  2 = client 
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return StatusCode(201, "Account created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Signup failed: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginInputDTO input)
        {
            input.Email = HashValues.ComputeHashValues(input.Email);
            input.UserName = HashValues.ComputeHashValues(input.UserName);
            input.Password = HashValues.ComputeHashValues(input.Password);

            try
            {
                var user = await _context.Users.Where(u => (u.Email == input.Email || u.UserName == input.UserName) && u.PasswordHash == input.Password).FirstOrDefaultAsync();
                if (user == null)
                    return Unauthorized("Incorrect email, username or password.");

                var token = TokenProvider.GenerateJwtToken(user, _configuration);


                var response = new
                {
                    Message = $"Welcome {user.UserName}",
                    Token = token,
                    User = new LoginOutputDTO
                    {
                        FullName = user.FullName,
                        Email = HashValues.ComputeHashValues(user.Email),
                        UserName = HashValues.ComputeHashValues(user.UserName),
                        Role_Id = user.RoleId,
                        UserId = user.UserId
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Login error: {ex.Message}");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendOTP(string email)
        {
            email = HashValues.ComputeHashValues(email);
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null) 
                    return NotFound("No user with that email.");

                var otp = new Random().Next(1000, 9999).ToString();
                var otpEntry = new UserOtp
                {
                    Email = email,
                    Otpcode = otp,
                    CreatedAt = DateTime.Now,
                    ExpirationTime = DateTime.Now.AddMinutes(10),
                    IsUsed = false
                };

                _context.UserOtps.Add(otpEntry);
                await _context.SaveChangesAsync();
                //send email 
                await _emailService.SendOtpAsync(email, otp);

                return Ok("OTP has been sent to your email.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to send OTP: {ex.Message}");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO input)
        {
            input.Email = HashValues.ComputeHashValues(input.Email);
            input.NewPasswordHash = HashValues.ComputeHashValues(input.NewPasswordHash);
            try
            {
                if (string.IsNullOrWhiteSpace(input.Email) ||
                    string.IsNullOrWhiteSpace(input.NewPasswordHash) ||
                    string.IsNullOrWhiteSpace(input.OTPCode))
                    return BadRequest("Missing required fields.");

                // Hash Password
                input.NewPasswordHash = HashValues.ComputeHashValues(input.NewPasswordHash);

                // Validate OTP
                var otpEntry = await _context.UserOtps
                    .FirstOrDefaultAsync(o =>
                        o.Email == input.Email &&
                        o.Otpcode == input.OTPCode &&
                        o.IsUsed == false &&
                        o.ExpirationTime > DateTime.Now);

                if (otpEntry == null)
                    return BadRequest("Invalid or expired OTP.");

                // Get the user
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == input.Email);
                if (user == null)
                    return NotFound("User not found.");

                // Prevent password reuse
                if (user.PasswordHash == input.NewPasswordHash)
                    return BadRequest("You cannot reuse your previous password.");

                // Update password and mark OTP as used
                user.PasswordHash = input.NewPasswordHash;
                otpEntry.IsUsed = true;

                await _context.SaveChangesAsync();

                return Ok("Password has been reset successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

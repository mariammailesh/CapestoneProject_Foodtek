using System;
using System.IO.Pipes;
using CapestoneProject.DTOs.Login.Request;
using CapestoneProject.DTOs.Login.Response;
using CapestoneProject.DTOs.ResetPassword.Request;
using CapestoneProject.DTOs.SignUp.Request;
using CapestoneProject.DTOs.Verification.Request;
using CapestoneProject.Helpers.HashValues;
using CapestoneProject.Helpers.JWT;
using CapestoneProject.Interfaces;
using CapestoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CapestoneProject.Services
{
    public class AuthenticationAppServices : IUserAuthentication
    {
        private readonly IUserAuthentication _userAuthentication;
        private readonly ESingleRestaurantManagementSystemContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailServices _emailService;

        public AuthenticationAppServices( ESingleRestaurantManagementSystemContext context, IEmailServices emailService, IConfiguration configuration)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
            //_userAuthentication = userAuthentication;
        }

        public async Task<bool> ResetUserPassword(ResetPasswordDTO input)
        {
            var user = await _context.Users.Where(u => u.Email == input.Email && u.UserOtps.Otpcode == input.OTP
                        && u.IsLoggedIn == false && u.UserOtps.ExpirationTime > DateTime.Now).SingleOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            if (input.Password != input.ConfirmPassword)
            {
                return false;
            }
            user.PasswordHash =HashValues.ComputeHashValues(input.ConfirmPassword);
            user.UserOtps.Otpcode = null;
            user.UserOtps.ExpirationTime = null;

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> SendOTP(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email && u.IsLoggedIn == false).SingleOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            Random otp = new Random();
            user.UserOtps.Otpcode = otp.Next(1111, 9999).ToString();
            user.UserOtps.ExpirationTime = DateTime.Now.AddMinutes(3);
            var otpEntry = new UserOtp
            {
                Email = email,
                Otpcode = user.UserOtps.Otpcode,
                CreatedAt = DateTime.Now,
                ExpirationTime = user.UserOtps.ExpirationTime,
                IsUsed = false
            };

            _context.UserOtps.Add(otpEntry);
            //send otp via email

            _context.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LoginOutputDTO> SignIn(LoginInputDTO input)
        {
            input.Email = HashValues.ComputeHashValues(input.Email);
            input.Password = HashValues.ComputeHashValues(input.Password);
            var user = await _context.Users.Where(u => (u.Email == input.Email || u.UserName == input.Email) && u.PasswordHash == input.Password && u.IsLoggedIn == false).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Incorrect email, username or password.");
            }
            var token = TokenProvider.GenerateJwtToken(user.UserId.ToString(), user.Role.NameEn);
            Random random = new Random();
            var otp = random.Next(1111, 9999);
            user.UserOtps.Otpcode = otp.ToString();
            user.UserOtps.ExpirationTime = DateTime.Now.AddMinutes(5);
            //Send via email
            var response = new LoginOutputDTO
            {
                Message = $"Welcome {user.UserName}",
                Token = token,
                FullName = user.FullName,
                Email = HashValues.ComputeHashValues(user.Email),
                UserName = HashValues.ComputeHashValues(user.UserName),
                Role_Id = user.RoleId,
                UserId = user.UserId
            };
            _context.Update(user);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<bool> SignOut(int userId)
        {
            var user = await _context.Users.Where(u => u.UserId == userId && u.IsLoggedIn == true).SingleOrDefaultAsync();
            if (user == null)
            {
                return false;
            }

            user.LastLoginTime = DateTime.Now;
            user.IsLoggedIn = false;

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public async Task<string> SignUp(SignUpInputDTO input)
        {
            User User = new User();
            User.Email = HashValues.ComputeHashValues(input.Email);
            User.UserName = HashValues.ComputeHashValues(input.UserName);
            User.PasswordHash = HashValues.ComputeHashValues(input.Password);
            User.PhoneNumber = input.PhoneNumber;
            User.FullName = input.FullName;
            User.BirthDate = input.BirthDate;   
            User.CreatedBy = "System";
            User.CreatedAt = DateTime.Now;
            User.RoleId = 2; // client Id = 2

            Random random = new Random();
            var otp = random.Next(1111, 9999);
            User.UserOtps.Otpcode = otp.ToString();
            User.UserOtps.ExpirationTime = DateTime.Now.AddMinutes(5);
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            // send otp code via email
            return "Verifuing Your email using otp";
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            input.Email = HashValues.ComputeHashValues(input.Email);
            var user = await _context.Users.Where(u => (u.Email == input.Email || u.UserName == input.Email) && u.UserOtps.Otpcode == input.OTPCode
                        && u.IsLoggedIn == false && u.UserOtps.ExpirationTime > DateTime.Now).SingleOrDefaultAsync();
            if (user == null)
            {
                return "User not found";
            }

            if (input.IsSignup)
            {
                user.IsVerified = true;
                user.UserOtps.ExpirationTime = null;
                user.UserOtps.Otpcode = null;
                _context.Update(user);
                await _context.SaveChangesAsync();
                return "Your Account Is Verified";
            }
            else
            {
                user.LastLoginTime = DateTime.Now;
                user.IsLoggedIn = true;
                user.UserOtps.ExpirationTime = null;
                user.UserOtps.Otpcode = null;

                _context.Update(user);
                await _context.SaveChangesAsync();
                string jwtToken = TokenProvider.GenerateJwtToken(user.UserId.ToString(), user.Role.NameEn);
                return jwtToken;
            }
        }
    }
}

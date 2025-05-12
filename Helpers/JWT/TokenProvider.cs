using CapestoneProject.Models;
using CapestoneProject;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.VisualBasic;

namespace CapestoneProject.Helpers.JWT
{
    public static class TokenProvider
    {
        public static string GenerateJwtToken(string userId, string roleName)
        {
            // Initialization handler
            var JWTTokenHandler = new JwtSecurityTokenHandler();
            // Setup token key : 1- Long secret.    2- Convert secret to bytes.
            string secret = "LongPrimarySecretForSingleRestaurantManagementApplicationASPCoreModuleForDevelopmentPurposes";
            var tokenBytesKey = Encoding.UTF8.GetBytes(secret);
            // Setup token descriptor (claims, expiry, signature)
            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(5),
                Subject = new ClaimsIdentity (new Claim[]
                {
                    new Claim("UserId", userId),
                    new Claim("Role", roleName)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenBytesKey), SecurityAlgorithms.HmacSha256Signature)
            };
            // Encoding data to a JSON format 
            var tokenJSON = JWTTokenHandler.CreateToken(descriptor);    
            // Encoding JSON result as token string 
            var token = JWTTokenHandler.WriteToken(tokenJSON);
            return token;
        }

        public static string ISValidToken(string token)
        {
            try
            {
                // Initialization handler
                var JWTTokenHandler = new JwtSecurityTokenHandler();
                // Setup token key : 1- Long secret.    2- Convert secret to bytes.
                string secret = "LongPrimarySecretForSingleRestaurantManagementApplicationASPCoreModuleForDevelopmentPurposes";
                var tokenBytesKey = Encoding.UTF8.GetBytes(secret);

                var tokenValidatorParms = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenBytesKey),
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                var tokenBase = JWTTokenHandler.ValidateToken(token, tokenValidatorParms, out SecurityToken validationToken);
                return "Valid";
            }
            catch(Exception ex)
            {
                return $"InValid {ex.Message}";
            }
        }
    }
}


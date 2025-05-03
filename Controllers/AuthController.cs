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
//

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("signup")] //static route
        public async Task<IActionResult> Signup([FromBody] SignUpInputDTO input)
        {
            string message = "";
            try
            {
                //validate input 
                if (ValidationHelper.IsValidPassword(input.Password) && ValidationHelper.IsValidEmail(input.Email) &&
                    ValidationHelper.IsValidName(input.FullName) && ValidationHelper.IsValidBirthDate(input.BirthDate) &&
                    ValidationHelper.IsValidNationalPhoneNumber(input.PhoneNumber) && ValidationHelper.IsValidUserName(input.UserName))
                {
                    string connectionString = "Data Source=DESKTOP-7QLOIQ2\\SQLEXPRESS;Initial Catalog=\"E-Single Restaurant Management System\";Integrated Security=True;Trust Server Certificate=True";
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("sp_RegisterUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Full_Name", input.FullName);
                    command.Parameters.AddWithValue("@UserName", input.UserName);
                    command.Parameters.AddWithValue("@Birth_Date", input.BirthDate);
                    command.Parameters.AddWithValue("@Email", input.Email);
                    command.Parameters.AddWithValue("@Phone_Number", input.PhoneNumber);
                    command.Parameters.AddWithValue("@PasswordHash", input.Password);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result > 0)
                        return StatusCode(201, "Your Account Has Been Created!");
                    else
                        return StatusCode(400, "Failed to Create Account");

                }
                return StatusCode(400, "Failed to Create Account");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }
        }
        [HttpPost]
        [Route("login")] //static route
        public async Task<IActionResult> Login([FromBody] LoginInputDTO input)
        {
            var User = new LoginOutputDTO();
            try
            {
                if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
                    throw new Exception("Email and Password are required ");
                string connectionString = "Data Source=DESKTOP-7QLOIQ2\\SQLEXPRESS;Initial Catalog=\"E-Single Restaurant Management System\";Integrated Security=True;Trust Server Certificate=True";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("sp_LoginUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", input.Email);
                command.Parameters.AddWithValue("@PasswordHash", input.Password);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User.UserId = Convert.ToInt32(reader["UserId"]);
                        User.Role_Id = Convert.ToInt32(reader["Role_Id"]);
                        User.FullName = reader["Full_Name"].ToString();
                        User.Email = reader["Email"].ToString();
                        User.PhoneNumber = reader["Phone_Number"].ToString();
                        User.UserName = reader["UserName"].ToString();
                    }
                    else
                    {
                        throw new Exception("Failed to Login! Incorrect Email or Password!"); // Invalid login
                    }
                }
                connection.Close();

                var response = new
                {
                    Message = $"Welcome {User.UserName}",
                    User = User
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }
        }

        [HttpPost("send-OTP")]
        public async Task<IActionResult> SendOTP(SendOTPInputDTO input)
        {
            try
            {
                // 1. generating the otp
                string otp = new Random().Next(11111, 99999).ToString();
                input.OTPCode = otp;
                input.ExpireOTP = DateTime.Now.AddMinutes(5); // otp expires after 5 minutes

                // 2. storing the otp in the database
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QLOIQ2\\SQLEXPRESS;Initial Catalog=\"E-Single Restaurant Management System\";Integrated Security=True;Trust Server Certificate=True"))
                {
                    SqlCommand sendOtpCmd = new SqlCommand("SendOTP", conn);
                    sendOtpCmd.CommandType = CommandType.StoredProcedure;
                    sendOtpCmd.Parameters.AddWithValue("@Email", input.Email);
                    sendOtpCmd.Parameters.AddWithValue("@OTPCode", input.OTPCode);
                    sendOtpCmd.Parameters.AddWithValue("@ExpireOTP", input.ExpireOTP); // add column to db?

                    conn.Open();
                    var result = sendOtpCmd.ExecuteNonQuery();
                    conn.Close();

                    if (result > 0)
                        return Ok("OTP Sent Successfully");
                    else
                        throw new Exception("Failed to Send OTP");
                }
                //3.send the otp to the user via email can be done using the same service as the JWT, that is implemented in the OTPHelper class

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO input)
        {
            try { 
                if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.NewPasswordHash) || string.IsNullOrWhiteSpace(input.OTPCode))
                return BadRequest("Missing data.");

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QLOIQ2\\SQLEXPRESS;Initial Catalog=\"E-Single Restaurant Management System\";Integrated Security=True;Trust Server Certificate=True");
                SqlCommand resetPwdCmd = new SqlCommand("ResetSuperAdminPassword", conn);
                resetPwdCmd.CommandType = CommandType.StoredProcedure;
                resetPwdCmd.Parameters.AddWithValue("@Email", input.Email);
                resetPwdCmd.Parameters.AddWithValue("@NewPasswordHash", input.NewPasswordHash);
                resetPwdCmd.Parameters.AddWithValue("@OTPCode", input.OTPCode.ToString());

                conn.Open();
                var result2 = resetPwdCmd.ExecuteNonQuery();
                if (!(result2 > 0))
                    throw new Exception("Can not reset password!");
                else
                    return Ok("Password Reset Successfully.");
                conn.Close();

                return Ok(result2);
 
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

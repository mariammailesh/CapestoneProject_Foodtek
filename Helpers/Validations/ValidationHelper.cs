using System.Text.RegularExpressions;

namespace CapestoneProject.Helpers.Validations
{
    public static class ValidationHelper
    {
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length <= 8 || password.Length >= 16)
                throw new Exception("Password Is Required");

            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
            if (!regex.IsMatch(password))
                throw new Exception("Password must be at least 8 characters long and contain uppercase, lowercase, number, and special character.");
            return true;
        }
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) || name.Length > 100)
                throw new Exception("Name Is Required And Should not be more than 50 character");
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    throw new Exception("Name is required and need to be an array of character and white spaces!");
            }
            return true;
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email Is  Required");

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            if (atIndex < 1 || dotIndex < atIndex + 2 || dotIndex >= email.Length - 2)
                throw new Exception("Email Is  Required");

            string domain = email.Substring(atIndex + 1, dotIndex - atIndex - 1);
            string extension = email.Substring(dotIndex + 1);

            if (domain.Length < 2 || extension.Length < 2)
                throw new Exception("Email Is  Required");

            foreach (char c in email.Substring(0, atIndex))
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '%' && c != '+' && c != '-')
                    throw new Exception("Email Is  Required");
            }

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regex.IsMatch(email))
                throw new Exception("Invalid email format!");

            var allowedDomains = new[] { "gmail.com", "hotmail.com", "outlook.com", "zoho.com" };
            var dmn = email.Split('@').Last().ToLower();

            if (!allowedDomains.Contains(dmn))
                throw new Exception("Invalid email format or unsupported domain! Use gmail, hotmail, outlook, yahoo, or zoho.");

            return true;
        }
        public static bool IsValidBirthDate(DateTime? birthDate)
        {
            if (!birthDate.HasValue) 
                throw new Exception("BirthDate Is Required");

            var today = DateTime.Today;
            var age = today.Year - birthDate.Value.Year;

            if (birthDate.Value.Date > today.AddYears(-age)) age--;

            return (age >= 16 ? true : throw new Exception("You must be at least 16 years old to sign up."));
        }

        public static bool IsValidNationalPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrEmpty(phone))
                throw new Exception("Phone Number Is Required");

            var regex = new Regex(@"^+9627[7-9][0-9]{7}$"); // Starts with +96277, +96278, or +96279
            if (!regex.IsMatch(phone))
                throw new Exception("Phone number must be a valid Jordanian number (e.g., +96279xxxxxxx).");
            return true;
        }


        public static bool IsValidUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new Exception("UserName Is Required");

            var regex = new Regex("^[A-Za-z]+$");
            if (!regex.IsMatch(userName))
                throw new Exception("Username must contain only English letters without spaces or symbols.");
            return true;
        }

    }
}

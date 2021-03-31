using System;
using System.Linq;
using System.Security.Cryptography;


namespace Model.Validation
{
    public class PasswordValidation
    {
        public string ValidatePasswordRegistration(string password, string repeatPassword)
        {
            string errorMessage = null;
            errorMessage += ValidatePasswordLength(password);
            errorMessage += ValidatePasswordComparison(password, repeatPassword);
            return errorMessage;
        }
        public string ValidatePasswordSignIn(string hashedPassword, string password)
        {
            string errorMessage = null;
            errorMessage = ValidatePasswordLength(password);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }
            
            if (!VerifyHashedPassword(hashedPassword, password))
            {
                return "Incorrect password.";
            }
            return null;
        }


        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return buffer3.SequenceEqual(buffer4);
        }

        private string ValidatePasswordLength(string password)
        {
            if (String.IsNullOrEmpty(password) || password.Length < 6)
                return "Password must be at least 6 characters.";
            return null;
        }

        private string ValidatePasswordComparison(string password, string repeatPassword)
        {
            if (password != repeatPassword)
                return "Different passwords.";
            return null;
        }
    }
}

using Model.Validation.Exceptions;
using System;
using System.Linq;
using System.Security.Cryptography;


namespace Model.Validation
{
    public class PasswordValidation
    {
        public void ValidatePasswordRegistration(string password, string repeatPassword)
        {
            ValidatePasswordLength(password);
            ComparePasswords(password, repeatPassword);
        }

        public void ValidatePasswordSignIn(string hashedPassword, string password)
        {
            ValidatePasswordLength(password);
            ValidateHashedPassword(hashedPassword, password);
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

        private void ValidatePasswordLength(string password)
        {
            int minLength = 6;
            if (String.IsNullOrEmpty(password) || password.Length < minLength)
            {
                throw new InvalidPasswordLengthException(minLength);
            }
        }

        private void ValidateHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                throw new InvalidPasswordException();
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            if (!buffer3.SequenceEqual(buffer4))
            {
                throw new InvalidPasswordException();
            }
        }

        private void ComparePasswords(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                throw new ComparePasswordsException();
            }
        }
    }
}

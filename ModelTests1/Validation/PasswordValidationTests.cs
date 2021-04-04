using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Validation;
using Model.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation.Tests
{
    [TestClass()]
    public class PasswordValidationTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ComparePasswordsException))]
        [DataRow("Password", "Password123")]
        public void ValidatePasswordRegistration_PasswordsNotEqual_ExpectedException(string pass, string repeatPass)
        {
            PasswordValidation passValidation = new PasswordValidation();
            passValidation.ValidatePasswordRegistration(pass, repeatPass);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidPasswordLengthException))]
        public void ValidatePasswordRegistration_InvalidPasswordLength_ExpectedException()
        {
            string password = "Pass";
            string repeatPassword = "Pass";
            PasswordValidation passValidation = new PasswordValidation();

            passValidation.ValidatePasswordRegistration(password, repeatPassword);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidPasswordLengthException))]
        public void ValidatePasswordRegistration_PasswordIsNull_ExpectedException()
        {
            string password = null;
            string repeatPassword = null;
            PasswordValidation passValidation = new PasswordValidation();

            passValidation.ValidatePasswordRegistration(password, repeatPassword);
        }
        //////////////////////
        //////////////////////

        [TestMethod()]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void ValidatePasswordSignIn_IncorrectPassword_ExpectedException()
        {
            string password = "IncorrectPass";
            string hashedPassword = "AK9nU0aKRgFjO89TDAvrvD7SWVjrTiXp3ldNp3mlLgknF3+vjxRCK/NZOCberCkljQ=="; //Ff-117
            PasswordValidation passValidation = new PasswordValidation();

            passValidation.ValidatePasswordSignIn(hashedPassword, password);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidPasswordLengthException))]
        public void ValidatePasswordSignIn_InvalidPassvordLength_ExpectedException()
        {
            string password = "Pass";
            string hashedPassword = "AK9nU0aKRgFjO89TDAvrvD7SWVjrTiXp3ldNp3mlLgknF3+vjxRCK/NZOCberCkljQ=="; //Ff-117
            PasswordValidation passValidation = new PasswordValidation();

            passValidation.ValidatePasswordSignIn(hashedPassword, password);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidPasswordLengthException))]
        public void ValidatePasswordSignIn_PasswordIsNull_ExpectedException()
        {
            string password = null;
            string hashedPassword = "AK9nU0aKRgFjO89TDAvrvD7SWVjrTiXp3ldNp3mlLgknF3+vjxRCK/NZOCberCkljQ=="; //Ff-117
            PasswordValidation passValidation = new PasswordValidation();

            passValidation.ValidatePasswordSignIn(hashedPassword, password);
        }
    }
}
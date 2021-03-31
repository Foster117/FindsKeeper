using Model.Database;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class UserValidation
    {
        AppDbContext _context = new AppDbContext();

        public string ValidateUserNameRegistration(string name)
        {
            string errorMessage = null;
            errorMessage += ValidateUserNameLength(name);
            errorMessage += CheckUserNameInDB(name);
            return errorMessage;
        }

        public string ValidateUserNameSignIn(string name)
        {
            string errorMessage = null;
            errorMessage += ValidateUserNameLength(name);
            errorMessage += SearchUserNameInDB(name);
            return errorMessage;
        }

        private string ValidateUserNameLength(string name)
        {
            if (String.IsNullOrEmpty(name) || name.Length < 2)
                return "Name must be at least 2 characters.";
            return null;
        }

        private string CheckUserNameInDB(string name)
        {
            User findedUser;
            using (_context = new AppDbContext())
            {
                findedUser = (from user in _context.Users
                              where user.Name == name
                              select user).FirstOrDefault();
            }
            if (findedUser == null)
                return null;
            else
                return "This name is already taken.";
        }
        private string SearchUserNameInDB(string name)
        {
            User findedUser;
            using (_context = new AppDbContext())
            {
                findedUser = (from user in _context.Users
                              where user.Name == name
                              select user).FirstOrDefault();
            }
            if (findedUser != null)
                return null;
            else
                return "User with this name is not registered.";
        }
    }
}

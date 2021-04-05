using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CurrentUser
    {
        private static CurrentUser _currentUser = null;
        public delegate void UserStateHandler(bool isLogged);
        public static event UserStateHandler UserStateNotify; 
        public string UserName { get; set; }
        public int UserId { get; set; }
        public bool IsLogged
        {
            get
            {
                if (_currentUser != null)
                    return true;
                return false;
            }
        }

        private CurrentUser(int userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }

        public static string GetUserName()
        {
            if (_currentUser != null)
            {
                return _currentUser.UserName;
            }
            return null;
        }
        public static void Login(User user)
        {
            if (_currentUser == null)
            {
                _currentUser = new CurrentUser(user.Id, user.Name);
                UserStateNotify?.Invoke(true);
            }
        }
        public static void Logout()
        {
            _currentUser = null;
            UserStateNotify?.Invoke(false);
        }
    }
}

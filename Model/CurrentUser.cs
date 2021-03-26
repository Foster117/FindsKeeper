using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class CurrentUser
    {
        private static CurrentUser _currentUser;
        public string UserName { get; set; }
        public int UserId { get; set; }

        private CurrentUser(int userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }

        public static CurrentUser GetUser(int userId, string userName)
        {
            if (_currentUser == null)
                _currentUser = new CurrentUser(userId, userName);
            return _currentUser;
        }
        public static void RemoveUser()
        {
            if (_currentUser != null)
                _currentUser = null;
        }
    }
}

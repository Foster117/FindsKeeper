using Model.Application.Users;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByName(string name);
    }
}

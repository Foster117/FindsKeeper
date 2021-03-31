using Model.Application.Users;
using Model.Database;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public void AddUser(User user)
        {
            using (_context = new AppDbContext())
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public User GetUserByName(string name)
        {
            User findedUser;
            using (_context = new AppDbContext())
            {
                findedUser = (from user in _context.Users
                              where user.Name == name
                              select user).FirstOrDefault();
            }
            return findedUser;
        }
    }
}

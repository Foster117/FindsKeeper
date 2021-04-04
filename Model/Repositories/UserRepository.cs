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
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByName(string name)
        {
            User findedUser = (from user in _context.Users
                               where user.Name == name
                               select user).FirstOrDefault();
            return findedUser;
        }
    }
}

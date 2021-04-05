using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
//using Rhino.Mocks;
using Model.Database;
using Model.Database.Models;
using System.Data.Entity;

namespace Model.Repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        [TestMethod()]
        public void AddUser_ValidUser_UserSaved()
        {
            // Arrange
            User newUser = new User() { Name = "Vasya", Password = "Password" };
            Mock<DbSet<User>> users = new Mock<DbSet<User>>();
            Mock<AppDbContext> mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Users).Returns(users.Object);
            UserRepository userRepo = new UserRepository(mockContext.Object);
            
            // Act
            userRepo.AddUser(newUser);

            // Assert
            users.Verify(m => m.Add(newUser), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        ////////////////////////////////
        ////////////////////////////////

        [TestMethod()]
        public void GetUserByName_ExistingUserName_UserInstanceExpected()
        {
            // Arrange
            string nameToSearch = "Popbob";
            User expected = new User() { Name = "Popbob", Password = "Pass2" };
            IQueryable<User> users = new List<User>
            {
                new User () { Name = "Nagibator", Password = "Pass" },
                new User () { Name = "AgentSmith", Password = "Pass1" },
                expected
            }.AsQueryable();
            Mock<DbSet<User>> usersTable = new Mock<DbSet<User>>();
            DbSetUsersMockSetup(usersTable, users);
            Mock<AppDbContext> mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Users).Returns(usersTable.Object);
            UserRepository userRepo = new UserRepository(mockContext.Object);

            // Act
            User actual = userRepo.GetUserByName(nameToSearch);

            // Assert
            Assert.AreSame(expected, actual);
        }

        [TestMethod()]
        public void GetUserByName_NonExistentUserName_NullExpected()
        {
            // Arrange
            string nameToSearch = "Frodo";
            var users = new List<User>
            {
                new User () { Name = "T1000", Password = "Pass" },
                new User () { Name = "JohnConnor", Password = "Pass1" },
                new User () { Name = "T800", Password = "Pass2" }
            }.AsQueryable();
            Mock<DbSet<User>> usersTable = new Mock<DbSet<User>>();
            DbSetUsersMockSetup(usersTable, users);
            Mock<AppDbContext> mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Users).Returns(usersTable.Object);
            UserRepository userRepo = new UserRepository(mockContext.Object);

            // Act
            User foundUser = userRepo.GetUserByName(nameToSearch);

            // Assert
            Assert.IsNull(foundUser);
        }


        private void DbSetUsersMockSetup(Mock<DbSet<User>> mock, IQueryable<User> collection)
        {
            mock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(collection.Provider);
            mock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(collection.Expression);
            mock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(collection.ElementType);
            mock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(collection.GetEnumerator());
        }
    }
}
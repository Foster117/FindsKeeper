using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Database.Models;
using Moq;
using Rhino.Mocks;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model.Database;
using Model.Application.Finds;

namespace Model.Repositories.Tests
{
    [TestClass()]
    public class FindRepositoryTests
    {
        [TestMethod()]
        public void GetFindById_ExistentId_DetailedFindModelInstanceExpected()
        {
            // Arrange
            int idToSearch = 2;
            DetailedFindModel foundFind;
            IQueryable<Find> finds = GetQueryableFindsList();
            Mock<DbSet<Find>> findsTable = new Mock<DbSet<Find>>();
            SetupDbSetFindsMock(findsTable, finds);
            Mock<AppDbContext> mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Finds).Returns(findsTable.Object);
            FindRepository findsRepo = new FindRepository(mockContext.Object);

            // Act
            foundFind = findsRepo.GetFindById(idToSearch);

            // Assert
            Assert.AreEqual(idToSearch, foundFind.Id);
        }

        [TestMethod()]
        public void GetFindById_NonExistentId_NullExpected()
        {
            // Arrange
            int idToSearch = 9;
            DetailedFindModel foundFind;
            IQueryable<Find> finds = GetQueryableFindsList();
            Mock<DbSet<Find>> findsTable = new Mock<DbSet<Find>>();
            SetupDbSetFindsMock(findsTable, finds);
            Mock<AppDbContext> mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Finds).Returns(findsTable.Object);
            FindRepository findsRepo = new FindRepository(mockContext.Object);

            // Act
            foundFind = findsRepo.GetFindById(idToSearch);

            // Assert
            Assert.IsNull(foundFind);
        }
        //////////////////////// 
        //////////////////////// 

        [TestMethod()]
        public void GetFindsPage_CorrectInputData_PagingResultInstanceExpected()
        {
            // Arrange
            int pageSize = 5;
            int offset = 0;
            PagingResult<List<FindsQuickViewModel>> expected;
            IQueryable<Find> finds = GetQueryableFindsList();
            Mock<DbSet<Find>> findTable = new Mock<DbSet<Find>>();
            SetupDbSetFindsMock(findTable, finds);
            int expectedTotalCount = findTable.Object.Count();
            Mock<AppDbContext> mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Finds).Returns(findTable.Object);
            FindRepository findRepo = new FindRepository(mockContext.Object);

            // Act
            expected = findRepo.GetFindsPage(pageSize, offset);

            // Assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(pageSize, expected.Items.Count);
            Assert.AreEqual(expectedTotalCount, expected.TotalCount);
        }


        //////////////////////// 
        //////////////////////// 
        private IQueryable<Find> GetQueryableFindsList()
        {
            return new List<Find>
            {
                new Find() { Id = 1, Name = "CopperRing", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 2, Name = "Coin", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 3, Name = "Aureus", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 4, Name = "Sword", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 5, Name = "15 kop", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 6, Name = "Fibula", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 7, Name = "Cross", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } },
                new Find() { Id = 8, Name = "Iron Axe", Preview = new FindImage(), Material = new Material(), Period = new Period(), Description = "Descr", User = new User(), UploadDate = DateTime.Now, Images = new List<FindImage>() { new FindImage() } }
            }.AsQueryable();
        }
        private void SetupDbSetFindsMock(Mock<DbSet<Find>> mock, IQueryable<Find> findsList)
        {
            mock.As<IQueryable<Find>>().Setup(m => m.Provider).Returns(findsList.Provider);
            mock.As<IQueryable<Find>>().Setup(m => m.Expression).Returns(findsList.Expression);
            mock.As<IQueryable<Find>>().Setup(m => m.ElementType).Returns(findsList.ElementType);
            mock.As<IQueryable<Find>>().Setup(m => m.GetEnumerator()).Returns(findsList.GetEnumerator());
        }
    }
}
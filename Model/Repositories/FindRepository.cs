using Model.Application.Finds;
using Model.Database.Models;
using Model.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Model.Repositories
{
    public class FindRepository : IFindRepository
    {
        private AppDbContext _context;

        public PagingResult<List<FindsQuickViewModel>> GetFindsPage(int pageSize, int offset)
        {
            List<FindsQuickViewModel> selectedFinds = GetFindsFromDatabase(pageSize, offset);
            int totalCount = GetTotalFindsCount();
            return new PagingResult<List<FindsQuickViewModel>>(selectedFinds, totalCount, offset);
        }

        public DetailedFindModel GetFindById(int id)
        {
            DetailedFindModel findById;
            using (_context = new AppDbContext())
            {
                findById = (from find in _context.Finds
                            where find.Id == id
                            select new DetailedFindModel()
                            {
                                Preview = find.Preview.ImageData,
                                Name = find.Name,
                                Material = find.Material.Name,
                                Period = find.Period.Name,
                                User = find.User.Name,
                                Description = find.Description,
                                UploadDate = find.UploadDate,
                                Images = find.Images
                            }).FirstOrDefault();
            }
            return findById;
        }

        public void AddFind()
        {
            throw new NotImplementedException();
        }
        public void RemoveFind()
        {
            throw new NotImplementedException();
        }
        public void UpdateFind()
        {
            throw new NotImplementedException();
        }


        private List<FindsQuickViewModel> GetFindsFromDatabase(int pageSize, int offset)
        {
            using (_context = new AppDbContext())
            {
                IQueryable<FindsQuickViewModel> finds = from find in _context.Finds
                                                        orderby find.UploadDate
                                                        select new FindsQuickViewModel
                                                        {
                                                            Id = find.Id,
                                                            Name = find.Name,
                                                            User = find.User.Name,
                                                            Period = find.Period.Name,
                                                            Material = find.Material.Name,
                                                            UploadDate = find.UploadDate,
                                                            Preview = find.Preview.ImageData
                                                            
                                                        };
                return finds.Skip(offset).Take(pageSize).ToList();
            }
        }
        private int GetTotalFindsCount()
        {
            using (_context = new AppDbContext())
            {
                return _context.Finds.OrderBy(f => f.UploadDate).Count();
            }
        }
    }
}

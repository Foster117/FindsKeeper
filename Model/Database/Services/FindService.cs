using Model.Application.Finds;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Model.Database.Services
{
    public class FindService : IFindService
    {
        private AppDbContext _context;

        public PagingResult<List<FindsQuickViewModel>> GetFindsPage(int pageSize, int offset)
        {
            List<FindsQuickViewModel> selectedFinds = GetFindsFromDatabase(pageSize, offset);
            int totalCount = GetTotalFindsCount();
            return new PagingResult<List<FindsQuickViewModel>>(selectedFinds, totalCount, offset);
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
                                                        join period in _context.Periods on find.PeriodId equals period.Id
                                                        join material in _context.Materials on find.MaterialId equals material.Id
                                                        join user in _context.Users on find.UserId equals user.Id
                                                        orderby find.UploadDate
                                                        select new FindsQuickViewModel
                                                        {
                                                            Id = find.Id,
                                                            Name = find.Name,
                                                            User = user.Name,
                                                            Period = period.Name,
                                                            Material = material.Name,
                                                            UploadDate = find.UploadDate
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

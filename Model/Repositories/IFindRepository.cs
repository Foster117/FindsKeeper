using Model.Application.Finds;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Repositories
{
    public interface IFindRepository
    {
        PagingResult<List<FindsQuickViewModel>> GetFindsPage(int pageSize, int offset);
        DetailedFindModel GetFindById(int id);
        void AddFind();
        void RemoveFind();
        void UpdateFind();
    }
}

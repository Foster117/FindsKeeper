using Model.Application.Finds;
using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Database.Services
{
    public interface IFindService
    {
        PagingResult<List<FindsQuickViewModel>> GetFindsPage(int pageSize, int offset);
        void AddFind();
        void RemoveFind();
        void UpdateFind();
    }
}

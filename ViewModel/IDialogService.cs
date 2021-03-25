using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Application.Finds;

namespace ViewModel
{
    public interface IDialogService
    {
        void OpenWindow(object dataContext);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface IClosable
    {
        Action CloseAction { get; set; }
    }
}

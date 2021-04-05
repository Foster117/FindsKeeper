using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public interface IImageRepository
    {
        byte[] MakeFindPreview(string path);
        byte[] MakeFindImage(string path);
    }
}

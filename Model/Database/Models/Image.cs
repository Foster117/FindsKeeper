using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
    }
}

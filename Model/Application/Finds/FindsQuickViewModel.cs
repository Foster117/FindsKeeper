using Model.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Application.Finds
{
    public class FindsQuickViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Period { get; set; }
        public string Material { get; set; }
        public DateTime UploadDate { get; set; }
        public byte[] Preview { get; set; }
    }
}

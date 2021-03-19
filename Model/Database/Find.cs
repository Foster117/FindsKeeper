using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Database
{
    public class Find
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public DateTime UploadDate { get; set; }
        public string Description { get; set; }
        public byte[] Preview { get; set; }
        public byte[] Photo1 { get; set; }
        public byte[] Photo2 { get; set; }
    }
}

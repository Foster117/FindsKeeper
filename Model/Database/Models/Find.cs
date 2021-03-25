using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Database.Models
{
    public class Find
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public DateTime UploadDate { get; set; }
        public string Description { get; set; }
        public FindImage Preview { get; set; }
        public List<FindImage> Images { get; set; }
    }
}

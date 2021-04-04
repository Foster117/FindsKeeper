using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Model.Database.Models;

namespace Model.Database
{
    public class AppDbContext : DbContext
    {
        static AppDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }
        public AppDbContext() : base("DBConnection")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Find> Finds { get; set; }
        public virtual DbSet<FindImage> Images { get; set; }
    }
}

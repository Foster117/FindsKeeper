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
        public DbSet<User> Users { get; set; } 
        public DbSet<Material> Materials { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Find> Finds { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}

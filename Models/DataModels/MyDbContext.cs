using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaiTap.Models.DataModels
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base ("name=Access")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext,Migrations.Configuration>("Access"));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
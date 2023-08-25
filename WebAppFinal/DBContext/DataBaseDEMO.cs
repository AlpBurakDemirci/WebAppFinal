using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using WebAppFinal.Models;

namespace WebAppFinal.DataBase

{
    public class DataBaseDEMO : DbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<School> Okullar { get; set; }
        public DbSet<Food> Yiyecekler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=C:\Users\abdd2\source\repos\WebAppFinal\WebAppFinal\DataBase\DataBaseWebAppFinal.db");
        
    }
}

using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarDemoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarDemo;Trusted_Connection=true");
        }//hangi veri tabanı
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }//hangi tablolar
        public DbSet<Brand> Brands { get; set; }
    }
}

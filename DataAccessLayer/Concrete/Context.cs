using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=DESKTOP-M927P0K\\SQLEXPRESS ; database=DbPagedList ;Trusted_Connection=True; Encrypt=False;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

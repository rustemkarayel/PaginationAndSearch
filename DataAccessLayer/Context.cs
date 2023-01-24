using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=ServerName ; database=DbPagedList-SearchBar ;Trusted_Connection=True; Encrypt=False;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

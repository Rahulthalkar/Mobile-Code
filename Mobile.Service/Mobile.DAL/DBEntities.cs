using Microsoft.EntityFrameworkCore;
using Mobile.Domain.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.DAL
{
    public class DBEntities:DbContext
    {
        public string ConnectionString { get; set; }
        public DBEntities(string connectionString)
        { 
            ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DBEntities(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<tblDropdown> Dropdowns { get; set; }
        public DbSet<tblUser> Users { get; set; }
    }
}

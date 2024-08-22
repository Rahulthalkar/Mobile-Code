using Microsoft.EntityFrameworkCore;
using Mobile.Domain.Table;

namespace Mobile.DB
{
    public class MobileDBContext:DbContext
    {
        public string ConnectionString { get; }

        public MobileDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public MobileDBContext(DbContextOptions <MobileDBContext>options) : base(options)
        {
        }
        public DbSet<tblDropdown> Dropdowns { get; set; }
        public DbSet<tblUser> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Web_Service.Models
{
    public class FootballFieldsdbMainContext : DbContext
    {
        public FootballFieldsdbMainContext()
        {
        }

        public DbSet<FootballFieldInfo> FootballFields { get; set; }

        public FootballFieldsdbMainContext(DbContextOptions<FootballFieldsdbMainContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();           
        }
    }
}
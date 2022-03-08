using Microsoft.EntityFrameworkCore;

namespace BulkInsertUsingEntityFrameworkCoreSample.Models
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<GuidKeyModel> GuidKeyModels { get; set; }
        public DbSet<IntKeyModel> IntKeyModels { get; set; }
    }
}

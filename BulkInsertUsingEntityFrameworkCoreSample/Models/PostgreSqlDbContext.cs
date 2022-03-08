using Microsoft.EntityFrameworkCore;

namespace BulkInsertUsingEntityFrameworkCoreSample.Models
{
    public class PostgreSqlDbContext : DbContext
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<GuidKeyModel> GuidKeyModels { get; set; }
        public DbSet<IntKeyModel> IntKeyModels { get; set; }
    }
}
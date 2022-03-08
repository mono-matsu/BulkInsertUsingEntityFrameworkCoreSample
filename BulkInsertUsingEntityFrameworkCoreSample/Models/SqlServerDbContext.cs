using Microsoft.EntityFrameworkCore;

namespace BulkInsertUsingEntityFrameworkCoreSample.Models
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {
        }

        public DbSet<GuidKeyModel> GuidKeyModels { get; set; }
        public DbSet<IntKeyModel> IntKeyModels { get; set; }
    }
}
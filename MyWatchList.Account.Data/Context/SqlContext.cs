using Microsoft.EntityFrameworkCore;
using MyWatchList.Account.Data.Mappings;

namespace MyWatchList.Account.Data.Context
{
    public class SqlContext : DbContext
    {
        public DbSet<Domain.Domain.Account> Accounts { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Domain.Account>(new AccountMapping().Configure);
        }
    }
}

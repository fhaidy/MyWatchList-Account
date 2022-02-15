using Microsoft.EntityFrameworkCore;
using MyWatchList.Account.Data.Mappings;

namespace MyWatchList.Account.Data.Context
{
    public class AccountContext : DbContext
    {
        public DbSet<Domain.Domain.Account> Accounts { get; set; }

        public AccountContext() { }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=accounts;Uid=sa;Pwd=Sqlsa!23");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
        }
    }
}

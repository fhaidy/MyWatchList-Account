using Microsoft.EntityFrameworkCore;

namespace MyWatchList.Account.Data.Context
{
    public class ContextFactory : DbContext
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var conn = "Server=localhost,1433;Database=accounts;Uid=sa;Pwd=Sqlsa!23";
            var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
            optionsBuilder.UseSqlServer(conn);
            return new SqlContext(optionsBuilder.Options);
        }
    }
}

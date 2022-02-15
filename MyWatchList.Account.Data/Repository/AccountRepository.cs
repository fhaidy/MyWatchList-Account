using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWatchList.Account.Data.Context;

namespace MyWatchList.Account.Data.Repository
{
    public class AccountRepository
    {
        private readonly AccountContext _context;
        private readonly DbSet<Domain.Domain.Account?> _accounts;

        public AccountRepository(AccountContext context)
        {
            _context = context;
            _accounts = _context.Set<Domain.Domain.Account>();
        }

        public async Task<Domain.Domain.Account?> InsertAsync(Domain.Domain.Account account)
        {
            if (account.Id == Guid.Empty)
                account.Id = Guid.NewGuid();

            account.CreationDate = DateTime.UtcNow;

            _accounts.Add(account);
            
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Domain.Domain.Account?> SelectByEmail(string email)
        {
            return await _accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user != null && user.Email == email);
        }
    }
}

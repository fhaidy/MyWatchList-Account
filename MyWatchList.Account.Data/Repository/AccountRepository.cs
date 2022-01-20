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
        private readonly SqlContext _context;
        private readonly DbSet<Domain.Domain.Account> _accounts;

        public AccountRepository(SqlContext context)
        {
            _context = context;
            _accounts = _context.Set<Domain.Domain.Account>();
        }

        public async Task<Domain.Domain.Account> InsertAsync(Domain.Domain.Account account)
        {
            if (account.Id == Guid.Empty)
                account.Id = Guid.NewGuid();

            account.CreationDate = DateTime.Now;

            _accounts.Add(account);
            
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Domain.Domain.Account> SelectAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id), "Id is Empty");

            return await _accounts.SingleOrDefaultAsync(item => item.Id.Equals(id));
        }

    }
}

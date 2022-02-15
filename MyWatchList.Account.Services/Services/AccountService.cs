using MyWatchList.Account.Data.Repository;

namespace MyWatchList.Account.Services.Services
{
    public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService(AccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Domain.Account?> GetByEmail(string email)
        {
            return await _repository.SelectByEmail(email);
        }

        public async Task<Domain.Domain.Account?> Post(Domain.Domain.Account obj)
        {
            return await _repository.InsertAsync(obj);
        }
    }
}

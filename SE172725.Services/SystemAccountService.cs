using SE172725.Repositories;
using SE172725.Repositories.Models;

namespace SE172725.Services
{
    public class SystemAccountService
    {
        private readonly SystemAccountRepository _repository;
        public SystemAccountService()
        {
            _repository = new SystemAccountRepository();
        }

        public async Task<SystemAccount> GetUserAccountAsync(string userName, string password)
        {
            return await _repository.GetAccountAsync(userName, password);
        }
    }
}

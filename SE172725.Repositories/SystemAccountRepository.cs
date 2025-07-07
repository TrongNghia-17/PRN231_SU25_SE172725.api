using Microsoft.EntityFrameworkCore;
using SE172725.Repositories.DBContext;
using SE172725.Repositories.Models;

namespace SE172725.Repositories
{
    public class SystemAccountRepository
    {
        private readonly Summer2025HandbagDbContext _context;

        public SystemAccountRepository()
        {
            _context ??= new DBContext.Summer2025HandbagDbContext();
        }

        public async Task<SystemAccount> GetAccountAsync(string userName, string password)
        {
            return await _context
                .SystemAccounts
                .FirstOrDefaultAsync(x => x.Email == userName && x.Password == password && x.IsActive == true);
        }
    }
}

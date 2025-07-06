using SE172725.Repositories;
using SE172725.Repositories.Models;

namespace SE172725.Services
{
    public class HandbagService : IHandbagService
    {
        private readonly HandbagRepository _handbagRepository;

        public HandbagService()
        {
            _handbagRepository = new HandbagRepository();
        }

        public async Task<List<Handbag>> GetAllAsync()
        {
            return await _handbagRepository.GetAllAsync();
        }
    }
}

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

        public Task<int> CreateAsync(Handbag request)
        {
            return _handbagRepository.CreateAsync(request);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _handbagRepository.GetByIdAsync(id);
            return await _handbagRepository.RemoveAsync(item);
        }

        public async Task<List<Handbag>> GetAllAsync()
        {
            return await _handbagRepository.GetAllAsync();
        }

        public async Task<Handbag> GetByIdAsync(int id)
        {
            return await _handbagRepository.GetByIdAsync(id);
        }

        public async Task<List<Handbag>> SearchAllAsync(string modelName, string material)
        {
            return await _handbagRepository.SearchAsync(modelName, material);
        }

        public Task<int> UpdateAsync(Handbag request)
        {
            return _handbagRepository.UpdateAsync(request);
        }
    }
}

using SE172725.Repositories;
using SE172725.Repositories.Models;
using SE172725.Services.DTOs;

namespace SE172725.Services
{
    public class HandbagService : IHandbagService
    {
        private readonly HandbagRepository _handbagRepository;

        public HandbagService()
        {
            _handbagRepository = new HandbagRepository();
        }

        public Task<int> CreateAsync(HandbagRequest request)
        {
            var handbag = new Handbag
            {
                ModelName = request.ModelName,
                Material = request.Material,
                Price = request.Price,
                Stock = request.Stock,
                BrandId = request.BrandId
            };

            return _handbagRepository.CreateAsync(handbag);
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

        public Task<int> UpdateAsync(HandbagRequest request)
        {
            var handbag = new Handbag
            {
                ModelName = request.ModelName,
                Material = request.Material,
                Price = request.Price,
                Stock = request.Stock,
                BrandId = request.BrandId
            };

            return _handbagRepository.UpdateAsync(handbag);
        }
    }
}

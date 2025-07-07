using SE172725.Repositories.Models;
using SE172725.Services.DTOs;

namespace SE172725.Services
{
    public interface IHandbagService
    {
        Task<List<Handbag>> GetAllAsync();
        Task<Handbag> GetByIdAsync(int id);
        Task<int> CreateAsync(HandbagRequest request);
        Task<int> UpdateAsync(HandbagRequest request);
        Task<bool> DeleteAsync(int id);
    }
}

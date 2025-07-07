using SE172725.Repositories.Models;

namespace SE172725.Services
{
    public interface IHandbagService
    {
        Task<List<Handbag>> GetAllAsync();
        Task<Handbag> GetByIdAsync(int id);
        Task<int> CreateAsync(Handbag request);
        Task<int> UpdateAsync(Handbag request);
        Task<bool> DeleteAsync(int id);
        Task<List<Handbag>> SearchAllAsync(string modelName, string material);
    }
}

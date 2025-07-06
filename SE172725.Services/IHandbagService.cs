using SE172725.Repositories.Models;

namespace SE172725.Services
{
    public interface IHandbagService
    {
        Task<List<Handbag>> GetAllAsync();
    }
}

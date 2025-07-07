using Microsoft.EntityFrameworkCore;
using SE172725.Repositories.Basic;
using SE172725.Repositories.DBContext;
using SE172725.Repositories.Models;

namespace SE172725.Repositories
{
    public class HandbagRepository : GenericRepository<Handbag>
    {
        private readonly Summer2025HandbagDbContext _context;

        public HandbagRepository()
        {
            _context = new DBContext.Summer2025HandbagDbContext();
        }

        public async Task<List<Handbag>> GetAllAsync()
        {
            var item = await _context
                .Handbags
                .Include(x => x.Brand)
                .ToListAsync();

            return item ?? new List<Handbag>();
        }

        public async Task<Handbag> GetByIdAsync(int id)
        {
            var item = await _context
                .Handbags
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.HandbagId == id);

            return item ?? new Handbag();
        }

        public async Task<List<Handbag>> SearchAsync(string modelName, string material)
        {
            var item = await _context
                .Handbags
                .Include(x => x.Brand)
                .Where(x =>
                (
                    (x.ModelName.Contains(modelName) || string.IsNullOrEmpty(modelName)) 
                    && (x.Material.Contains(material) || string.IsNullOrEmpty(material)) 
                ))
                .ToListAsync(); 

            return item ?? new List<Handbag>();
        }
    }
}

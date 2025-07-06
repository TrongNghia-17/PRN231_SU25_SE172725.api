using Microsoft.EntityFrameworkCore;
using SE172725.Repositories.DBContext;
using SE172725.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE172725.Repositories
{
    public class HandbagRepository
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
    }
}

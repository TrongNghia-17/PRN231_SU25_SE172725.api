using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SE172725.Repositories.Models;
using SE172725.Services;

namespace PRN231_SU25_SE172725.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandbagsController : ControllerBase
    {
        private readonly IHandbagService _handbagService;

        public HandbagsController(IHandbagService handbagService)
        {
            _handbagService = handbagService;
        }

        [HttpGet("/api/handbags")]
        //[Authorize(Roles = "1, 2")]
        public async Task<IEnumerable<Handbag>> Get()
        {
            return await _handbagService.GetAllAsync();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "1, 2")]
        public async Task<Handbag> Get(int id)
        {
            return await _handbagService.GetByIdAsync(id);
        }

        [HttpPost]
        [Authorize(Roles = "1, 2")]
        public async Task<int> Post([FromBody] Handbag request)
        {
            return await _handbagService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<int> Put([FromBody] Handbag request)
        {
            return await _handbagService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<bool> Delete(int id)
        {
            return await _handbagService.DeleteAsync(id);
        }

        [HttpGet("search")]
        [EnableQuery]
        //[Authorize(Roles = "1, 2")]
        public async Task<List<Handbag>> SearchAll([FromQuery] string? modelName, [FromQuery] string? material)
        {
            return await _handbagService.SearchAllAsync(modelName, material);
        }
    }
}

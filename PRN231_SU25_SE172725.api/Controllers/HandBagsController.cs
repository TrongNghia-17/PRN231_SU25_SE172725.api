using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE172725.Repositories.Models;
using SE172725.Services;
using SE172725.Services.DTOs;

namespace PRN231_SU25_SE172725.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandBagsController : ControllerBase
    {
        private readonly IHandbagService _handbagService;

        public HandBagsController(IHandbagService handbagService)
        {
            _handbagService = handbagService;
        }

        [HttpGet]
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
        //[Authorize(Roles = "1, 2")]
        public async Task<int> Post(HandbagRequest request)
        {
            return await _handbagService.CreateAsync(request);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "1, 2")]
        public async Task<int> Put(HandbagRequest request)
        {
            return await _handbagService.UpdateAsync(request);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "1")]
        public async Task<bool> Delete(int id)
        {
            return await _handbagService.DeleteAsync(id);
        }
    }
}

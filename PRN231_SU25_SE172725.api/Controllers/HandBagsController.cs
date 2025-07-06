using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE172725.Repositories.Models;
using SE172725.Services;

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
    }
}

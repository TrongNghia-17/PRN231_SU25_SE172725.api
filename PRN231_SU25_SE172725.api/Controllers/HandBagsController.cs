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
        public async Task<IActionResult> Get()
        {
            try
            {
                var handbags = await _handbagService.GetAllAsync();
                return Ok(handbags);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("HB50001", "Internal server error: " + ex.Message));
            }
        }

        [HttpGet("/api/handbags/{id}")]
        //[Authorize(Roles = "1, 2")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var handbag = await _handbagService.GetByIdAsync(id);
                if (handbag == null || handbag.HandbagId == 0)
                {
                    return NotFound(new ErrorResponse("HB40401", "Resource not found"));
                }
                return Ok(handbag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("HB50001", "Internal server error: " + ex.Message));
            }
        }

        [HttpPost("/api/handbags")]
        [Authorize(Roles = "1, 2")]
        public async Task<IActionResult> Post([FromBody] Handbag request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).FirstOrDefault();
                    return BadRequest(new ErrorResponse("HB40001", errors ?? "Missing/invalid input"));
                }

                var id = await _handbagService.CreateAsync(request);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("HB50001", "Internal server error: " + ex.Message));
            }
        }

        [HttpPut("/api/handbags/{id}")]
        [Authorize(Roles = "1, 2")]
        public async Task<IActionResult> Put([FromBody] Handbag request, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).FirstOrDefault();
                    return BadRequest(new ErrorResponse("HB40001", errors ?? "Missing/invalid input"));
                }

                var existingHandbag = await _handbagService.GetByIdAsync(id);
                if (existingHandbag == null || existingHandbag.HandbagId == 0)
                {
                    return NotFound(new ErrorResponse("HB40401", "Resource not found"));
                }

                request.HandbagId = id;
                var result = await _handbagService.UpdateAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("HB50001", "Internal server error: " + ex.Message));
            }
        }

        [HttpDelete("/api/handbags/{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _handbagService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new ErrorResponse("HB40401", "Resource not found"));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("HB50001", "Internal server error: " + ex.Message));
            }
        }

        [HttpGet("search")]
        [EnableQuery]
        //[Authorize(Roles = "1, 2")]
        public async Task<List<Handbag>> SearchAll([FromQuery] string? modelName, [FromQuery] string? material)
        {
            return await _handbagService.SearchAllAsync(modelName, material);
        }
    }

    public record ErrorResponse(string ErrorCode, string Message);
}

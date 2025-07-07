using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SE172725.Repositories.Models;
using SE172725.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PRN231_SU25_SE172725.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAccountsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SystemAccountService _systemAccountsService;

        public SystemAccountsController(IConfiguration config, SystemAccountService userAccountsService)
        {
            _config = config;
            _systemAccountsService = userAccountsService;     //// Add DJ
        }

        [HttpPost("/api/auth")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _systemAccountsService.GetUserAccountAsync(request.Email, request.Password);

            if (user == null || user.Result == null)
                return Unauthorized();

            var token = GenerateJSONWebToken(user.Result);

            string role = user.Result.Role switch
            {
                1 => "administrator",
                2 => "moderator",
                3 => "developer",
                _ => "member"
            };

            var response = new LoginResponse(token, role);

            return Ok(response);
        }

        private string GenerateJSONWebToken(SystemAccount systemAccount)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                    , _config["Jwt:Audience"]
                    , new Claim[]
                    {
                new(ClaimTypes.Name, systemAccount.Username),
                //new(ClaimTypes.Email, systemUserAccount.Email),
                new(ClaimTypes.Role, systemAccount.Role.ToString()),
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public sealed record LoginRequest(string Email, string Password);
        public sealed record LoginResponse(string Token, string Role);
    }
}

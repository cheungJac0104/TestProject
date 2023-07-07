using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestProject.Context;
using TestProject.Models;
using TestProject.Services.Staff;

namespace TestProject.Controllers.v1.auth
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;
		private readonly AppDBContext _db;
        private readonly IStaffServices _staffServices;
        private readonly IConfiguration _configuration;
		public AuthController(ILogger<AuthController> logger, AppDBContext db, IConfiguration configuration, IStaffServices staffServices)
		{
			_logger = logger;
			_db = db;
            _configuration = configuration;
            _staffServices = staffServices;
        }
        [ApiVersion("1.0")]
        [HttpPost("Login")]
		[AllowAnonymous]
        public IActionResult Login([FromBody] StaffQuery login)
		{
            var user = _staffServices.FindStaffAsync(login);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.USERNAME),
                    new Claim(JwtRegisteredClaimNames.Email, user.EMAIL),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtOptions:Key"] ?? ""));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtOptions:ExpiryDays"]));

                var token = new JwtSecurityToken(
                    _configuration["JwtOptions:Issuer"],
                    _configuration["JwtOptions:Audience"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expires
                });
            }

            return Unauthorized();
        }
    }
}


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestProject.Context;
using TestProject.MessageQueue.Interfaces;
using TestProject.MessageQueue.Messages;
using TestProject.Middleware.AppSettingsOptions;
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
        private readonly IRabbitMQHandler _rabbitMQHandler;
        private readonly JwtOptions _jwtOptions;
		public AuthController(
            ILogger<AuthController> logger,
            AppDBContext db,
            IStaffServices staffServices,
            IOptions<JwtOptions> jwtOptions,
            IRabbitMQHandler rabbitMQHandler)
		{
			_logger = logger;
			_db = db;
            _jwtOptions = jwtOptions.Value;
            _staffServices = staffServices;
            _rabbitMQHandler = rabbitMQHandler;
        }
        [ApiVersion("1.0")]
        [HttpPost("Login")]
		[AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] StaffQuery login)
		{
            try
            {
                var user = _staffServices.FindStaffAsync(login);

                if (user != null)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Name, user.USERNAME),
                    new Claim(JwtRegisteredClaimNames.Typ, user.STAFF_TYPE),
                    new Claim(JwtRegisteredClaimNames.Email, user.EMAIL),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtOptions.ExpiryDays));

                    var token = new JwtSecurityToken(
                        _jwtOptions.Issuer,
                        _jwtOptions.Audience,
                        claims,
                        expires: expires,
                        signingCredentials: creds
                    );

                    var resultToken = new JwtSecurityTokenHandler().WriteToken(token);

                    var loginTokenMessage = new LoginTokenMessage()
                    {
                        SenderId = Guid.NewGuid(),
                        SenderName = user.USERNAME,
                        Token = resultToken,
                        ExpiryDate = expires
                    };

                    var senderId = await _rabbitMQHandler.SendLoginToken(loginTokenMessage);

                    return Ok(loginTokenMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            
            return Unauthorized();
        }


        [ApiVersion("1.0")]
        [HttpGet("CheckLogin")]
        public async Task<IActionResult> CheckLogin()
        {
            await _rabbitMQHandler.ReceiveLoginToken();
            return Ok();
        }
    }
}


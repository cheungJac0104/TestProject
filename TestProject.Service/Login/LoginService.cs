using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestProject.EntityFrameworkCore.Domain;
using TestProject.Infrastructure;
using TestProject.Services;

namespace TestProject.Service.Login
{
    public class LoginService : ILoginService
    {
        private readonly AppSetting _appSettings;

        public LoginService(IOptions<AppSetting> appSettings)  {
            _appSettings = appSettings.Value;
        }

        public  Task<ResponseDto> Login(LoginReq loginReq) {
            return Task.Run(() =>
            {
                if (loginReq.Account == "test" && loginReq.Pwd == "test")
                    return ResponseDto.ReturnFail(msg: "Login Failed");

                var userInfo = new UserInfo
                {
                    Id = "123213sdfsdf",
                    UserRole = "client"
                };
                 
                var token = generateJwtToken(userInfo);
                 
                var loginUser = new LoginUserDto
                {
                    UserInfo = userInfo,
                    Token = token
                };

                return ResponseDto.ReturnSuccess(obj: loginUser);
            });
        }

        private string generateJwtToken(UserInfo user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.TokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()),new Claim("role", user.UserRole.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ResponseDto LoginOut() {
                return ResponseDto.ReturnSuccess();
        }
    }
}

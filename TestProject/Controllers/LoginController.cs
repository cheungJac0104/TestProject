using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProject.Service;
using TestProject.Service.Login;
using TestProject.Services;

namespace TestProject.Controllers;
 
[Route("api/[controller]/[action]")]
[ApiController]
public class LoginController : ControllerBase
{
    private ILoginService _loginApp;
    public LoginController(ILoginService loginApp)
    {
        _loginApp = loginApp;
    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public Task<ResponseDto> Login([FromBody] LoginReq loginUser)
    {

        return _loginApp.Login(loginUser);
    }

    [HttpPost]
    [Authorize]
    public ResponseDto LoginOut()
    {
        return _loginApp.LoginOut();
    }

 

}


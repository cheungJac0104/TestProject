

using TestProject.Service;
using TestProject.Service.Login;

namespace TestProject.Services
{
    public interface ILoginService
    {
        Task<ResponseDto> Login(LoginReq loginReq);
        public ResponseDto LoginOut();
    }
}

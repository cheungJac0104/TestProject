using System.ComponentModel.DataAnnotations;


namespace TestProject.Service.Login
{
    public class LoginReq
    {
        [Required(ErrorMessage ="登录账户不能为空")]
        public string Account { get; set; }

        [Required(ErrorMessage = "登录密码不能为空")]
        public string Pwd { get; set; }
    }
}

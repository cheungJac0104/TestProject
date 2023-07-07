using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.EntityFrameworkCore.Domain;
using TestProject.Infrastructure;

namespace TestProject.Service.Login
{
    public class LoginUserDto
    {
        /// <summary>
        /// 登录用户信息
        /// </summary>
        public UserInfo UserInfo { get; set; } = new UserInfo();
 

        public string Token { get; set; }
        public DateTime Validtime { get; set; }
    }
}

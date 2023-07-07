using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProject.EntityFrameworkCore.Domain
{
    /// <summary>
    /// 登录账户表
    /// </summary>
    [Table("loginaccount")]
    public class LoginAccount:BaseEntity
    {

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// 登录账户
        /// </summary>
        public string Account { get; set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; } = string.Empty;
        /// <summary>
        /// 账户类型
        /// </summary>
        public int Usertype { get; set; } = 0;

        /// <summary>
        /// /账户状态;1启用2禁用3锁定
        /// </summary>
        public int Status { get; set; } = 0;
    }
}

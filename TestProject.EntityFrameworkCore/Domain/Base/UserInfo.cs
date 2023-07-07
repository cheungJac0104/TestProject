using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProject.EntityFrameworkCore.Domain
{
    [Table("userinfo")]
    public class UserInfo: BaseEntity
    {

        public string UnionId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public int Gender { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Phone { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        /// <summary>
        /// 1启用2禁用3锁定
        /// </summary>
        public int Status { get; set; } = 0;
        public string OpenId { get; set; } = string.Empty;
        public bool IsSubscribe { get; set; } = false;
    }
}

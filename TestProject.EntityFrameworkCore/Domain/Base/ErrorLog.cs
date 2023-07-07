using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProject.EntityFrameworkCore.Domain
{
    [Table("errorlog")]
    public class ErrorLog:BaseEntity
    {
        public string Message { get; set; }=string.Empty;

        /// <summary>
        /// 级别
        /// </summary>
        public int Level;

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; } = string.Empty;
        /// <summary>
        /// 错误内容
        /// </summary>
        [Column(TypeName = "text")]
        public string Content { get; set; } = string.Empty;
      
        public string Ip { get; set; } = string.Empty;

    }
}

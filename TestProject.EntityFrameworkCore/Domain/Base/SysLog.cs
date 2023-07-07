using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProject.EntityFrameworkCore.Domain
{
    [Table("syslog")]
    public class SysLog : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
       
        public string Operator { get; set; } = string.Empty;
        
        public string Ip { get; set; } = string.Empty;

        [Column(TypeName = "text")]
        public string Content { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProject.EntityFrameworkCore
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string ModifyUser { get; set; }

        public DateTime? ModifyTime { get; set; }



    }
}

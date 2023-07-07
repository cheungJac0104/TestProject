using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Infrastructure
{
    public class AppSetting
    {

        public string TokenKey { get; set; }       

        /// <summary>
        /// 数据库类型 SqlServer、MySql
        /// </summary>
        public string DbType { get; set; }

        public string UploadPath { get; set; }
        public string FileFormatAddress { get; set; }


     

    }
}

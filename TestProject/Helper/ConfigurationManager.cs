using TestProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using static TestProject.Helper.GlobalVar;

namespace TestProject.Helper
{
    //custom IConfiguration
    public static class ConfigurationManager
    {
            
        public static string currentConnectionString = "";
        public static string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static enumSource currentConnectionType = enumSource.WEBAPI;
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(currentPath)
                    .AddJsonFile("Settings/appsettings.json") // your path here
                    .Build();

            int _iConnectionType = 0;
            int.TryParse(AppSetting.GetValue<string>("ConnectionStrings:connectionType"), out _iConnectionType);
            currentConnectionType = (enumSource)_iConnectionType;
        }



        public static dynamic getDBConnection () 
        {

            if (currentConnectionType == enumSource.WEBAPI)
            {
                var _connectionString = AppSetting.GetValue<string>("ConnectionStrings:connection");
                return new MysqlDBContext(_connectionString);
            }
            if (currentConnectionType == enumSource.MEDIKARE_V1)
            {
                var _connectionString = AppSetting.GetValue<string>("ConnectionStrings:connection");
                return new FirebirdlDBContext(_connectionString);
            }
            if (currentConnectionType == enumSource.MEDIKARE_V3)
            {
                var _connectionString = AppSetting.GetValue<string>("ConnectionStrings:connection");
                return new MysqlDBContext(_connectionString);
            }

            return null;

        }

    }
}

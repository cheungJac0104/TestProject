
namespace TestProject.Helper
{
    public static class GlobalVar
    {
        public const string CONST_BUCKET_NAME = "report";
        public const string CONST_TEMP_FOLDER = "StaticFiles/Images";
        public const string CONST_FOLDER_PATH = "StaticFiles";
        public const string CONST_IMAGE_FOLDER = "Images";

        public enum enumSource : int
        {
            WEBAPI = 0,
            MEDIKARE_V1 = 1,
            MEDIKARE_V3 = 2,
        }
         
    }



}

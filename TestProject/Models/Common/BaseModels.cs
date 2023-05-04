using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestProject.Models
{
    //API Standard Response
    public class ApiResponse
    {
        public string version { get; set; } = "20200130";
        public bool isNew { get; set; } = false;
        public int total { get; set; } = 0;
        public string message { get; set; } = string.Empty;

#nullable enable
        public ApiError? err { get; set; }
#nullable disable

        public List<dynamic> data { get; set; } = new List<dynamic>();
    }

    //API Standard Response 
    public class ApiError
    {
        public string message { get; set; } = string.Empty;
        public bool hasError { get; set; } = true;

        public ApiError(string _message = "")
        {
            message = _message;
        }
    }

    public class ApiQuery
    {
        public int qPage { get; set; } = 1;
        public int qPageSize { get; set; } = 10;
    }

    public class ExcelResponse : ApiResponse
    {
        public List<string> excelHeaders { get; set; } = new List<string>();
    }

    public class DatabaseFields
    {
        [Key]
        [StringLength(20)]
        [JsonPropertyName("recordIdx")]
        public string RECORD_IDX { get; set; }
#nullable enable
        [StringLength(50)]
        public string? CREATEBY { get; set; }
        [StringLength(50)]
        public string? CREATEDATE { get; set; }
        [StringLength(50)]
        public string? MODIFYBY { get; set; }
        [StringLength(50)]
        public string? MODIFYDATE { get; set; }
        public int? ISDELETE { get; set; } = 0;
        public int? ISACTIVE { get; set; } = 1;
        [StringLength(10)]
        [JsonPropertyName("clinicCode")]
        public string? CLINIC_CODE { get; set; }
        [JsonPropertyName("isPhysicalDelete")]
        public int? IS_PHYSICAL_DELETE { get; set; }

        protected Dictionary<string, dynamic> _ToJson()
        {
            Dictionary<string, dynamic> map = new Dictionary<string, dynamic>();
            map["recordIdx"] = RECORD_IDX;
            map["createby"] = CREATEBY;
            map["createdate"] = CREATEDATE;
            map["modifyby"] = MODIFYBY;
            map["modifydate"] = MODIFYDATE;
            map["isdelete"] = ISDELETE;
            map["isactive"] = ISACTIVE;
            map["clinicCode"] = CLINIC_CODE;
            map["isPhysicalDelete"] = IS_PHYSICAL_DELETE;
            return map;
        }
#nullable disable
    }
}

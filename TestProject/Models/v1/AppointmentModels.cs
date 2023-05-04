using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class AppointmentQuery : ApiQuery
    {
#nullable enable
        public string? recordIdx { get; set; }
        public string? status { get; set; }
        public string? appDatetime { get; set; }
        public string? arrDatetime { get; set; }
#nullable disable

    }

    public class AppointmentPostBody
    {
        public int isNewPatient { get; set; }

        public DateTime appDatetime { get; set; }
        public string arrDatetime { get; set; }

        public string status { get; set; }
    }


    [Table("M_APPOINTMENT")]
    public class MAppointment : DatabaseFields
    {

#nullable enable
        public int? IS_NEW_PATIENT { get; set; }
        [StringLength(50)]
        public string? STATUS { get; set; }
        public int? ISHELD { get; set; }
        [StringLength(20)]
        public string? CASE_ID { get; set; }
        public DateTime APP_DATETIME { get; set; }
        [StringLength(100)]
        public string? ARR_DATETIME { get; set; }
        public int? CASE_NUM { get; set; }
        [StringLength(1000)]
        public string? CASE_REMARK { get; set; }
#nullable disable

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["isNewPatient"] = IS_NEW_PATIENT;
            map["status"] = STATUS;
            map["isheld"] = ISHELD;
            map["caseId"] = CASE_ID;
            map["appDatetime"] = APP_DATETIME.ToString();
            map["arrDatetime"] = ARR_DATETIME;
            map["caseNum"] = CASE_NUM;
            map["caseRemark"] = CASE_REMARK;
            return map;
        }

    }
}

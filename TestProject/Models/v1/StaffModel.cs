using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{

    public class StaffQuery
    {
 
        public string? username { get; set; }
        public string? userpassword { get; set; }
   
    }

    [Table("M_STAFF")]
    public class MStaff : DatabaseFields
    {
        [StringLength(20)]
        public string STAFF_TYPE { get; set; }
        [StringLength(20)]
        public string COMPANY_ID { get; set; }
        [StringLength(30)]
        public string USERNAME { get; set; }
        [StringLength(220)]
        public string USERPW { get; set; }
        [StringLength(50)]
        public string ENAME { get; set; }
        [StringLength(50)]
        public string CNAME { get; set; }
        [StringLength(50)]
        public string TITLE { get; set; }
        [StringLength(50)]
        public string CTITLE { get; set; }
        [StringLength(50)]
        public string TEL { get; set; }
        [StringLength(50)]
        public string MOBILE { get; set; }
        [StringLength(150)]
        public string EMAIL { get; set; }
        [StringLength(20)]
        public string CONSULTATION_CASE_DEFAULT { get; set; }

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["staffType"] = STAFF_TYPE;
            map["companyId"] = COMPANY_ID;
            map["username"] = USERNAME;
            map["ename"] = ENAME;
            map["cname"] = CNAME;
            map["title"] = TITLE;
            map["ctitle"] = CTITLE;
            map["mobile"] = MOBILE;
            map["patientId"] = EMAIL;
            map["consultationCaseDefault"] = CONSULTATION_CASE_DEFAULT;
            return map;
        }
    }

 




}

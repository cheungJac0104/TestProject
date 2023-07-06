using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class PatientQuery : ApiQuery
    {
        [Key]
#nullable enable
        public string? recordIdx { get; set; }
        public string? patientId { get; set; }
        public string? patientIdRegExp { get; set; }
        public string? keyword { get; set; }
#nullable disable

    }

    public class PatientPostBody
    {
        public string ename { get; set; }
        public string cname { get; set; }
        public string hkid { get; set; }

        public string dob { get; set; }
        public string gender { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public string reg_date { get; set; }
    }


    [Table("M_PATIENT_INFO")]
    public class MPatientInfo : DatabaseFields
    {
        [StringLength(20)]
        public string PID { get; set; }
        [StringLength(20)]
        public string DOCTOR_ID { get; set; }
        [StringLength(20)]
        public string COMPANY_ID { get; set; }
        [StringLength(30)]
        public string PATIENT_CODE { get; set; }

        [StringLength(250)]
        public string ENAME { get; set; }


#nullable enable
        [StringLength(100)]
        public string? HKID { get; set; }
        [StringLength(250)]
        public string? CNAME { get; set; }
        [StringLength(100)]
        public string? DOB { get; set; }
        public int? DOB_YEAR { get; set; }
        public int? DOB_MONTH { get; set; }
        public int? DOB_DAY { get; set; }
        [StringLength(15)]
        public string? GENDER { get; set; }
        [StringLength(10)]
        public string? BLOODTYPE { get; set; }
        [StringLength(200)]
        public string? OCCUPATION { get; set; }
        [StringLength(400)]
        public string? CONTACT { get; set; }
        [StringLength(100)]
        public string? TEL1 { get; set; }
        [StringLength(100)]
        public string? TEL2 { get; set; }
        [StringLength(100)]
        public string? MOBILE { get; set; }
        [StringLength(200)]
        public string? EMAIL { get; set; }
        [StringLength(250)]
        public string? ADDRESS1 { get; set; }
        [StringLength(250)]
        public string? ADDRESS2 { get; set; }
        [StringLength(250)]
        public string? ADDRESS3 { get; set; }
        [StringLength(100)]
        public string? REG_DATE { get; set; }
        [StringLength(1000)]
        public string? REMARK { get; set; }

        public string? PAYMENT_METHOD { get; set; }

        public string? ID_TYPE { get; set; }
        [StringLength(250)]
        public string? ESURNAME { get; set; }
        [StringLength(250)]
        public string? CSURNAME { get; set; }
        [StringLength(250)]
        public string? EGIVENNAME { get; set; }
        [StringLength(250)]
        public string? CGIVENNAME { get; set; }
        public int? ISNOTICE { get; set; }
        [StringLength(1000)]
        public string? DRUG_ALLERGY { get; set; }
        [StringLength(100)]
        public string? COLOR { get; set; }
        public string? PAYMENT_METHOD_ENAME { get; set; }

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["pid"] = PID;
            map["doctorId"] = DOCTOR_ID;
            map["companyId"] = COMPANY_ID;
            map["patientCode"] = PATIENT_CODE;
            map["ename"] = ENAME;
            map["cname"] = CNAME;
            map["hkid"] = HKID;
            map["dob"] = DOB;
            map["dobYear"] = DOB_YEAR;
            map["dobMonth"] = DOB_MONTH;
            map["dobDay"] = DOB_DAY;
            map["gender"] = GENDER;
            map["bloodtype"] = BLOODTYPE;
            map["occupation"] = OCCUPATION;
            map["contact"] = CONTACT;
            map["tel1"] = TEL1;
            map["tel2"] = TEL2;
            map["mobile"] = MOBILE;
            map["email"] = EMAIL;
            map["address1"] = ADDRESS1;
            map["address2"] = ADDRESS2;
            map["address3"] = ADDRESS3;
            map["regDate"] = REG_DATE;
            map["remark"] = REMARK;
            map["idType"] = ID_TYPE;
            map["esurname"] = ESURNAME;
            map["csurname"] = CSURNAME;
            map["egivenname"] = EGIVENNAME;
            map["cgivenname"] = CGIVENNAME;
            map["isnotice"] = ISNOTICE;
            map["drugAllergy"] = DRUG_ALLERGY;
            map["color"] = COLOR;
            map["paymentMethod"] = PAYMENT_METHOD;
            map["paymentMethodEname"] = PAYMENT_METHOD_ENAME;
            return map;
        }
#nullable disable

    }
}

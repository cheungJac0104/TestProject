using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{

    public class PatientQueueQuery : ApiQuery
    {
        [Key]
        #nullable enable
        public string? recordIdx { get; set; }
        public string? patientRecordIdx { get; set; }
        public string? status { get; set; }
        public string? appDate { get; set; }
        public string? appDatetime { get; set; }
        public string? arrDatetime { get; set; }
        public string? doctorId { get; set; }
#nullable disable

    }


    public class PatientQueue : DatabaseFields
    {
        [Key]
        #nullable enable
        public int? IS_NEW_PATIENT { get; set; }
        public string? STATUS { get; set; }
        public int? ISHELD { get; set; }
        public string? CASE_ID { get; set; }
        public DateTime? APP_DATETIME { get; set; }
        public string? ARR_DATETIME { get; set; }
        public int? CASE_NUM { get; set; }
        public string? CASE_REMARK { get; set; }

        // from M_EVENT
        public string? DOCTOR_ID { get; set; }

        // from M_PATIENT_INFO
        public string? PATIENT_RECORD_IDX { get; set; }
        public string? PID { get; set; }
        public string? PATIENT_CODE { get; set; }
        public string? ENAME { get; set; }
        public string? CNAME { get; set; }
        public string? HKID { get; set; }
        public string? DOB { get; set; } 
        public int? DOB_YEAR { get; set; }
        public int? DOB_MONTH { get; set; }
        public int? DOB_DAY { get; set; }
        public string? GENDER { get; set; }
        public string? BLOODTYPE { get; set; }
        public string? REG_DATE { get; set; }
        public string? REMARK { get; set; }
        public string? ID_TYPE { get; set; }
        public string? ESURNAME { get; set; }
        public string? CSURNAME { get; set; }
        public string? EGIVENNAME { get; set; }
        public string? CGIVENNAME { get; set; }
        public string? OCCUPATION { get; set; }
        public string? CONTACT { get; set; }

        public string? TEL1 { get; set; }
        public string? TEL2 { get; set; }
        public string? MOBILE { get; set; }
        public string? EMAIL { get; set; }
        public string? ADDRESS1 { get; set; }
        public string? ADDRESS2 { get; set; }
        public string? ADDRESS3 { get; set; }
        public string? COLOR { get; set; }
        public string? TITLE { get; set; }
        public string? DESCRIPTION { get; set; }

        public int? ISNOTICE { get; set; }
        public string? DRUG_ALLERGY { get; set; }
        #nullable disable

        public Dictionary<string, dynamic> ToJson() {
            Dictionary<string, dynamic> map = _ToJson();
            map["patientRecordIdx"] = PATIENT_RECORD_IDX;
            map["isNewPatient"] = IS_NEW_PATIENT;
            map["status"] = STATUS;
            map["isheld"] = ISHELD;
            map["caseId"] = CASE_ID;
            map["appDatetime"] = APP_DATETIME.ToString();
            map["arrDatetime"] = ARR_DATETIME;
            map["caseNum"] = CASE_NUM;
            map["caseRemark"] = CASE_REMARK;
            map["doctorId"] = DOCTOR_ID;
            map["patientId"] = PID;
            map["pid"] = PID;
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
            map["regDate"] = REG_DATE;
            map["remark"] = REMARK;
            map["idType"] = ID_TYPE;
            map["esurname"] = ESURNAME;
            map["csurname"] = CSURNAME;
            map["egivenname"] = EGIVENNAME;
            map["cgivenname"] = CGIVENNAME;
            map["occupation"] = OCCUPATION;
            map["contact"] = CONTACT;
            map["tel1"] = TEL1;
            map["tel2"] = TEL2;
            map["mobile"] = MOBILE;
            map["email"] = EMAIL;
            map["address1"] = ADDRESS1;
            map["address2"] = ADDRESS2;
            map["address3"] = ADDRESS3;
            map["color"] = COLOR;
            map["title"] = TITLE;
            map["description"] = DESCRIPTION;
            map["isnotice"] = ISNOTICE;
            map["drugAllergy"] = DRUG_ALLERGY;
            return map;
        }

    }

 


}

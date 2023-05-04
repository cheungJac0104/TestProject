using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{


    [Table("M_EVENT")]
    public class MEvent : DatabaseFields
    {

        public string COMPANY_ID { get; set; }
        public string PATIENT_ID { get; set; }
        public string DOCTOR_ID { get; set; }
        public string MEDICAL_ID { get; set; }

        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string RESOURCES_ID { get; set; }
        public string EVENTCASE_ID { get; set; }

#nullable enable

        public DateTime? DATETIME_START { get; set; }
        public DateTime? DATETIME_END { get; set; }

#nullable disable

    }

 


}

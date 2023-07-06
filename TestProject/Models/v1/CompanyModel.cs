using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{

    [Table("M_COMPANY")]
    public class MCompany : DatabaseFields
    {
        [StringLength(250)]
        public string ENAME { get; set; }
        [StringLength(250)]
        public string CNAME { get; set; }
        [StringLength(2000)]
        public string EADDRESS { get; set; }
        [StringLength(2000)]
        public string CADDRESS { get; set; }
        [StringLength(100)]
        public string TEL1 { get; set; }
        [StringLength(100)]
        public string TEL2 { get; set; }
        [StringLength(50)]
        public string EMAIL1 { get; set; }
        [StringLength(50)]
        public string EMAIL2 { get; set; }
        [StringLength(250)]
        public string WEBSITE { get; set; }
        [StringLength(2000)]
        public string REMARK { get; set; }

    }

 




}

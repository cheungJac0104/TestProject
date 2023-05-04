using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{


    [Table("S_RECORD_IDX")]
    public class SRecordIdx
    {
#nullable enable
        [Key]
        [Column(Order = 0)]
        public int RECORD_IDX { get; set; }
        [StringLength(30)]
        public string TABLENAME { get; set; }
        [StringLength(20)]
        public string INDEX_PREFIX { get; set; }
        public int INDEX_LENGHT { get; set; }
        public int INDEX_LAST_ID { get; set; }
        [StringLength(100)]
        public string? DESCRIPTION { get; set; }
        public int? ISDELETE { get; set; } = 0;
        public int? ISACTIVE { get; set; } = 1;
        [StringLength(5)]
        public string? LOCK_STATUS { get; set; }
#nullable disable
    }





}

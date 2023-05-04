using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{


    [Table("S_DICOM_DB")]
    public class SDicomDB
    {

        [Key]
        public string RECORD_IDX { get; set; }
        [StringLength(50)]
        public string DB_NAME { get; set; }
    }

    //M_PATIENT_FILE_BIN On Dicom DB
    [Table("M_PATIENT_FILE_BIN")]
    public class MPatientFileBinDicom : DatabaseFields
    {
        #nullable enable
        public string? FILE_ID { get; set; } // for webapi
        public byte[]? FILE_BIN { get; set; } // for webapi  not string 
        #nullable disable
    }



}

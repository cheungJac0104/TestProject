using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{

    public class PatientFileQuery : ApiQuery
    {
        [Key]
        #nullable enable
        public string? companyId { get; set; }
        public string? created { get; set; } // UTC timestamp of second
        public string? createDate { get; set; } // string of MM/DD/YYYY hh:mm
        public string? fileDate { get; set; } // string of YYYYMMDD
        public string? patientFileTypeIdx { get; set; }
        public string? modified { get; set; } // UTC timestamp of second
        public string? modifyDate { get; set; } // string of MM/DD/YYYY hh:mm

        public string? recordIdx { get; set; }
        public string? patientId { get; set; }
        public string? patientRecordIdx { get; set; }
                
        public string? isdelete { get; set; }
        public string? isactive { get; set; }
        public string? parentId { get; set; }
        public string? groupId { get; set; }
        public string? userId { get; set; }

#nullable disable

    }



    public class PatientFile : DatabaseFields
    {
      // TODO: join tables for medikare v3 as follows:
      // M_PATIENT_FILE.RECORD_IDX = m_patient_file_locate.FILE_ID &&
      // m_patient_file_locate.HEADER_ID = m_file_header.RECORD_IDX
      // WHERE M_PATIENT_FILE.PATIENT_ID = patientId

      // TODO: join tables for medikare v1 as follows:
      // M_PATIENT_FILE.RECORD_IDX = m_patient_file_bin.FILE_ID &&
      // WHERE M_PATIENT_FILE.PATIENT_ID = patientId
        [Key]
#nullable enable
        public string? PATIENT_ID { get; set; }
        public string? PARENT_ID { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? FILE_TYPE { get; set; }
        public string? DATE_UPLOADED { get; set; }
        public string? DATE_MODIFIED { get; set; }        
        public string? FILE_BIN_TYPE { get; set; }
        public string? FILE_OPEN_TYPE { get; set; }
        public string? GROUP_ID { get; set; }
        public string? DICOM_DB_ID { get; set; }


        // FROM M_PATIENT_FILE_LOCATE (medikare v3) 
        public string? HEADER_ID { get; set; }
        public string? FILE_DATE { get; set; }
        public string? FILE_PID { get; set; }
        public string? FILE_NAME { get; set; }
        public string? FILE_EXT { get; set; }
        public string? FILE_THUMBNAILNAME { get; set; }

        // FROM M_FILE_HEADER
        public string? HEADER_TYPE { get; set; }
        public string? FILE_PREFIX { get; set; }
        public string? WEB_PATH { get; set; }
        public string? WEB_THUMBNAILPATH { get; set; }
#nullable disable


        public Dictionary<string, dynamic> ToJson() {
            Dictionary<string, dynamic> map = _ToJson();
            map["dicomDbId"] = DICOM_DB_ID;
            map["patientId"] = PATIENT_ID;
            //map["headerType"] = HEADER_TYPE;
            map["fileName"] = FILE_NAME;
            map["fileType"] = FILE_TYPE;
            map["dateUploaded"] = DATE_UPLOADED;
            map["dateModified"] = DATE_MODIFIED;
            //map["filePrefix"] = FILE_PREFIX;
            map["webPath"] = WEB_PATH;
            map["webThumbnailPath"] = WEB_THUMBNAILPATH;

            // dynamic create this downloadUrl based on M_file_header values
            // if (DICOM_DB_ID == "WEBAPI") { // webapi
            //   map["downloadUrl"] = $"{WEB_PATH}/webapi/{PATIENT_ID}/{FILE_NAME}";  // http://webapi/api/v1/patientFileLocate/webapi/{fileDir}/{fileObj}
            // } else if (DICOM_DB_ID == null || DICOM_DB_ID == "") { // Medikare V3
            //   map["downloadUrl"] = WEB_PATH + "smb" + FILE_PREFIX + HEADER_TYPE + PATIENT_ID + FILE_NAME; // http://webapi/api/v1/patientFileLocate/smb/?filePrefix={filePrefix}&headerType={headerType}&patientId={patientId}&fileName={fileName}
            // } else { // Medikare V1
            //   map["downloadUrl"] = $"{WEB_PATH}/dicom/{DICOM_DB_ID}/{RECORD_IDX}"; // http://webapi/api/v1/patientFileLocate/dicom/{dicomDbId}/{fileId}
            // }

            return map;
        }

    }

    [Table("M_PATIENT_FILE_GROUP")]
    public class MPatientFileGroup : DatabaseFields
    {
#nullable enable
        [StringLength(20)]
        public string? PARENT_GROUP { get; set; }
        [StringLength(50)]
        public string? ENAME { get; set; }

        #nullable disable

    }

    [Table("M_PATIENT_FILE")]
    public class MPatientFile : DatabaseFields
    {
#nullable enable
        [StringLength(20)]
        public string? PATIENT_ID { get; set; }
        [StringLength(20)]
        public string? PARENT_ID { get; set; }
        //public string? FILE_ID { get; set; }
        [StringLength(200)]
        public string? FILE_NAME { get; set; }
        [StringLength(20)]
        public string? GROUP_ID { get; set; }
        [StringLength(20)]
        public string? DICOM_DB_ID { get; set; }
        [StringLength(20)]
        public string? FILE_TYPE { get; set; }
        [StringLength(20)]
        public string? DATE_UPLOADED { get; set; }
        [StringLength(20)]
        public string? DATE_MODIFIED { get; set; } 
        [StringLength(20)]
        public string? FILE_BIN_TYPE { get; set; }
        [StringLength(20)]
        public string? FILE_OPEN_TYPE { get; set; }


        // TODO: add other property from M_PATIENT_FILE
#nullable disable


        public PatientFile ToPatientFile() {
          PatientFile _patientFile = new PatientFile();
          _patientFile.RECORD_IDX = RECORD_IDX;
          _patientFile.DICOM_DB_ID = DICOM_DB_ID;
          _patientFile.PATIENT_ID = PATIENT_ID;
          _patientFile.FILE_NAME = FILE_NAME;
          _patientFile.FILE_TYPE = FILE_TYPE;
          _patientFile.DATE_UPLOADED = DATE_UPLOADED;
          _patientFile.DATE_MODIFIED = DATE_MODIFIED;
          _patientFile.CREATEBY = CREATEBY;
          _patientFile.CREATEDATE = CREATEDATE;
          _patientFile.MODIFYBY = MODIFYBY;
          _patientFile.MODIFYDATE = MODIFYDATE;
          _patientFile.ISACTIVE = ISACTIVE;
          _patientFile.ISDELETE = ISDELETE;
          _patientFile.CLINIC_CODE = CLINIC_CODE;

          return _patientFile;
        }

    }

    [Table("M_PATIENT_FILE_BIN")]
    public class MPatientFileBin : DatabaseFields
    {
#nullable enable
        [StringLength(20)]
        public string? FILE_ID { get; set; }
         
#nullable disable

    }





    [Table("M_FILE_HEADER")]
    public class MFileHeader
    {
        [Key]
        [StringLength(20)]
        public string RECORD_IDX { get; set; }

        #nullable enable
        public string? HEADER_TYPE { get; set; }
        [StringLength(120)]
        public string? FILE_PREFIX { get; set; }
        [StringLength(120)]
        public string? WEB_PATH { get; set; }
        public int? ACTIVE { get; set; }
        [StringLength(20)]
        public string? CREATEBY { get; set; }
        [StringLength(10)]
        public string? CLINIC_CODE { get; set; }

        #nullable disable

    }

    [Table("M_PATIENT_FILE_LOCATE")]
    public class MPatientFileLocate : DatabaseFields
    {

        #nullable enable
        [StringLength(20)]
        public string? FILE_ID { get; set; }
        [StringLength(20)]
        public string? HEADER_ID { get; set; }
        [StringLength(50)]
        public string? FILE_DATE { get; set; }
        [StringLength(20)]
        public string? FILE_PID { get; set; }
        [StringLength(150)]
        public string? FILE_NAME { get; set; }
        [StringLength(10)]
        public string? FILE_EXT { get; set; }
        [StringLength(150)]
        public string? FILE_THUMBNAILNAME { get; set; }
        public byte[]? FILE_BIN_TH { get; set; } 
         
        #nullable disable

    }

    [Table("M_PATIENT_FILE_TYPE")]
    public class MPatientFileType : DatabaseFields
    {

#nullable enable
        [StringLength(200)]
        public string? ENAME { get; set; }
        [StringLength(200)]
        public string? CNAME { get; set; }
        [StringLength(500)]
        public string? DESCRIPTION { get; set; }
         
#nullable disable

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["ENAME"] = ENAME;
            map["CNAME"] = CNAME;
            map["DESCRIPTION"] = DESCRIPTION;
            return map;
        }

    }


}

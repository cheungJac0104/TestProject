using TestProject.Models;
using TestProject.Context;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace TestProject.Services
{
    public class PatientQueueServices : IPatientQueueServices
    {
        private readonly AppDBContext _dBContext;
        private readonly ILogger<PatientQueueServices> _logger;
        private readonly IConfiguration _configuration;  

        public PatientQueueServices(AppDBContext dBContext, IConfiguration configuration, ILogger<PatientQueueServices> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<Tuple<List<PatientQueue>, int>> FindAllPatientQueues(PatientQueueQuery query)
        {
            // using (var db = (FirebirdlDBContext)_connection)
            using (var db = this._dBContext)
            {
                try
                {
                    List<PatientQueue> _arr = new List<PatientQueue>();
                    var _totalQuery = from a in db.MAppointment
                                      join e in db.MEvent on a.RECORD_IDX equals e.RECORD_IDX
                                      join p in db.MPatientInfo on e.PATIENT_ID equals p.RECORD_IDX
                                      where (true)
                                        && (String.IsNullOrEmpty(query.recordIdx) ? (true) : (e.RECORD_IDX.Equals(query.recordIdx)))
                                        && (String.IsNullOrEmpty(query.patientRecordIdx) ? (true) : (p.RECORD_IDX.Equals(query.patientRecordIdx)))
                                        && (String.IsNullOrEmpty(query.appDate) ? (true) : (e.DATETIME_START >= DateTime.ParseExact(query.appDate + " 00:00:00", "dd/MM/yyyy HH:mm:ss", null) && e.DATETIME_START < DateTime.ParseExact(query.appDate + " 23:59:59", "dd/MM/yyyy HH:mm:ss", null)))
                                        && (String.IsNullOrEmpty(query.doctorId) ? (true) : (e.DOCTOR_ID.Equals(query.doctorId)))
                                        && (String.IsNullOrEmpty(query.status) ? (true) : (a.STATUS.Equals(query.status)))
                                      select new PatientQueue
                                      {
                                          RECORD_IDX = e.RECORD_IDX,
                                          CREATEBY = e.CREATEBY,
                                          CREATEDATE = e.CREATEDATE,
                                          MODIFYBY = e.MODIFYBY,
                                          MODIFYDATE = e.MODIFYDATE,
                                          ISDELETE = e.ISDELETE,
                                          ISACTIVE = e.ISACTIVE,
                                          CLINIC_CODE = e.CLINIC_CODE,
                                          IS_PHYSICAL_DELETE = e.IS_PHYSICAL_DELETE,
                                          PATIENT_RECORD_IDX = p.RECORD_IDX,
                                          IS_NEW_PATIENT = a.IS_NEW_PATIENT,
                                          STATUS = a.STATUS,
                                          ISHELD = a.ISHELD,
                                          CASE_ID = a.CASE_ID,
                                          APP_DATETIME = e.DATETIME_START,
                                          ARR_DATETIME = a.ARR_DATETIME,
                                          CASE_NUM = a.CASE_NUM,
                                          CASE_REMARK = a.CASE_REMARK,
                                          DOCTOR_ID = e.DOCTOR_ID,
                                          PID = p.PID,
                                          PATIENT_CODE = p.PATIENT_CODE,
                                          ENAME = p.ENAME,
                                          CNAME = p.CNAME,
                                          DOB = p.DOB,
                                          DOB_YEAR = p.DOB_YEAR,
                                          DOB_MONTH = p.DOB_MONTH,
                                          DOB_DAY = p.DOB_DAY,
                                          GENDER = p.GENDER,
                                          BLOODTYPE = p.BLOODTYPE,
                                          REG_DATE = p.REG_DATE,
                                          HKID = p.HKID,
                                          ID_TYPE = p.ID_TYPE,
                                          ESURNAME = p.ESURNAME,
                                          CSURNAME = p.CSURNAME,
                                          EGIVENNAME = p.EGIVENNAME,
                                          CGIVENNAME = p.CGIVENNAME,
                                          OCCUPATION = p.OCCUPATION,
                                          TEL1 = p.TEL1,
                                          TEL2 = p.TEL2,
                                          MOBILE = p.MOBILE,
                                          EMAIL = p.EMAIL,
                                          ADDRESS1 = p.ADDRESS1,
                                          ADDRESS2 = p.ADDRESS2,
                                          ADDRESS3 = p.ADDRESS3,
                                          COLOR = p.COLOR,
                                          TITLE = e.TITLE,
                                          DESCRIPTION = e.DESCRIPTION,
                                          ISNOTICE = p.ISNOTICE,
                                          DRUG_ALLERGY = p.DRUG_ALLERGY
                                      };

                    var total = _totalQuery.Count();
                    
                    if (total == 0)
                    {   
                        throw new KeyNotFoundException($"PatientQueue Record not found - {query.status}");
                    }

                    try
                    {
                      var _resultQuery = _totalQuery.OrderBy(x => x.APP_DATETIME)
                            // .Skip(query.qPageSize * (query.qPage - 1))
                            // .Take(query.qPageSize);
                            .Take(query.qPageSize * query.qPage);

                        
                        _arr = _resultQuery.Cast<PatientQueue>().ToList();
                        return Tuple.Create(_arr, total);
                    }
                    catch (Exception ex)
                    {
                        System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    throw;
                }
            }
        }

 


    }


}

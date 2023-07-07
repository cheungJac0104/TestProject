using System;
using TestProject.Models;
using TestProject.Context;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace TestProject.Services
{
    public class PatientInfoServices : IPatientInfoServices
    {
        private readonly AppDBContext _dBContext;
        private readonly ILogger<PatientInfoServices> _logger;

        public PatientInfoServices(AppDBContext dBContext, ILogger<PatientInfoServices> logger)
        {
            _dBContext = dBContext;
            _logger = logger;


        }

        public async Task<Tuple<List<MPatientInfo>, int>> FindAllPatients(PatientQuery query)
        {

            // var _connection = ConfigurationManager.getDBConnection();
            // using (var db = (FirebirdlDBContext)_connection)
            using (var db = this._dBContext)
            {
                if (query == null)
                {
                    throw new KeyNotFoundException($"missing query, query is null");

                }
                try
                {
                    List<MPatientInfo> _arr = new List<MPatientInfo>();
                    var _totalQuery = from p in db.MPatientInfo
                                      where (true)
                                        && (String.IsNullOrEmpty(query.recordIdx) ? (true) : (p.RECORD_IDX.Equals(query.recordIdx)))
                                        && (String.IsNullOrEmpty(query.patientId) ? (true) : (p.PID.Equals(query.patientId)))
                                        && (String.IsNullOrEmpty(query.patientIdRegExp) ? (true) :
                                        (p.PID.Contains(query.patientIdRegExp)))
                                        && (String.IsNullOrEmpty(query.keyword) ? (true) : (
                                          p.PID.Equals(query.keyword)
                                          || p.PATIENT_CODE.Equals(query.keyword)
                                          || p.ENAME.ToLower().Contains(query.keyword.ToLower())
                                          || p.MOBILE.Contains(query.keyword)
                                        ))

                                      select new MPatientInfo
                                      {
                                          RECORD_IDX = p.RECORD_IDX,
                                          CREATEBY = p.CREATEBY,
                                          CREATEDATE = p.CREATEDATE,
                                          MODIFYBY = p.MODIFYBY,
                                          MODIFYDATE = p.MODIFYDATE,
                                          ISDELETE = p.ISDELETE,
                                          ISACTIVE = p.ISACTIVE,
                                          CLINIC_CODE = p.CLINIC_CODE,
                                          IS_PHYSICAL_DELETE = p.IS_PHYSICAL_DELETE,
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
                                          ISNOTICE = p.ISNOTICE,
                                          DRUG_ALLERGY = p.DRUG_ALLERGY,
                                          PAYMENT_METHOD = p.PAYMENT_METHOD
                                      };


                    var total = _totalQuery.Count();

                    if (total == 0)
                    {
                        throw new KeyNotFoundException($"Patient Record not found - {query.patientId}");
                    }

                    try
                    {
                        List<MPaymentMethod> _paymentMethods = new List<MPaymentMethod>();
                        var _totalQuery1 = db.MPaymentMethod.Where(
                            a => (true)
                        );
                        var _resultQuery1 = _totalQuery1.OrderBy(x => x.RECORD_IDX);
                        _paymentMethods = _resultQuery1.ToList();

                        var _resultQuery = _totalQuery.OrderByDescending(x => x.ENAME)
                            .Skip(query.qPageSize * (query.qPage - 1))
                            .Take(query.qPageSize);
                        _arr = _resultQuery.ToList();
                        _arr.ForEach((p) => {
                            p.PAYMENT_METHOD_ENAME = _LookupPaymentMethodEname(p.PAYMENT_METHOD, _paymentMethods);
                        });
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


        public async Task<MPatientInfo> FindOnePatient(string recordIdx)
        {

            if (recordIdx == null)
            {
                throw new KeyNotFoundException($"No record id");
            }


            // var _connection = ConfigurationManager.getDBConnection();
            // using (var db = (FirebirdlDBContext)_connection)
            using (var db = this._dBContext)
            {
                try
                {
                    // var _result = db.MPatientInfo.Where(a => a.RECORD_IDX == recordIdx);


                    var _totalQuery = from p in db.MPatientInfo
                                      where (p.RECORD_IDX.Equals(recordIdx))

                                      select new MPatientInfo
                                      {
                                          RECORD_IDX = p.RECORD_IDX,
                                          CREATEBY = p.CREATEBY,
                                          CREATEDATE = p.CREATEDATE,
                                          MODIFYBY = p.MODIFYBY,
                                          MODIFYDATE = p.MODIFYDATE,
                                          ISDELETE = p.ISDELETE,
                                          ISACTIVE = p.ISACTIVE,
                                          CLINIC_CODE = p.CLINIC_CODE,
                                          IS_PHYSICAL_DELETE = p.IS_PHYSICAL_DELETE,
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
                                          ISNOTICE = p.ISNOTICE,
                                          DRUG_ALLERGY = p.DRUG_ALLERGY,
                                          PAYMENT_METHOD = p.PAYMENT_METHOD
                                      };

                    var total = _totalQuery.Count();

                    if (total == 0)
                    {
                        throw new KeyNotFoundException($"Patient Record not found - {recordIdx}");
                    }


                    List<MPaymentMethod> _paymentMethods = new List<MPaymentMethod>();
                    var _totalQuery1 = db.MPaymentMethod.Where(
                        a => (true)
                    );
                    var _resultQuery1 = _totalQuery1.OrderBy(x => x.RECORD_IDX);
                    _paymentMethods = _resultQuery1.ToList();

                    var _tmp = _totalQuery.FirstOrDefault();

                    _tmp.PAYMENT_METHOD_ENAME = _LookupPaymentMethodEname(_tmp.PAYMENT_METHOD, _paymentMethods);

                    return _tmp;
                }
                catch (Exception ex)
                {
                    System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    throw;
                }


            }

        }

        public async Task<MPatientInfo> AddOnePatient(PatientPostBody body)
        {
            if (body == null)
            {
                throw new KeyNotFoundException("missing body, body is null");
            }

            try
            {
                using (var db = _dBContext.Database.BeginTransaction())
                {
                    MPatientInfo mPatient = new()
                    {
                        ENAME = body.ename,
                        CNAME = body.cname,
                        EMAIL = body.email,
                        HKID = body.hkid,
                        GENDER = body.gender,
                        ADDRESS1 = body.address,
                        DOB = body.dob,
                        MOBILE = body.mobile,
                        REG_DATE = body.reg_date
                    };

                    var _rtn = _dBContext.MPatientInfo.Add(mPatient);

                    db.Commit();

                    return _rtn.Entity;
                }
            }
            catch (Exception ex)
            {
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }


        }


        private string _LookupPaymentMethodEname(string recordIdx, List<MPaymentMethod> paymentMethods)
        {
            var ename = "";
            paymentMethods.ForEach((pm) => {
                if (pm.RECORD_IDX.Equals(recordIdx))
                {
                    ename = pm.E_NAME;
                }
            });
            return ename;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PatientInfoController : ControllerBase
    {

        private readonly ILogger<PatientInfoController> _logger;
        private readonly IPatientInfoServices _service;

        public PatientInfoController(ILogger<PatientInfoController> logger, IPatientInfoServices service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [ApiVersion("1.0")]
        [HttpGet("{recordIdx}")]
        public async Task<ApiResponse> FindOnePatient(string recordIdx)
        {
            ApiResponse _rtn = new ApiResponse();
            try
            {
                MPatientInfo mPatientInfo = await _service.FindOnePatient(recordIdx);

                try
                {
                    _rtn.total = 1;
                    _rtn.data.Add(mPatientInfo.ToJson());
                }
                catch (Exception ex)
                {
                    ApiError _err = new ApiError($"Patient Info conversion error - {ex.Message}");
                    _logger.LogWarning(_err.message);
                    _rtn.err = _err;
                }

            }
            catch (KeyNotFoundException ex1)
            {
                ApiError _err = new ApiError($"Patient Info error - {ex1.Message}");
                _logger.LogWarning(_err.message);
                _rtn.err = _err;
            }
            catch (Exception ex3)
            {
                ApiError _err = new ApiError($"Patient Info error - {ex3.Message}");
                _logger.LogWarning(_err.message);
                _rtn.err = _err;
            }
            return _rtn;
        }

        /// <summary>
        /// Get Patient Record By PatientQuery
        /// </summary>
        /// <param name="PatientQuery"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResponse> FindAllPatients([FromQuery] PatientQuery query)
        {
            ApiResponse _rtn = new ApiResponse();
            try
            {
                (List<MPatientInfo> items, int total) = await _service.FindAllPatients(query);

                try
                {
                    _rtn.total = total;
                    items.ForEach((x) =>
                    {
                        _rtn.data.Add(x.ToJson());
                    });
                }
                catch (Exception ex)
                {
                    ApiError _err = new ApiError($"Patient Info conversion error - {ex.Message}");
                    _logger.LogWarning(_err.message);
                    _rtn.err = _err;
                }

            }
            catch (KeyNotFoundException ex1)
            {
                ApiError _err = new ApiError($"Patient Info error - {ex1.Message}");
                _logger.LogWarning(_err.message);
                _rtn.err = _err;
            }
            catch (Exception ex3)
            {
                ApiError _err = new ApiError($"Patient Info error - {ex3.Message}");
                _logger.LogWarning(_err.message);
                _rtn.err = _err;
            }
            return _rtn;
        }



    }
}

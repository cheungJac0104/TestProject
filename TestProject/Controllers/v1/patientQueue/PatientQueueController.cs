using TestProject.Models;
using TestProject.Services;
using Microsoft.AspNetCore.Mvc;

//
//Event Controller
//
namespace TestProject.Controllers
{
    
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class PatientQueueController : ControllerBase
    {

        private readonly ILogger<PatientQueueController> _logger;
        private readonly IPatientQueueServices _service;

        public PatientQueueController(ILogger<PatientQueueController> logger, IPatientQueueServices service)
        {
            _logger = logger;
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get Event Query
        /// </summary> 
        /// <param name="PatientQueueQuery"></param>
        /// <returns></returns>
        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<ApiResponse> FindAllPatientQueues([FromQuery] PatientQueueQuery query)
        {
            ApiResponse _rtn = new ApiResponse();
            try
            {
                (List<PatientQueue> PatientQueue, int total) = await _service.FindAllPatientQueues(query);

                try
                {
                    _rtn.total = total;
                    PatientQueue.ForEach((x) =>
                    {
                        _rtn.data.Add(x.ToJson());
                    });
                }
                catch (Exception ex)
                {
                    ApiError _err = new ApiError($"data conversion error - {query.status} - {ex.Message}");
                    _logger.LogWarning(_err.message);
                    _rtn.err = _err;
                    return _rtn;
                }
            }
            catch (Exception ex)
            {
                ApiError _err = new ApiError($"database query error - {query.status} - {ex.Message}");
                _logger.LogWarning(_err.message);
                _rtn.err = _err;
                return _rtn;
            }
            return _rtn;
        }

    }
}

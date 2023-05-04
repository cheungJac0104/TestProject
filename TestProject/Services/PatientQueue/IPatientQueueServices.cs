using TestProject.Models;
using System.Threading.Tasks;

namespace TestProject.Services
{
    public interface IPatientQueueServices
    {
        Task<Tuple<List<PatientQueue>, int>> FindAllPatientQueues(PatientQueueQuery query);

    }
}

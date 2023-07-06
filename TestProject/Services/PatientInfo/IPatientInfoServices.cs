using TestProject.Models;

namespace TestProject.Services
{
        public interface IPatientInfoServices
    {
        Task<Tuple<List<MPatientInfo>, int>> FindAllPatients(PatientQuery query);
        Task<MPatientInfo> FindOnePatient(string recordIdx);
        Task<MPatientInfo> AddOnePatient(PatientPostBody body);
    }
}

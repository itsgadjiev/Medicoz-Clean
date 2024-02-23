using Medicoz.Domain;

namespace Medicoz.Application.Contracts.Percistance
{
    public interface IDoctorDepartmentRepository : IGenericRepository<Domain.DoctorDepartment>
    {
        List<DoctorDepartment> FindDoctorDepartmentsByDoctorId(string doctorId);

        Task<List<DoctorDepartment>> GetAllAsyncIncluded();
    }
}

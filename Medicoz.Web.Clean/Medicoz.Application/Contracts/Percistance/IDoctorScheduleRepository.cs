using Medicoz.Domain;

namespace Medicoz.Application.Contracts.Percistance;

public interface IDoctorScheduleRepository : IGenericRepository<Domain.DoctorSchedule>
{
    Task<List<DoctorSchedule>> GetDoctorSchedulesByDoctorIdAsync(string doctorId);
    Task<string> GetDoctorScheduleByStartAndEndTimeAsync(DateTime reservationDate, string doctorId);
}

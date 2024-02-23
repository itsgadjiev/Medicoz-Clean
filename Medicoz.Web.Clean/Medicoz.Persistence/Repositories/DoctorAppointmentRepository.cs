using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Domain.Common.Enums;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Persistence.Repositories;

public class DoctorAppointmentRepository : GenericRepository<DoctorAppointment>, IDoctorAppointmentRepository
{
    public DoctorAppointmentRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<List<DoctorAppointment>> GetAllReservedAppointmentsFromTodayByDoctorIdAsync(string doctorId)
    {
       return await _context.DoctorAppointment
            .Where(x => x.DoctorId == doctorId && x.ReservationDate > DateTime.Now)
            .Include(x=>x.DoctorSchedule)
            .ToListAsync();
    }

    public Task<List<DoctorAppointment>> GetAppointmentsFromTodayByStatus(string doctorEmail, AppointmentStatus appointmentStatus)
    {
        return _context.DoctorAppointment.Include(x=>x.Doctor).Where(x=>x.Doctor.Email == doctorEmail && x.AppointmentStatus == appointmentStatus && x.ReservationDate >= DateTime.Now).ToListAsync();
    }

    public Task<List<DoctorAppointment>> GetAppointmentsByStatusForToday(string doctorEmail, AppointmentStatus appointmentStatus)
    {
        return _context.DoctorAppointment.Include(x => x.Doctor).Where(x => x.Doctor.Email == doctorEmail && x.AppointmentStatus == appointmentStatus && x.ReservationDate.Day == DateTime.Now.Day).ToListAsync();
    }

    public bool IsReserved(DateTime reservationDate, string doctorScheduleId)
    {
        if (_context.DoctorAppointment.Any(x => x.ReservationDate == reservationDate && x.DoctorScheduleId == doctorScheduleId))
        {
            return true;
        }
        return false;
    }

    public Task<List<DoctorAppointment>> GetPreviousAppointmentsByStatus(string doctorEmail, AppointmentStatus appointmentStatus)
    {
        return _context.DoctorAppointment.Include(x => x.Doctor).Where(x => x.Doctor.Email == doctorEmail && x.AppointmentStatus == appointmentStatus && x.ReservationDate < DateTime.Now).ToListAsync();
    }
}

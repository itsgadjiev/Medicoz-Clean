﻿using Medicoz.Domain;

namespace Medicoz.Application.Contracts.Percistance;

public interface IDoctorScheduleRepository : IGenericRepository<Domain.DoctorSchedule>
{
    Task<List<DoctorSchedule>> GetDoctorSchedulesByDoctorIdAsync(int doctorId);
 
}
﻿using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.ViewModels;

namespace Medicoz.Application.Features.DoctorDetail.Queries.GetDoctorDetail;

public class GetDoctorDetailQueryHandler : IRequestHandler<GetDoctorDetailQuery, DoctorDetailViewModel>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly ILocalizationService<Domain.Doctor> _localizationService;
    private readonly IDoctorScheduleRepository _doctorScheduleRepository;
    private readonly IDoctorAppointmentRepository _doctorAppointmentRepository;

    public GetDoctorDetailQueryHandler(
        IDoctorRepository doctorRepository,
        ILocalizationService<Domain.Doctor> localizationService,
        IDoctorScheduleRepository doctorScheduleRepository,
        IDoctorAppointmentRepository doctorAppointmentRepository)
    {
        _doctorRepository = doctorRepository;
        _localizationService = localizationService;
        _doctorScheduleRepository = doctorScheduleRepository;
        _doctorAppointmentRepository = doctorAppointmentRepository;
    }

    public async Task<DoctorDetailViewModel> Handle(GetDoctorDetailQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);
        if (doctor == null)
        {
            return null;
        }

        return new DoctorDetailViewModel
        {
            Id = doctor.Id,
            Phone = doctor.Phone,
            Email = doctor.Email,
            ImageURL = doctor.ImageURL,
            Name = doctor.Name,
            Surname = doctor.Surname,
            Fee = doctor.Fee,
            Description = _localizationService.GetLocalizedValue(request.DoctorId, nameof(DoctorDetailViewModel.Description)),
            Education = _localizationService.GetLocalizedValue(request.DoctorId, nameof(DoctorDetailViewModel.Education)),
            Experience = _localizationService.GetLocalizedValue(request.DoctorId, nameof(DoctorDetailViewModel.Experience)),
            Title = _localizationService.GetLocalizedValue(request.DoctorId, nameof(DoctorDetailViewModel.Title)),
            DoctorSchedulesOnMonday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Monday),
            DoctorSchedulesOnTuesday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Tuesday),
            DoctorSchedulesOnFriday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Friday),
            DoctorSchedulesOnSaturday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Saturday),
            DoctorSchedulesOnThursday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Thursday),
            DoctorSchedulesOnSunday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Sunday),
            DoctorSchedulesOnWednesday = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAndDayAsync(request.DoctorId, DayOfWeek.Wednesday),
            AllDoctorSchedules =await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAsync(doctor.Id),
            ReservedDoctorAppointments = await _doctorAppointmentRepository.GetAllReservedAppointmentsFromTodayByDoctorIdAsync(request.DoctorId),
        };
    }
}

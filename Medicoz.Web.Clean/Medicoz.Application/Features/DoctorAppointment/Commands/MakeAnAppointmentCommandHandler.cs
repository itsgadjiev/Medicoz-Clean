using MediatR;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.DoctorAppointment.Commands;

public class MakeAnAppointmentCommandHandler : IRequestHandler<MakeAnAppointmentCommand, Unit>
{
    private readonly IDoctorAppointmentRepository _doctorAppointmentRepository;
    private readonly IDoctorScheduleRepository _doctorScheduleRepository;
    private readonly IEmailSender _emailSender;

    public MakeAnAppointmentCommandHandler(IDoctorAppointmentRepository doctorAppointmentRepository, IDoctorScheduleRepository doctorScheduleRepository, IEmailSender emailSender)
    {
        _doctorAppointmentRepository = doctorAppointmentRepository;
        _doctorScheduleRepository = doctorScheduleRepository;
        _emailSender = emailSender;
    }
    public async Task<Unit> Handle(MakeAnAppointmentCommand request, CancellationToken cancellationToken)
    {
        //yoxla datelere gor tap doctorScheduleId

        if (request.ReservationDate < DateTime.Now)
            throw new BadRequestException(request.ReservationDate.ToString("T"), "Select Correct Date");

        if (request.ReservationDate >= DateTime.Now.AddDays(30))
            throw new BadRequestException(request.ReservationDate.ToString("T"), "Only 30 days pre-reservation allowed");

        var doctorScheduleId = await _doctorScheduleRepository.GetDoctorScheduleByStartAndEndTimeAsync(request.ReservationDate, request.DoctorId);
        if (doctorScheduleId == null)
            throw new BadRequestException("dciD", "Doctor is not workign on this Time");


        if (_doctorAppointmentRepository.IsReserved(request.ReservationDate, doctorScheduleId))
            throw new BadRequestException(request.ReservationDate.ToString("T"), "This date is already reserved");

        var doctorAppointment = new Domain.DoctorAppointment()
        {
            DoctorId = request.DoctorId,
            ReservationDate = request.ReservationDate,
            DoctorScheduleId = doctorScheduleId,
            PasentEmail = request.PasentEmail,
            PasentName = request.PasentName,
            PasentPhone = request.PasentPhone,
            PasentNotes = request.PasentNotes,
            PasentId = request.PasentId,
            Id = Guid.NewGuid().ToString()
        };

        await _doctorAppointmentRepository.AddAsync(doctorAppointment);
        _emailSender.SendEmailAsync(request.PasentEmail, "Medicoz Doctor Appointment", $"Doctor Appointment on:{request.ReservationDate.ToShortTimeString()}");

        return Unit.Value;
    }
}

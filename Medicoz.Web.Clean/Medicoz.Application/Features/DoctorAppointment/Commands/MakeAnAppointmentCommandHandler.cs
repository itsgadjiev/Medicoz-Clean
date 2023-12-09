using MediatR;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.DoctorAppointment.Commands
{
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
            var doctorScheduleId = await _doctorScheduleRepository.GetDoctorScheduleByStartAndEndTimeAsync(request.ReservationDate, request.DoctorId);

            if (doctorScheduleId == null)
                throw new BadRequestException(doctorScheduleId.ToString(),"Doctor is not workign on this Time");


            if (_doctorAppointmentRepository.IsReserved(request.ReservationDate, doctorScheduleId.Value))
                throw new BadRequestException(request.ReservationDate.ToString("T"), "This date is already reserved");
            
            var doctorAppointment = new Domain.DoctorAppointment()
            {
                DoctorId = request.DoctorId,
                ReservationDate = request.ReservationDate,
                DoctorScheduleId = doctorScheduleId.Value,
                PasentEmail = request.PasentEmail,
                PasentName=request.PasentName,
                PasentPhone = request.PasentPhone,
                PasentNotes = request.PasentNotes,
                PasentId = request.PasentId,
            };

            await _doctorAppointmentRepository.AddAsync(doctorAppointment);
            _emailSender.SendEmail(request.PasentEmail, "Medicoz Doctor Appointment", $"Doctor Appointment on:{request.ReservationDate.ToShortTimeString()}");

            return Unit.Value;
        }
    }
}

using FluentValidation;

namespace Medicoz.Application.Features.DoctorAppointment.Commands;

public class MakeAnAppointmentCommandValidator :AbstractValidator<MakeAnAppointmentCommand>
{
    public MakeAnAppointmentCommandValidator()
    {
        RuleFor(x=>x.PasentNotes).NotNull().NotEmpty().MaximumLength(450);
        RuleFor(x=>x.PasentPhone).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x=>x.PasentEmail).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x=>x.PasentEmail).NotNull().NotEmpty().MaximumLength(100);
    }
}

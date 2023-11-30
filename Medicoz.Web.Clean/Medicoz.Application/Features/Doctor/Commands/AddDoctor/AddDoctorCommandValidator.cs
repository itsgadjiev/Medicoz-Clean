using FluentValidation;

namespace Medicoz.Application.Features.Doctor.Commands.AddDoctor
{
    public class AddDoctorCommandValidator : AbstractValidator<AddDoctorCommand>
    {
        public AddDoctorCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(x => x.TitleAz).NotEmpty().WithMessage("TitleAz is required.");
            RuleFor(x => x.TitleEn).NotEmpty().WithMessage("TitleEn is required.");
            RuleFor(x => x.DescriptionAz).NotEmpty().WithMessage("DescriptionAz is required.");
            RuleFor(x => x.DescriptionEn).NotEmpty().WithMessage("DescriptionEn is required.");
            RuleFor(x => x.EducationAz).NotEmpty().WithMessage("EducationAz is required.");
            RuleFor(x => x.EducationEn).NotEmpty().WithMessage("EducationEn is required.");
            RuleFor(x => x.ExperienceAz).NotEmpty().WithMessage("ExperienceAz is required.");
            RuleFor(x => x.ExperienceEn).NotEmpty().WithMessage("ExperienceEn is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Image).NotNull().WithMessage("Image is required.");

        }
    }
}

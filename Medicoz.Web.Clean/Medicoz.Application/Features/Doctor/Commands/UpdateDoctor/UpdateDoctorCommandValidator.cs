using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Doctor.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandValidator :AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidator()
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
            RuleFor(x => x.Fee).NotEmpty().NotNull().WithMessage("Fee is required.");
        }
    }
}

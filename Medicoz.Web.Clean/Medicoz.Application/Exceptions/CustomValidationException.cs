using FluentValidation.Results;

namespace Medicoz.Application.Exceptions
{
    public class CustomValidationException : ApplicationException
    {
        public List<ValidationFailure> Errors { get; }

        public CustomValidationException(List<ValidationFailure> errors)
        {
            Errors = errors;
        }
    }
}

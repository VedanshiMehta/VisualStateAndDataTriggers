using C11_Exercises.DataModel;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
    public class RegistrationValidator : AbstractValidator<RegisterDataModel>
    {
        private List<ValidationFailure> _errors;

        public RegistrationValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is required.")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is invalid");

            RuleFor(x=>x.Password).NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(5)
                .WithMessage("Password should be greater than 5 characters.");

            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .WithMessage("Confirm Password is required")
                .Equal(x => x.Password)
                .WithMessage("Confirm Password should match with Password")
                .When(y => !string.IsNullOrEmpty(y.Password));

        }
        public override ValidationResult Validate(ValidationContext<RegisterDataModel> context)
        {
            var validationresult = base.Validate(context);
            _errors = validationresult.Errors;
            return validationresult;
        }
        public string GetErrorMessage()
        {
            if (_errors.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                return _errors?[0].ErrorMessage ?? string.Empty;
            }
        }

    }
}

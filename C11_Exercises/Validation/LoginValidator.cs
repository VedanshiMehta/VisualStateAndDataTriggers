
using C11_Exercises.DataModel;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
    public class LoginValidator : AbstractValidator<LoginDataModel>
    {
        private List<ValidationFailure> _errors;
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is required.")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is invalid");
        RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(5)
                .WithMessage("Password should be grater than 5 characters.");
        }
        public override ValidationResult Validate(ValidationContext<LoginDataModel> context)
        {
            var validationResult = base.Validate(context);
            _errors = validationResult.Errors;
            return validationResult;
        }
        public string GetErrorMessage([CallerMemberName] string name = "")
        {
            if (_errors.Count == 0)
            {    
                return string.Empty;
            }
            else
            {
                return _errors?.FirstOrDefault(x => x.PropertyName == name)?.ErrorMessage;
            }
        }

    }
}

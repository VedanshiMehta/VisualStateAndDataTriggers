using C11_Exercises.Validation;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.DataModel
{
    public partial class RegisterDataModel : ObservableObject
    {
        private RegistrationValidator _validator;
        [ObservableProperty]
        private string _message;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _confirmPassword;

        public RegisterDataModel()
        {
            _validator = new RegistrationValidator();
        }

        public bool ValidateAll()
        {
            var result = _validator.Validate(this);
            Message = _validator.GetErrorMessage();
            return result.IsValid;
        }
    }
}

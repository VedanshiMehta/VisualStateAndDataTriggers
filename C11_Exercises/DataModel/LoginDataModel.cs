using C11_Exercises.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.DataModel
{
    public class LoginDataModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private string _errorMessageEmail;
        private string _errorMessagePassword;
        private bool _isEnabled;
        private LoginValidator _validator;

        public LoginDataModel()
        {
            _validator = new LoginValidator();
            IsEnabled = false;
        }

        public string Email 
        { 
            get 
            { 
                return _email; 
            } 
            set
            { 
                _email = value;
                var result = _validator.Validate(this);
                IsEnabled = result.IsValid;
                ErrorMessageEmail = _validator.GetErrorMessage();
            } 
        }
        public string Password 
        { 
            get
            { 
                return _password; 
            } 
            set 
            { 
                _password = value; 
                var result = _validator.Validate(this);
                IsEnabled = result.IsValid;
                ErrorMessagePassword = _validator.GetErrorMessage();
            } 
        }
        public string ErrorMessageEmail { get { return _errorMessageEmail; } set { _errorMessageEmail = value; OnPropertyChanged(); } }
        public string ErrorMessagePassword { get {return _errorMessagePassword; } set { _errorMessagePassword = value; OnPropertyChanged(); } }
        public bool IsEnabled { get { return _isEnabled; }  set { _isEnabled = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

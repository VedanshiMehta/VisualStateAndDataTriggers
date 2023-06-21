using C11_Exercises.DataModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.ViewModel
{
    public partial class RegistrationViewModel : ObservableObject
    {
        [ObservableProperty]
        private RegisterDataModel _dataModel;

        public RegistrationViewModel()
        {
            DataModel = new RegisterDataModel();
        }

        [RelayCommand]
        public void RegisterUser()
        {
            var isValid = DataModel.ValidateAll();
            if (isValid)
            {
                Console.WriteLine("Registration Successful");
            }
            else
            {
                Console.WriteLine(DataModel.Message);
            }
        }
    }   
}

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
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private LoginDataModel _dataModel;

        public LoginViewModel()
        {
            DataModel = new LoginDataModel();
        }
        [RelayCommand]
        public void LoginUser()
        {
            Console.WriteLine("Login Successful");
        }
    }
}

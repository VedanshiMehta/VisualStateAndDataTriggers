using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.ViewModel
{
    public partial class CountryViewModel : ObservableObject
    {
        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                if (_isExpanded)
                {
                    Rotation = 180;
                }
                else
                {
                    Rotation = 0;
                }
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        List<string> countryDetails;
        [ObservableProperty]
        string selectedCountry;
        [ObservableProperty]
        double rotation;
        public CountryViewModel()
        {
            selectedCountry = "Select Country";
            countryDetails = new List<string>()
            {
                    "India",
                    "Dubai",
                    "London",
                    "Georgia",
                    "Japan",
                    "Africa",
                     "Maldives",
                    "New Zealand",
                    "Singapore",
                    "Zimbabwe"
            };
        }

        [RelayCommand]
        private void SelectCountryAction()
        {
            IsExpanded = false;
        }
    }

}

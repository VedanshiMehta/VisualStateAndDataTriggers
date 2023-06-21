using C11_Exercises.GroupClass;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.ViewModel
{
    public partial class AnimalViewModel : ObservableObject 
    {
        [ObservableProperty]
        private ObservableCollection<AnimalGroups> _animals;

        public AnimalViewModel()
        {
            AddAnimals();
        }

        private void AddAnimals()
        {
            Animals = new ObservableCollection<AnimalGroups>()
            {
               new AnimalGroups("Bears",new List<Animal>()
               { 
               
                    new Animal
                    {
                        Name = "American Black Bear",
                        Location = "North America"
                    },
                    new Animal
                    {
                        Name = "Asian Black Bear",
                        Location = "Asia"
                    },

               }),


            new AnimalGroups("Monkeys", new List<Animal>
            {
                new Animal
                {
                    Name = "Baboon",
                    Location = "Africa & Asia"
                },
                new Animal
                {   
                    Name = "Capuchin Monkey",
                    Location = "Central & South America"
                },
                new Animal
                {
                    Name = "Blue Monkey",
                    Location = "Central and East Africa"
                },
              })

            };
        }
    }
}

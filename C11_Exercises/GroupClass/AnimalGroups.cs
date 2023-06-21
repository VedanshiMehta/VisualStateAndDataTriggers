using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.GroupClass
{
    public class AnimalGroups : List<Animal>
    {
        public string Name { get; set; }
        public AnimalGroups(string name,List<Animal> animals):base(animals)
        {
            Name = name;
        }
    }
}

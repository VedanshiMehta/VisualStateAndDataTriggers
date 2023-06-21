using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises
{
    public interface IDeviceOrientationService
    {
        string GetOrientation();
        string Platform { get; set; }
    }
}

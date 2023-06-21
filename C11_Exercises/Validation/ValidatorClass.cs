using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
    public class ValidatorClass : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            if(button.IsPressed)
            {
                button.BackgroundColor = Colors.Orange;
                button.TextColor = Colors.White;
            }
            else if(!button.IsPressed)
            {
                button.BackgroundColor = Colors.Gray;
                button.TextColor = Colors.Black;
            }
        }
    }
}

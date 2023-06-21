using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
    public class AttachedNumericValidationBehaviour
    {
        public static readonly BindableProperty AttachBehaviorProperty = BindableProperty.CreateAttached("AttachBehavior",
            typeof(bool),
            typeof(AttachedNumericValidationBehaviour),
            false,
            propertyChanged: OnAttachBehaviorChanged);
        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }
        public static void SetAttachBehavior(BindableObject view, bool value) 
        {
            view.SetValue(AttachBehaviorProperty, value);
        }
        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            Entry entry = view as Entry;
            if(entry == null)
            {
                return;
            }
            bool attachbehavior = (bool)newValue;
            if(attachbehavior)
            {
                entry.TextChanged += Entry_TextChanged;
            }
            else
            {
                entry.TextChanged -= Entry_TextChanged;
            }
        }

        private static void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }
    }
}

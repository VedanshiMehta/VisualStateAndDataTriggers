using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
    public class NumericValidationStyleBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AttachBehaviorProperty = BindableProperty.CreateAttached("AttachBehavior", typeof(bool),
        typeof(NumericValidationStyleBehavior), 
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
        static void OnAttachBehaviorChanged(BindableObject view, object oldValue,
       object newValue)
        {
            Entry entry = view as Entry;
            if (entry == null)
            {
                return;
            }
            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                
                entry.Behaviors.Add(new NumericValidationStyleBehavior());
                entry.Behaviors.Add(new LenghthValidationBehavior());
            }
            else
            {
                try
                {
                    var list = new List<Behavior>(entry.Behaviors);
                    for (var i = 0; i < list.Count; i++)
                    {
                        entry.Behaviors.Remove(list[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            bool isValid = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }

    }
}

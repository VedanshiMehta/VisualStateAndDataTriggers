using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(entry);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= Entry_TextChanged;
            entry.TextColor = Colors.DarkMagenta;
            base.OnDetachingFrom(entry);
        }
    }
}

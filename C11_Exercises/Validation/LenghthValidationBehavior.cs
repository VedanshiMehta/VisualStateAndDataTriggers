using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C11_Exercises.Validation
{
   
    public class LenghthValidationBehavior : Behavior<Entry>
    {
        private int length = 6;
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(entry);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);
          
            //if (entry.Text.Length > length)
            //{
            //    entry.Text = e.OldTextValue;
            //}
            entry.TextColor = (!isValid || entry.Text.Length < length) ? Colors.Red : Colors.Black;

        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= Entry_TextChanged;
            entry.TextColor = Colors.DarkMagenta;
            base.OnDetachingFrom(entry);
        }
    }
}

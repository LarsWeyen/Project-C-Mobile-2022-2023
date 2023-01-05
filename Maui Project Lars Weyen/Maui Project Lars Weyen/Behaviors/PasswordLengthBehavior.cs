using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Behaviors
{
    class PasswordLengthBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            string input = args.NewTextValue;

            ((Entry)sender).TextColor = input.Length >= 6 ? Colors.Green: Colors.Red;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Converters
{
    class CharLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string beschrijving = (string)value;
            if (beschrijving.Length <= 24)
            {
                return beschrijving;
            }
            return beschrijving.Substring(24) + " ...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

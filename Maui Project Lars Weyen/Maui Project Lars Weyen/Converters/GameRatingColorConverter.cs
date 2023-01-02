using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Project_Lars_Weyen.Converters
{
    public class GameRatingColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                value = System.Convert.ToDouble((int)value);
            }
           
            double rating = (double)value;
            double maxScore = double.Parse((string)parameter);
            if (rating < maxScore/3.0)
            {
                string hex = "#D47967";
                return Color.FromArgb(hex);               
            }
            else if (rating < 2*(maxScore / 3.0))
            {
                string hex = "#F9B361";
                return Color.FromArgb(hex);
            }
            else
            {
                string hex = "#00C896";
                return Color.FromArgb(hex);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

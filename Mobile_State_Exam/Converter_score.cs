using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mobile_State_Exam
{
    class Converter_score : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            if ((int)value >= 80)
                return "correct";
            if ((int)value < 80 && (int)value >= 0)
                return "wrong";
            else
            {
                return "none";
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ICT_VNPT.Func.Ulti {
    public class TrueFalseToVisibilityConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            switch (value.ToString().ToLower()) {
                case "true":
                    return Visibility.Visible;
                case "false":
                    return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value is Visibility) {
                if ((Visibility)value == Visibility.Visible)
                    return "True";
                else
                    return "False";
            }
            return "False";
        }

    }
}

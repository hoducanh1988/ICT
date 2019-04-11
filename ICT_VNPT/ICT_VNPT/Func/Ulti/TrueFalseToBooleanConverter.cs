using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ICT_VNPT.Func.Ulti {

    public class TrueFalseToBooleanConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            switch (value.ToString().ToLower()) {
                case "true":
                    return true;
                case "false":
                    return false;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value is bool) {
                if ((bool)value == true)
                    return "True";
                else
                    return "False";
            }
            return "False";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment {
    public interface IMultimeter : IEquipment {

        //Giá trị hàm trả về -------------------//
        // double.minValue = truy vấn thất bại => lỗi máy đo
        // giá trị = truy vấn thành công

        double get_DC_Current_Value(int measure_time, int waittime, string range);
        double get_DC_Voltage_Value(int measure_time, int waittime, string range);
        double get_AC_Current_Value(int measure_time, int waittime, string range);
        double get_AC_Voltage_Value(int measure_time, int waittime, string range);
        double get_TwoWire_Resistance_Value(int measure_time, int waittime, string range);
        double get_FourWire_Resistance_Value(int measure_time, int waittime, string range);
        double get_Continuity_Value(int measure_time, int waittime, string range);
        double get_Diode_Value(int measure_time, int waittime, string range);
        double get_Capacitance_Value(int measure_time, int waittime, string range);
        double get_Frequency_Voltage_Value(int measure_time, int waittime, string range);
        double get_Frequency_Current_Value(int measure_time, int waittime, string range);
        double get_Period_Voltage_Value(int measure_time, int waittime, string range);
        double get_Period_Current_Value(int measure_time, int waittime, string range);

    }
}

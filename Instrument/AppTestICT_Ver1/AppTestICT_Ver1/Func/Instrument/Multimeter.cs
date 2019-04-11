using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTestICT_Ver1.Func.Global;
using System.Reflection;

namespace AppTestICT_Ver1.Func.Instrument {
    public class Multimeter : Instrument {

        enum ModeType {
            DC_Volt = 0,
            DC_Current = 1,
            AC_Volt = 2,
            AC_Current = 3,
            RES_2Wire = 4,
            RES_4Wire = 5,
            FREQ_Volt = 6,
            FREQ_Current = 7,
            PED_Volt = 8,
            PED_Current = 9,
            Capacitance = 10,
            Continuity = 11,
            Diode = 12,
            TEMP = 13,
            TCOUPL = 14
        }

        Dictionary<int, string> dictModeName = new Dictionary<int, string>() {
            { 0, "get_DC_Voltage_Value" },
            { 1, "get_DC_Current_Value" },
            { 2, "get_AC_Voltage_Value" },
            { 3, "get_AC_Current_Value" },
            { 4, "get_TwoWire_Resistance_Value" },
            { 5, "get_FourWire_Resistance_Value" },
            { 6, "get_Frequency_Voltage_Value" },
            { 7, "get_Frequency_Current_Value" },
            { 8, "get_Period_Voltage_Value" },
            { 9, "get_Period_Current_Value" },
            { 10, "get_Capacitance_Value" },
            { 11, "get_Continuity_Value" },
            { 12, "get_Diode_Value" },
            { 13, "" },
            { 14, "" },
        };


        public Multimeter() {

            //"Keithley2110.dll"
            LoadLibrary("Keithley2110", InstrumentType.Meter);
        }


        //
        //
        //
        //
        //GIÁ TRỊ TRẢ VỀ CỦA METHOD ---------------------------------------------------------------/
        /*
         *  0 = THÀNH CÔNG
         *  1 = LỖI THIẾT BỊ ĐO
         * -1 = LỖI PHẦN MỀM => FILE DLL KHÔNG TỒN TẠI METHOD HOẶC PROPERTY MÀ PHẦN MỀM GỌI ĐẾN
         */
         //
         //
         //
         //

        #region 1. SUB FUNCTION --------------------------------------------------------------------//

        int _get_measured_value(ModeType mode, int measure_time, out double value) {

            value = double.MinValue;

            //kiểm tra kết nối tới máy đo
            if (IsConnected == false) return 1; //loi may do

            // Reflection Method
            string methodstring;
            bool r = dictModeName.TryGetValue((int)mode,out methodstring);
            MethodInfo method = t.GetMethod(methodstring, new Type[] { typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[1];
            parameters[0] = measure_time;

            // Invoke method
            try {
                value = (double)method.Invoke(Instance, parameters);
                return value == double.MinValue ? 1 : 0;
            }
            catch { return -1; }
        }

        #endregion


        #region 2. MEASURE METHOD ------------------------------------------------------------------//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_DC_Current_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.DC_Current, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_DC_Voltage_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.DC_Volt, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_AC_Voltage_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.AC_Volt, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_AC_Current_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.AC_Current, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_TwoWire_Resistance_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.RES_2Wire, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_FourWire_Resistance_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.RES_4Wire, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Frequency_Voltage_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.FREQ_Volt, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Frequency_Current_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.FREQ_Current, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Period_Voltage_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.PED_Volt, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Period_Current_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.PED_Current, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Capacitance_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.Capacitance, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Continuity_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.Continuity, measure_time, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Diode_Value(int measure_time, out double value) {
            return _get_measured_value(ModeType.Diode, measure_time, out value);
        }

        #endregion
    }
}

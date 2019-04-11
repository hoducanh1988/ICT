using ICT_VNPT.Func.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.Instrument {
    public class Multimeter : AbstractInstrument {

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
            //LoadLibrary("Keithley2110", InstrumentType.Meter);
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

        int _get_measured_value(ModeType mode, int measure_time, int wait_time, string range, out double value) {

            value = double.MinValue;

            //kiểm tra kết nối tới máy đo
            myGlobal.debugLog.MeterLog += "check connect to device...\r\n";
            myGlobal.debugLog.MeterLog += string.Format("result = {0}...\r\n", IsConnected == false ? "false" : "true");
            if (IsConnected == false) return 1; //loi may do

            // Reflection Method
            string methodstring;
            bool r = dictModeName.TryGetValue((int)mode, out methodstring);
            MethodInfo method = t.GetMethod(methodstring, new Type[] { typeof(int), typeof(int), typeof(string) });
            myGlobal.debugLog.MeterLog += "reflection method...\r\n";
            myGlobal.debugLog.MeterLog += string.Format("result = {0}...\r\n", method == null ? "false" : "true");
            if (method == null) return -1;

            // Invoke method
            myGlobal.debugLog.MeterLog += "get measured value...\r\n";
            try {
                //createDelegate
                var func = (Func<int, int, string, double>)method.CreateDelegate(typeof(Func<int, int, string, double>), Instance);
                value = func(measure_time, wait_time, range);

                myGlobal.debugLog.MeterLog += string.Format("result = {0}...\r\n", value);
                return value == double.MinValue ? 1 : 0;
            }
            catch (Exception ex) {
                myGlobal.debugLog.MeterLog += ex.ToString() + "\r\n";
                return -1;
            }
        }

        #endregion

        #region 2. MEASURE METHOD ------------------------------------------------------------------//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_DC_Current_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get DC current value...\r\n";
            return _get_measured_value(ModeType.DC_Current, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_DC_Voltage_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get DC voltage value...\r\n";
            return _get_measured_value(ModeType.DC_Volt, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_AC_Voltage_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get AC voltage value...\r\n";
            return _get_measured_value(ModeType.AC_Volt, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_AC_Current_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get AC current value...\r\n";
            return _get_measured_value(ModeType.AC_Current, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_TwoWire_Resistance_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get TwoWire resistance value...\r\n";
            return _get_measured_value(ModeType.RES_2Wire, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_FourWire_Resistance_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get FourWire resistance value...\r\n";
            return _get_measured_value(ModeType.RES_4Wire, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Frequency_Voltage_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get Frequency voltage value...\r\n";
            return _get_measured_value(ModeType.FREQ_Volt, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Frequency_Current_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get Frequency current value...\r\n";
            return _get_measured_value(ModeType.FREQ_Current, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Period_Voltage_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get period voltage value...\r\n";
            return _get_measured_value(ModeType.PED_Volt, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Period_Current_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get period current value...\r\n";
            return _get_measured_value(ModeType.PED_Current, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Capacitance_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get capacitance value...\r\n";
            return _get_measured_value(ModeType.Capacitance, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Continuity_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get continuity value...\r\n";
            return _get_measured_value(ModeType.Continuity, measure_time, wait_time, range, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measure_time"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int get_Diode_Value(int measure_time, int wait_time, string range, out double value) {
            myGlobal.debugLog.MeterLog += "get diode value...\r\n";
            return _get_measured_value(ModeType.Diode, measure_time, wait_time, range, out value);
        }

        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTestICT_Ver1.Func.Global;

using System.Reflection;

namespace AppTestICT_Ver1.Func.Instrument {
    public class PowerSupply : Instrument {

        public PowerSupply() {

            //"AgilentE3632A.dll"
            LoadLibrary("AgilentE3632A", InstrumentType.Power);
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

        private T _delegate_method<T>(string methodname) {

            string obj1 = typeof(T) == typeof(int) ? "1" : null;
            string obj2 = typeof(T) == typeof(int) ? "-1" : null;

            //kiểm tra kết nối tới máy đo
            if (IsConnected == false) return (T) Convert.ChangeType(obj1, typeof(T)); //loi may do

            // Reflection Method
            MethodInfo method = t.GetMethod(methodname);
            if (method == null) return (T)Convert.ChangeType(obj2, typeof(T));

            // Invoke method
            return (T)method.Invoke(Instance, null);
        }
        private T _delegate_method<T>(string methodname, bool value) {

            string obj1 = typeof(T) == typeof(int) ? "1" : null;
            string obj2 = typeof(T) == typeof(int) ? "-1" : null;

            //kiểm tra kết nối tới máy đo
            if (IsConnected == false) return (T)Convert.ChangeType(obj1, typeof(T)); //loi may do

            // Reflection Method
            MethodInfo method = t.GetMethod(methodname, new Type[] { typeof(bool) });
            if (method == null) return (T)Convert.ChangeType(obj2, typeof(T));

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[1];
            parameters[0] = value;

            // Invoke method
            return (T)method.Invoke(Instance, parameters);
        }
        private T _delegate_method<T>(string methodname, double value) {

            string obj1 = typeof(T) == typeof(int) ? "1" : null;
            string obj2 = typeof(T) == typeof(int) ? "-1" : null;

            //kiểm tra kết nối tới máy đo
            if (IsConnected == false) return (T)Convert.ChangeType(obj1, typeof(T)); //loi may do

            // Reflection Method
            MethodInfo method = t.GetMethod(methodname, new Type[] { typeof(double) });
            if (method == null) return (T)Convert.ChangeType(obj2, typeof(T));

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[1];
            parameters[0] = value;

            // Invoke method
            return (T)method.Invoke(Instance, parameters);
        }
        private T _delegate_method<T>(string methodname, double value1, double value2) {

            string obj1 = typeof(T) == typeof(int) ? "1" : null;
            string obj2 = typeof(T) == typeof(int) ? "-1" : null;

            //kiểm tra kết nối tới máy đo
            if (IsConnected == false) return (T)Convert.ChangeType(obj1, typeof(T)); //loi may do

            // Reflection Method
            MethodInfo method = t.GetMethod(methodname, new Type[] { typeof(double), typeof(double) });
            if (method == null) return (T)Convert.ChangeType(obj2, typeof(T));

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = value1;
            parameters[1] = value2;

            // Invoke method
            return (T)method.Invoke(Instance, parameters);
        }

        #endregion

        #region 2. MAIN METHOD ------------------------------------------------------------------//
        //
        public int Preset() {
            return _delegate_method<int>("Preset");
        }
        //
        public int clear_Current_Protection_Flag() {
            return _delegate_method<int>("clear_Current_Protection_Flag");
        }
        //
        public int clear_Voltage_Protection_Flag() {
            return _delegate_method<int>("clear_Voltage_Protection_Flag");
        }

        public string get_Current_Protection_Flag() {
            return _delegate_method<string>("get_Current_Protection_Flag");
        }

        public string get_Current_Protection_Level() {
            return _delegate_method<string>("get_Current_Protection_Level");
        }

        public string get_Current_Protection_State() {
            return _delegate_method<string>("get_Current_Protection_State");
        }

        public string get_Current_Step() {
            return _delegate_method<string>("get_Current_Step");
        }

        public string get_Output_State() {
            return _delegate_method<string>("get_Output_State");
        }

        public string get_Output_Value() {
            return _delegate_method<string>("get_Output_Value");
        }

        public string get_Trigger_Delay() {
            return _delegate_method<string>("get_Trigger_Delay");
        }

        public string get_Voltage_Protection_Flag() {
            return _delegate_method<string>("get_Voltage_Protection_Flag");
        }

        public string get_Voltage_Protection_Level() {
            return _delegate_method<string>("get_Voltage_Protection_Level");
        }

        public string get_Voltage_Protection_State() {
            return _delegate_method<string>("get_Voltage_Protection_State");
        }

        public string get_Voltage_Range() {
            return _delegate_method<string>("get_Voltage_Range");
        }

        public string get_Voltage_Step() {
            return _delegate_method<string>("get_Voltage_Step");
        }

        public int set_Current_Protection_Level(double value) {
            return _delegate_method<int>("set_Current_Protection_Level", value);
        }

        public int set_Current_Protection_State(bool flag) {
            return _delegate_method<int>("set_Current_Protection_State", flag);
        }

        public int set_Current_Step(double value) {
            return _delegate_method<int>("set_Current_Step", value);
        }

        public int set_Output_State(bool flag) {
            return _delegate_method<int>("set_Output_State", flag);
        }

        public int set_Output_Value(double volt, double limit_current) {
            return _delegate_method<int>("set_Output_Value", volt, limit_current);
        }
    
        public int set_Trigger_Delay(double value) {
            return _delegate_method<int>("set_Trigger_Delay", value);
        }

        public int set_Voltage_Protection_Level(double value) {
            return _delegate_method<int>("set_Voltage_Protection_Level", value);
        }

        public int set_Voltage_Protection_State(bool flag) {
            return _delegate_method<int>("set_Voltage_Protection_State", flag);
        }

        public int set_Voltage_Range(double value) {
            return _delegate_method<int>("set_Voltage_Range", value);
        }

        public int set_Voltage_Step(double value) {
            return _delegate_method<int>("set_Voltage_Step", value);
        }

        public string get_Current_Limit_Value() {
            return _delegate_method<string>("get_Current_Limit_Value");
        }

        public string get_Current_Actual_Value() {
            return _delegate_method<string>("get_Current_Actual_Value");
        }

        public string get_Voltage_Limit_Value() {
            return _delegate_method<string>("get_Voltage_Limit_Value");
        }

        public string get_Voltage_Actual_Value() {
            return _delegate_method<string>("get_Voltage_Actual_Value");
        }

        #endregion


    }
}

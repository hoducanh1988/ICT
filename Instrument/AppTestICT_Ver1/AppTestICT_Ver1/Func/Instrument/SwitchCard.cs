using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTestICT_Ver1.Func.Global;
using System.Reflection;

namespace AppTestICT_Ver1.Func.Instrument {
    public class SwitchCard : Instrument {

        public SwitchCard() {
            //"Pickering50635005.dll"
            LoadLibrary("Pickering50635005", InstrumentType.Switcher);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public int switchOFF(int bank, int channel) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("switchOFF", new Type[] { typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = bank;
            parameters[1] = channel;

            // Invoke method
            try {
                int r = (int)method.Invoke(Instance, parameters);
                return r;
            }
            catch {
                return -1;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public int switchOFF(int bank, int row, int column) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("switchOFF", new Type[] { typeof(int), typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[3];
            parameters[0] = bank;
            parameters[1] = row;
            parameters[2] = column;

            // Invoke method
            try {
                int r = (int)method.Invoke(Instance, parameters);
                return r;
            }
            catch {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public int switchON(int bank, int channel) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("switchON", new Type[] { typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = bank;
            parameters[1] = channel;

            // Invoke method
            try {
                int r = (int)method.Invoke(Instance, parameters);
                return r;
            }
            catch {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public int switchON(int bank, int row, int column) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("switchON", new Type[] { typeof(int), typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[3];
            parameters[0] = bank;
            parameters[1] = row;
            parameters[2] = column;

            // Invoke method
            try {
                int r = (int)method.Invoke(Instance, parameters);
                return r;
            }
            catch {
                return -1;
            }
        }


        }
}

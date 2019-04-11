using ICT_VNPT.Func.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.Instrument {
    public class SwitchCard : AbstractInstrument {

        public SwitchCard() {
            //"Pickering50635005.dll"
            //LoadLibrary("Pickering50635005", InstrumentType.Switcher);
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
        /// open all channels of the switch card
        /// </summary>
        /// <returns>0 = success, 1 = fail switch card, -1 = fail software</returns>
        public int Set_Card_Open() {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("Set_Card_Open");
            if (method == null) return -1;

            // Invoke method - invoke
            //int result = (int)method.Invoke(Instance, null);

            //Invoke method - CreateDelegate
            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>), Instance);
            int result = func();
            
            // Return value
            return result;

        }


        /// <summary>
        /// open all channels in a bank of switch card
        /// </summary>
        /// <param name="Bank">Value = 1, 2</param>
        /// <returns>0 = success, 1 = fail switch card, -1 = fail software</returns>
        public int Set_Bank_Open(int Bank) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("Set_Bank_Open", new Type[] { typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[1];
            parameters[0] = Bank;

            // Invoke method
            try {
                //int r = (int)method.Invoke(Instance, parameters);

                //Invoke method - CreateDelegate
                var func = (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>), Instance);
                int r = func(Bank);

                return r;
            } catch {
                return -1;
            }
        }


        /// <summary>
        /// open a channel in a bank of switch card
        /// </summary>
        /// <param name="Bank">Value = 1, 2</param>
        /// <param name="Channel">Value = 1,2,3...32</param>
        /// <returns>0 = success, 1 = fail switch card, -1 = fail software</returns>
        public int Set_Channel_Open(int Bank, int Channel) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("Set_Channel_Open", new Type[] { typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = Bank;
            parameters[1] = Channel;

            // Invoke method
            try {
                //int r = (int)method.Invoke(Instance, parameters);

                //Invoke method - CreateDelegate
                var func = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>), Instance);
                int r = func(Bank, Channel);

                return r;
            } catch {
                return -1;
            }
        }


        /// <summary>
        /// close a channel in a bank of switch card
        /// </summary>
        /// <param name="Bank">Value = 1, 2</param>
        /// <param name="Channel">Value = 1,2,3...32</param>
        /// <returns>0 = success, 1 = fail switch card, -1 = fail software</returns>
        public int Set_Channel_Close(int Bank, int Channel) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("Set_Channel_Close", new Type[] { typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = Bank;
            parameters[1] = Channel;

            // Invoke method
            try {
                //int r = (int)method.Invoke(Instance, parameters);

                //Invoke method - CreateDelegate
                var func = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>), Instance);
                int r = func(Bank, Channel);

                return r;
            } catch {
                return -1;
            }
        }


        /// <summary>
        /// close a channel in a bank of switch card
        /// </summary>
        /// <param name="Bank">Value = 1, 2</param>
        /// <param name="Channel">Value = 1,2,3...32</param>
        /// <returns>0 = success, 1 = fail switch card, -1 = fail software</returns>
        public int Set_Channel_Close(int BankStart, int Channel1, int Channel2) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("Set_Channel_Close", new Type[] { typeof(int), typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[3];
            parameters[0] = BankStart;
            parameters[1] = Channel1;
            parameters[2] = Channel2;

            // Invoke method
            try {
                //int r = (int)method.Invoke(Instance, parameters);

                //Invoke method - CreateDelegate
                var func = (Func<int, int, int, int>)method.CreateDelegate(typeof(Func<int, int, int, int>), Instance);
                int r = func(BankStart, Channel1, Channel2);

                return r;
            } catch {
                return -1;
            }
        }


        /// <summary>
        /// get state of a specified channel of a bank of switch card
        /// </summary>
        /// <param name="Bank">Value = 1, 2</param>
        /// <param name="Channel">Value = 1,2,3...32</param>
        /// <returns>0 = open, 1 = close, -1 = fail software</returns>
        public int Get_Channel_State(int Bank, int Channel) {
            //kiểm tra kết nối tới switch card
            if (IsConnected == false) return 1; //loi switch card

            // Reflection Method
            MethodInfo method = t.GetMethod("Get_Channel_State", new Type[] { typeof(int), typeof(int) });
            if (method == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = Bank;
            parameters[1] = Channel;

            // Invoke method
            try {
                //int r = (int)method.Invoke(Instance, parameters);

                //Invoke method - CreateDelegate
                var func = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>), Instance);
                int r = func(Bank, Channel);

                return r;
            } catch {
                return -1;
            }
        }

    }
}

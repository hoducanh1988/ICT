using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using AppTestICT_Ver1.Func.Global;

namespace AppTestICT_Ver1.Func.Instrument {
    public class Instrument {

        protected Type t = null;
        protected object Instance = null;


        public bool IsConnected {
            get {
                if (t == null || Instance == null) return false;
                PropertyInfo propertyIsConnected = t.GetProperty("IsConnected");
                return (bool)propertyIsConnected.GetValue(Instance, null);
            }
        }


        /// <summary>
        /// Load DLL file to application, return : 0=Success, 1=Error DLL file, -1=Error software
        /// </summary>
        /// <param name="dllFileName">Keithley2110, Keithley2110.dll, Keithley2110.DLL</param>
        /// <returns></returns>
        public int LoadLibrary(string dllFileName, InstrumentType insType) {
            try {
                Assembly asm = Assembly.LoadFrom(string.Format("{0}{1}.dll", AppDomain.CurrentDomain.BaseDirectory, dllFileName.Replace(".dll", "").Replace(".DLL", "").Trim()));
                t = asm.GetType(string.Format("{0}.{1}", dllFileName.Replace(".dll", "").Replace(".DLL", "").Trim(), insType.ToString()));
                Instance = Activator.CreateInstance(t);

                return (t == null || Instance == null) ? 1 : 0;
            }
            catch {
                return -1;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Open(int conType, string address) {
            if (t == null || Instance == null) return 1;

            // Reflection Method
            MethodInfo methodOpen = t.GetMethod("Open", new Type[] { typeof(int), typeof(string) });
            if (methodOpen == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[2];
            parameters[0] = conType;
            parameters[1] = address;

            // Invoke method
            bool result = (bool)methodOpen.Invoke(Instance, parameters);

            //Return value
            return result == true ? 0 : 1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Close() {
            if (t == null || Instance == null) return 1;

            // Reflection Method
            MethodInfo methodClose = t.GetMethod("Close");
            if (methodClose == null) return -1;

            // Invoke method
            bool result = (bool)methodClose.Invoke(Instance, null);

            // Return value
            return result == true ? 0 : 1;
        }

    }
}

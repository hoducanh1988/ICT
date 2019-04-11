using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Reflection;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.Instrument {
    public abstract class AbstractInstrument {

        protected Type t = null;
        protected object Instance = null;


        bool _isconnected = false;
        public bool IsConnected {
            get {
                if (t == null || Instance == null) return false;
                if (!_isconnected) {
                    PropertyInfo propertyIsConnected = t.GetProperty("IsConnected");
                    _isconnected = (bool)propertyIsConnected.GetValue(Instance, null);
                }
                return _isconnected;
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


        public int Open() {
            if (t == null || Instance == null) return 1;

            // Reflection Method
            MethodInfo methodOpen = t.GetMethod("Open");
            if (methodOpen == null) return -1;

            // Invoke method - Invoke
            //bool result = (bool)methodOpen.Invoke(Instance, null);

            // Invoke method - CreateDelegate
            var func = (Func<bool>)methodOpen.CreateDelegate(typeof(Func<bool>), Instance);
            bool result = func();

            //Return value
            return result == true ? 0 : 1;
        }

        public int Open(string visaaddress) {
            if (t == null || Instance == null) return 1;

            // Reflection Method
            MethodInfo methodOpen = t.GetMethod("Open", new Type[] { typeof(string) });
            if (methodOpen == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[1];
            parameters[0] = visaaddress;

            // Invoke method - Invoke
            //bool result = (bool)methodOpen.Invoke(Instance, parameters);

            // Invoke method - CreateDelegate
            var func = (Func<string, bool>)methodOpen.CreateDelegate(typeof(Func<string, bool>), Instance);
            bool result = func(visaaddress);

            //Return value
            return result == true ? 0 : 1;
        }

        public int Open(string ip, string port, string user, string pass) {
            if (t == null || Instance == null) return 1;

            // Reflection Method
            MethodInfo methodOpen = t.GetMethod("Open", new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) });
            if (methodOpen == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[4];
            parameters[0] = ip;
            parameters[1] = port;
            parameters[2] = user;
            parameters[3] = pass;

            // Invoke method - Invoke
            //bool result = (bool)methodOpen.Invoke(Instance, parameters);

            // Invoke method - CreateDelegate
            var func = (Func<string, string, string, string, bool>)methodOpen.CreateDelegate(typeof(Func<string, string, string, string, bool>), Instance);
            bool result = func(ip, port, user, pass);

            //Return value
            return result == true ? 0 : 1;
        }

        public int Open(string portname, string baudrate, string databits, Parity parity, StopBits stopbits) {
            if (t == null || Instance == null) return 1;

            // Reflection Method
            MethodInfo methodOpen = t.GetMethod("Open", new Type[] { typeof(string), typeof(string), typeof(string), typeof(Parity), typeof(StopBits) });
            if (methodOpen == null) return -1;

            // Specify parameters for the method we will be invoking
            object[] parameters = new object[5];
            parameters[0] = portname;
            parameters[1] = baudrate;
            parameters[2] = databits;
            parameters[3] = parity;
            parameters[4] = stopbits;

            // Invoke method - Invoke
            //bool result = (bool)methodOpen.Invoke(Instance, parameters);

            // Invoke method - CreateDelegate
            var func = (Func<string, string, string, Parity, StopBits, bool>)methodOpen.CreateDelegate(typeof(Func<string, string, string, Parity, StopBits, bool>), Instance);
            bool result = func(portname, baudrate, databits, parity, stopbits);

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

            // Invoke method - Invoke
            //bool result = (bool)methodClose.Invoke(Instance, null);

            // Invoke method - CreateDelegate
            var func = (Func<bool>)methodClose.CreateDelegate(typeof(Func<bool>), Instance);
            bool result = func();

            // Return value
            return result == true ? 0 : 1;
        }




    }
}

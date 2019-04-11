using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

using Equipment;
using Protocol;

namespace Keithley2110 {
    public class Meter : IMultimeter {

        #region 1. VARIABLES -------------------------------//
        class ModeInfo {
            public bool flagRange { get; set; }
            public bool flagResolution { get; set; }
            public string ResolutionValue { get; set; }
            public string modeExpress { get; set; }
        }

        enum MeasureMode {
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

        Dictionary<int, ModeInfo> dictModeString = new Dictionary<int, ModeInfo>() {
            { 0, new ModeInfo() { modeExpress = "VOLTage:DC", flagRange = true, flagResolution = true, ResolutionValue = "0.0000003" } },
            { 1, new ModeInfo() { modeExpress = "CURRent:DC", flagRange = true, flagResolution = true, ResolutionValue = "0.0000003" } },
            { 2, new ModeInfo() { modeExpress = "VOLTage:AC", flagRange = true, flagResolution = true, ResolutionValue = "0.000001" } },
            { 3, new ModeInfo() { modeExpress = "CURRent:AC", flagRange = true, flagResolution = true, ResolutionValue = "0.000001" } },
            { 4, new ModeInfo() { modeExpress = "RESistance", flagRange = true, flagResolution = true, ResolutionValue = "0.0000003" } },
            { 5, new ModeInfo() { modeExpress = "FRESistance", flagRange = true, flagResolution = true, ResolutionValue = "0.0000003" } },
            { 6, new ModeInfo() { modeExpress = "FREQuency:VOLT", flagRange = true, flagResolution = false } },
            { 7, new ModeInfo() { modeExpress = "FREQuency:CURR", flagRange = true, flagResolution = false } },
            { 8, new ModeInfo() { modeExpress = "PERiod:VOLT", flagRange = true, flagResolution = false } },
            { 9, new ModeInfo() { modeExpress = "PERiod:CURR", flagRange = true, flagResolution = false } },
            { 10, new ModeInfo() { modeExpress = "CAPacitance", flagRange = true, flagResolution = false } },
            { 11, new ModeInfo() { modeExpress = "CONTinuity", flagRange = false, flagResolution = false } },
            { 12, new ModeInfo() { modeExpress = "DIODe", flagRange = false, flagResolution = false } },
        };

        IProtocol device;

        #endregion -----------------------------------------//

        #region 2. SUB FUNCTION ----------------------------//

        bool _preset_device() {
            //device.WriteLine("*RST");
            //device.WriteLine("*CLS");
            return device.WriteLine(":SYSTem:PRESet");
        }

        double _read_measured_value(int measure_time) {
            List<double> results = new List<double>();
            int count = 0;
        REP:
            count++;
            double v;
            bool r = double.TryParse(device.Query(":READ?"), out v); //read buffer
            if (r == true) results.Add(v);
            if (count < measure_time) goto REP;

            return results.Count > 0 ? Math.Round(results.Average(), 9) : double.MinValue;
        }

        bool _configure_mode(MeasureMode mode, string range) {
            ModeInfo modeInfo = new ModeInfo();
            bool r = dictModeString.TryGetValue((int)mode, out modeInfo);

            //
            // switch mode
            //
            r = device.WriteLine(string.Format(":CONFigure:{0}", modeInfo.modeExpress));
            if (!r) return false;

            //
            // set range
            if (modeInfo.flagRange == true) {
                if (string.IsNullOrEmpty(range) == true || string.IsNullOrWhiteSpace(range) == true || range == "-") {
                    //set range auto
                    r = device.WriteLine(string.Format(":{0}:RANGe:AUTO 1", modeInfo.modeExpress));
                    if (!r) return false;
                }
                else {
                    //set auto range off
                    r = device.WriteLine(string.Format(":{0}:RANGe:AUTO 0", modeInfo.modeExpress));
                    if (!r) return false;

                    //set range manual
                    r = device.WriteLine(string.Format(":{0}:RANGe {1}", modeInfo.modeExpress, range));
                    if (!r) return false;
                }
            }

            //
            // resolution
            //
            if (modeInfo.flagResolution == true) {
                r = device.WriteLine(string.Format(":{0}:RESolution {1}", modeInfo.modeExpress, modeInfo.ResolutionValue));
                if (!r) return false;
            }

            device.Query(":CONFigure?");

            //Wait mode is stable
            Thread.Sleep(100);

            return r;
        }

        double _measured_value(MeasureMode mode, int measure_time, int waittime, string range) {

            //Preset device
            if (!_preset_device()) return double.MinValue;

            //switch device to DCI mode
            if (!_configure_mode(mode, range)) return double.MinValue;

            //delay
            if (waittime > 0) Thread.Sleep(waittime);

            //Get DC current value
            return _read_measured_value(measure_time);
        }


        #endregion -----------------------------------------//

        #region 3. COMMON ----------------------------------//

        public bool IsConnected {
            get {
                if (device == null) return false;
                return device.IsConnected();
            }
        }

        public bool Open() {
            return false;
        }

        public bool Open(string visaaddress) {
            device = new SCPI();
            return device.Open(visaaddress);
        }

        public bool Open(string portname, string baudrate, string databits, Parity parity, StopBits stopbits) {
            return false;
        }

        public bool Open(string ip, string portnumber, string user, string password) {
            return false;
        }

        public bool Close() {
            if (device == null) return false;
            return device.Close();
        }

        #endregion -----------------------------------------//

        #region 4. MAIN ------------------------------------//

        //double.MinValue = error may do
        //OK
        public double get_DC_Current_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.DC_Current, measure_time, waittime, range);

        }

        //OK
        public double get_DC_Voltage_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.DC_Volt, measure_time, waittime, range);

        }

        //OK
        public double get_AC_Current_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.AC_Current, measure_time, waittime, range);
        }

        //OK
        public double get_AC_Voltage_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.AC_Volt, measure_time, waittime, range);

        }

        //OK
        public double get_TwoWire_Resistance_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.RES_2Wire, measure_time, waittime, range);

        }

        //OK
        public double get_FourWire_Resistance_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.RES_4Wire, measure_time, waittime, range);

        }

        //OK
        public double get_Continuity_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.Continuity, measure_time, waittime, range);

        }

        //OK
        public double get_Diode_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.Diode, measure_time, waittime, range);

        }

        //OK
        public double get_Capacitance_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.Capacitance, measure_time, waittime, range);

        }

        //uncheck
        public double get_Frequency_Voltage_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.FREQ_Volt, measure_time, waittime, range);

        }

        //uncheck
        public double get_Frequency_Current_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.FREQ_Current, measure_time, waittime, range);

        }

        //uncheck
        public double get_Period_Voltage_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.PED_Volt, measure_time, waittime, range);

        }

        //uncheck
        public double get_Period_Current_Value(int measure_time, int waittime, string range) {
            if (device == null || this.IsConnected == false) return double.MinValue;
            return _measured_value(MeasureMode.PED_Current, measure_time, waittime, range);

        }

        #endregion -----------------------------------------//
    }


}

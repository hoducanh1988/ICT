using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.IO {

    public abstract class AbstractLogger {

        protected string dir_Jig_Index = ""; //log

        public AbstractLogger() {
            bool r = string.IsNullOrEmpty(myGlobal.settingInfo.ResultPath) || myGlobal.settingInfo.ResultPath.ToLower().Contains("default");
            string _dir = r == true ? AppDomain.CurrentDomain.BaseDirectory : myGlobal.settingInfo.ResultPath;

            //Create RootLogDirectory folder
            if (!Directory.Exists(_dir)) Directory.CreateDirectory(_dir);

            //Create ProductName Folder
            _dir = Path.Combine(_dir, Properties.Settings.Default.ScriptName.ToLower().Replace(".csv", "").Replace("script_test_", ""));
            if (!Directory.Exists(_dir)) Directory.CreateDirectory(_dir);

            //Create StationName Folder
            _dir = Path.Combine(_dir, "ict");
            if (!Directory.Exists(_dir)) Directory.CreateDirectory(_dir);

            //Create JigIndex Folder
            _dir = Path.Combine(_dir, myGlobal.settingInfo.JigNumber);
            if (!Directory.Exists(_dir)) Directory.CreateDirectory(_dir);

            dir_Jig_Index = _dir;
        }
    }


    public class VnptTestItemInfo {
        public VnptTestItemInfo() {
            Lower_Limit = Upper_Limit = Actual_Value = Unit_Of_Measurement = Result = "NONE";
        }

        public string Lower_Limit { get; set; }
        public string Upper_Limit { get; set; }
        public string Actual_Value { get; set; }
        public string Unit_Of_Measurement { get; set; }
        public string Result { get; set; }
    }


    public class VnptLogMoreInfo {

        public VnptLogMoreInfo() {
            Info1 = Info2 = Info3 = Info4 = Info5 = Info6 = Info7 = Info8 = Info9 = Info10 = "";
        }

        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public string Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
        public string Info8 { get; set; }
        public string Info9 { get; set; }
        public string Info10 { get; set; }
    }



}

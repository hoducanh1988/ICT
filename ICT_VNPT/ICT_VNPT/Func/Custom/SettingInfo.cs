using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.Custom
{
    public class SettingInfo : CNotifyPropertyChanged {

        //Constructor
        public SettingInfo() {

            //test case
            ItemError = "Stop";
            EnablePower = "Yes";
            OFFPower = "Yes";
            ResetSwitch = "Yes";

            //test tree option
            LoadRecent = "No";
            ShowTestItem = "Yes";
            ShowTestUnit = "Yes";
            ShowTreeRegistry = "Yes";
            CasePath = AppDomain.CurrentDomain.BaseDirectory;

            //go or no go option
            InputSerial = "Yes";

            //Test result option
            ResultSaveLog = "Yes";
            ResultFileFormat = "*.CSV";
            
            if (Directory.Exists("D:\\LOGDATA")) ResultPath = "D:\\LOGDATA";
            else ResultPath = AppDomain.CurrentDomain.BaseDirectory;

            ResultCreateSub = "Yes";
            ResultScroll = "Yes";

            //Debug log
            ShowTablogMeter = true;
            ShowTablogSwitch = true;
            ShowTablogPower = true;
            DebugTextLimit = "10000";
            DebugPath = AppDomain.CurrentDomain.BaseDirectory;
            DebugCreateSub = "Yes";
            DebugScroll = "Yes";

            //Label Printer
            PrintLabel = "No";
            PrinterName = "";

            //Permission optional
            PermissionAccess = "0";

        }

        #region  Test case option

        string _itemerr;
        public string ItemError {
            get { return _itemerr; }
            set {
                _itemerr = value;
                OnPropertyChanged(nameof(ItemError));
            }
        }
        string _enablepower;
        public string EnablePower {
            get { return _enablepower; }
            set {
                _enablepower = value;
                OnPropertyChanged(nameof(EnablePower));
            }
        }
        string _offpower;
        public string OFFPower {
            get { return _offpower; }
            set {
                _offpower = value;
                OnPropertyChanged(nameof(OFFPower));
            }
        }
        string _resetswitch;
        public string ResetSwitch {
            get { return _resetswitch; }
            set {
                _resetswitch = value;
                OnPropertyChanged(nameof(ResetSwitch));
            }
        }

        #endregion

        #region Test tree option

        string _loadrecent;
        public string LoadRecent {
            get { return _loadrecent; }
            set {
                _loadrecent = value;
                OnPropertyChanged(nameof(LoadRecent));
            }
        }
        string _showtestitem;
        public string ShowTestItem {
            get { return _showtestitem; }
            set {
                _showtestitem = value;
                OnPropertyChanged(nameof(ShowTestItem));
            }
        }
        string _showtestunit;
        public string ShowTestUnit {
            get { return _showtestunit; }
            set {
                _showtestunit = value;
                OnPropertyChanged(nameof(ShowTestUnit));
            }
        }
        string _showtreeregistry;
        public string ShowTreeRegistry {
            get { return _showtreeregistry; }
            set {
                _showtreeregistry = value;
                OnPropertyChanged(nameof(ShowTreeRegistry));
            }
        }
        string _casepath;
        public string CasePath {
            get { return _casepath; }
            set {
                _casepath = value;
                OnPropertyChanged(nameof(CasePath));
            }
        }

        #endregion

        #region Go/NoGo option

        string _inputserial;
        public string InputSerial {
            get { return _inputserial; }
            set {
                _inputserial = value;
                OnPropertyChanged(nameof(InputSerial));
            }
        }

        #endregion

        #region Test result option

        string _resultsavelog;
        public string ResultSaveLog {
            get { return _resultsavelog; }
            set {
                _resultsavelog = value;
                OnPropertyChanged(nameof(ResultSaveLog));
            }
        }
        string _resultfileformat;
        public string ResultFileFormat {
            get { return _resultfileformat; }
            set {
                _resultfileformat = value;
                OnPropertyChanged(nameof(ResultFileFormat));
            }
        }
        string _resultpath;
        public string ResultPath {
            get { return _resultpath; }
            set {
                _resultpath = value;
                OnPropertyChanged(nameof(ResultPath));
            }
        }
        string _resultcreatesub;
        public string ResultCreateSub {
            get { return _resultcreatesub; }
            set {
                _resultcreatesub = value;
                OnPropertyChanged(nameof(ResultCreateSub));
            }
        }
        string _resultscroll;
        public string ResultScroll {
            get { return _resultscroll; }
            set {
                _resultscroll = value;
                OnPropertyChanged(nameof(ResultScroll));
            }
        }

        #endregion

        #region Debug log

        bool _showtablogmeter;
        public bool ShowTablogMeter {
            get { return _showtablogmeter; }
            set {
                _showtablogmeter = value;
                myGlobal.debugLog.ShowMeter = value;
                OnPropertyChanged(nameof(ShowTablogMeter));
            }
        }
        bool _showtablogswitch;
        public bool ShowTablogSwitch {
            get { return _showtablogswitch; }
            set {
                _showtablogswitch = value;
                myGlobal.debugLog.ShowSW = value;
                OnPropertyChanged(nameof(ShowTablogSwitch));
            }
        }
        bool _showtablogpower;
        public bool ShowTablogPower {
            get { return _showtablogpower; }
            set {
                _showtablogpower = value;
                myGlobal.debugLog.ShowPW = value;
                OnPropertyChanged(nameof(ShowTablogPower));
            }
        }
        string _debugtextlimit;
        public string DebugTextLimit {
            get { return _debugtextlimit; }
            set {
                _debugtextlimit = value;
                OnPropertyChanged(nameof(DebugTextLimit));
            }
        }
        string _debugpath;
        public string DebugPath {
            get { return _debugpath; }
            set {
                _debugpath = value;
                OnPropertyChanged(nameof(DebugPath));
            }
        }
        string _debugcreatesub;
        public string DebugCreateSub {
            get { return _debugcreatesub; }
            set {
                _debugcreatesub = value;
                OnPropertyChanged(nameof(DebugCreateSub));
            }
        }
        string _debugscroll;
        public string DebugScroll {
            get { return _debugscroll; }
            set {
                _debugscroll = value;
                OnPropertyChanged(nameof(DebugScroll));
            }
        }

        #endregion

        #region label printer

        string _printlabel;
        public string PrintLabel {
            get { return _printlabel; }
            set {
                _printlabel = value;
                OnPropertyChanged(nameof(PrintLabel));
            }
        }
        string _printername;
        public string PrinterName {
            get { return _printername; }
            set {
                _printername = value;
                OnPropertyChanged(nameof(PrinterName));
            }
        }

        #endregion

        #region Permission optional

        string _permissionaccess;
        public string PermissionAccess {
            get { return _permissionaccess; }
            set {
                _permissionaccess = value;
                OnPropertyChanged(nameof(PermissionAccess));
            }
        }

        #endregion

    }
}

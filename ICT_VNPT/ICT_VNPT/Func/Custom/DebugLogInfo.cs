using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;

namespace ICT_VNPT.Func.Custom
{
    public class DebugLogInfo : CNotifyPropertyChanged {


        public void Clear() {

            SystemLog = "";
            MeterLog = "";
            SwitchLog = "";
            PowerLog = "";
            ErrorLog = "";
        }

        bool _showmeter;
        public bool ShowMeter {
            get { return _showmeter; }
            set {
                _showmeter = value;
                OnPropertyChanged(nameof(ShowMeter));
            }
        }
        bool _showsw;
        public bool ShowSW {
            get { return _showsw; }
            set {
                _showsw = value;
                OnPropertyChanged(nameof(ShowSW));
            }
        }
        bool _showpw;
        public bool ShowPW {
            get { return _showpw; }
            set {
                _showpw = value;
                OnPropertyChanged(nameof(ShowPW));
            }
        }
        
        string _systemlog;
        public string SystemLog {
            get { return _systemlog; }
            set {
                _systemlog = value;
                OnPropertyChanged(nameof(SystemLog));
            }
        }
        string _meterlog;
        public string MeterLog {
            get { return _meterlog; }
            set {
                _meterlog = value;
                OnPropertyChanged(nameof(MeterLog));
            }
        }
        string _switchlog;
        public string SwitchLog {
            get { return _switchlog; }
            set {
                _switchlog = value;
                OnPropertyChanged(nameof(SwitchLog));
            }
        }
        string _powerlog;
        public string PowerLog {
            get { return _powerlog; }
            set {
                _powerlog = value;
                OnPropertyChanged(nameof(PowerLog));
            }
        }
        string _errorlog;
        public string ErrorLog {
            get { return _errorlog; }
            set {
                _errorlog = value;
                OnPropertyChanged(nameof(ErrorLog));
            }
        }

    }
}

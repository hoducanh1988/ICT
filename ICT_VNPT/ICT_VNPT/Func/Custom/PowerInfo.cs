using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;

namespace ICT_VNPT.Func.Custom {
    public class PowerInfo : CNotifyPropertyChanged {

        public PowerInfo() {
            IsPower = "False";
            OutVoltage = "12";
            OutCurrent = "2";
            OverVoltage = "15.5";
            OverCurrent = "2.5";
            IsProtect = "True";
            VoltStep = "0.0001";
            CurrentStep = "0.0001";
            TriggerSource = "IMM";
            TriggerDelay = "0";
            VoltRange = "P15V";
        }

        public override string ToString() {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", OutVoltage, OutCurrent, IsProtect, OverVoltage, OverCurrent, VoltStep, CurrentStep, TriggerSource, TriggerDelay, VoltRange);
        }

        string _outvolt;
        public string OutVoltage {
            get { return _outvolt; }
            set {
                _outvolt = value;
                OnPropertyChanged(nameof(OutVoltage));
            }
        }
        string _outcurr;
        public string OutCurrent {
            get { return _outcurr; }
            set {
                _outcurr = value;
                OnPropertyChanged(nameof(OutCurrent));
            }
        }
        string _overvolt;
        public string OverVoltage {
            get { return _overvolt; }
            set {
                _overvolt = value;
                OnPropertyChanged(nameof(OverVoltage));
            }
        }
        string _overcurr;
        public string OverCurrent {
            get { return _overcurr; }
            set {
                _overcurr = value;
                OnPropertyChanged(nameof(OverCurrent));
            }
        }
        string _isprotect;
        public string IsProtect {
            get { return _isprotect; }
            set {
                _isprotect = value;
                OnPropertyChanged(nameof(IsProtect));
            }
        }
        string _ispower;
        public string IsPower {
            get { return _ispower; }
            set {
                _ispower = value;
                OnPropertyChanged(nameof(IsPower));
            }
        }
        public string VoltStep { get; set; }
        public string CurrentStep { get; set; }
        public string TriggerSource { get; set; }
        public string TriggerDelay { get; set; }
        public string VoltRange { get; set; }
    }
}

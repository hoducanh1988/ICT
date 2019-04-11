using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.Custom {

    public class GoTestInfo : CNotifyPropertyChanged {

        public GoTestInfo() {
            PCName = System.Environment.MachineName;
            IPAddress = "";
            IsStartActive = true;
            IsQuitActive = false;
            TestTime = "00:00:00";
            TotalTestTime = "00:00:00";
            AvrTestTime = "00:00:00";
            ProgressValue = 0;
            ProgressMax = 1;
        }


        public void Clear() {
            TestTime = "00:00:00";
            IsStartActive = true;
            IsQuitActive = false;
            ProgressValue = 0;
            ProgressMax = 1;
            TotalResult = "";
            SN = "";
            ErrorCode = "";
            ErrorString = "";
            ErrorItem = "";
        }

        string _result;
        public string TotalResult {
            get { return _result; }
            set {
                _result = value;
                OnPropertyChanged(nameof(TotalResult));

                if (_result == "Passed" || _result == "Failed") {
                    PassedCount = myGlobal.goPassedCount;
                    FailedCount = myGlobal.goTotalTestCount - myGlobal.goPassedCount;
                    YIELD = (double)Math.Round( (myGlobal.goPassedCount * 100) / myGlobal.goTotalTestCount, 2);

                    TimeSpan time_tt = TimeSpan.FromMilliseconds(myGlobal.goTotalTestTime);
                    TimeSpan time_tav = TimeSpan.FromMilliseconds(myGlobal.goTotalTestTime / myGlobal.goTotalTestCount);
                    TotalTestTime = time_tt.ToString("hh':'mm':'ss");
                    AvrTestTime = time_tav.ToString("hh':'mm':'ss");
                }
            }
        }
        string _testtime;
        public string TestTime {
            get { return _testtime; }
            set {
                _testtime = value;
                OnPropertyChanged(nameof(TestTime));
            }
        }
        string _totaltesttime;
        public string TotalTestTime {
            get { return _totaltesttime; }
            set {
                _totaltesttime = value;
                OnPropertyChanged(nameof(TotalTestTime));
            }
        }
        string _avrtesttime;
        public string AvrTestTime {
            get { return _avrtesttime; }
            set {
                _avrtesttime = value;
                OnPropertyChanged(nameof(AvrTestTime));
            }
        }
        double _failedcount;
        public double FailedCount {
            get { return _failedcount; }
            set {
                _failedcount = value;
                OnPropertyChanged(nameof(FailedCount));
            }
        }
        double _passedcount;
        public double PassedCount {
            get { return _passedcount; }
            set {
                _passedcount = value;
                OnPropertyChanged(nameof(PassedCount));
            }
        }
        double _yield;
        public double YIELD {
            get { return _yield; }
            set {
                _yield = value;
                OnPropertyChanged(nameof(YIELD));
            }
        }
        string _pcname;
        public string PCName {
            get { return _pcname; }
            set {
                _pcname = value;
                OnPropertyChanged(nameof(PCName));
            }
        }
        string _ipaddress;
        public string IPAddress {
            get { return _ipaddress; }
            set {
                _ipaddress = value;
                OnPropertyChanged(nameof(IPAddress));
            }
        }
        string _sn;
        public string SN {
            get { return myGlobal.dutSerialNumber; }
            set {
                _sn = value;
                OnPropertyChanged(nameof(SN));
            }
        }
        string _erroritem;
        public string ErrorItem {
            get { return _erroritem; }
            set {
                _erroritem = value;
                OnPropertyChanged(nameof(ErrorItem));
            }
        }
        string _errorcode;
        public string ErrorCode {
            get { return _errorcode; }
            set {
                _errorcode = value;
                OnPropertyChanged(nameof(ErrorCode));
            }
        }
        string _errorstring;
        public string ErrorString {
            get { return _errorstring; }
            set {
                _errorstring = value;
                OnPropertyChanged(nameof(ErrorString));
            }
        }

        bool _isstartactive;
        public bool IsStartActive {
            get { return _isstartactive; }
            set {
                _isstartactive = value;
                OnPropertyChanged(nameof(IsStartActive));
            }
        }
        bool _isquitactive;
        public bool IsQuitActive {
            get { return _isquitactive; }
            set {
                _isquitactive = value;
                OnPropertyChanged(nameof(IsQuitActive));
            }
        }

        int _progressvalue;
        public int ProgressValue {
            get { return _progressvalue; }
            set {
                _progressvalue = value;
                OnPropertyChanged(nameof(ProgressValue));
            }
        }
        int _progressmax;
        public int ProgressMax {
            get { return _progressmax; }
            set {
                _progressmax = value;
                OnPropertyChanged(nameof(ProgressMax));
            }
        }

    }
}

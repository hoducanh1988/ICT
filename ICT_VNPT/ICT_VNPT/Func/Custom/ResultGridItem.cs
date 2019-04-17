using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.Custom {
    public class ResultGridItem : CNotifyPropertyChanged {

        public ResultGridItem() {
            SerialNumber = "";
            ItemName = "";
            UnitType = "";
            ItemUnit = "";
            RetryTime = "";
            NumValue = "";
            LowerLimit = "";
            UpperLimit = "";
            UOM = "";
            UnitType = "";
            ItemResult = "";
        }

        public override string ToString() {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"",
                                SerialNumber,
                                ItemName,
                                ItemUnit,
                                RetryTime,
                                LowerLimit,
                                NumValue,
                                UpperLimit,
                                UOM,
                                ItemResult,
                                TestTime,
                                ErrorCode,
                                ItemMessage
                                );
        }

        string _sn;
        public string SerialNumber {
            get { return _sn; }
            set {
                _sn = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        string _itemname;
        public string ItemName {
            get { return _itemname; }
            set {
                _itemname = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }
        string _unittype;
        public string UnitType {
            get { return _unittype; }
            set {
                _unittype = value;
                OnPropertyChanged(nameof(UnitType));
            }
        }

        string _itemunit;
        public string ItemUnit {
            get { return _itemunit; }
            set {
                _itemunit = value;

                string uom;
                bool r = myParameter.dictUOM.TryGetValue(_itemunit, out uom);
                if (r == true) {
                    if (UnitType == null || UnitType == "-") UOM = uom;
                    else UOM = UnitType + uom;
                }

                OnPropertyChanged(nameof(ItemUnit));
            }
        }
        string _retrytime;
        public string RetryTime {
            get { return _retrytime; }
            set {
                _retrytime = value;
                OnPropertyChanged(nameof(RetryTime));
            }
        }
        string _lowerlimit;
        public string LowerLimit {
            get { return _lowerlimit; }
            set {
                _lowerlimit = value;
                OnPropertyChanged(nameof(LowerLimit));
            }
        }
        string _upperlimit;
        public string UpperLimit {
            get { return _upperlimit; }
            set {
                _upperlimit = value;
                OnPropertyChanged(nameof(UpperLimit));
            }
        }
        string _value;
        public string NumValue {
            get { return _value; }
            set {
                _value = value;
                OnPropertyChanged(nameof(NumValue));
            }
        }
        string _uom;
        public string UOM {
            get { return _uom; }
            set {
                _uom = value;
                OnPropertyChanged(nameof(UOM));
            }
        }
        string _itemresult;
        public string ItemResult {
            get { return _itemresult; }
            set {
                _itemresult = value;
                OnPropertyChanged(nameof(ItemResult));
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
        string _itemmessage;
        public string ItemMessage {
            get { return _itemmessage; }
            set {
                _itemmessage = value;
                OnPropertyChanged(nameof(ItemMessage));
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.Func.Custom {

    public class TestItemInfo : CNotifyPropertyChanged  {

        public TestItemInfo() {
            LowerValue = "0";
            UpperValue = "-1";
            MeasureTime = "3";
            RetryTime = "1";
            WaitTime = "0";
            IsCheck = "True";
            IsPower = "False";
            ItemResult = "";
            ItemUnit = "R";
            UnitType = "-";
            Range = "-";
        }


        public override string ToString() {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\"",
                                 OrderNo,
                                 ItemName,
                                 Bank1,
                                 Bank2,
                                 ItemUnit,
                                 UnitType,
                                 LowerValue,
                                 UpperValue,
                                 MeasureTime,
                                 RetryTime,
                                 WaitTime,
                                 Range,
                                 IsPower == "True" ? "1" : "0",
                                 IsCheck == "True" ? "1" : "0",
                                 GoodMessage,
                                 ErrorMessage
                );
        }


        string _order;
        public string OrderNo {
            get { return _order; }
            set {
                _order = value;
                OnPropertyChanged(nameof(OrderNo));
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
        string _itemunit;
        public string ItemUnit {
            get { return _itemunit; }
            set {
                _itemunit = value;
                OnPropertyChanged(nameof(ItemUnit));
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
        string _ispower;
        public string IsPower {
            get { return _ispower; }
            set {
                _ispower = value;
                OnPropertyChanged(nameof(IsPower));
            }
        }
        string _ischeck;
        public string IsCheck {
            get { return _ischeck; }
            set {
                _ischeck = value;
                OnPropertyChanged(nameof(IsCheck));
            }
        }

        string _bank1;
        public string Bank1 {
            get { return _bank1; }
            set {
                _bank1 = value;
                OnPropertyChanged(nameof(Bank1));
            }
        }
        string _bank2;
        public string Bank2 {
            get { return _bank2; }
            set {
                _bank2 = value;
                OnPropertyChanged(nameof(Bank2));
            }
        }
        string _lowervalue;
        public string LowerValue {
            get { return _lowervalue; }
            set {
                _lowervalue = value;
                OnPropertyChanged(nameof(LowerValue));
            }
        }
        string _uppervalue;
        public string UpperValue {
            get { return _uppervalue; }
            set {
                _uppervalue = value;
                OnPropertyChanged(nameof(UpperValue));
            }
        }
        string _measuretime;
        public string MeasureTime {
            get { return _measuretime; }
            set {
                _measuretime = value;
                OnPropertyChanged(nameof(MeasureTime));
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
        string _waittime;
        public string WaitTime {
            get { return _waittime; }
            set {
                _waittime = value;
                OnPropertyChanged(nameof(WaitTime));
            }
        }
        string _range;
        public string Range {
            get { return _range; }
            set {
                _range = value;
                OnPropertyChanged(nameof(Range));
            }
        }
       
        string _goodmessage;
        public string GoodMessage {
            get { return _goodmessage; }
            set {
                _goodmessage = value;
                OnPropertyChanged(nameof(GoodMessage));
            }
        }
        string _errormessage;
        public string ErrorMessage {
            get { return _errormessage; }
            set {
                _errormessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        string _result;
        public string ItemResult {
            get { return _result; }
            set {
                _result = value;
                OnPropertyChanged(nameof(ItemResult));
            }
        }
       
    }
}

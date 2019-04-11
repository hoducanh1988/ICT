using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTestICT_Ver1.Func.Ulti;

namespace AppTestICT_Ver1.Func.Custom {
    public class GridTestItem : CNotifyPropertyChanged {

        //Constructor =====================================//
        public GridTestItem() {

        }

        //Properties =======================================//
        string _testitem;
        public string testitem {
            get { return _testitem; }
            set {
                _testitem = value;
                OnPropertyChanged(nameof(testitem));
            }
        }
        string _bank1;
        public string bank1 {
            get { return _bank1; }
            set {
                _bank1 = value;
                OnPropertyChanged(nameof(bank1));
            }
        }
        string _bank2;
        public string bank2 {
            get { return _bank2; }
            set {
                _bank2 = value;
                OnPropertyChanged(nameof(bank2));
            }
        }
        string _unit;
        public string unit {
            get { return _unit; }
            set {
                _unit = value;
                OnPropertyChanged(nameof(unit));
            }
        }
        string _standard;
        public string standard {
            get { return _standard; }
            set {
                _standard = value;
                OnPropertyChanged(nameof(standard));
            }
        }
        string _actual;
        public string actual {
            get { return _actual; }
            set {
                _actual = value;
                OnPropertyChanged(nameof(actual));
            }
        }
        string _result;
        public string result {
            get { return _result; }
            set {
                _result = value;
                OnPropertyChanged(nameof(result));
            }
        }

    }
}

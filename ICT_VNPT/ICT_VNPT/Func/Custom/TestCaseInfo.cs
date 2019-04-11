using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;

namespace ICT_VNPT.Func.Custom {
    public class TestCaseInfo : CNotifyPropertyChanged {

        public TestCaseInfo() {
            Name = "Test-Case";
            Items = new ObservableCollection<TestItemInfo>();
        }

        public string Name { get; set; }

        int _count;
        public int ItemCount {
            get { return Items.Count; }
            set {
                _count = value;
                OnPropertyChanged(nameof(ItemCount));
            }
        }

        public ObservableCollection<TestItemInfo> Items { get; set; }
    }
}

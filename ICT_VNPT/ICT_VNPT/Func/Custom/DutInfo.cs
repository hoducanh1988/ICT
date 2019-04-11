using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.Custom
{
    public class DutInfo
    {
        public DutInfo(string name) {
            Name = name;
            Cases = new ObservableCollection<TestCaseInfo>();
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public ObservableCollection<TestCaseInfo> Cases { get; set; }
    }
}

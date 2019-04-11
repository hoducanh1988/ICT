using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;

namespace ICT_VNPT.Func.Custom
{
    public class MainWindowInfo : CNotifyPropertyChanged {

        public MainWindowInfo() {
            WindowTitle = "ICT_VNPT - ";
        }

        string _windowtitle;
        public string WindowTitle {
            get { return _windowtitle; }
            set {
                _windowtitle = value;
                OnPropertyChanged(nameof(WindowTitle));
            }
        }

    }
}

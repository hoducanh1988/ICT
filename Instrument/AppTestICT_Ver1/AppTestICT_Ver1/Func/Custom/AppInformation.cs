using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTestICT_Ver1.Func.Ulti;

namespace AppTestICT_Ver1.Func.Custom {
    public class AppInformation : CNotifyPropertyChanged {

        //Constructor =====================================//
        public AppInformation() {

            appver = "Phiên bản 1.0.0.0";
            builddate = "Ngày tạo 11/12/2018";
            copyright = "Bản quyền công ty VNPT Technology 2018";
            apptitle = "TOOL TEST I.C.T VER__1 - GW040";
        }

        //Properties =======================================//
        string _appver;
        public string appver {
            get { return _appver; }
            set {
                _appver = value;
                OnPropertyChanged(nameof(appver));
            }
        }
        string _builddate;
        public string builddate {
            get { return _builddate; }
            set {
                _builddate = value;
                OnPropertyChanged(nameof(builddate));
            }
        }
        string _copyright;
        public string copyright {
            get { return _copyright; }
            set {
                _copyright = value;
                OnPropertyChanged(nameof(copyright));
            }
        }
        string _apptitle;
        public string apptitle {
            get { return _apptitle; }
            set {
                _apptitle = value;
                OnPropertyChanged(nameof(apptitle));
            }
        }


    }
}

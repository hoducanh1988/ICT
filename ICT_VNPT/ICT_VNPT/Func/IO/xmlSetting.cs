using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.IO {
    public class xmlSetting {

        public static bool SaveData() {
            try {
                XmlHelper.ToXmlFile(myGlobal.settingInfo, AppDomain.CurrentDomain.BaseDirectory + "Setting.xml");
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool LoadData() {
            try {
                myGlobal.settingInfo = XmlHelper.FromXmlFile<SettingInfo>(AppDomain.CurrentDomain.BaseDirectory + "Setting.xml");
                if (Base.PrinterIsValid(myGlobal.settingInfo.PrinterName)) {
                    myGlobal.myPrintDialog = new System.Windows.Controls.PrintDialog();
                    myGlobal.myPrintDialog.PrintQueue = new PrintQueue(new PrintServer(), myGlobal.settingInfo.PrinterName);
                }
                return true;
            }
            catch {
                return false;
            }
        }

    }
}

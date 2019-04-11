using ICT_VNPT.Func.Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ICT_VNPT.Func.IO {
    public class csvResult {

        public static bool SaveData(string kq) {
            try {
                string folderpath = string.Format("{0}\\LogResult", myGlobal.settingInfo.ResultPath);
                if (Directory.Exists(folderpath) == false) {
                    Directory.CreateDirectory(folderpath);
                    Thread.Sleep(100);
                }

                if (myGlobal.settingInfo.ResultCreateSub == "Yes") {
                    folderpath = string.Format("{0}\\{1}", folderpath, DateTime.Now.ToString("ddMMyyyy"));
                    if (Directory.Exists(folderpath) == false) {
                        Directory.CreateDirectory(folderpath);
                        Thread.Sleep(100);
                    }
                }

                string _title = "\"SN\",\"ItemName\",\"Unit\",\"Retry\",\"LL\",\"Actual\",\"UL\",\"UOM\",\"Result\",\"Time\",\"Code\",\"Message\"";

                StreamWriter sw = new StreamWriter(folderpath + string.Format("\\{0}_{1}_{2}_{3}.csv", myGlobal.dutSerialNumber, DateTime.Now.ToString("ddMMyyyy"), DateTime.Now.ToString("HHmmss"), kq), true, Encoding.Unicode);
                sw.WriteLine(_title);
                foreach (var item in myGlobal.resultGridItems) {
                    sw.WriteLine(item.ToString());
                }
                sw.Dispose();

                return true;
            }
            catch {
                return false;
            }
        }
    }
}

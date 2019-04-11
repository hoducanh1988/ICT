using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;

namespace ICT_VNPT.Func.IO {
    public class xmlResult {

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

                XmlHelper.ToXmlFile(myGlobal.resultGridItems, folderpath + string.Format("\\{0}_{1}_{2}_{3}.xml", myGlobal.dutSerialNumber, DateTime.Now.ToString("ddMMyyyy"), DateTime.Now.ToString("HHmmss"), kq));
                return true;
            }
            catch {
                return false;
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.IO;

namespace ICT_VNPT.Func.Excute {
    public class TestAllItems : AbstractExcute {

        public static bool getResult() {

            if (myGlobal.duts.Count == 0) return false;
            if (myGlobal.duts[0].Cases[0].Items.Count == 0) return false;

            //reset test tree icon
            myGlobal.debugLog.SystemLog += string.Format("# Reset test tree icon.\r\n");
            foreach (var i in myGlobal.duts[0].Cases[0].Items) {
                i.ItemResult = "";
            }

            //reset data grid 
            myGlobal.debugLog.SystemLog += string.Format("# Reset data grid.\r\n");
            App.Current.Dispatcher.Invoke(new Action(() => { myGlobal.resultGridItems.Clear(); }));

            //
            myGlobal.debugLog.SystemLog += string.Format("# Set flag item testing is 1.\r\n");
            myGlobal.IsItemTesting = 1;

            //test item
            int r = 0;
            foreach (var itm in myGlobal.duts[0].Cases[0].Items) {
                myGlobal.debugLog.SystemLog += string.Format("\r\n# Testing item ( name = {0}, unit = {1}, bank1 = {2}, bank2 = {3})\r\n", itm.ItemName, itm.ItemUnit, itm.Bank1, itm.Bank2);
                myGlobal.debugLog.SystemLog += string.Format("~ Is check = {0}\r\n", itm.IsCheck);
                if (itm.IsCheck == "True") {
                    r += TestItem.Validating(itm);

                    if (r != 0 && myGlobal.settingInfo.ItemError == "Stop") {
                        myGlobal.goTestInfo.ProgressValue = myGlobal.goTestInfo.ProgressMax;
                        break;
                    }

                }
                myGlobal.goTestInfo.ProgressValue += 1;
            }

            //off power supply
            if (myGlobal.settingInfo.OFFPower == "Yes") {
                if (myGlobal.settingInfo.EnablePower.ToLower().Contains("yes")) {
                    if (myGlobal.powerDevice != null && myGlobal.powerDevice.IsConnected) set_Power_Supply_OFF();
                }
            }
            
            //reset relay
            if (myGlobal.settingInfo.ResetSwitch == "Yes") {
                if (myGlobal.switchDevice != null && myGlobal.switchDevice.IsConnected) myGlobal.switchDevice.Set_Card_Open();
            }

            //save result xml
            if (myGlobal.settingInfo.ResultSaveLog == "Yes") {
                //if (myGlobal.settingInfo.ResultFileFormat == "*.XML") xmlResult.SaveData(r == 0 ? "PASSED" : "FAILED");
                //if (myGlobal.settingInfo.ResultFileFormat == "*.CSV") csvResult.SaveData(r == 0 ? "PASSED" : "FAILED");

                if (!System.IO.Directory.Exists("D:\\LOGDATA")) {
                    System.IO.Directory.CreateDirectory("D:\\LOGDATA");
                    System.Threading.Thread.Sleep(100);
                }

                new LogTotal().To_CSV_File(new VnptLogMoreInfo()); //log total
            }
            
            //reset SN
            myGlobal.dutSerialNumber = "";
            myGlobal.IsItemTesting = 0;

            return r == 0;
        }

    }
}

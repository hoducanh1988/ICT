using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Custom;

namespace ICT_VNPT.Func.IO {
    public class csvScriptTest {
        
        public static bool ToCsvFile(string filename) {
            try {
                string strTitle = "\"Order\",\"TestItemName\",\"Bank1\",\"Bank2\",\"Unit\",\"UnitType\",\"LowerValue\",\"UpperValue\",\"MeasureTime\",\"Retry\",\"WaitTime\",\"Range\",\"IsPower\",\"IsCheck\",\"GoodMessage\",\"ErrorMessage\"";
                if (myGlobal.duts[0].Path == null)  myGlobal.duts[0].Path = filename;

                StreamWriter sw = new StreamWriter(filename, false, Encoding.Unicode);
                //write title
                sw.WriteLine(strTitle);

                //write content
                foreach (var item in myGlobal.duts[0].Cases[0].Items) {
                    sw.WriteLine(item.ToString());
                }

                //exit
                sw.Dispose();

                myGlobal.windowInfo.WindowTitle = string.Format("ICT_VNPT - {0}", filename);
                return true;
            } catch {
                return false; 
            }
        }


        public static bool FromCsvFile(string filepath, string filename) {
            try {
                StreamReader sr = new StreamReader(filepath, Encoding.Unicode);
                string data = sr.ReadLine(); //ignore title
                //check file format
                string[] buffer = data.Split(new string[] { "\",\"" }, StringSplitOptions.None);
                if (buffer.Length != 16) return false;

                List<TestItemInfo> items = new List<TestItemInfo>();

                //read test item
                while (sr.Peek() != -1) {
                    data = sr.ReadLine();
                    buffer = data.Split(new string[] { "\",\"" }, StringSplitOptions.None);
                    if (buffer.Length != 16) return false;

                    var item = new TestItemInfo() {
                        OrderNo = buffer[0].Replace("\"", "").Trim(),
                        ItemName = buffer[1].Replace("\"", "").Trim(),
                        Bank1 = buffer[2].Replace("\"", "").Trim(),
                        Bank2 = buffer[3].Replace("\"", "").Trim(),
                        ItemUnit = buffer[4].Replace("\"", "").Trim(),
                        UnitType = buffer[5].Replace("\"", "").Trim(),
                        LowerValue = buffer[6].Replace("\"", "").Trim(),
                        UpperValue = buffer[7].Replace("\"", "").Trim(),
                        MeasureTime = buffer[8].Replace("\"", "").Trim(),
                        RetryTime = buffer[9].Replace("\"", "").Trim(),
                        WaitTime = buffer[10].Replace("\"", "").Trim(),
                        Range = buffer[11].Replace("\"", "").Trim(),
                        IsPower = buffer[12].Replace("\"", "").Trim() == "1" ? "True" : "False",
                        IsCheck = buffer[13].Replace("\"", "").Trim() == "1" ? "True" : "False",
                        GoodMessage = buffer[14].Replace("\"", "").Trim(),
                        ErrorMessage  = buffer[15].Replace("\"", "").Trim()
                    };

                    items.Add(item);
                }

                myGlobal.duts.Clear();

                filename = filename.Replace("Script_Test_", "").Replace(".csv", "").Replace(".CSV", "");

                var dut = new ICT_VNPT.Func.Custom.DutInfo(filename) { Path = filepath };
                dut.Cases.Add(new ICT_VNPT.Func.Custom.TestCaseInfo());

                foreach (var i in items) {
                    dut.Cases[0].Items.Add(i);
                }

                myGlobal.duts.Add(dut);
                myGlobal.SelectedItemIndex = -1;

                myGlobal.windowInfo.WindowTitle = string.Format("ICT_VNPT - {0}", filepath);
                return true;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}

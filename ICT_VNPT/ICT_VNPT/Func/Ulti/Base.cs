using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Excute;
using ICT_VNPT.Func.Global;
using System.Printing;

namespace ICT_VNPT.Func.Ulti {
    public class Base {

        /// <summary>
        /// Convert connection type to integer { UART=0, TELNET=1, SCPI=2, DRIVER=3 }
        /// </summary>
        /// <param name="cnnType"></param>
        /// <returns></returns>
        public static int ConvertConnectionTypeToInt(string cnnType) {
            switch (cnnType) {
                case "UART": return 0;
                case "TELNET": return 1;
                case "SCPI": return 2;
                case "DRIVER": return 3;
                default: return 4;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemRoot"></param>
        /// <param name="itemRef"></param>
        /// <returns></returns>
        public static bool assignTestItem(TestItemInfo itemRoot, TestItemInfo itemRef) {
            try {
                itemRoot.OrderNo = itemRef.OrderNo;
                itemRoot.ItemName = itemRef.ItemName;
                itemRoot.ItemUnit = itemRef.ItemUnit;
                itemRoot.IsPower = itemRef.IsPower;
                itemRoot.IsCheck = itemRef.IsCheck;
                itemRoot.Bank1 = itemRef.Bank1;
                itemRoot.Bank2 = itemRef.Bank2;
                itemRoot.LowerValue = itemRef.LowerValue;
                itemRoot.UpperValue = itemRef.UpperValue;
                itemRoot.MeasureTime = itemRef.MeasureTime;
                itemRoot.RetryTime = itemRef.RetryTime;

                itemRoot.GoodMessage = itemRef.GoodMessage;
                itemRoot.ErrorMessage = itemRef.ErrorMessage;
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ResultGridItem FromTestItemInfo(TestItemInfo item) {
            ResultGridItem result = new ResultGridItem();

            result.ItemName = item.ItemName;
            result.UnitType = item.UnitType;
            result.ItemUnit = item.ItemUnit;
            result.LowerLimit = item.LowerValue;
            result.UpperLimit = item.UpperValue;
            result.SerialNumber = myGlobal.dutSerialNumber;

            return result;
        }


        //"Even", "Odd", "None", "Mark", "Space"
        public static Parity StringToParity(string input) {
            switch (input) {
                case "Even": { return Parity.Even; }
                case "Odd": { return Parity.Odd; }
                case "None": { return Parity.None; }
                case "Mark": { return Parity.Mark; }
                case "Space": { return Parity.Space; }
                default: return Parity.None;
            }
        }

        //"1", "1.5", "2" 
        public static StopBits StringToStopBits(string input) {
            switch (input) {
                case "1": { return StopBits.One; }
                case "1.5": { return StopBits.OnePointFive; }
                case "2": { return StopBits.Two; }
                default: return StopBits.None;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="printername"></param>
        /// <returns></returns>
        public static bool PrinterIsValid(string printername) {
            if (printername == null || printername == string.Empty || printername == "") return false;

            LocalPrintServer printServer = new LocalPrintServer();
            PrintQueueCollection printQueuesOnLocalServer = printServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            List<string> printers = printQueuesOnLocalServer.Select(p => p.Name).ToList();

            return printers.Contains(printername);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unittype"></param>
        /// <returns></returns>
        public static double UnitTypeToDouble(string unittype) {
            switch (unittype) {
                case "p": return Math.Pow(10, -12);
                case "n": return Math.Pow(10, -9);
                case "u": return Math.Pow(10, -6);
                case "m": return Math.Pow(10, -3);
                case "-": return Math.Pow(10, 0);
                case "k": return Math.Pow(10, 3);
                case "M": return Math.Pow(10, 6);
                case "G": return Math.Pow(10, 9);
                case "T": return Math.Pow(10, 12);
                case "P": return Math.Pow(10, 15);
                case "E": return Math.Pow(10, 18);
                case "Z": return Math.Pow(10, 21);
                case "Y": return Math.Pow(10, 24);
                default: return Math.Pow(10, 0);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemunit"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static string RangeToMultimeterRange(string itemunit, string range) {
            string data = "";
            switch (itemunit) {
                case "R": {
                        myParameter.dictRangeResistance.TryGetValue(range, out data);
                        break;
                    }
                case "Ca": {
                        myParameter.dictRangeCapacitance.TryGetValue(range, out data);
                        break;
                    }
                case "V": {
                        myParameter.dictRangeDCVoltage.TryGetValue(range, out data);
                        break;
                    }
                case "A": {
                        myParameter.dictRangeDCCurrent.TryGetValue(range, out data);
                        break;
                    }
                default: {
                        data = "-";
                        break;
                    }
            }
            return data;
        }

    }

}

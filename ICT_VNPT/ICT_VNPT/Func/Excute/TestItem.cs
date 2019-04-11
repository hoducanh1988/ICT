using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICT_VNPT.Func.Excute {

    public class TestItem : AbstractExcute {


        public static int Validating(TestItemInfo itemtest) {
            int count = 0;
        REP:
            Stopwatch st = new Stopwatch();
            int err = 0;
            double value = double.MinValue;
            bool kq = false;

            itemtest.ItemResult = "wait";
            ResultGridItem resultItem = Base.FromTestItemInfo(itemtest);
            st.Start();

            count++;
            try {
                myGlobal.debugLog.SystemLog += string.Format("~ try time is {0}/{1}\r\n", count, itemtest.RetryTime);
                //0. kiểm tra thông tin cài đặt item test

                //.............1. kiểm tra kết nối tới máy đo...............................//
                //Switch card
                kq = connect_Switch_Card(ref resultItem);
                myGlobal.debugLog.SystemLog += string.Format("~ check connection to switch card ... {0}\r\n", kq == true ? "Connected" : "Disconnected");
                if (!kq) { err = -1; goto END; }

                //multimeter
                kq = connect_Multimeter(ref resultItem);
                myGlobal.debugLog.SystemLog += string.Format("~ check connection to multimeter ... {0}\r\n", kq == true ? "Connected" : "Disconnected");
                if (!kq) { err = -1; goto END; }

                //power supply
                if (myGlobal.settingInfo.EnablePower.ToLower().Contains("yes")) {
                    kq = connect_Power_Supply(ref resultItem);
                    myGlobal.debugLog.SystemLog += string.Format("~ check connection to power supply ... {0}\r\n", kq == true ? "Connected" : "Disconnected");
                    if (!kq) { err = -1; goto END; }
                }

                //..............2. cấu hình máy đo...........................................//
                if (itemtest.IsPower.ToLower().Contains("true")) {
                    kq = config_Switch_Card(ref resultItem, itemtest);
                    myGlobal.debugLog.SystemLog += string.Format("~ config close channel switch card ... {0}\r\n", kq == true ? "PASS" : "FAIL");
                    if (!kq) { err = 2; goto END; }

                    if (myGlobal.settingInfo.EnablePower.ToLower().Contains("yes")) {
                        //output power supply
                        if (!myGlobal.powerDevice_Output_State) {
                            kq = set_Power_Supply_ON(ref resultItem);
                            myGlobal.debugLog.SystemLog += string.Format("~ set power supply output ... {0}\r\n", kq == true ? "PASS" : "FAIL");
                            if (!kq) { err = 4; goto END; }
                        }
                    }
                }
                else {
                    if (myGlobal.settingInfo.EnablePower.ToLower().Contains("yes")) {
                        //off power supply
                        if (myGlobal.powerDevice_Output_State) {
                            kq = set_Power_Supply_OFF(ref resultItem);
                            myGlobal.debugLog.SystemLog += string.Format("~ set power supply off ... {0}\r\n", kq == true ? "PASS" : "FAIL");
                            if (!kq) { err = 4; goto END; }
                        }
                    }
                    kq = config_Switch_Card(ref resultItem, itemtest);
                    myGlobal.debugLog.SystemLog += string.Format("~ config close channel switch card ... {0}\r\n", kq == true ? "PASS" : "FAIL");
                    if (!kq) { err = 2; goto END; }
                }

                //3. wait contact relay stable
                myGlobal.debugLog.SystemLog += string.Format("~ wait switch card contact relay stable {0} ms\r\n", myGlobal.switchcardInfo.StableTime);
                if (myGlobal.switchcardInfo.StableTime > 0) Thread.Sleep(myGlobal.switchcardInfo.StableTime);

                ////4. get limit
                double ll = double.TryParse(itemtest.LowerValue, out ll) == true ? ll : 0;
                double ul = double.TryParse(itemtest.UpperValue, out ul) == true ? (ul == -1 ? double.MaxValue : ul) : double.MaxValue;

                ll = ll != double.MaxValue && ll != double.MinValue ? ll * Base.UnitTypeToDouble(itemtest.UnitType) : ll;
                ul = ul != double.MaxValue && ul != double.MinValue ? ul * Base.UnitTypeToDouble(itemtest.UnitType) : ul;


                //5. Đo và lấy dữ liệu kết quả từ máy đo
                int r = int.MinValue;
                string mrange = Base.RangeToMultimeterRange(itemtest.ItemUnit, itemtest.Range);
                int wait = int.Parse(itemtest.WaitTime);
                int meastime = int.Parse(itemtest.MeasureTime);

                switch (itemtest.ItemUnit) {
                    case "R": { r = myGlobal.meterDevice.get_TwoWire_Resistance_Value(meastime, wait, mrange, out value); break; } //Resistance 2 wires
                    case "D": { r = myGlobal.meterDevice.get_Diode_Value(meastime, wait, mrange, out value); break; } //Diode
                    case "V": { r = myGlobal.meterDevice.get_DC_Voltage_Value(meastime, wait, mrange, out value); break; } //DC Voltage
                    case "A": { value = double.TryParse(myGlobal.powerDevice.get_Current_Actual_Value(), out value) == true ? value : 0; break; } //DC Current
                    case "Co": { r = myGlobal.meterDevice.get_Continuity_Value(meastime, wait, mrange, out value); break; } //Continuity
                    case "Ca": { r = myGlobal.meterDevice.get_Capacitance_Value(meastime, wait, mrange, out value); break; } //Capacitance
                    case "L": { r = myGlobal.meterDevice.get_TwoWire_Resistance_Value(meastime, wait, mrange, out value); break; } //
                    case "Vac": { r = myGlobal.meterDevice.get_AC_Voltage_Value(meastime, wait, mrange, out value); break; } //AC voltage
                    case "Aac": { r = myGlobal.meterDevice.get_AC_Current_Value(meastime, wait, mrange, out value); break; } //AC current
                    case "Freq": { r = myGlobal.meterDevice.get_Frequency_Voltage_Value(meastime, wait, mrange, out value); break; } //Frequency
                    case "R4": { r = myGlobal.meterDevice.get_FourWire_Resistance_Value(meastime, wait, mrange, out value); break; } //Resistance 4 wires
                    default: break;
                }
                myGlobal.debugLog.SystemLog += string.Format("~ get measured value from multimeter ... {0}\r\n", r == 0 ? "PASS" : "FAIL");

                if (r != 0) {
                    resultItem.ItemMessage = "Can't get measured value from multimeter";
                    err = 3;
                    goto END;
                }

                //6. Phán định pass/fail
                resultItem.NumValue = value.ToString();

                myGlobal.debugLog.SystemLog += string.Format("~ Measured value ... {0}\r\n", value);
                myGlobal.debugLog.SystemLog += string.Format("~ Lower limit ... {0}\r\n", ll);
                myGlobal.debugLog.SystemLog += string.Format("~ Upper limit ... {0}\r\n", ul);
                

                if (value < ll || value > ul) {
                    resultItem.ItemMessage = itemtest.ErrorMessage;
                    err = 1;
                    goto END;
                }
                else {
                    resultItem.ItemMessage = itemtest.GoodMessage;
                    err = 0;
                }
            }

            catch (Exception ex) {
                resultItem.ItemMessage = ex.Message;
                err = -1; //Lỗi tham số cài đặt
                goto END;
            }


        //Hiển thị kết quả đo
        END:
            st.Stop();
            resultItem.TestTime = st.ElapsedMilliseconds.ToString();

            myGlobal.debugLog.SystemLog += string.Format("~ Result = {0}\r\n", err == 0 ? "PASS" : "FAIL");
            resultItem.ItemResult = itemtest.ItemResult = err == 0 ? "passed" : "failed";
            resultItem.ErrorCode = err.ToString();
            if (err != 0 && int.Parse(itemtest.RetryTime) > 1) resultItem.RetryTime = count.ToString();
            else { if (count > 1) resultItem.RetryTime = count.ToString(); }

            App.Current.Dispatcher.Invoke(new Action(() => { myGlobal.resultGridItems.Add(resultItem); }));

            if (count < int.Parse(itemtest.RetryTime) && err != 0) { goto REP; } else return err;
        }



    }
}

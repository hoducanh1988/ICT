using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Instrument;
using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Ulti;
using System.Reflection;

namespace ICT_VNPT.Func.Excute {
    public abstract class AbstractExcute {

        #region Connect device

        //"UART", "TELNET", "SCPI", "DRIVER"
        public static int _openDevice(AbstractInstrument instrument, InstrumentInfo info) {
            switch (info.CnnType) {
                case "UART": {
                        return instrument.Open(info.ComPort, info.ComBaudRate, info.ComDataBit, Base.StringToParity(info.ComParity), Base.StringToStopBits(info.ComStopBit));
                    }
                case "TELNET": {
                        return instrument.Open(info.TelnetIP, info.TelnetPort, info.TelnetUser, info.TelnetPassword);
                    }
                case "SCPI": {
                        return instrument.Open(info.VisaAddress);
                    }
                case "DRIVER": {
                        return instrument.Open();
                    }
                default: return -1;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static bool connect_Switch_Card(ref ResultGridItem Item) {
            try {
                if (myGlobal.switchDevice == null) myGlobal.switchDevice = new SwitchCard();
                if (myGlobal.switchDevice.IsConnected == false) {
                    int r = myGlobal.switchDevice.LoadLibrary(myGlobal.switchcardInfo.DLLFile, InstrumentType.Switcher);
                    if (r == 0) {
                        int kq = _openDevice(myGlobal.switchDevice, myGlobal.switchcardInfo);
                        if (kq == 0) {
                            if (myGlobal.switchDevice.IsConnected == false) {
                                Item.ItemMessage = "can't connect to switch card";
                                return false;
                            }
                            else return true;
                        }
                        else {
                            Item.ItemMessage = "can't open switch card";
                            return false;
                        }
                    }
                    else {
                        Item.ItemMessage = "can't load file dll switch card";
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static bool connect_Multimeter(ref ResultGridItem Item) {
            try {
                if (myGlobal.meterDevice == null) myGlobal.meterDevice = new Multimeter();
                if (myGlobal.meterDevice.IsConnected == false) {
                    int r = myGlobal.meterDevice.LoadLibrary(myGlobal.multimeterInfo.DLLFile, InstrumentType.Meter);
                    if (r == 0) {
                        int kq = _openDevice(myGlobal.meterDevice, myGlobal.multimeterInfo);
                        if (kq == 0) {
                            if (myGlobal.meterDevice.IsConnected == false) {
                                Item.ItemMessage = "can't connect to multimeter";
                                return false;
                            }
                            else return true;
                        }
                        else {
                            Item.ItemMessage = "can't open multimeter";
                            return false;
                        }
                    }
                    else {
                        Item.ItemMessage = "can't load file dll multimeter";
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static bool connect_Power_Supply(ref ResultGridItem Item) {
            try {
                if (myGlobal.powerDevice == null) myGlobal.powerDevice = new PowerSupply();
                if (myGlobal.powerDevice.IsConnected == false) {
                    int r = myGlobal.powerDevice.LoadLibrary(myGlobal.powersupplyInfo.DLLFile, InstrumentType.Power);
                    if (r == 0) {
                        int kq = _openDevice(myGlobal.powerDevice, myGlobal.powersupplyInfo);
                        if (kq == 0) {
                            if (myGlobal.powerDevice.IsConnected == false) {
                                Item.ItemMessage = "can't connect to power supply";
                                return false;
                            }
                            else {
                                return config_Power_Supply(ref Item);
                            }
                        }
                        else {
                            Item.ItemMessage = "can't open power supply";
                            return false;
                        }
                    }
                    else {
                        Item.ItemMessage = "can't load file dll power supply";
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }

        #endregion

        #region Configure device
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static bool config_Power_Supply(ref ResultGridItem Item) {
            try {
                int r = 0;
                
                //preset
                r += myGlobal.powerDevice.Preset();
                Thread.Sleep(1000);

                //set volt range
                r += myGlobal.powerDevice.set_Voltage_Range(double.Parse(myGlobal.powersupplyInfo.OutVoltage));
                Thread.Sleep(1000);

                //set output value
                r += myGlobal.powerDevice.set_Output_Value(double.Parse(myGlobal.powersupplyInfo.OutVoltage), double.Parse(myGlobal.powersupplyInfo.OutCurrent));
                Thread.Sleep(500);

                //set protect value
                r += myGlobal.powerDevice.set_Current_Protection_Level(double.Parse(myGlobal.powersupplyInfo.OverCurrent));
                Thread.Sleep(500);

                r += myGlobal.powerDevice.set_Voltage_Protection_Level(double.Parse(myGlobal.powersupplyInfo.OverVoltage));
                Thread.Sleep(500);

                //set protect flag
                r += myGlobal.powerDevice.set_Voltage_Protection_State(myGlobal.powersupplyInfo.IsProtectVolt == "True" ? true : false);
                Thread.Sleep(500);

                r += myGlobal.powerDevice.set_Current_Protection_State(myGlobal.powersupplyInfo.IsProtectCurrent == "True" ? true : false);
                Thread.Sleep(500);

                //set step
                r += myGlobal.powerDevice.set_Voltage_Step(double.Parse(myGlobal.powersupplyInfo.VoltStep));
                Thread.Sleep(500);

                r += myGlobal.powerDevice.set_Current_Step(double.Parse(myGlobal.powersupplyInfo.CurrentStep));
                Thread.Sleep(500);

                //set trigger
                r += myGlobal.powerDevice.set_Trigger_Delay(double.Parse(myGlobal.powersupplyInfo.TriggerDelay));
                Thread.Sleep(500);

                //remote 
                myGlobal.powerDevice.Remote();
                Thread.Sleep(500);

                if (r == 0) return true;
                else {
                    Item.ItemMessage = "Can't configure power supply";
                    return false;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool config_Switch_Card(ref ResultGridItem Item, TestItemInfo info) {
            try {
                int s = 0;

                //close specified channel and com in bank1
                //--------------------
                //s += myGlobal.switchDevice.Set_Bank_Open(1);
                //s += myGlobal.switchDevice.Set_Channel_Close(1, int.Parse(info.Bank1));

                //close specified channel and com in bank2
                //--------------------
                //s += myGlobal.switchDevice.Set_Bank_Open(2);
                //s += myGlobal.switchDevice.Set_Channel_Close(2, int.Parse(info.Bank2));
                

                //close specified channel and com in Bank1 && Bank2
                //--------------------
                s = myGlobal.switchDevice.Set_Channel_Close(1, int.Parse(info.Bank1), int.Parse(info.Bank2));


                if (s == 0) return true;
                else {
                    Item.ItemMessage = "Can't ON/OFF switch card";
                    return false;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }

        #endregion

        #region Set Power Supply

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static bool set_Power_Supply_ON(ref ResultGridItem Item) {
            try {
                int r = myGlobal.powerDevice.set_Output_State(true);

                if (r == 0) {
                    myGlobal.powerDevice_Output_State = true;
                    return true;
                } else {
                    Item.ItemMessage = "Can't output power supply";
                    return false;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static bool set_Power_Supply_OFF(ref ResultGridItem Item) {
            try {
                int r = myGlobal.powerDevice.set_Output_State(false);

                if (r == 0) {
                    myGlobal.powerDevice_Output_State = false;
                    return true;
                }
                else {
                    Item.ItemMessage = "Can't off power supply";
                    return false;
                }
            }
            catch (Exception ex) {
                Item.ItemMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool set_Power_Supply_OFF() {
            try {
                int r = myGlobal.powerDevice.set_Output_State(false);

                if (r == 0) {
                    myGlobal.powerDevice_Output_State = false;
                    return true;
                } else {
                    return false;
                }
            }
            catch {
                return false;
            }
        }

        #endregion
    }
}

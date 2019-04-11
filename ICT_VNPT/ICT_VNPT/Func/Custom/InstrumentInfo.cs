using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.IO;

namespace ICT_VNPT.Func.Custom {
    public class InstrumentInfo : CNotifyPropertyChanged  {

        //
        //Constructor ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //
        public InstrumentInfo() {

            //switch card
            StableTime = 500; //ms

            //power supply
            OutVoltage = "12";
            OutCurrent = "2";
            OverVoltage = "15.5";
            OverCurrent = "2.5";
            IsProtectVolt = "True";
            IsProtectCurrent = "True";
            VoltStep = "0.0001";
            CurrentStep = "0.0001";
            TriggerSource = "IMM";
            TriggerDelay = "0";
        }

        //
        //Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //

        //
        //Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //
        //
        
        //common
        string _name;
        public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        string _dllfile;
        public string DLLFile {
            get { return _dllfile; }
            set {
                _dllfile = value;
                OnPropertyChanged(nameof(DLLFile));

                //change device
                Name = DLLFile.Replace(".DLL", "").Replace(".dll", "");
                CnnType = "";

                switch (InstType) {
                    case "M": {
                            if (myGlobal.meterDevice != null) {
                                myGlobal.meterDevice.Close();
                                myGlobal.meterDevice = null;

                                
                            }
                            break;
                        }
                    case "S": {
                            if (myGlobal.switchDevice != null) {
                                myGlobal.switchDevice.Close();
                                myGlobal.switchDevice = null;
                            }
                            break;
                        }
                    case "P": {
                            if (myGlobal.powerDevice != null) {
                                myGlobal.powerDevice.Close();
                                myGlobal.powerDevice = null;
                            }
                            break;
                        }
                }
            }
        }
        string _cnntype;
        public string CnnType {
            get { return _cnntype; }
            set {
                _cnntype = value;
                OnPropertyChanged(nameof(CnnType));
            }
        }
        string _type;
        public string InstType {
            get { return _type; }
            set {
                _type = value;
                OnPropertyChanged(nameof(InstType));

                if (InstType == "M") {
                    myParameter.dictRangeResistance = iniRange.FromIniFile(Name, "R");
                    myParameter.dictRangeCapacitance = iniRange.FromIniFile(Name, "Ca");
                    myParameter.dictRangeDCVoltage = iniRange.FromIniFile(Name, "V");
                    myParameter.dictRangeDCCurrent = iniRange.FromIniFile(Name, "A");
                }
            }
        }

        //Multimeter

        //Switch card
        int _stabletime;
        public int StableTime {
            get { return _stabletime; }
            set {
                _stabletime = value;
                OnPropertyChanged(nameof(StableTime));
            }
        }

        //Power supply
        string _outvolt;
        public string OutVoltage {
            get { return _outvolt; }
            set {
                _outvolt = value;
                OnPropertyChanged(nameof(OutVoltage));
            }
        }
        string _outcurr;
        public string OutCurrent {
            get { return _outcurr; }
            set {
                _outcurr = value;
                OnPropertyChanged(nameof(OutCurrent));
            }
        }
        string _overvolt;
        public string OverVoltage {
            get { return _overvolt; }
            set {
                _overvolt = value;
                OnPropertyChanged(nameof(OverVoltage));
            }
        }
        string _overcurr;
        public string OverCurrent {
            get { return _overcurr; }
            set {
                _overcurr = value;
                OnPropertyChanged(nameof(OverCurrent));
            }
        }
        string _isprotectvolt;
        public string IsProtectVolt {
            get { return _isprotectvolt; }
            set {
                _isprotectvolt = value;
                OnPropertyChanged(nameof(IsProtectVolt));
            }
        }
        string _isprotectcurr;
        public string IsProtectCurrent {
            get { return _isprotectcurr; }
            set {
                _isprotectcurr = value;
                OnPropertyChanged(nameof(IsProtectCurrent));
            }
        }
        string _voltstep;
        public string VoltStep {
            get { return _voltstep; }
            set {
                _voltstep = value;
                OnPropertyChanged(nameof(VoltStep));
            }
        }
        string _currentstep;
        public string CurrentStep {
            get { return _currentstep; }
            set {
                _currentstep = value;
                OnPropertyChanged(nameof(CurrentStep));
            }
        }
        string _triggersource;
        public string TriggerSource {
            get { return _triggersource; }
            set {
                _triggersource = value;
                OnPropertyChanged(nameof(TriggerSource));
            }
        }
        string _triggerdelay;
        public string TriggerDelay {
            get { return _triggerdelay; }
            set {
                _triggerdelay = value;
                OnPropertyChanged(nameof(TriggerDelay));
            }
        }

        public string VoltRange {
            get { return OutVoltage; }
        }


        //SCPI
        string _visaaddress;
        public string VisaAddress {
            get { return _visaaddress; }
            set {
                _visaaddress = value;
                OnPropertyChanged(nameof(VisaAddress));
            }
        }


        //UART
        string _comport;
        public string ComPort {
            get { return _comport; }
            set {
                _comport = value;
                OnPropertyChanged(nameof(ComPort));
            }
        }
        string _combaudrate;
        public string ComBaudRate {
            get { return _combaudrate; }
            set {
                _combaudrate = value;
                OnPropertyChanged(nameof(ComBaudRate));
            }
        }
        string _comdatabit;
        public string ComDataBit {
            get { return _comdatabit; }
            set {
                _comdatabit = value;
                OnPropertyChanged(nameof(ComDataBit));
            }
        }
        string _comparity;
        public string ComParity {
            get { return _comparity; }
            set {
                _comparity = value;
                OnPropertyChanged(nameof(ComParity));
            }
        }
        string _comstopbit;
        public string ComStopBit {
            get { return _comstopbit; }
            set {
                _comstopbit = value;
                OnPropertyChanged(nameof(ComStopBit));
            }
        }

        //Telnet
        string _telnetip;
        public string TelnetIP {
            get { return _telnetip; }
            set {
                _telnetip = value;
                OnPropertyChanged(nameof(TelnetIP));
            }
        }
        string _telnetport;
        public string TelnetPort {
            get { return _telnetport; }
            set {
                _telnetport = value;
                OnPropertyChanged(nameof(TelnetPort));
            }
        }
        string _telnetuser;
        public string TelnetUser {
            get { return _telnetuser; }
            set {
                _telnetuser = value;
                OnPropertyChanged(nameof(TelnetUser));
            }
        }
        string _telnetpass;
        public string TelnetPassword {
            get { return _telnetpass; }
            set {
                _telnetpass = value;
                OnPropertyChanged(nameof(TelnetPassword));
            }
        }

    }
}

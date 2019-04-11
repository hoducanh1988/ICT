using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Instrument;

namespace ICT_VNPT.Func.Global {
    public class myGlobal {

        //Window Info ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //~~~~~~~~~~//
        public static MainWindowInfo windowInfo = new MainWindowInfo();

        //~~~~~~~~~~//
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        //Instrument ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //~~~~~~~~~~//

        //Instrument Information
        public static InstrumentInfo multimeterInfo = new InstrumentInfo() { Name = "Keithley 2110", CnnType = "SCPI", InstType = "M" };
        public static InstrumentInfo switchcardInfo = new InstrumentInfo() { Name = "Pickering 50635-005", CnnType = "DRIVER", InstType = "S" };
        public static InstrumentInfo powersupplyInfo = new InstrumentInfo() { Name = "HP Agilent E3632A", CnnType = "SCPI", InstType = "P" };

        //Instrument Instance
        public static Multimeter meterDevice = null;
        public static SwitchCard switchDevice = null;
        public static PowerSupply powerDevice = null;

        public static bool powerDevice_Output_State = false;
        //~~~~~~~~~~//
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        //DUT ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //~~~~~~~~~~//
        public static ObservableCollection<DutInfo> duts = new ObservableCollection<DutInfo>();
        public static int SelectedItemIndex = -1;
        //~~~~~~~~~~//
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        //Test Result ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //~~~~~~~~~~//
        public static ObservableCollection<ResultGridItem> resultGridItems = new ObservableCollection<ResultGridItem>();
        public static GoTestInfo goTestInfo = new GoTestInfo();
        public static int IsItemTesting = 0;
        public static string dutSerialNumber = "";

        public static string ProductSerialNumber = "";

        public static double goTestTime = 0;
        public static double goTotalTestTime = 0;

        public static double goPassedCount = 0;
        public static double goTotalTestCount = 0;

        //~~~~~~~~~~//
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        //Debug Log ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //~~~~~~~~~~//
        public static DebugLogInfo debugLog = new DebugLogInfo();
        public static SettingInfo settingInfo = new SettingInfo();
        //~~~~~~~~~~//
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

        //Label Print ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        //~~~~~~~~~~//
        public static PrintDialog myPrintDialog;
        //~~~~~~~~~~//
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    }
}

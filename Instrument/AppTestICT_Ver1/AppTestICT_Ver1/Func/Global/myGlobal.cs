using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTestICT_Ver1.Func.Custom;
using AppTestICT_Ver1.Func.Instrument;

namespace AppTestICT_Ver1.Func.Global {
    public class myGlobal {


        //Parameters
        public static List<string> listProduct = new List<string>() { "GW040", "GW020", "ONT Adapter" };


        // Variables
        public static AppInformation appinfo = new AppInformation();
        public static ObservableCollection<GridTestItem> gridTestItem = new ObservableCollection<GridTestItem>();

        //Instruments
        public static Multimeter multimeter = null;
        public static SwitchCard switchcard = null;
        public static PowerSupply powersupply = null;
    }
}

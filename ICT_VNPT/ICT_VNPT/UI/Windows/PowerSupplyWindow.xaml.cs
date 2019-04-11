using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;

namespace ICT_VNPT.UI.Windows {
    /// <summary>
    /// Interaction logic for PowerSupplyWindow.xaml
    /// </summary>
    public partial class PowerSupplyWindow : Window {

        public PowerSupplyWindow(string dllfile) {
            InitializeComponent();

            //add power supply to form
            switch (dllfile) {
                case "AgilentE3632A.dll": {
                        //this.power_supply_container.Children.Add(new ucPickering50635005());
                        break;
                    }
                default: break;
            }

        }
    }
}

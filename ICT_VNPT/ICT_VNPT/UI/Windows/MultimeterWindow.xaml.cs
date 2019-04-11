using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ICT_VNPT.UI.UserControls.Instruments.Debug.Multimeter;

namespace ICT_VNPT.UI.Windows {
    /// <summary>
    /// Interaction logic for MultimeterWindow.xaml
    /// </summary>
    public partial class MultimeterWindow : Window {
        public MultimeterWindow(string dllfile) {
            InitializeComponent();

            //add multimeter to form
            switch (dllfile) {
                case "Keithley2110.dll": {
                        this.multimeter_container.Children.Add(new ucKeithley2110());
                        break;
                    }
                default: break;
            }
        }
    }
}

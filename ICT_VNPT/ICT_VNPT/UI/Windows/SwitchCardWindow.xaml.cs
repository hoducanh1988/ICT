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

using ICT_VNPT.UI.UserControls.Instruments.Debug.SwitchCard;

namespace ICT_VNPT.UI.Windows {
    /// <summary>
    /// Interaction logic for SwitchCardWindow.xaml
    /// </summary>
    public partial class SwitchCardWindow : Window {
        public SwitchCardWindow(string dllfile) {
            InitializeComponent();

            //add switch card to form
            switch (dllfile) {
                case "Pickering50635005.dll": {
                        this.switch_card_container.Children.Add(new ucPickering50635005());
                        break;
                    }
                case "VnptSwitchModuleVer1.dll":
                    {
                        this.switch_card_container.Children.Add(new ucVnptSwitchModule());
                        break;
                    }
                default: break;
            }
        }
    }
}

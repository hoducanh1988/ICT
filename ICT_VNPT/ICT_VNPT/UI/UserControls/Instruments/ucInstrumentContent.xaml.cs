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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ICT_VNPT.Func.Global;

namespace ICT_VNPT.UI.UserControls.Instruments
{
    /// <summary>
    /// Interaction logic for ucInstrumentContent.xaml
    /// </summary>
    public partial class ucInstrumentContent : UserControl
    {

        public ucInstrumentContent()
        {
            InitializeComponent();

            for (int i = 1; i < 100; i++) { myParameter.serialports.Add(string.Format("COM{0}", i)); }

            //Properties
            cbbConnType.ItemsSource = myParameter.connectionTypes;

            //Parameters
            cbbComPort.ItemsSource = myParameter.serialports;
            cbbComBaudRate.ItemsSource = myParameter.baudRates;
            cbbComDataBit.ItemsSource = myParameter.dataBits;
            cbbComParity.ItemsSource = myParameter.paritys;
            cbbComStopBit.ItemsSource = myParameter.stopBits;

            //Configurations
            cbbProtectCurrent.ItemsSource = myParameter.booleans;
            cbbProtectVolt.ItemsSource = myParameter.booleans;
            cbbTriggerSource.ItemsSource = myParameter.triggersources;

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string btncontent = b.Content.ToString();

            switch (btncontent) {
                case "...": {
                        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                        dlg.Filter = "*.dll|*.dll";
                        dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        dlg.FileName = "";
                        dlg.Title = "Chọn file thư viện điều khiển máy đo";

                        if (dlg.ShowDialog() == true) {
                            txtdllPath.Text = dlg.SafeFileName;
                        }

                        break;
                    }
                default: break;
            }
        }
    }
}

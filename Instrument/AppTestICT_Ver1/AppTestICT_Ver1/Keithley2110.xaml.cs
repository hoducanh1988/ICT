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
using Protocol;

namespace AppTestICT_Ver1 {
    /// <summary>
    /// Interaction logic for Keithley2110.xaml
    /// </summary>
    public partial class Keithley2110 : Window {

        IProtocol device;

        List<string> commands = new List<string>() {
            ":SYSTem:PRESet\n",
            "TRIGger:DELay:AUTO 0\n",
            "TRIGger:DELay:AUTO?\n",
            "TRIGger:SOURce EXT\n",
            "TRIGger:SOURce?\n",
            "TRIGger:DELay 1\n",
            "TRIGger:DELay?\n",
            ":CONFigure:RESistance\n",
            ":RESistance:RANGe:AUTO 1\n",
            ":RESistance:RESolution 0.000000001\n",
            ":CONFigure?\n",
            ":READ?\n"
        };


        public Keithley2110() {
            InitializeComponent();
            foreach (var x in commands) rtb_command.AppendText(x);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;

            switch (b.Content) {
                case "Connect": {
                        device = new SCPI();
                        device.Open(txt_visaaddress.Text);

                        b.Background = device.IsConnected() ? Brushes.Lime : Brushes.Red;
                        break;
                    }
                case "Send": {
                        rtb_result.Document.Blocks.Clear();
                        device = new SCPI();
                        device.Open(txt_visaaddress.Text);

                        foreach (var x in commands) {
                            if (!x.Contains("?")) device.Write(x);
                            else {
                                string data = device.Query(x).Replace("\r","").Replace("\n","").Trim();
                                data = data + "\n";
                                rtb_result.AppendText(data);
                            }
                        }

                        device.Close();

                        break;
                    }
            }
        }
    }
}

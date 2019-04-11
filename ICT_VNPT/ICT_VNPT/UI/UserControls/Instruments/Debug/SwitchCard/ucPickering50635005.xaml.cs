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
using System.Diagnostics;

using ICT_VNPT.UI.UserControls.Instruments.Debug.SwitchCard.Relay;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Instrument;
using ICT_VNPT.Func.Excute;

namespace ICT_VNPT.UI.UserControls.Instruments.Debug.SwitchCard
{
    /// <summary>
    /// Interaction logic for ucPickering50635005.xaml
    /// </summary>
    public partial class ucPickering50635005 : UserControl
    {
        public ucPickering50635005()
        {
            InitializeComponent();

            //add relay into Card
            addRelayIntoCard();

            //check card is connect or not
            if (myGlobal.switchDevice == null || myGlobal.switchDevice.IsConnected == false) {
                this.tbStatus.Text = "Disconnected"; this.tbStatus.Foreground = Brushes.Red;
                this.grid_main.IsEnabled = false;
            }
            else {
                this.tbStatus.Text = "Connected"; this.tbStatus.Foreground = Brushes.Lime;
                this.grid_main.IsEnabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e) {
            TextBlock block = sender as TextBlock;
            switch (block.Text) {
                case "Reset Bank1": {
                        int r = myGlobal.switchDevice.Set_Bank_Open(1);
                        if (r == 0) addRelayIntoBank1();
                        break;
                    }
                case "Reset Bank2": {
                        int r = myGlobal.switchDevice.Set_Bank_Open(2);
                        if (r == 0) addRelayIntoBank2();
                        break;
                    }
                case "Reset Card": {
                        int r = myGlobal.switchDevice.Set_Card_Open();
                        if (r == 0) addRelayIntoCard();
                        break;
                    }
                case "View Card": {
                        Process.Start(string.Format("{0}Data\\pickering-50635005\\pickering-50635005-card.PNG", AppDomain.CurrentDomain.BaseDirectory));
                        break;
                    }
                case "View Specification": {
                        Process.Start(string.Format("{0}Data\\pickering-50635005\\pickering-50635005-specification.PNG", AppDomain.CurrentDomain.BaseDirectory));
                        break;
                    }
                case "View Pin Layout": {
                        Process.Start(string.Format("{0}Data\\pickering-50635005\\pickering-50635005-pinlayout.PNG", AppDomain.CurrentDomain.BaseDirectory));
                        break;
                    }
                default: break;
            }
        }


        void addRelayIntoCard() {
            this.bank1.Children.Clear();
            this.bank2.Children.Clear();

            for (int i = 1; i <= 32; i++) {
                this.bank1.Children.Add(new ucRelay("1", i < 10 ? string.Format("0{0}", i) : i.ToString(), "open"));
                this.bank2.Children.Add(new ucRelay("2", i < 10 ? string.Format("0{0}", i) : i.ToString(), "open"));
            }
        }

        void addRelayIntoBank1() {
            this.bank1.Children.Clear();
            for (int i = 1; i <= 32; i++) {
                this.bank1.Children.Add(new ucRelay("1", i < 10 ? string.Format("0{0}", i) : i.ToString(), "open"));
            }
        }

        void addRelayIntoBank2() {
            this.bank2.Children.Clear();
            for (int i = 1; i <= 32; i++) {
                this.bank2.Children.Add(new ucRelay("2", i < 10 ? string.Format("0{0}", i) : i.ToString(), "open"));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                if (myGlobal.switchDevice == null) myGlobal.switchDevice = new ICT_VNPT.Func.Instrument.SwitchCard();
                if (myGlobal.switchDevice.IsConnected == false) {
                    int r = myGlobal.switchDevice.LoadLibrary(myGlobal.switchcardInfo.DLLFile, InstrumentType.Switcher);
                    if (r == 0) {
                        int kq = AbstractExcute._openDevice(myGlobal.switchDevice, myGlobal.switchcardInfo);
                        if (kq == 0) {
                            if (myGlobal.switchDevice.IsConnected == false) {
                                MessageBox.Show("can't connect to switch card", "Connect switch card", MessageBoxButton.OK, MessageBoxImage.Error);
                            } else {
                                this.tbStatus.Text = "Connected"; this.tbStatus.Foreground = Brushes.Lime;
                                this.grid_main.IsEnabled = true;
                            }
                        } else {
                            MessageBox.Show("can't open switch card", "Connect switch card", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    } else {
                        MessageBox.Show("can't load file dll switch card", "Connect switch card", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else {
                    this.tbStatus.Text = "Connected"; this.tbStatus.Foreground = Brushes.Lime;
                    this.grid_main.IsEnabled = true;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Connect switch card", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

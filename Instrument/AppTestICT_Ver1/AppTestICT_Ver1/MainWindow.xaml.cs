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
using System.Windows.Navigation;
using System.Windows.Shapes;

using AppTestICT_Ver1.Func.Global;

namespace AppTestICT_Ver1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private void lblMin_MouseDown(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;

        }


        private void Label_MouseDown(object sender, MouseButtonEventArgs e) {
            Label l = sender as Label;
            string _labelcontent = l.Content.ToString();

            switch (_labelcontent) {
                case "X": {
                        this.Close();
                        break;
                    }
                default: break;
            }
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            //this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string _btncontent = b.Content.ToString();

            switch (_btncontent) {
                case "START": {
                        Thread t = new Thread(new ThreadStart(() => {
                            //---------------Multimeter --------------------------------------------//
                            //myGlobal.multimeter = new AppTestICT_Ver1.Func.Instrument.Multimeter();
                            //int r = myGlobal.multimeter.Open(ConnectionType.SCPI, "USB0::0x05E6::0x2110::8009790::INSTR");
                            //double dcv_value;
                            //r = myGlobal.multimeter.get_TwoWire_Resistance_Value(10, out dcv_value);
                            //MessageBox.Show(r.ToString() + ":::" + dcv_value.ToString());

                            //---------------SwitchCard --------------------------------------------//
                            //myGlobal.switchcard = new AppTestICT_Ver1.Func.Instrument.SwitchCard();
                            //int r = myGlobal.switchcard.Open(ConnectionType.DRIVER, "USB0::0x05E6::0x2110::8009790::INSTR");
                            //MessageBox.Show(r.ToString());

                            //---------------PowerSupply -------------------------------------------//
                            myGlobal.powersupply = new AppTestICT_Ver1.Func.Instrument.PowerSupply();
                            int r = myGlobal.powersupply.Open((int)ConnectionType.SCPI, "GPIB0::7::INSTR");
                            myGlobal.powersupply.set_Output_State(true);
                            myGlobal.powersupply.set_Output_Value(12, 2);
                            Thread.Sleep(500);

                            while (true) {
                                if (myGlobal.powersupply.IsConnected) {
                                    Dispatcher.Invoke(new Action(() => {

                                        lbltest.Content = string.Format("CURR: [MAX={0}, ACT={1}] VOLT: [MAX={2}, ACT={3}]",
                                                                     myGlobal.powersupply.get_Current_Limit_Value(),
                                                                     myGlobal.powersupply.get_Current_Actual_Value(),
                                                                     myGlobal.powersupply.get_Voltage_Limit_Value(),
                                                                     myGlobal.powersupply.get_Voltage_Actual_Value()
                                                                     );
                                    }));
                                }
                                else {
                                    Dispatcher.Invoke(new Action(() => {
                                        lbltest.Content = "disconnected";
                                    }));
                                }
                                Thread.Sleep(100);
                            }

                        }));
                        t.IsBackground = true;
                        t.Start();

                        break;
                    }
                default: break;
            }

        }
    }
}

using ICT_VNPT.Func.Ulti;
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

namespace ICT_VNPT.UI.UserControls.Instruments.Debug.SwitchCard.Relay
{
    /// <summary>
    /// Interaction logic for ucRelay.xaml
    /// </summary>
    public partial class ucRelay : UserControl
    {

        class RelayInfo : CNotifyPropertyChanged {
            public string Bank { get; set; }

            string _channel;
            public string Channel {
                get { return _channel; }
                set {
                    _channel = value;
                    OnPropertyChanged(nameof(Channel));
                }
            }
            string _state;
            public string State {
                get { return _state; }
                set {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        RelayInfo relay = new RelayInfo();

        public ucRelay(string bank, string channel, string state)
        {
            InitializeComponent();
            relay.Bank = bank;
            relay.Channel = channel;
            relay.State = state;

            this.DataContext = relay;
        }


        private void FrameWorkElement_MouseDown(object sender, MouseButtonEventArgs e) {
            if (relay.State == "open") {
                int r = myGlobal.switchDevice.Set_Channel_Close(int.Parse(relay.Bank), int.Parse(relay.Channel));
                if (r == 0) relay.State = "close";
            }
            else {
                int r = myGlobal.switchDevice.Set_Channel_Open(int.Parse(relay.Bank), int.Parse(relay.Channel));
                if (r == 0) relay.State = "open";
            }
        }
    }
}

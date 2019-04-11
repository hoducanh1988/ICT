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
using System.Windows.Threading;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.UI.UserControls
{
    /// <summary>
    /// Interaction logic for DebugLog.xaml
    /// </summary>
    public partial class DebugLog : UserControl
    {
        

        public DebugLog()
        {
            InitializeComponent();
            this.DataContext = myGlobal.debugLog;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (sender, e) => {
                if (myGlobal.IsItemTesting == 1) {
                    this._scrollViewerSystem.ScrollToEnd();
                }
            };
            timer.Start();

        }
    }
}

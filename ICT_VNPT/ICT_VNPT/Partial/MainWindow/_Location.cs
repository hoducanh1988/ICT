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

namespace ICT_VNPT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private void SetStartupLocation() {
            //double scaleX = 0.887;
            //double scaleY = 0.86;

            double scaleX = 0.887;
            double scaleY = 0.93;

            //double scaleX = 1;
            //double scaleY = 1;

            this.Height = SystemParameters.WorkArea.Height * scaleY + 10;
            this.Width = SystemParameters.WorkArea.Width * scaleX + 10;

            this.Top = (SystemParameters.WorkArea.Height * (1 - scaleY)) / 2;
            this.Left = (SystemParameters.WorkArea.Width * (1 - scaleX)) / 2;
        }

    }
}

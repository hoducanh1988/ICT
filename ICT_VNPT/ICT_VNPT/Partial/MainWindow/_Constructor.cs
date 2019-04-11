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
using ICT_VNPT.Func.IO;

namespace ICT_VNPT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            //Khoi tao UI control
            InitializeComponent();
            this.DataContext = myGlobal.windowInfo; 

            //Set location for Main Window
            this.SetStartupLocation();

            //
            //xmlSetting.LoadData();
        }
    }
}

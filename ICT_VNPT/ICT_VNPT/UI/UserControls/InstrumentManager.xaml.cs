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

namespace ICT_VNPT.UI.UserControls
{
    /// <summary>
    /// Interaction logic for InstrumentManager.xaml
    /// </summary>
    public partial class InstrumentManager : UserControl
    {
        public InstrumentManager()
        {
            //Init control
            InitializeComponent();

            //Load xml file
            xmlInstrument.LoadData();

            //Binding data
            this.meterInfo.DataContext = myGlobal.multimeterInfo;
            this.switchInfo.DataContext = myGlobal.switchcardInfo;
            this.powerInfo.DataContext = myGlobal.powersupplyInfo;
        }
    }
}

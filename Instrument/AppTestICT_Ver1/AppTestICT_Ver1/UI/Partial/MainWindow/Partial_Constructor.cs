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

using AppTestICT_Ver1.Func.Global;

namespace AppTestICT_Ver1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            //Khoi tao UI control
            InitializeComponent();

            //Binding main UI with appinfo
            this.gridAppInfo.DataContext = myGlobal.appinfo;
            this.gridAppTitle.DataContext = myGlobal.appinfo;

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo điện trở R21",
                bank1 = "32",
                bank2 = "1",
                unit = "R",
                standard = "9.5 ~ 10.5",
                actual = "9.7",
                result = "PASS"
            });

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo diode D12",
                bank1 = "32",
                bank2 = "2",
                unit = "D",
                standard = "0 ~ 0.7",
                actual = "0.6",
                result = "PASS"
            });

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo điện áp đầu ra J5",
                bank1 = "32",
                bank2 = "3",
                unit = "V",
                standard = "3.1 ~ 3.5",
                actual = "3.3",
                result = "PASS"
            });

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo dòng điện nguồn",
                bank1 = "-",
                bank2 = "-",
                unit = "A",
                standard = "1.7 ~ 2.3",
                actual = "1.8",
                result = "PASS"
            });

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo thông dẫn connector J3",
                bank1 = "32",
                bank2 = "5",
                unit = "Co",
                standard = "0 ~ 3",
                actual = "--",
                result = "Waiting..."
            });

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo giá trị tụ điện C2",
                bank1 = "32",
                bank2 = "6",
                unit = "Ca",
                standard = "9.7 ~ 10.3",
                actual = "--",
                result = "--"
            });

            myGlobal.gridTestItem.Add(new AppTestICT_Ver1.Func.Custom.GridTestItem() {
                testitem = "Đo giá trị cuộn dây L34",
                bank1 = "32",
                bank2 = "7",
                unit = "L",
                standard = "9.5 ~ 10.2",
                actual = "--",
                result = "--"
            });

            this.mainGrid.ItemsSource = myGlobal.gridTestItem;

            //Set location for Main Window
            this.SetStartupLocation();
        }

    }
}

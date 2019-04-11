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
using Microsoft.Win32;

using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.IO;
using System.IO;

namespace ICT_VNPT.UI.UserControls
{
    /// <summary>
    /// Interaction logic for TestResult.xaml
    /// </summary>
    public partial class TestResult : UserControl
    {
        public TestResult()
        {
            InitializeComponent();
            this.gridResult.ItemsSource = myGlobal.resultGridItems;

            Thread t = new Thread(new ThreadStart(() => {
                while (true) {
                    if (myGlobal.settingInfo.ResultScroll == "Yes") {
                        if (myGlobal.IsItemTesting == 1) {
                            Dispatcher.Invoke(new Action(() => {
                                if (this.gridResult.Items.Count > 0) {
                                    this.gridResult.ScrollIntoView(gridResult.Items[this.gridResult.Items.Count - 1]);
                                }

                            }));
                        }
                    }
                    
                    Thread.Sleep(100);
                }
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void GridResult_LostFocus(object sender, RoutedEventArgs e) {
            this.gridResult.UnselectAll();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            MenuItem item = sender as MenuItem;
            switch (item.Header.ToString()) {
                case "Refresh": {
                        this.gridResult.UnselectAll();
                        break;
                    }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;

            switch (b.Content.ToString()) {
                case "Clear Grid": {
                        ViewHelper.clearTestResult();
                        break;
                    }
                case "CSV": {
                        if (myGlobal.resultGridItems.Count == 0) break;
                        if (myGlobal.resultGridItems.Count == 0) break;
                        SaveFileDialog fileDialog = new SaveFileDialog();
                        fileDialog.InitialDirectory = "C:\\";
                        fileDialog.Filter = "*.csv|*.csv";

                        if (fileDialog.ShowDialog() == true) {

                            string _title = "\"SN\",\"ItemName\",\"Unit\",\"Retry\",\"LL\",\"Actual\",\"UL\",\"UOM\",\"Result\",\"Time\",\"Code\",\"Message\"";
                            StreamWriter sw = new StreamWriter(fileDialog.FileName, true, Encoding.Unicode);
                            sw.WriteLine(_title);
                            foreach (var item in myGlobal.resultGridItems) {
                                sw.WriteLine(item.ToString());
                            }
                            sw.Dispose();
                        }
                        break;
                    }
                case "Excel": {
                        break;
                    }
                case "XML": {
                        if (myGlobal.resultGridItems.Count == 0) break;
                        SaveFileDialog fileDialog = new SaveFileDialog();
                        fileDialog.InitialDirectory = "C:\\";
                        fileDialog.Filter = "*.xml|*.xml";

                        if (fileDialog.ShowDialog() == true) {
                            XmlHelper.ToXmlFile(myGlobal.resultGridItems, fileDialog.FileName);
                        }
                        break;
                    }
                default: break;
            }
        }
    }
}

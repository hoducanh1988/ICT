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

using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Excute;
using ICT_VNPT.Func.IO;
using ICT_VNPT.UI.Windows;

namespace ICT_VNPT.UI.UserControls.TestItems {
    /// <summary>
    /// Interaction logic for TreeTestView.xaml
    /// </summary>
    public partial class TreeTestView : UserControl {


        public TreeTestView() {
            InitializeComponent();
            this.trvItemTest.ItemsSource = myGlobal.duts;

            //load xmlsetting
            xmlSetting.LoadData();

            //load file test case
            if (myGlobal.settingInfo.LoadRecent == "Yes") {
                if (Properties.Settings.Default.ScriptPath.Trim().Length == 0) return;
                if (System.IO.File.Exists(Properties.Settings.Default.ScriptPath) == true) {
                    csvScriptTest.FromCsvFile(Properties.Settings.Default.ScriptPath, Properties.Settings.Default.ScriptName);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            MenuItem itm = sender as MenuItem;
            switch (itm.Header.ToString()) {
                case "New An Item": {
                        try {
                            int index = myGlobal.duts[0].Cases[0].Items.Count + 1;
                            var item = new TestItemInfo() { ItemName = string.Format("New Item {0}", index), OrderNo = index.ToString() };
                            myGlobal.duts[0].Cases[0].Items.Add(item);
                            myGlobal.duts[0].Cases[0].ItemCount = myGlobal.duts[0].Cases[0].Items.Count;
                        }
                        catch { }
                        break;
                    }
                case "New Range Item": {
                        NewRangeItemWindow window = new NewRangeItemWindow();
                        window.ShowDialog();
                        int rangeCount = window.numberItem;
                        if (rangeCount == 0) break;

                        try {
                            for (int i = 0; i < rangeCount; i++) {
                                var index = myGlobal.duts[0].Cases[0].Items.Count + 1;
                                var item = new TestItemInfo() { ItemName = string.Format("New Item {0}", index), OrderNo = index.ToString() };
                                myGlobal.duts[0].Cases[0].Items.Add(item);
                                myGlobal.duts[0].Cases[0].ItemCount = myGlobal.duts[0].Cases[0].Items.Count;
                            }

                        }
                        catch { }
                        break;
                    }
                case "Delete Item": {
                        try {
                            var item = (TestItemInfo)trvItemTest.SelectedItem;
                            myGlobal.duts[0].Cases[0].Items.Remove(item);
                            myGlobal.duts[0].Cases[0].ItemCount = myGlobal.duts[0].Cases[0].Items.Count;

                            for (int i = 0; i < myGlobal.duts[0].Cases[0].Items.Count; i++) {
                                myGlobal.duts[0].Cases[0].Items[i].OrderNo = string.Format("{0}", i + 1);
                            }
                        }
                        catch { }
                        break;
                    }

                case "Refresh": {
                        break;
                    }

                case "Run Test (F6)": {
                        try {
                            var item = (TestItemInfo)trvItemTest.SelectedItem;
                            int idx = myGlobal.duts[0].Cases[0].Items.IndexOf(item);

                            Thread t = new Thread(new ThreadStart(() => {
                                TestItem.Validating(myGlobal.duts[0].Cases[0].Items[idx]);

                                //off power supply
                                if (myGlobal.settingInfo.OFFPower == "Yes") {
                                    if (myGlobal.settingInfo.EnablePower.ToLower().Contains("yes")) {
                                        if (myGlobal.powerDevice != null && myGlobal.powerDevice.IsConnected) AbstractExcute.set_Power_Supply_OFF();
                                    }
                                }
                                //reset relay
                                if (myGlobal.settingInfo.ResetSwitch == "Yes") {
                                    if (myGlobal.switchDevice != null && myGlobal.switchDevice.IsConnected) myGlobal.switchDevice.Set_Card_Open();
                                }

                            }));
                            t.IsBackground = true;
                            t.Start();
                        }
                        catch {
                        }
                        break;
                    }

                default: break;
            }
        }

        private void TrvItemTest_Selected(object sender, RoutedEventArgs e) {
            try {
                var item = (TestItemInfo)trvItemTest.SelectedItem;
                myGlobal.SelectedItemIndex = myGlobal.duts[0].Cases[0].Items.IndexOf(item);
            }
            catch {
                myGlobal.SelectedItemIndex = -1;
            }
        }
    }
}

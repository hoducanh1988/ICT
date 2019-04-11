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

using ICT_VNPT.UI.Windows;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.Ulti;
using System.Threading;
using System.Diagnostics;
using ICT_VNPT.Func.Excute;
using Microsoft.Win32;
using ICT_VNPT.Func.IO;

namespace ICT_VNPT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            MenuItem item = sender as MenuItem;
            string _iHeader = item.Header.ToString();

            switch (_iHeader) {

                //MenuItem_File
                case "New (Ctrl + N)": {
                        var window = new NewScriptWindow();
                        window.ShowDialog();
                        break;
                    }

                case "Open (Ctrl + O)": {
                        var dlg = new OpenFileDialog();
                        dlg.InitialDirectory = myGlobal.settingInfo.CasePath;
                        dlg.Filter = "Script test (*.csv)|*.csv";
                        dlg.Title = "Select script test case file";

                        if (dlg.ShowDialog() == true) {
                            csvScriptTest.FromCsvFile(dlg.FileName, dlg.SafeFileName);

                            Properties.Settings.Default.ScriptPath = dlg.FileName;
                            Properties.Settings.Default.ScriptName = dlg.SafeFileName;
                            Properties.Settings.Default.Save();

                            MessageBox.Show("Success", "Open File", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;
                    }

                case "Save (Ctrl + S)": {
                        if (myGlobal.duts.Count == 0) return;

                        if (myGlobal.duts[0].Path == null) { //new test case
                            var dlg = new SaveFileDialog();
                            dlg.InitialDirectory = myGlobal.settingInfo.CasePath;
                            dlg.FileName = string.Format("Script_Test_{0}.csv", myGlobal.duts[0].Name);
                            dlg.Filter = "*.csv|*.csv";
                            dlg.Title = "Save script test to file";
                            if (dlg.ShowDialog() == true) {
                                csvScriptTest.ToCsvFile(dlg.FileName);

                                Properties.Settings.Default.ScriptPath = dlg.FileName;
                                Properties.Settings.Default.ScriptName = dlg.SafeFileName;
                                Properties.Settings.Default.Save();

                                MessageBox.Show("Success", "Save File", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else {
                            csvScriptTest.ToCsvFile(myGlobal.duts[0].Path);
                            MessageBox.Show("Success", "Save File", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        break;
                    }

                case "SaveAs": {
                        MessageBox.Show(myParameter.dictRangeCapacitance.Count.ToString());
                        break;
                    }

                case "Exit (Ctrl + Shift + X)": {
                        this.Close();
                        break;
                    }

                //MenuItem_View
                case "Reset Tree Icons": {
                        ViewHelper.resetTreeIcon();
                        break;
                    }

                case "Clear Debug Windows": {
                        ViewHelper.clearDebugWindow();
                        break;
                    }

                case "Clear Test Results": {
                        ViewHelper.clearTestResult();
                        break;
                    }

                case "Clear Status Bar": {
                        ViewHelper.clearStatusBar();
                        break;
                    }

                case "Show Status Bar": {

                        break;
                    }

                case "Reset All": {
                        ViewHelper.clearAll();
                        break;
                    }

                //MenuItem_Tests
                case "Run Tree (F5)": {
                        if (myGlobal.duts.Count == 0) break;
                        if (myGlobal.duts[0].Cases[0].Items.Count == 0) break;

                        Thread t = new Thread(new ThreadStart(() => {
                            Stopwatch st = new Stopwatch();
                            st.Start();

                            bool r = TestAllItems.getResult();

                            st.Stop();
                            string tt = (st.ElapsedMilliseconds / 1000).ToString();

                            MessageBox.Show("All item is tested. total time = " + tt + " sec", "Test Tree", MessageBoxButton.OK, MessageBoxImage.Information);
                        }));
                        t.IsBackground = true;
                        t.Start();
                        break;
                    }


                //MenuItem_Debug
                case "Multimeter device": {
                        this.Opacity = 0.5;
                        var window = new MultimeterWindow(myGlobal.multimeterInfo.DLLFile);
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }

                case "Switch card device": {
                        this.Opacity = 0.5;
                        var window = new SwitchCardWindow(myGlobal.switchcardInfo.DLLFile);
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }

                case "Power supply device": {
                        this.Opacity = 0.5;
                        var window = new PowerSupplyWindow(myGlobal.powersupplyInfo.DLLFile);
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }

                //MenuItem_Options
                case "Edit configurations": {
                        this.Opacity = 0.5;
                        var window = new EditConfigurationWindow();
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }

                //MenuItem_Windows

                //MenuItem_Help
                case "ICT Help": {
                        this.Opacity = 0.5;
                        var window = new HelpWindow();
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }
                case "ICT About": {
                        this.Opacity = 0.5;
                        var window = new AboutWindow();
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }
                case "ICT History": {
                        this.Opacity = 0.5;
                        var window = new HistoryWindow();
                        window.ShowDialog();
                        this.Opacity = 1;
                        break;
                    }


            }




        }

    }
}

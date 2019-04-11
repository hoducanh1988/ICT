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
using ICT_VNPT.UI.Windows;
using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.IO;
using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Excute;

using System.Diagnostics;

namespace ICT_VNPT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {


        private void CommandBinding_Open(object sender, ExecutedRoutedEventArgs e) {
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

        }

        private void CommandBinding_New(object sender, ExecutedRoutedEventArgs e) {
            var window = new NewScriptWindow();
            window.ShowDialog();
        }

        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e) {
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

                    MessageBox.Show("Success","Save File", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else {
                csvScriptTest.ToCsvFile(myGlobal.duts[0].Path);
                MessageBox.Show("Success", "Save File", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
        }


        private void CommandBinding_Run(object sender, ExecutedRoutedEventArgs e) {
            if (myGlobal.duts.Count == 0) return;
            if (myGlobal.duts[0].Cases[0].Items.Count == 0) return;

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
        }

        private void CommandBinding_Pause(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("Pause");
        }

        private void CommandBinding_Stop(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("Stop");
        }

        private void CommandBinding_Retry(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("Retry");
        }

    }
}

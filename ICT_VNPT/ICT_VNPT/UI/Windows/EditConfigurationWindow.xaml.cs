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
using System.Windows.Shapes;
using System.Printing;

using ICT_VNPT.Func.Global;
using ICT_VNPT.Func.IO;

namespace ICT_VNPT.UI.Windows
{
    /// <summary>
    /// Interaction logic for EditConfigurationWindow.xaml
    /// </summary>
    public partial class EditConfigurationWindow : Window
    {
        public EditConfigurationWindow()
        {
            InitializeComponent();

            //Test case options
            this.cbbErrorOption.ItemsSource = myParameter.testCaseErrorOptions;
            this.cbbEnablePower.ItemsSource = myParameter.yesNoOptions;
            this.cbbOFFPower.ItemsSource = myParameter.yesNoOptions;
            this.cbbResetSwCard.ItemsSource = myParameter.yesNoOptions;

            //Test tree options
            this.cbbAutoLoadRecentTestCase.ItemsSource = myParameter.yesNoOptions;
            this.cbbShowItemCount.ItemsSource = myParameter.yesNoOptions;
            this.cbbShowItemUnit.ItemsSource = myParameter.yesNoOptions;
            //this.cbbShowTreeRegistry.ItemsSource = myParameter.yesNoOptions;

            //Go/NoGo options
            this.cbbInputSN.ItemsSource = myParameter.yesNoOptions;

            //Test result options
            this.cbbAutoSaveLogTestResult.ItemsSource = myParameter.yesNoOptions;
            this.cbbLogResultGenSubFolder.ItemsSource = myParameter.yesNoOptions;
            this.cbbFormatLogResult.ItemsSource = myParameter.resultLogFormats;
            this.cbbLogResultAutoScroll.ItemsSource = myParameter.yesNoOptions;

            //Debug log options
            this.cbbDebugLogGenSubFolder.ItemsSource = myParameter.yesNoOptions;
            this.cbbDebugLogAutoScroll.ItemsSource = myParameter.yesNoOptions;

            //Label Printer
            this.cbbPrintOption.ItemsSource = myParameter.yesNoOptions;

            //binding data
            this.DataContext = myGlobal.settingInfo;

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;

            switch (b.Tag.ToString()) {
                case "Save": {
                        xmlSetting.SaveData();
                        this.Close();
                        MessageBox.Show("Success.","Save Setting", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                case "DebugLog": {
                        var dialog = new System.Windows.Forms.FolderBrowserDialog();
                        dialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
                        dialog.ShowNewFolderButton = true;
                        dialog.Description = "Chọn đường dẫn lưu folder debug log";

                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            myGlobal.settingInfo.DebugPath = dialog.SelectedPath;
                        }
                        break;
                    }
                case "TestResult": {
                        var dialog = new System.Windows.Forms.FolderBrowserDialog();
                        dialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
                        dialog.ShowNewFolderButton = true;
                        dialog.Description = "Chọn đường dẫn lưu folder test result";

                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            myGlobal.settingInfo.ResultPath = dialog.SelectedPath;
                        }
                        break;
                    }
                case "TestTree": {
                        var dialog = new System.Windows.Forms.FolderBrowserDialog();
                        dialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
                        dialog.ShowNewFolderButton = true;
                        dialog.Description = "Chọn đường dẫn lưu test tree";

                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            myGlobal.settingInfo.CasePath = dialog.SelectedPath;
                        }
                        break;
                    }
                case "SelectPrinter": {
                        // Create the print dialog object and set options
                        myGlobal.myPrintDialog = new PrintDialog();

                        // Display the dialog. This returns true if the user presses the Print button.
                        Nullable<Boolean> print = myGlobal.myPrintDialog.ShowDialog();

                        if (print == true) {
                            myGlobal.settingInfo.PrinterName = myGlobal.myPrintDialog.PrintQueue.FullName;
                            myGlobal.myPrintDialog.PrintQueue = new PrintQueue(new PrintServer(), myGlobal.settingInfo.PrinterName);
                        }
                        break;
                    }
                default: break;
            }
        }
    }
}

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
using ICT_VNPT.Func.Ulti;
using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Excute;
using ICT_VNPT.UI.Windows;
using System.Threading;

using System.Diagnostics;
using System.Windows.Xps.Packaging;
using System.IO;

namespace ICT_VNPT.UI.UserControls.TestItems {
    /// <summary>
    /// Interaction logic for TestGo.xaml
    /// </summary>
    public partial class TestGo : UserControl {
        private Thread thread_start = null;

        public TestGo() {
            InitializeComponent();
            this.DataContext = myGlobal.goTestInfo;
        }


        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;

            switch (b.Content.ToString()) {
                case "START": {
                        _start_Validating_Product();
                        break;
                    }
                case "QUIT": {
                        if (thread_start != null && thread_start.IsAlive == true) {
                            if (MessageBox.Show("Sudden stop checking the product may cause some system errors.\n" +
                                "Do you still want to stop checking?\n" +
                                "Click 'OK' to stop, 'Cancel' to continue checking.",
                                "Quit Test Warning",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Warning) == MessageBoxResult.OK) {

                                //stop test
                                thread_start.Abort();
                                //show fail
                                _forced_Finish_Test_Control();
                            }
                        }
                        break;
                    }
                default: break;
            }
        }



        #region support-function

        /// <summary>
        /// 
        /// </summary>
        void _start_Validating_Product() {

            //clear text log
            myGlobal.debugLog.Clear();

            myGlobal.debugLog.SystemLog += string.Format("> START VALIDATING\r\n");

            string _dutname;
            //check dut test item exist or not
            myGlobal.debugLog.SystemLog += string.Format(">\r\n> {0}, Check DUT test items is exist or not...\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            if (!_dut_TestItem_Loaded(out _dutname)) return;

            //get dut serial number
            myGlobal.debugLog.SystemLog += string.Format(">\r\n> {0}, Get DUT serial number...", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            if (!_get_Dut_SerialNumber(_dutname)) return;
            myGlobal.debugLog.SystemLog += myGlobal.dutSerialNumber + "\r\n";

            //init control
            myGlobal.debugLog.SystemLog += string.Format(">\r\n> {0}, Reset display on control ...\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            _init_Test_Control();

            //test item
            myGlobal.debugLog.SystemLog += string.Format(">\r\n> {0}, Test ICT for all items ...\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            _test_Dut_All_Items();

            //update measured time in realtime
            _update_MeasuredTime();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dutname"></param>
        /// <returns></returns>
        bool _dut_TestItem_Loaded(out string dutname) {

            dutname = "";
            //check dut count 0 = fail, 1 = pass
            int v = myGlobal.duts.Count;
            bool r = v > 0;
            myGlobal.debugLog.SystemLog += string.Format("# DUT counted = {0} ??? {1}\r\n", v, r == true ? "PASS" : "FAIL");
            if (r == false) return false;

            //check test items of dut
            v = myGlobal.duts[0].Cases[0].Items.Count;
            r = v > 0;
            myGlobal.debugLog.SystemLog += string.Format("# Test items counted = {0} ??? {1}\r\n", v, r == true ? "PASS" : "FAIL");
            if (r == false) return false;

            //return
            dutname = myGlobal.duts[0].Name;
            myGlobal.dutSerialNumber = "";

            myGlobal.debugLog.SystemLog += string.Format("# Get DUT name = {0}\r\n", dutname);
            myGlobal.debugLog.SystemLog += string.Format("# Clear before DUT Serial Number\r\n");

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dutname"></param>
        /// <returns></returns>
        bool _get_Dut_SerialNumber(string dutname) {

            if (myGlobal.settingInfo.InputSerial == "Yes") {
                InputSerialWindow inputSerial = new InputSerialWindow(dutname);
                inputSerial.ShowDialog();
                if (inputSerial.IsCheck == 0) return false;
                return true;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        void _test_Dut_All_Items() {

            thread_start = new Thread(new ThreadStart(() => {
                Stopwatch st = new Stopwatch();
                st.Start();

                bool r = TestAllItems.getResult();

                myGlobal.debugLog.SystemLog += string.Format(">\r\n");
                myGlobal.debugLog.SystemLog += string.Format("> Total result = {0}\r\n", r == true ? "PASS" : "FAIL");
                myGlobal.debugLog.SystemLog += string.Format("> Total time = {0} ms\r\n", st.ElapsedMilliseconds);

                st.Stop();
                myGlobal.goTestTime = st.ElapsedMilliseconds;
                myGlobal.goTotalTestTime += myGlobal.goTestTime;

                myGlobal.goTotalTestCount += 1;
                myGlobal.goPassedCount += r == true ? 1 : 0;

                _finish_Test_Control(r);
            }));
            thread_start.IsBackground = true;
            thread_start.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        void _update_MeasuredTime() {
            Thread s = new Thread(new ThreadStart(() => {
                while (thread_start == null || thread_start.IsAlive == false) { Thread.Sleep(100); }
                Stopwatch ss = new Stopwatch();
                ss.Start();
                while (thread_start.IsAlive == true) {
                    TimeSpan time = TimeSpan.FromMilliseconds(ss.ElapsedMilliseconds);
                    myGlobal.goTestInfo.TestTime = time.ToString("hh':'mm':'ss");
                    Thread.Sleep(500);
                }
                ss.Stop();
            }));
            s.IsBackground = true;
            s.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        void _init_Test_Control() {
            myGlobal.goTestInfo.TotalResult = "Waiting...";
            myGlobal.goTestInfo.ProgressValue = 0;
            myGlobal.goTestInfo.ProgressMax = myGlobal.duts[0].Cases[0].Items.Count;
            myGlobal.goTestInfo.TestTime = "00:00:00";
            myGlobal.goTestInfo.SN = "";
            myGlobal.goTestInfo.ErrorCode = "";
            myGlobal.goTestInfo.ErrorString = "";
            myGlobal.goTestInfo.ErrorItem = "";
            myGlobal.goTestInfo.IsQuitActive = true;
            myGlobal.goTestInfo.IsStartActive = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        void _finish_Test_Control(bool r) {

            myGlobal.goTestInfo.TotalResult = r == true ? "Passed" : "Failed";
            myGlobal.goTestInfo.IsQuitActive = false;
            myGlobal.goTestInfo.IsStartActive = true;

            //get items error
            List<ResultGridItem> error_items = myGlobal.resultGridItems.Where(item => item.ItemResult == "failed").ToList();

            //count error items
            myGlobal.goTestInfo.ErrorItem = string.Format("{0} / {1}", error_items.Count(), myGlobal.duts[0].Cases[0].Items.Count);

            //show error string
            myGlobal.goTestInfo.ErrorString = r == false ? error_items.SelectMany(item => string.Format("# {0}: \"{1}\".\r\n", item.ItemName, item.ItemMessage)).ToList().Aggregate("", (x, y) => x + y) : "";

            //print error
            _print_Error_String(r);

        }


        /// <summary>
        /// 
        /// </summary>
        void _forced_Finish_Test_Control() {
            myGlobal.goTotalTestCount += 1;

            myGlobal.goTestInfo.TotalResult = "Failed";
            myGlobal.goTestInfo.IsQuitActive = false;
            myGlobal.goTestInfo.IsStartActive = true;

            //get items error
            List<ResultGridItem> error_items = myGlobal.resultGridItems.Where(item => item.ItemResult == "failed").ToList();

            //count error items
            myGlobal.goTestInfo.ErrorItem = string.Format("{0} / {1}", error_items.Count(), myGlobal.duts[0].Cases[0].Items.Count);

            //show error string
            myGlobal.goTestInfo.ErrorString = error_items.SelectMany(item => string.Format("# {0}: \"{1}\".\r\n", item.ItemName, item.ItemMessage)).ToList().Aggregate("", (x, y) => x + y);
        }


        /// <summary>
        /// 
        /// </summary>
        void _print_Error_String(bool result) {
            //show error log
            string _errorstring = string.Format("Product Name: {0}\r\n", myGlobal.duts[0].Name.ToUpper()) +
                                              string.Format("Product Number: {0}\r\n", myGlobal.ProductSerialNumber) +
                                              string.Format("Date: {0}\r\n\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")) +
                                              string.Format("Total Result: {0}\r\n", myGlobal.goTestInfo.TotalResult) +
                                              string.Format("Tested Time: {0}\r\n", myGlobal.goTestInfo.TestTime) +
                                              string.Format("Error Items: {0}\r\n", myGlobal.goTestInfo.ErrorItem) +
                                              "Error String: \r\n" +
                                              "-------------------------------------------------\r\n" +
                                              myGlobal.goTestInfo.ErrorString +
                                              "--------------------------------------------------\r\n";
            myGlobal.debugLog.ErrorLog = _errorstring;
            myGlobal.ProductSerialNumber = "";

            //Print error string 
            if (myGlobal.settingInfo.PrintLabel.ToLower().Contains("yes") && result == false) {
                Dispatcher.Invoke(new Action(() => {

                    if (myGlobal.myPrintDialog != null) {
                        //print data
                        FlowDocument doc = new FlowDocument();
                        Paragraph paragraph = null;
                        paragraph = new Paragraph(new Run(_errorstring));
                        paragraph.FontSize = 12;
                        paragraph.FontWeight = FontWeights.Normal;

                        doc.Blocks.Add(paragraph);
                        doc.Name = "myFlowDoc";
                        doc.FontSize = 12.0;
                        doc.FontWeight = FontWeights.Normal;

                        IDocumentPaginatorSource idpSource = doc;
                        myGlobal.myPrintDialog.PrintDocument(idpSource.DocumentPaginator, "Printing...");

                    }
                    else MessageBox.Show("Label Printer is not setting or not exist.\nPlease check setting again.", "Error Label Printer", MessageBoxButton.OK, MessageBoxImage.Error);

                }));
            }
        }

        #endregion

    }
}

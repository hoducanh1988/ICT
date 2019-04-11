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
using ICT_VNPT.Func.Custom;
using ICT_VNPT.Func.Global;

namespace ICT_VNPT.UI.UserControls.TestItems.TreeTest.TestSetting {
    /// <summary>
    /// Interaction logic for Parameters.xaml
    /// </summary>
    public partial class Parameters : UserControl {
        public Parameters() {

            //Init control
            InitializeComponent();

            //Init data for combobox
            this.cbbBank1.ItemsSource = myParameter.banks;
            this.cbbBank2.ItemsSource = myParameter.banks;
            this.cbbMeasureTime.ItemsSource = myParameter.measuretimes;
            this.cbbRetryTime.ItemsSource = myParameter.retrytimes;
            this.cbbUnitType.ItemsSource = myParameter.unittypes;
            this.cbbItemUnit.ItemsSource = myParameter.testunits;
            this.cbbRange.ItemsSource = null;

            //Databinding
            Thread t = new Thread(new ThreadStart(() => {
                int _oldIndex = -2;
                while (true) {

                    if (myGlobal.SelectedItemIndex != -1) {
                        if (myGlobal.SelectedItemIndex != _oldIndex) {
                            Dispatcher.Invoke(new Action(() => {
                                this.tbGuide.Text = "";
                                this.IsEnabled = true;
                                this.grid_switch_card.DataContext = myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex];
                                this.grid_limit.DataContext = myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex];
                                this.grid_test_time.DataContext = myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex];
                                this.grid_range.DataContext = myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex];
                                this.grid_unittype.DataContext = myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex];
                                _load_data_for_combobox_range(myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex].ItemUnit);
                            }));
                            _oldIndex = myGlobal.SelectedItemIndex;
                        }

                    }
                    if (myGlobal.SelectedItemIndex != _oldIndex) {
                        Dispatcher.Invoke(new Action(() => {
                            this.tbGuide.Text = "";
                            this.IsEnabled = false;
                            this.grid_switch_card.DataContext = null;
                            this.grid_limit.DataContext = null;
                            this.grid_test_time.DataContext = null;
                            this.grid_range.DataContext = null;
                            this.grid_unittype.DataContext = null;
                        }));
                        _oldIndex = myGlobal.SelectedItemIndex;
                    }
                    Thread.Sleep(250);
                }
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void FrameWorkElement_Focus(object sender, RoutedEventArgs e) {
            string data;

            FrameworkElement element = sender as FrameworkElement;
            myParameter.dictGuide.TryGetValue(element.Tag.ToString(), out data);

            tbGuide.Text = data;
        }

        private void CbbItemUnit_DropDownClosed(object sender, EventArgs e) {
            _load_data_for_combobox_range(myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex].ItemUnit);
        }


        void _load_data_for_combobox_range(string data) {
            this.cbbRange.IsEnabled = true;
            //set itemsoure for cbbrange
            switch (data) {
                case "R": {
                        this.cbbRange.ItemsSource = myParameter.dictRangeResistance.Select(x => x.Key);
                        break;
                    }
                case "Ca": {
                        this.cbbRange.ItemsSource = myParameter.dictRangeCapacitance.Select(x => x.Key);
                        break;
                    }
                case "V": {
                        this.cbbRange.ItemsSource = myParameter.dictRangeDCVoltage.Select(x => x.Key);
                        break;
                    }
                case "A": {
                        this.cbbRange.ItemsSource = myParameter.dictRangeDCCurrent.Select(x => x.Key);
                        break;
                    }
                default: {
                        try {
                            this.cbbRange.IsEnabled = false;
                            myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex].Range = "-";
                        } catch { }
                        
                        break;
                    }
            }
        }
    }
}

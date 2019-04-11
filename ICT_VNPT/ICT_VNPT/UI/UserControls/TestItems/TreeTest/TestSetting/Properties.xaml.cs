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

namespace ICT_VNPT.UI.UserControls.TestItems.TreeTest.TestSetting {
    /// <summary>
    /// Interaction logic for Properties.xaml
    /// </summary>
    public partial class Properties : UserControl {
        public Properties() {

            //Init control
            InitializeComponent();

            //Init data for combobox
            this.cbbIsCheck.ItemsSource = myParameter.booleans;
            this.cbbIsPower.ItemsSource = myParameter.booleans;

            //Databinding
            Thread t = new Thread(new ThreadStart(() => {
                int _oldIndex = -2;
                while (true) {
                    if (myGlobal.SelectedItemIndex != -1) {
                        if (myGlobal.SelectedItemIndex != _oldIndex) {
                            Dispatcher.Invoke(new Action(() => {
                                this.tbGuide.Text = "";
                                this.IsEnabled = true;
                                this.DataContext = myGlobal.duts[0].Cases[0].Items[myGlobal.SelectedItemIndex];
                            }));
                            _oldIndex = myGlobal.SelectedItemIndex;
                        }
                    }
                    else {
                        if (myGlobal.SelectedItemIndex != _oldIndex) {
                            Dispatcher.Invoke(new Action(() => {
                                this.tbGuide.Text = "";
                                this.IsEnabled = false;
                                this.DataContext = null;
                            }));
                            _oldIndex = myGlobal.SelectedItemIndex;
                        }
                    }
                    Thread.Sleep(100);
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

    }
}

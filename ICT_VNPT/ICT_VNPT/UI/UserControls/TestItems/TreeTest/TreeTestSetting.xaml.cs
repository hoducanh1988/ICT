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

namespace ICT_VNPT.UI.UserControls.TestItems
{
    /// <summary>
    /// Interaction logic for TreeTestSetting.xaml
    /// </summary>
    public partial class TreeTestSetting : UserControl
    {
        public TreeTestSetting()
        {
            InitializeComponent();
            this.DataContext = myGlobal.settingInfo;

            //Thread t = new Thread(new ThreadStart(() => {
            //    int _oldIndex = -2;
            //    while (true) {
            //        if (myGlobal.SelectedItemIndex  == -1) {
            //            if (myGlobal.SelectedItemIndex != _oldIndex) {
            //                Dispatcher.Invoke(new Action(() => {
            //                    this.TabSetting.SelectedIndex = 0;
            //                }));
            //                _oldIndex = myGlobal.SelectedItemIndex;
            //            }
            //        }
            //        else {
            //            if (myGlobal.SelectedItemIndex != _oldIndex) {
            //                Dispatcher.Invoke(new Action(() => {
            //                    this.TabSetting.SelectedIndex = 1;
            //                }));
            //                _oldIndex = myGlobal.SelectedItemIndex;
            //            }
            //        }
            //        Thread.Sleep(100);
            //    }
            //}));
            //t.IsBackground = true;
            //t.Start();

        }
    }
}

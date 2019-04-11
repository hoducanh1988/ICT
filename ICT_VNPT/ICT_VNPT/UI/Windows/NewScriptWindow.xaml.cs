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

using ICT_VNPT.Func.Global;

namespace ICT_VNPT.UI.Windows
{
    /// <summary>
    /// Interaction logic for NewScriptWindow.xaml
    /// </summary>
    public partial class NewScriptWindow : Window
    {
        public NewScriptWindow()
        {
            InitializeComponent();

            this.txtScriptName.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            switch (b.Content.ToString()) {
                case "OK": {
                        checkScriptName();
                        break;
                    }
                default:break;
            }
        }

        private void TxtScriptName_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                checkScriptName();
            }
        }

        void checkScriptName() {
            if (txtScriptName.Text.Trim() != "") {
                myGlobal.duts.Clear();

                var dut = new ICT_VNPT.Func.Custom.DutInfo(txtScriptName.Text.Trim());
                dut.Cases.Add(new ICT_VNPT.Func.Custom.TestCaseInfo());
                myGlobal.duts.Add(dut);

                myGlobal.SelectedItemIndex = -1;
                this.Close();
            }
            else {
                MessageBox.Show("Please input script name first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtScriptName.Focus();
            }
        }


    }
}

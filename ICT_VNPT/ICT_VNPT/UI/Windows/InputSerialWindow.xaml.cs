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

namespace ICT_VNPT.UI.Windows {
    /// <summary>
    /// Interaction logic for InputSerialWindow.xaml
    /// </summary>
    public partial class InputSerialWindow : Window {
        public int IsCheck = 0;

        public InputSerialWindow(string _title) {
            InitializeComponent();

            this.Title = _title + " - Unit Serial Number";
            this.txtSN.Focus();
        }

        private void TxtSN_KeyDown(object sender, KeyEventArgs e) {
            lblMessage.Content = "";

            if (e.Key == Key.Enter) {
                if (checkSN() == false) {
                    txtSN.Focus();
                }
                else {
                    this.Close();
                }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            switch (b.Content.ToString()) {
                case "Ok": {
                        if (checkSN() == false) {
                            txtSN.Focus();
                        }
                        else {
                            this.Close();
                        }
                        break;
                    }
                case "Cancel": {
                        IsCheck = 0;
                        this.Close();
                        break;
                    }
                default: break;
            }
        }

        bool checkSN() {
            if (txtSN.Text.Trim().Length == 0) {
                lblMessage.Content = "Vui lòng nhập số SN.";
                return false;
            }
            IsCheck = 1;
            myGlobal.dutSerialNumber = txtSN.Text.Trim();
            myGlobal.ProductSerialNumber = txtSN.Text.Trim();
            return true;
        }

    }
}

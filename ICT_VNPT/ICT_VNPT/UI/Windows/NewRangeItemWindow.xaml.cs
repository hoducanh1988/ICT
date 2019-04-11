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

namespace ICT_VNPT.UI.Windows
{
    /// <summary>
    /// Interaction logic for NewRangeItemWindow.xaml
    /// </summary>
    public partial class NewRangeItemWindow : Window
    {
        public int numberItem = 0;

        public NewRangeItemWindow()
        {
            InitializeComponent();

            this.txtSQty.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            switch (b.Content.ToString()) {
                case "OK": {
                        checkScriptName();
                        break;
                    }
                default: break;
            }
        }

        private void TxtSQty_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                checkScriptName();
            }
        }

        void checkScriptName() {
            if (txtSQty.Text.Trim() != "") {
                if (int.TryParse(txtSQty.Text.Trim(), out numberItem)) {
                    this.Close();
                }
                else {
                    MessageBox.Show("Quantity of new item is not numeric.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtSQty.Focus();
                }
            }
            else {
                MessageBox.Show("Please input quantity of new item.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSQty.Focus();
            }
        }

    }
}

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

using AppTestICT_Ver1.Func.Global;


namespace AppTestICT_Ver1 {
    /// <summary>
    /// Interaction logic for ProductOptional_Window.xaml
    /// </summary>
    public partial class ProductOptional_Window : Window {
        public ProductOptional_Window() {
            InitializeComponent();
            this.cbblistProduct.ItemsSource = myGlobal.listProduct;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e) {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button b = sender as Button;
            string _btnContent = b.Content.ToString();
            switch (_btnContent) {
                case "OK": {
                        MainWindow window = new MainWindow();
                        window.Show();
                        this.Close();
                        break;
                    }
                case "Exit": {
                        this.Close();
                        break;
                    }

            }
        }
    }
}

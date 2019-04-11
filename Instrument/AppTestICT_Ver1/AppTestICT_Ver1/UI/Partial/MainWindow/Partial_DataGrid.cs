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

using AppTestICT_Ver1.Func.Global;

namespace AppTestICT_Ver1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private void MainGrid_LostFocus(object sender, RoutedEventArgs e) {
            this.mainGrid.UnselectAll();
            this.mainGrid.UnselectAllCells();
        }

        private void MainGrid_MouseLeave(object sender, MouseEventArgs e) {
            this.mainGrid.UnselectAll();
            this.mainGrid.UnselectAllCells();
        }

    }
}

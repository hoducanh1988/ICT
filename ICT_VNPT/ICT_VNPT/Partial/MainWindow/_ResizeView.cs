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

namespace ICT_VNPT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        enum GridSize { Zero = 0, OnePerThree = 1, OnePerTwo = 2, TwoPerThree = 3, FivePerSeven = 4, Max = 5 }
        GridLength GridWidth(GridSize size) {
            double _width = this.grid_Root.ActualWidth;
            switch (size) {
                case GridSize.Zero: return new GridLength(0);
                case GridSize.OnePerThree: return new GridLength(1 * (_width / 3) - 3);
                case GridSize.OnePerTwo: return new GridLength(1 * (_width / 2) - 3);
                case GridSize.TwoPerThree: return new GridLength(2 * (_width / 3) - 3);
                case GridSize.FivePerSeven: return new GridLength(5 * (_width / 7) - 3);
                case GridSize.Max: return new GridLength(_width - 3);
                default: return new GridLength(0);
            }
        }
        GridLength GridHeight(GridSize size) {
            double _height = this.grid_Root.ActualHeight;
            switch (size) {
                case GridSize.Zero: return new GridLength(0);
                case GridSize.OnePerThree: return new GridLength(1 * (_height / 3) - 3);
                case GridSize.OnePerTwo: return new GridLength(1 * (_height / 2) - 3);
                case GridSize.TwoPerThree: return new GridLength(2 * (_height / 3) - 3);
                case GridSize.FivePerSeven: return new GridLength(5 * (_height / 7) - 3);
                case GridSize.Max: return new GridLength(_height - 3);
                default: return new GridLength(0);
            }
        }
        void setViewSize(Grid root, Grid child, GridSize condition, GridSize root_width_false, GridSize root_width_true, GridSize child_height_false, GridSize child_height_true) {
            bool r = root.ColumnDefinitions[0].Width == GridWidth(condition);

            root.ColumnDefinitions[0].Width = r == false ? GridWidth(root_width_false) : GridWidth(root_width_true);
            child.RowDefinitions[0].Height = r == false ? GridHeight(child_height_false) : GridHeight(child_height_true);
        }
        class GridInfo {

            public int Index { get; set; }
            public GridSize condition { get; set; }
            public GridSize width_false { get; set; }
            public GridSize width_true { get; set; }
            public GridSize height_false { get; set; }
            public GridSize height_true { get; set; }
        }


        Dictionary<string, GridInfo> dictGridInfo = new Dictionary<string, GridInfo>() {
            {"MaximizeTestItem", new GridInfo() { Index = 0,
                                                  condition = GridSize.Max,
                                                  width_false = GridSize.Max, width_true = GridSize.FivePerSeven,
                                                  height_false = GridSize.Max, height_true =  GridSize.TwoPerThree } },
            {"MaximizeTestResult", new GridInfo() { Index = 0,
                                                    condition = GridSize.Max,
                                                    width_false = GridSize.Max, width_true = GridSize.FivePerSeven,
                                                    height_false = GridSize.Zero, height_true =  GridSize.TwoPerThree } },
            {"MaximizeInstrument", new GridInfo() { Index = 1,
                                                    condition = GridSize.Zero,
                                                    width_false = GridSize.Zero, width_true = GridSize.FivePerSeven,
                                                    height_false = GridSize.Max, height_true =  GridSize.OnePerTwo } },
            {"MaximizeDebug", new GridInfo() { Index = 1,
                                                    condition = GridSize.Zero,
                                                    width_false = GridSize.Zero, width_true = GridSize.FivePerSeven,
                                                    height_false = GridSize.Zero, height_true =  GridSize.OnePerTwo } }
        };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {

            //get size of main window after resize
            double _width = this.grid_Root.ActualWidth;
            double _height = this.grid_Root.ActualHeight;

            //resize control follow main window size

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) {
            
            //get button sender
            Button b = sender as Button;
            string keytag = b.Tag.ToString();

            //Set view
            GridInfo info;
            dictGridInfo.TryGetValue(keytag, out info);
            setViewSize(grid_Root, info.Index == 0 ? grid_Child_Left : grid_Child_Right, 
                        info.condition, 
                        info.width_false, info.width_true, 
                        info.height_false, info.height_true);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expander_Expanded(object sender, RoutedEventArgs e) {
            double _width = this.grid_test_tree.ActualWidth;
            if (_width > 0) this.grid_test_tree.ColumnDefinitions[0].Width = new GridLength((_width / 2) - 2.5);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expander_Collapsed(object sender, RoutedEventArgs e) {
            double _width = this.grid_test_tree.ActualWidth;
            if (_width > 0) this.grid_test_tree.ColumnDefinitions[0].Width = new GridLength(_width - 5);
        }

    }
}

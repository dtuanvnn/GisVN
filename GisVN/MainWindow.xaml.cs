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

namespace GisVN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create tab item.
        /// </summary>
        /// <param name="header">The header text.</param>
        private void CreateTabItem<T>(string header)
        {
            var tabItem = new FabTab.FabTabItem();
            var instance = Activator.CreateInstance<T>();
            tabItem.Header = header;
            tabItem.Content = instance;
            this.tabControl.Items.Add(tabItem);
        }

        /// <summary>
        /// Action input menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The route event arguments.</param>
        private void mInput_Click(object sender, RoutedEventArgs e)
        {
            CreateTabItem<SampleView>("Nhập dữ liệu");
        }

        /// <summary>
        /// Action search menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The route event arguments.</param>
        private void mSearch_Click(object sender, RoutedEventArgs e)
        {
            CreateTabItem<SearchGiay>("Tìm kiếm dữ liệu");
        }
    }
}

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
            this.AddHandler(CloseableTabItem.CloseTabEvent, new RoutedEventHandler(this.CloseTab));
        }

        private void CloseTab(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = e.Source as TabItem;
            if (tabItem != null)
            {
                TabControl tabControl = tabItem.Parent as TabControl;
                if (tabControl != null)
                {
                    tabControl.Items.Remove(tabItem);
                }
            }
        }

        /// <summary>
        /// Tạo tab item closeable.
        /// </summary>
        /// <param name="header">Tên tab</param>
        private void CreateNewTabItem(string header)
        {
            CloseableTabItem tabItem = new CloseableTabItem();
            tabItem.Header = header;
            MainTab.Items.Add(tabItem);
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTabItem("Nhập dữ liệu");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTabItem("Tìm kiếm dữ liệu");
        }
    }
}

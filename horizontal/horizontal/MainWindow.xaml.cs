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

namespace horizontal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Menu menu = new Menu();
        Bill bill = new Bill();
        Assistance assistance = new Assistance();
        Order order = new Order();

        public MainWindow()
        {
            InitializeComponent();
            mainStackPanel.Children.Add(menu);
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(menu);
        }

        private void billButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(bill);
        }
    }
}

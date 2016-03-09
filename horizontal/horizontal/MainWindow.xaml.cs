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
            menuButton.Background = Brushes.LightGray;
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(menu);
            menuButton.Background = Brushes.LightGray;
            billButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.White;
            orderButton.Background = Brushes.White;
        }

        private void billButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(bill);
            menuButton.Background = Brushes.White;
            billButton.Background = Brushes.LightGray;
            assistanceButton.Background = Brushes.White;
            orderButton.Background = Brushes.White;
        }

        private void assistanceButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(assistance);
            menuButton.Background = Brushes.White;
            billButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.LightGray;
            orderButton.Background = Brushes.White;
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(order);
            menuButton.Background = Brushes.White;
            billButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.White;
            orderButton.Background = Brushes.LightGray;
        }
    }
}

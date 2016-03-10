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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void dinnerTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.LightGray;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.White;
        }

        private void lunchTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.LightGray;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.White;
        }

        private void kidsTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.LightGray;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.White;
        }

        private void dessertTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.LightGray;
            drinksTab.Background = Brushes.White;
        }

        private void drinksTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.LightGray;
        }
    }
}

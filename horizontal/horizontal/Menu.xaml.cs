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
        private Dinner dinner = new Dinner();
        private Lunch lunch = new Lunch();
        private Kids kids = new Kids();
        private Dessert dessert = new Dessert();
        private Drinks drinks = new Drinks();

        public Menu()
        {
            InitializeComponent();
            menuStackPanel.Children.Add(dinner);
            dinnerTab.Background = Brushes.LightGray;
        }

        private void dinnerTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.LightGray;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.White;

            menuStackPanel.Children.Clear();
            menuStackPanel.Children.Add(dinner);
        }

        private void lunchTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.LightGray;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.White;

            menuStackPanel.Children.Clear();
            menuStackPanel.Children.Add(lunch);
        }

        private void kidsTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.LightGray;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.White;

            menuStackPanel.Children.Clear();
            menuStackPanel.Children.Add(kids);
        }

        private void dessertTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.LightGray;
            drinksTab.Background = Brushes.White;

            menuStackPanel.Children.Clear();
            menuStackPanel.Children.Add(dessert);
        }

        private void drinksTab_Click(object sender, RoutedEventArgs e)
        {
            dinnerTab.Background = Brushes.White;
            lunchTab.Background = Brushes.White;
            kidsTab.Background = Brushes.White;
            dessertTab.Background = Brushes.White;
            drinksTab.Background = Brushes.LightGray;

            menuStackPanel.Children.Clear();
            menuStackPanel.Children.Add(drinks);
        }
    }
}

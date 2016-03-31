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
        Order order = new Order();
        Assistance assistance = new Assistance();
        Bill bill = new Bill();
        private List<OrderInfo> ordersList;
        private List<NameEnter> names;

        public MainWindow()
        {
            InitializeComponent();
            mainStackPanel.Children.Add(menu);
            ordersList = new List<OrderInfo>();
            names = new List<NameEnter>();

            menuButton.Background = Brushes.LightGray;
            menuButton.FontWeight = FontWeights.Bold;
        }

        public void addToOrder(OrderInfo newOrder)
        {
            ordersList.Add(newOrder);
            order.addToOrder(newOrder);
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(menu);

            menuButton.Background = Brushes.LightGray;
            orderButton.Background = Brushes.White;
            billButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.White;

            menuButton.FontWeight = FontWeights.Bold;
            orderButton.FontWeight = FontWeights.Regular;
            assistanceButton.FontWeight = FontWeights.Regular;
            billButton.FontWeight = FontWeights.Regular;
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(order);

            menuButton.Background = Brushes.White;
            orderButton.Background = Brushes.LightGray;
            billButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.White;

            menuButton.FontWeight = FontWeights.Regular;
            orderButton.FontWeight = FontWeights.Bold;
            assistanceButton.FontWeight = FontWeights.Regular;
            billButton.FontWeight = FontWeights.Regular;
        }

        private void billButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(bill);

            menuButton.Background = Brushes.White;
            orderButton.Background = Brushes.White;
            billButton.Background = Brushes.LightGray;
            assistanceButton.Background = Brushes.White;

            menuButton.FontWeight = FontWeights.Regular;
            orderButton.FontWeight = FontWeights.Regular;
            assistanceButton.FontWeight = FontWeights.Regular;
            billButton.FontWeight = FontWeights.Bold;
        }

        private void assistanceButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(assistance);

            menuButton.Background = Brushes.White;
            orderButton.Background = Brushes.White;
            billButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.LightGray;

            menuButton.FontWeight = FontWeights.Regular;
            orderButton.FontWeight = FontWeights.Regular;
            assistanceButton.FontWeight = FontWeights.Bold;
            billButton.FontWeight = FontWeights.Regular;
        }

        private void numPeopleSelected(object sender, SelectionChangedEventArgs e)
        {
            int numPeople = numPeopleSelector.SelectedIndex + 1;
            peopleStackPanel.Children.Clear();
            for (int i = 0; i < numPeople; i++)
            {
                NameEnter nameEnter = new NameEnter();
                nameEnter.personNum.Content = "Person " + (i + 1);
                nameEnter.personName.Text = "Person " + (i + 1);
                peopleStackPanel.Children.Add(nameEnter);
            }
        }

        private void confirmNumPeople_Click(object sender, RoutedEventArgs e)
        {
            introCanvas.Visibility = System.Windows.Visibility.Hidden;
            foreach (NameEnter name in peopleStackPanel.Children)
            {
                names.Add(name);
            }
        }
    }
}

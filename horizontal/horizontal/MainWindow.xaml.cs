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
    public static class Global
    {
        public static List<OrderInformation> ordersList;
        public static List<OrderInformation> confirmedList;
        public static List<String> names;
        public static StackPanel mainStackPanel;

        public static Menu menu = new Menu();
        public static Order order = new Order();
        public static Assistance assistance = new Assistance();
        public static Bill bill = new Bill();

        public static void addToOrder(OrderInformation newOrder)
        {
            Global.ordersList.Add(newOrder);
            Global.order.addToOrder(newOrder);
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Global.mainStackPanel = mainStackPanel;

            //mainStackPanel.Children.Add(menu);
            Global.ordersList = new List<OrderInformation>();
            Global.confirmedList = new List<OrderInformation>();
            Global.names = new List<String>();

            menuButton.Background = Brushes.LightGray;
            menuButton.FontWeight = FontWeights.Bold;
            
            menuButton.IsEnabled = false;
            orderButton.IsEnabled = false;
            assistanceButton.IsEnabled = false;
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(Global.menu);

            menuButton.Background = Brushes.LightGray;
            orderButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.White;

            menuButton.FontWeight = FontWeights.Bold;
            orderButton.FontWeight = FontWeights.Regular;
            assistanceButton.FontWeight = FontWeights.Regular;
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(Global.order);

            menuButton.Background = Brushes.White;
            orderButton.Background = Brushes.LightGray;
            assistanceButton.Background = Brushes.White;

            menuButton.FontWeight = FontWeights.Regular;
            orderButton.FontWeight = FontWeights.Bold;
            assistanceButton.FontWeight = FontWeights.Regular;
        }

        private void billButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(Global.bill);

            menuButton.Background = Brushes.White;
            orderButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.White;

            menuButton.FontWeight = FontWeights.Regular;
            orderButton.FontWeight = FontWeights.Regular;
            assistanceButton.FontWeight = FontWeights.Regular;
        }

        private void assistanceButton_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();
            mainStackPanel.Children.Add(Global.assistance);

            menuButton.Background = Brushes.White;
            orderButton.Background = Brushes.White;
            assistanceButton.Background = Brushes.LightGray;

            menuButton.FontWeight = FontWeights.Regular;
            orderButton.FontWeight = FontWeights.Regular;
            assistanceButton.FontWeight = FontWeights.Bold;
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
                Global.names.Add(name.personName.Text);
            }
            mainStackPanel.Children.Add(Global.menu);
            menuButton.IsEnabled = true;
            orderButton.IsEnabled = true;
            assistanceButton.IsEnabled = true;

            Global.bill.addUsers();
        }
    }
}

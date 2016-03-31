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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        public static Boolean orderPending = true;

        OrderDialog orderDialog;

        public Order()
        {
            InitializeComponent();
        }

        public void addToOrder(OrderInfo newOrder)
        {
            orderStackPanel.Children.Add(newOrder);
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (OrderInfo item in orderStackPanel.Children)
            {

                item.orderGrid.Background = Brushes.LightGray;
                item.xbutton.Visibility = Visibility.Hidden;
                item.sentLabel.Visibility = Visibility.Visible;
                //item.name.Content = "SENT   " + item.name.Content;


            }
            //orderStackPanel.Children.Clear();
            orderPending = false;

        }

        private void billOptionsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void finishDiningButton_Click(object sender, RoutedEventArgs e)
        {
            if (orderPending == true)
            {
                Console.WriteLine("YOU HAVE ITEMS NOT SENT");
                Console.ReadLine();
                
            }
        }
    }
}

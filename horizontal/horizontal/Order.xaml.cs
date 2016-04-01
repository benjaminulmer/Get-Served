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
        public float total;

        public Order()
        {
            InitializeComponent();
            total = 0;
        }

        public void addToOrder(OrderInformation newOrder)
        {
            orderPending = true;
            OrderInfo orderInfo = new OrderInfo();
            orderInfo.orderInfo = newOrder;
            orderInfo.name.Content = newOrder.item;
            total += newOrder.price;
            orderInfo.price.Content = "$" + newOrder.price.ToString("0.00");
            foreach (String desc in newOrder.mods)
            {
                Label label = new Label();
                label.Content = desc;
                orderInfo.subNameStackPanel.Children.Add(label);
            }
            foreach (float price in newOrder.modsPrice)
            {
                Label label = new Label();
                total += price;
                label.Content = "$" + price.ToString("0.00");
                label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
                orderInfo.subPriceStackPanel.Children.Add(label);
            }
            int count = 0;
            foreach (String name in newOrder.users)
            {
                if (count == 0)
                {
                    orderInfo.forLabel.Content += name;
                }
                else
                {
                    orderInfo.forLabel.Content += (", " + name);
                }
                count++;
            }
            totalLabel.Content = "Total: $" + total.ToString("0.00");
            orderStackPanel.Children.Add(orderInfo);
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (OrderInfo item in orderStackPanel.Children)
            {
                item.orderGrid.Background = Brushes.LightGray;
                item.xbutton.Visibility = Visibility.Hidden;
                item.sentLabel.Visibility = Visibility.Visible;
                item.individualOrderButton.Visibility = Visibility.Hidden;
            }
            foreach (OrderInformation item in Global.ordersList)
            {
                Global.confirmedList.Add(item);
            }
            Global.ordersList.Clear();
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
            else {
                Global.mainStackPanel.Children.Clear();
                Global.mainStackPanel.Children.Add(Global.bill);
            }
        }
    }
}

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
                //do a thing
            }
            orderStackPanel.Children.Clear();
        }
    }
}

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
    /// Interaction logic for OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : UserControl
    {
        private string orderName;
        public OrderInformation orderInfo;

        public string OrderName
        {
            get { return orderName; }
            set
            {
                orderName = value;
                this.name.Content = value;
            }
        }

        private string priceValue;
        public string PriceValue
        {
            get { return priceValue; }
            set
            {
                priceValue = value;
                this.price.Content = value;
            }
        }

        public OrderInfo()
        {
            InitializeComponent();
            
        }

        private void deleteClick(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void individualOrderButton_Click(object sender, RoutedEventArgs e)
        {
            orderGrid.Background = Brushes.LightGray;
            xbutton.Visibility = Visibility.Hidden;
            sentLabel.Visibility = Visibility.Visible;
            individualOrderButton.Visibility = Visibility.Hidden;

            Global.order.total -= orderInfo.price;
            Global.ordersList.Remove(orderInfo);
            Global.confirmedList.Add(orderInfo);
        }
    }
}

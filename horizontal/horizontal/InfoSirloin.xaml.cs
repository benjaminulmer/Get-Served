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
    /// Interaction logic for InfoSirloin.xaml
    /// 
    /// When info/order for Top Sirloin is clicked
    /// 
    /// </summary>
    public partial class InfoSirloin : UserControl
    {
        Dinner dinnerPage;

        public InfoSirloin(Dinner dinnerPage)
        {
            InitializeComponent();
            this.dinnerPage = dinnerPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Add(dinnerPage);
            (this.Parent as Panel).Children.Remove(this);
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = VisualTreeHelper.GetParent(this);
            while (!(mainWindow is MainWindow)) { mainWindow = VisualTreeHelper.GetParent(mainWindow); }

            OrderInfo newOrder = new OrderInfo();
            newOrder.OrderName = "Sirloin Steak";
            newOrder.PriceValue = "$35.00";
            
            (mainWindow as MainWindow).addToOrder(newOrder);

            (this.Parent as Panel).Children.Add(dinnerPage);
            (this.Parent as Panel).Children.Remove(this);
        }

        private void nutritionButton_Click(object sender, RoutedEventArgs e)
        {
            nutritionPopup.IsOpen = true;
        }

        private void ButtonPopup_Click(object sender, RoutedEventArgs e)
        {
            nutritionPopup.IsOpen = false;
        }
    }
}

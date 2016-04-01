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
    /// Interaction logic for InfoSalmon.xaml
    /// </summary>
    public partial class InfoSalmon : UserControl
    {
        Dinner dinnerPage;

        public InfoSalmon(Dinner dinnerPage)
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
            OrderInformation newOrder = new OrderInformation();
            newOrder.item = "Baked Salmon";
            newOrder.price = 25;

            Global.addToOrder(newOrder);

            Global.mainStackPanel.Children.Add(dinnerPage);
            Global.mainStackPanel.Children.Remove(this);
            //confrimCanvas.Visibility = System.Windows.Visibility.Hidden;
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

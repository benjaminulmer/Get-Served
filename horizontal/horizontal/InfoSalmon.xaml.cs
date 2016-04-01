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
            confrimCanvas.Visibility = System.Windows.Visibility.Visible;
            peopleStackPanel.Children.Clear();
            foreach (String name in Global.names)
            {
                NameChoose nameChoose = new NameChoose();
                nameChoose.nameCB.Content = name;
                peopleStackPanel.Children.Add(nameChoose);
            }
        }

        private void nutritionButton_Click(object sender, RoutedEventArgs e)
        {
            nutritionPopup.IsOpen = true;
        }

        private void ButtonPopup_Click(object sender, RoutedEventArgs e)
        {
            nutritionPopup.IsOpen = false;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            confrimCanvas.Visibility = System.Windows.Visibility.Hidden;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            OrderInformation newOrder = new OrderInformation();
            newOrder.item = "Oven Baked Salmon";
            newOrder.price = 35;
            if (vegiCB.IsChecked == true)
            {
                newOrder.mods.Add("Extra vegetables");
                newOrder.modsPrice.Add(3.5f);
            }
            if (potatoCB.IsChecked == true)
            {
                newOrder.mods.Add("Sub rice for baked potato");
                newOrder.modsPrice.Add(3);
            }
            if (cSauceCB.IsChecked == true)
            {
                newOrder.mods.Add("Add cajun sauce");
                newOrder.modsPrice.Add(2);
            }
            if (spinachCB.IsChecked == true)
            {
                newOrder.mods.Add("Sub asparagus for spinach");
                newOrder.modsPrice.Add(0);
            }
            if (lemonCB.IsChecked == true)
            {
                newOrder.mods.Add("No lemons");
                newOrder.modsPrice.Add(0);
            }
            if (nutCB.IsChecked == true)
            {
                newOrder.mods.Add("Nut-free sauce");
                newOrder.modsPrice.Add(0);
            }
            foreach (NameChoose name in peopleStackPanel.Children)
            {
                if (name.nameCB.IsChecked == true)
                {
                    newOrder.users.Add(name.nameCB.Content.ToString());
                }
            }
            Global.addToOrder(newOrder);

            (this.Parent as Panel).Children.Add(dinnerPage);
            (this.Parent as Panel).Children.Remove(this);
            confrimCanvas.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}

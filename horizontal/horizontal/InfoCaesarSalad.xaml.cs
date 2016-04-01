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
    /// Interaction logic for InfoCaesarSalad.xaml
    /// </summary>
    public partial class InfoCaesarSalad : UserControl
    {
        Dinner dinnerPage;

        public InfoCaesarSalad(Dinner dinnerPage)
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
            int checkedCount = 0;
            foreach (NameChoose name in peopleStackPanel.Children)
            {
                if (name.nameCB.IsChecked == true)
                {
                    checkedCount++;
                }
            }
            if (checkedCount == 0)
            {
                errorLabel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                OrderInformation newOrder = new OrderInformation();
                newOrder.item = "Caesar Salad";
                newOrder.price = 15;
                if (shrimpCB.IsChecked == true)
                {
                    newOrder.mods.Add("Add shrimp");
                    newOrder.modsPrice.Add(5);
                }
                if (chickenCB.IsChecked == true)
                {
                    newOrder.mods.Add("Add chicken");
                    newOrder.modsPrice.Add(5);
                }
                if (salmonCB.IsChecked == true)
                {
                    newOrder.mods.Add("Add salmon");
                    newOrder.modsPrice.Add(5);
                }
                if (glutenCB.IsChecked == true)
                {
                    newOrder.mods.Add("Gluten-free");
                    newOrder.modsPrice.Add(0);
                }
                if (dressingCB.IsChecked == true)
                {
                    newOrder.mods.Add("Light Dressing");
                    newOrder.modsPrice.Add(0);
                }
                if (cheeseCB.IsChecked == true)
                {
                    newOrder.mods.Add("No cheese");
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
}

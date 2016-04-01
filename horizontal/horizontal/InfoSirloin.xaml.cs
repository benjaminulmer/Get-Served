﻿using System;
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
            //OrderInfo newOrder = new OrderInfo();
            //newOrder.OrderName = "Sirloin Steak";
            //newOrder.PriceValue = "$35.00";
            
            //(mainWindow as MainWindow).addToOrder(newOrder);

            //(this.Parent as Panel).Children.Add(dinnerPage);
            //(this.Parent as Panel).Children.Remove(this);
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
            newOrder.item = "Sirloin Steak";
            newOrder.price = 35;
            if (shrimpCB.IsChecked == true)
            {
                newOrder.mods.Add("Add shrimp");
                newOrder.modsPrice.Add(5);
            }
            if (pSauceCB.IsChecked == true)
            {
                newOrder.mods.Add("Add peppercorn sauce");
                newOrder.modsPrice.Add(4);
            }
            if (cSauceCB.IsChecked == true)
            {
                newOrder.mods.Add("Add cajun sauce");
                newOrder.modsPrice.Add(2);
            }
            if (friesCB.IsChecked == true)
            {
                newOrder.mods.Add("Sub bake potato for fries");
                newOrder.modsPrice.Add(0);
            }
            if (tomatoesCB.IsChecked == true)
            {
                newOrder.mods.Add("No tomatoes");
                newOrder.modsPrice.Add(0);
            }
            if (shrimpCB.IsChecked == true)
            {
                newOrder.mods.Add("No mushrooms");
                newOrder.modsPrice.Add(0);
            }

            Global.addToOrder(newOrder);

            (this.Parent as Panel).Children.Add(dinnerPage);
            (this.Parent as Panel).Children.Remove(this);
            confrimCanvas.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}

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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();
            OrderInfo info = new OrderInfo();
            info.name.Content = "Thing 1";
            info.price.Content = "$500.00";
            orderStackPanel.Children.Add(info);
            for (int i = 0; i < 15; i++)
            {
                OrderInfo info2 = new OrderInfo();
                info2.name.Content = "Thing 2";
                info2.price.Content = "$5.00";
                orderStackPanel.Children.Add(info2);
            }
            
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

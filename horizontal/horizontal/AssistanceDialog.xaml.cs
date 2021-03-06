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
using System.Diagnostics; 

namespace horizontal
{
    /// <summary>
    /// Interaction logic for AssistanceDialog.xaml
    /// </summary>
    public partial class AssistanceDialog : UserControl
    {
        Assistance parent;

        public AssistanceDialog(Assistance parent)
        {
            this.parent = parent;
            InitializeComponent();
            cancelButton.Visibility = System.Windows.Visibility.Hidden;
            confirmButton.Visibility = System.Windows.Visibility.Hidden;
            customRequest.Visibility = System.Windows.Visibility.Hidden;
        }

        private void resetParentButtonColors()
        {
            parent.refillButton.Background = Brushes.White;
            parent.serverButton.Background = Brushes.White;
            parent.managerButton.Background = Brushes.White;
            parent.customButton.Background = Brushes.White;
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            resetParentButtonColors();
            cancelButton.Visibility = System.Windows.Visibility.Hidden;
            confirmButton.Visibility = System.Windows.Visibility.Hidden;
            customRequest.Visibility = System.Windows.Visibility.Hidden;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            resetParentButtonColors();
            cancelButton.Visibility = System.Windows.Visibility.Hidden;
            confirmButton.Visibility = System.Windows.Visibility.Hidden;
            customRequest.Visibility = System.Windows.Visibility.Hidden;

            parent.refillButton.IsEnabled = false;
            parent.serverButton.IsEnabled = false;
            parent.managerButton.IsEnabled = false;
            parent.customButton.IsEnabled = false;
            topLabel.Content = "Assistance is on its way!";

            okButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void okButtonClicked(object sender, RoutedEventArgs e)
        {
            resetParentButtonColors();
            cancelButton.Visibility = System.Windows.Visibility.Hidden;
            confirmButton.Visibility = System.Windows.Visibility.Hidden;
            parent.refillButton.IsEnabled = true;
            parent.serverButton.IsEnabled = true;
            parent.managerButton.IsEnabled = true;
            parent.customButton.IsEnabled = true;

            topLabel.Content = "";
            okButton.Visibility = System.Windows.Visibility.Hidden;


        }

    }
}
